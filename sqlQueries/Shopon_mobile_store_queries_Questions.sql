-- 1. List all the products
SELECT * FROM dbo.product; 
-- 2. List product name and product price
SELECT productname, price FROM dbo.product;
-- 3. List all customers
SELECT * FROM dbo.customer;
-- 4. List Customername and mobile no
SELECT customername, mobileno FROM dbo.customer;
-- 5. List all orders
SELECT * FROM dbo.orderd;
-- 6. List customer id and orderd date
SELECT customerid, orderdate FROM dbo.orderd;
-- 7. List all the order item
SELECT * FROM dbo.orderitem;
-- 8. List all the product with product id 100
SELECT * FROM dbo.orderitem WHERE pid=100;
-- 9. List all the info of product with name Vivo V3
SELECT * FROM dbo.product WHERE productname LIKE 'VIVO V3';
-- 10. List pid, productname, price of the phone named "Samsung GalaxyNote-4"
SELECT pid, productname, price FROM dbo.product WHERE productname LIKE 'Samsung GalaxyNote-4';
-- 11. Print product info for all the product with category id 2003
SELECT * FROM dbo.product WHERE categoryid=2003;
-- 12. List all the customers address with city as 'Bangalore'
SELECT * FROM dbo.customeraddress WHERE city LIKE 'Bangalore';
-- 13. List all the orders which was ordered on '2013-02-02'
SELECT * FROM dbo.orderd WHERE orderdate ='2013-02-02';
-- 14. Print all the orders of the customer with id 1
SELECT * FROM dbo.orderd WHERE customerid=1;
-- 15. List all the product with company id 1001 or 1002
SELECT productname,companyid FROM dbo.product WHERE companyid in (1001,1002);
-- 16. List all the product with price more than 30000
SELECT productname, price FROM dbo.product WHERE price>30000;
-- 17. List all the products of the category id 2001 or 2003 with 
-- the price more than 30000
SELECT productname, categoryid, price from dbo.product WHERE categoryid IN (2001,2003) AND price>30000;
-- 18. List all the order of customer id 1 or 4 with ordered on '2013-02-02' 
-- or '2013-02-07'
SELECT * FROM dbo.orderd WHERE customerid IN (1,4) AND orderdate='2013-02-02';
-- 19. List all the customer whos name starts with character 'A'
SELECT customername FROM dbo.customer WHERE customername LIKE 'A%';
-- 20. List all the customer whos name ends with character 'i'
SELECT customername FROM dbo.customer WHERE customername LIKE '%i';
-- 21. List all the customer whos name starts with 'R' and ends with 'i'
SELECT customername FROM dbo.customer WHERE customername LIKE 'R%i';
-- 22. List all the orders for the year 2013
SELECT * FROM dbo.orderd WHERE YEAR(orderdate)=2013;
-- 23. List all the products which are not from the category 2001
SELECT * FROM dbo.product WHERE categoryid NOT IN(2001);
-- 24. List all the products which are not from the category 2001
-- or 2003 with the price more than 30000 and product name has '6' in it
SELECT * FROM dbo.product WHERE categoryid NOT IN(2001,2003) AND price>30000 AND productname LIKE '%6%';
-- 25. List all the customers whos mobile no doesnt start with 9
SELECT customername, mobileno FROM dbo.customer WHERE mobileno NOT LIKE '9%';

-- 26. List all the nokia phones
-- 32. List all the customer who have orderd for phone '6S'
--SELECT * FROM dbo.customer;
--SELECT * FROM dbo.orderd;
--SELECT * FROM dbo.product;
SELECT customername, productname from dbo.customer as c, dbo.orderitem as o1, dbo.orderd as o2, dbo.product as p WHERE p.productname LIKE '%6s%' AND o1.orderid=o2.orderid AND o1.pid=p.pid;
-- 33. List all the customers who have ordered for Apple I-Pad Mini from bangalore
-- 34. List all the phones which Goutham orderd for
-- 35. List all the phones which Amrutha orderd for in the 2014

-- 36. List all the customer who have not bought any product
SELECT 
*
FROM dbo.customer as c WITH(NOLOCK)
LEFT OUTER JOIN dbo.orderd as o WITH(NOLOCK)
ON c.customerid=o.customerid
WHERE o.customerid NOT IN(c.customerid);


-- 37. List Fav phones of Bangalorean

-- 41. List companyid, companyname, productname, product price of all products
SELECT 
     p.productname, p.price,c.companyid,c.companyname
FROM dbo.company as c WITH(NOLOCK)
    INNER JOIN dbo.product AS p WITH(NOLOCK)
	    ON c.companyid=p.companyid;
 
-- 42. List customer name, stname and city of all the customer.
SELECT
     c.customername, a.stName, a.state
FROM dbo.customer AS c WITH(NOLOCK)
    INNER JOIN dbo.customeraddress as a WITH(NOLOCK)
	ON c.customerid= a.customerid;

-- 43. List customer name and customer city  of all the customer
-- who have never bought any product
SELECT c.customername, a.city
FROM dbo.customer AS c WITH(NOLOCK)
INNER JOIN dbo.customeraddress as a WITH(NOLOCK)
ON c.customerid = a.customerid
INNER JOIN dbo.orderd as o WITH(NOLOCK)
ON c.customerid = o.customerid
WHERE c.customerid NOT IN(o.customerid);

-- 44. List Customer id, customer name, orderdate, of all the orders
SELECT 
     c.customerid, c.customername, o.orderdate
FROM dbo.customer AS c WITH(NOLOCK)
INNER JOIN dbo.orderd as o WITH(NOLOCK)
ON c.customerid = o.customerid;

-- 45. List Customer id, customer name, orderdate, company and 

/* 51. Get the total sales based on orderid  */

/* 56. Total sales based on company  */

/* 61. Display all phones which are sold with the no. of quantity */



/* VIEW */
CREATE VIEW v_CustomerOrder 
AS
SELECT
c.customerid,c.customername,p.pid,p.productname,o.orderid,o.orderdate,o.totalAmount
FROM dbo.customer AS c WITH(NOLOCK)
     INNER JOIN dbo.orderd AS o WITH(NOLOCK)
	 ON c.customerid=o.customerid
	 INNER JOIN dbo.orderitem as oi WITH(NOLOCK)
	 ON o.orderid=oi.orderid
	 INNER JOIN dbo.product AS p WITH(NOLOCK)
	 ON oi.pid=p.pid
WHERE p.isDeleted=0;

SELECT * FROM dbo.v_CustomerOrder;