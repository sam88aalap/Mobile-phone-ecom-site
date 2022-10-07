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

-- 26. List all the nokia phones--SELECT * FROM dbo.product WHERE companyid = (SELECT companyid FROM dbo.company WHERE companyname LIKE 'nokia');SELECT 	p.productnameFROM dbo.company as c WITH(NOLOCK)	INNER JOIN dbo.product as p WITH(NOLOCK)		ON c.companyid = p.companyidWHERE c.companyname LIKE 'nokia';-- 27. List all the samsung phones--SELECT * FROM dbo.product WHERE companyid = (SELECT companyid FROM dbo.company WHERE companyname LIKE 'samsung');SELECT 	p.productnameFROM dbo.company as c WITH(NOLOCK)	INNER JOIN dbo.product as p WITH(NOLOCK)		ON c.companyid = p.companyidWHERE c.companyname LIKE 'samsung';-- 28. List all the Apple phones--SELECT * FROM dbo.product WHERE companyid = (SELECT companyid FROM dbo.company WHERE companyname LIKE 'apple');SELECT 	p.productnameFROM dbo.company as c WITH(NOLOCK)	INNER JOIN dbo.product as p WITH(NOLOCK)		ON c.companyid = p.companyidWHERE c.companyname LIKE 'apple';-- 29. List all the customers from Bangalore--SELECT customername,city FROM dbo.customer as cus, dbo.customeraddress as adr  WHERE adr.city LIKE 'Bangalore' AND cus.customerid = adr.customerid;SELECT 	c.customername, ca.cityFROM dbo.customeraddress as ca WITH(NOLOCK)	INNER JOIN dbo.customer as c WITH(NOLOCK)	 ON c.customerid = ca.customeridWHERE ca.city LIKE 'bangalore';-- 30. List all the customers who are not from Bangalore--SELECT customername,city FROM dbo.customer as cus, dbo.customeraddress as adr  WHERE adr.city NOT LIKE 'Bangalore' AND cus.customerid = adr.customerid;SELECT c.customername, ca.cityFROM dbo.customeraddress as ca WITH(NOLOCK)	INNER JOIN dbo.customer as c WITH(NOLOCK)	 ON c.customerid = ca.customeridWHERE ca.city NOT LIKE 'bangalore';-- 31. List all the customer who have orderd on the date '2013-02-02'--SELECT customername, orderdate FROM dbo.customer as c, dbo.orderd as o WHERE o.orderdate ='2013-02-02' AND o.customerid=c.customerid;SELECT 	c.customername, o.orderidFROM dbo.customer as c WITH(NOLOCK)	INNER JOIN dbo.orderd as o WITH(NOLOCK)		ON c.customerid = o.customeridWHERE o.orderdate = '2013-02-02';-- 32. List all the customer who have orderd for phone '6S'--SELECT * FROM dbo.customer WHERE customerid IN (SELECT customerid FROM dbo.orderd WHERE orderid IN (SELECT orderid FROM orderitem WHERE pid IN (SELECT pid FROM dbo.product WHERE productname LIKE '%6s%'))); SELECT 	c.customername, o.orderid, p.productnameFROM dbo.customer as c WITH(NOLOCK)	INNER JOIN dbo.orderd as o WITH(NOLOCK)		ON c.customerid = o.customerid	INNER JOIN dbo.orderitem as oi WITH(NOLOCK)		ON o.orderid = oi.orderid	INNER JOIN dbo.product as p WITH(NOLOCK)		ON oi.pid = p.pidWHERE p.productname LIKE '%6s%';
-- 32. List all the customer who have orderd for phone '6S'
--SELECT * FROM dbo.customer;
--SELECT * FROM dbo.orderd;
--SELECT * FROM dbo.product;
SELECT customername, productname from dbo.customer as c, dbo.orderitem as o1, dbo.orderd as o2, dbo.product as p WHERE p.productname LIKE '%6s%' AND o1.orderid=o2.orderid AND o1.pid=p.pid;
-- 33. List all the customers who have ordered for Apple I-Pad Mini from bangaloreSELECT customername, productname, city from dbo.customer as c, dbo.orderitem as o1, dbo.orderd as o2, dbo.product as p, dbo.customeraddress as a WHERE p.productname LIKE 'Apple I-Pad' AND a.city='bangalore' AND o1.orderid=o2.orderid AND o1.pid=p.pid;SELECT 	c.customername, o.orderid, p.productname, ca.cityFROM dbo.customer as c WITH(NOLOCK)	INNER JOIN dbo.customeraddress as ca WITH(NOLOCK)		ON c.customerid = ca.customerid AND ca.city LIKE 'bangalore'	INNER JOIN dbo.orderd as o WITH(NOLOCK)		ON ca.customerid = o.customerid	INNER JOIN dbo.orderitem as oi WITH(NOLOCK)		ON o.orderid = oi.orderid	INNER JOIN dbo.product as p WITH(NOLOCK)		ON oi.pid = p.pid AND p.isDeleted = 0WHERE p.productname LIKE 'Apple I-Pad Mini';
-- 34. List all the phones which Goutham orderd forSELECT customername, productname from dbo.customer, dbo.product WHERE customername LIKE 'Goutham' AND orderid IN (SELECT orderid FROM orderitem WHERE pid IN (SELECT pid FROM dbo.product WHERE pr))); SELECT 	c.customername, o.orderid, p.productnameFROM dbo.customer as c WITH(NOLOCK)	INNER JOIN dbo.orderd as o WITH(NOLOCK)		ON c.customerid = o.customerid	INNER JOIN dbo.orderitem as oi WITH(NOLOCK)		ON o.orderid = oi.orderid	INNER JOIN dbo.product as p WITH(NOLOCK)		ON oi.pid = p.pid AND p.isDeleted = 0WHERE c.customername LIKE 'Goutham';
-- 35. List all the phones which Amrutha orderd for in the 2014SELECT customername, productname from dbo.customer as c, dbo.orderitem as o1, dbo.orderd as o2, dbo.product as p WHERE c.customername LIKE 'Amrutha' AND o1.orderid=o2.orderid AND o1.pid=p.pid;SELECT 	c.customername, o.orderid, p.productname ,o.orderdateFROM dbo.customer as c WITH(NOLOCK)	INNER JOIN dbo.orderd as o WITH(NOLOCK)		ON c.customerid = o.customerid AND year(o.orderdate) = '2014'	INNER JOIN dbo.orderitem as oi WITH(NOLOCK)		ON o.orderid = oi.orderid	INNER JOIN dbo.product as p WITH(NOLOCK)		ON oi.pid = p.pid AND p.isDeleted = 0WHERE c.customername LIKE 'Amruthi';

-- 36. List all the customer who have not bought any product
SELECT 
*
FROM dbo.customer as c WITH(NOLOCK)
LEFT OUTER JOIN dbo.orderd as o WITH(NOLOCK)
ON c.customerid=o.customerid
WHERE o.customerid NOT IN(c.customerid);


-- 37. List Fav phones of BangaloreanSELECT TOP 3	p.productname, COUNT(p.productname) TotalOrderFROM dbo.customer as c WITH(NOLOCK)	INNER JOIN dbo.customeraddress as ca WITH(NOLOCK)		ON c.customerid = ca.customerid AND ca.city LIKE 'bangalore'	INNER JOIN dbo.orderd as o WITH(NOLOCK)		ON ca.customerid = o.customerid	INNER JOIN dbo.orderitem as oi WITH(NOLOCK)		ON o.orderid = oi.orderid	INNER JOIN dbo.product as p WITH(NOLOCK)		ON oi.pid = p.pid AND p.isDeleted = 0GROUP BY 	P.productnameORDER BY 	TotalOrder DESC-- 38. List all the products which were sold in the year 2013SELECT 	p.productnameFROM dbo.customer as c WITH(NOLOCK)	INNER JOIN dbo.orderd as o WITH(NOLOCK)		ON c.customerid = o.customerid 	INNER JOIN dbo.orderitem as oi WITH(NOLOCK)		ON o.orderid = oi.orderid	INNER JOIN dbo.product as p WITH(NOLOCK)		ON oi.pid = p.pid AND p.isDeleted = 0WHERE YEAR(o.orderdate) = '2013'GROUP BY 	p.productname;-- 39. List all the Nokia phones orderd by 'Ravi'SELECT 	c.customername,p.productnameFROM dbo.customer as c WITH(NOLOCK)	INNER JOIN dbo.orderd as o WITH(NOLOCK)		ON c.customerid = o.customerid 	INNER JOIN dbo.orderitem as oi WITH(NOLOCK)		ON o.orderid = oi.orderid	INNER JOIN dbo.product as p WITH(NOLOCK)		ON oi.pid = p.pid AND p.isDeleted = 0	INNER JOIN dbo.company AS co WITH(NOLOCK)		ON p.companyid = co.companyid AND co.companyname = 'Nokia'WHERE c.customername = 'Ravi';-- 40. List all the phones with its company nameSELECT 	p.productname, c.companyname FROM dbo.product AS p WITH(NOLOCK)	INNER JOIN dbo.company AS c WITH(NOLOCK)		ON p.companyid = c.companyidWHERE p.isDeleted = 0;

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

-- 45. List Customer id, customer name, orderdate, company and -- product name with qty, price of all the ordersSELECT  c.customerid,c.customername,o.orderdate,co.companyname,p.productname,oi.qty,p.price FROM customer AS c INNER JOIN orderd AS o ON c.customerid = o.customerid INNER JOIN orderitem AS oi ON o.orderid = oi.orderid INNER JOIN product as p ON oi.pid = p.pid INNER JOIN company AS co ON co.companyid=p.companyid ;-- 46. List Customer id, customer name, orderdate, company and -- product name with qty, price and amount of all the orders -- where amount is qty*priceSELECT  c.customerid,c.customername,o.orderdate,co.companyname,p.productname,oi.qty,p.price,(p.price * oi.qty) AS amount FROM customer AS c INNER JOIN orderd AS o ON c.customerid = o.customerid INNER JOIN orderitem AS oi ON o.orderid = oi.orderid INNER JOIN product as p ON oi.pid = p.pid INNER JOIN company AS co ON co.companyid=p.companyid ;/* 47. List Customer id, customer name, orderdate, company and product name with qty, price and amount of all the orders  where amount > 50,000 (amount is qty*price) */SELECT  c.customerid,c.customername,o.orderdate,co.companyname,p.productname,oi.qty,p.price,(p.price * oi.qty) AS amount FROM customer AS c INNER JOIN orderd AS o ON c.customerid = o.customerid INNER JOIN orderitem AS oi ON o.orderid = oi.orderid INNER JOIN product as p ON oi.pid = p.pid INNER JOIN company AS co ON co.companyid=p.companyid  WHERE (p.price * oi.qty) > 50000;/* 48. List customerid, customername, city, companyname, productname,qty, price and amount of all the products orderd */SELECT  c.customerid,c.customername,ca.city,co.companyname,p.productname,oi.qty,p.price,(p.price * oi.qty) AS amount FROM customer AS c INNER JOIN customeraddress AS ca ON c.customerid = ca.customerid INNER JOIN orderd AS o ON c.customerid = o.customerid INNER JOIN orderitem AS oi ON o.orderid = oi.orderid INNER JOIN product as p ON oi.pid = p.pid INNER JOIN company AS co ON co.companyid=p.companyid ORDER BY c.customerid;/* 49. List all product, company, customer and customer address details for all orderswhich were ordered in the year 2014*/SELECT  c.customerid,c.customername,ca.city,p.pid,p.productname,co.companyname,oi.qty,p.price,(p.price * oi.qty) AS amount,o.orderdate FROM customer AS c INNER JOIN customeraddress AS ca ON c.customerid = ca.customerid INNER JOIN orderd AS o ON c.customerid = o.customerid INNER JOIN orderitem AS oi ON o.orderid = oi.orderid INNER JOIN product as p ON oi.pid = p.pid INNER JOIN company AS co ON co.companyid=p.companyid WHERE o.orderdate LIKE '2014%' ORDER BY c.customerid;/* 50. Update amount of order item */UPDATE orderitem SET amount = qty * (SELECT p.price FROM product AS p WHERE p.pid = orderitem.pid);

/* 51. Get the total sales based on orderid  */SELECT o.orderid,p.productname,SUM(p.price*oi.qty) Amount FROM  dbo.orderd AS o WITH (NOLOCK)INNER JOIN dbo.orderitem AS oi WITH (NOLOCK)ON o.orderid=oi.orderidINNER JOIN dbo.product AS p WITH (NOLOCK)ON p.pid=oi.pid GROUP BY o.orderid,p.productname;/* 52. Get the total sales based on given month  */SELECT o.orderid,p.productname,SUM(p.price*oi.qty) Amount ,DATENAME(month, o.orderdate) AS  OrderedMonthFROM  dbo.orderd AS o WITH (NOLOCK)INNER JOIN dbo.orderitem AS oi WITH (NOLOCK)ON o.orderid=oi.orderidINNER JOIN dbo.product AS p WITH (NOLOCK)ON p.pid=oi.pid GROUP BY o.orderid,p.productname,DATENAME(month, o.orderdate);/* 53. Get the total sales based on year  */SELECT o.orderid,p.productname,SUM(p.price*oi.qty) Amount ,YEAR(o.orderdate) OrderedYearFROM  dbo.orderd AS o WITH (NOLOCK)INNER JOIN dbo.orderitem AS oi WITH (NOLOCK)ON o.orderid=oi.orderidINNER JOIN dbo.product AS p WITH (NOLOCK)ON p.pid=oi.pid GROUP BY o.orderid,p.productname,DATENAME(month, o.orderdate),YEAR(o.orderdate);/* 54. Get the total sales based on month and year */SELECT o.orderid,p.productname,SUM(p.price*oi.qty) Amount ,DATENAME(month, o.orderdate) AS  OrderedMonth,YEAR(o.orderdate) OrderedYearFROM  dbo.orderd AS o WITH (NOLOCK)INNER JOIN dbo.orderitem AS oi WITH (NOLOCK)ON o.orderid=oi.orderidINNER JOIN dbo.product AS p WITH (NOLOCK)ON p.pid=oi.pid GROUP BY o.orderid,p.productname,DATENAME(month, o.orderdate),YEAR(o.orderdate);/* 55. Total sales based on product  */SELECT p.productname,oi.qty,oi.amount FROM  dbo.orderd AS o WITH (NOLOCK)INNER JOIN dbo.orderitem AS oi WITH (NOLOCK)ON o.orderid=oi.orderidINNER JOIN dbo.product AS p WITH (NOLOCK)ON p.pid=oi.pid GROUP BY p.productname,p.pid,oi.amount,oi.qty ;

/* 56. Total sales based on company  */SELECT o.orderid,c.customerid,c.customername,ca.city,co.companyname,p.productname,p.price,oi.qty,oi.amount,YEAR(o.orderdate) OrderYearFROM dbo.customer AS c WITH (NOLOCK)INNER JOIN dbo.customeraddress as ca WITH(NOLOCK)ON c.customerid =ca.customeridINNER JOIN  dbo.orderd AS o WITH (NOLOCK)ON c.customerid=o.customerid INNER JOIN dbo.orderitem AS oi WITH (NOLOCK)ON o.orderid=oi.orderidINNER JOIN dbo.product AS p WITH (NOLOCK)ON p.pid=oi.pid INNER JOIN dbo.company AS co WITH (NOLOCK)ON co.companyid = p.companyidGROUP BY YEAR(o.orderdate),o.orderid,c.customerid,c.customername,ca.city,co.companyname,p.productname,oi.qty,p.price,oi.amount;/* 57. Display top 3 sold mobiles */SELECT TOP 3 p.productname,SUM(p.price*oi.qty) Amount ,DATENAME(month, o.orderdate) AS  OrderedMonth,YEAR(o.orderdate) OrderedYearFROM  dbo.orderd AS o WITH (NOLOCK)INNER JOIN dbo.orderitem AS oi WITH (NOLOCK)ON o.orderid=oi.orderidINNER JOIN dbo.product AS p WITH (NOLOCK)ON p.pid=oi.pid GROUP BY p.productname,DATENAME(month, o.orderdate),YEAR(o.orderdate);/* 58. Top 3 customers based on billing amount */SELECT TOP 3 o.orderid, c.customername,p.productname,p.price,SUM(oi.qty*p.price) BillingAmountFROM dbo.customer AS c WITH (NOLOCK)INNER JOIN dbo.customeraddress as ca WITH(NOLOCK)ON c.customerid =ca.customeridINNER JOIN  dbo.orderd AS o WITH (NOLOCK)ON c.customerid=o.customerid INNER JOIN dbo.orderitem AS oi WITH (NOLOCK)ON o.orderid=oi.orderidINNER JOIN dbo.product AS p WITH (NOLOCK)ON p.pid=oi.pid INNER JOIN dbo.company AS co WITH (NOLOCK)ON co.companyid = p.companyidGROUP BY o.orderid,c.customername,p.productname,p.priceORDER BY BillingAmount DESC ;/* 59. Top 3rd customer based on billing amount */SELECT * FROM (SELECT c.customername,p.productname,p.price,SUM(oi.qty*p.price)AS BillingAmount,DENSE_RANK() OVER(ORDER BY (p.price*oi.qty) DESC ) AS billingRankFROM dbo.customer AS c WITH (NOLOCK)INNER JOIN  dbo.orderd AS o WITH (NOLOCK)ON c.customerid=o.customerid INNER JOIN dbo.orderitem AS oi WITH (NOLOCK)ON o.orderid=oi.orderidINNER JOIN dbo.product AS p WITH (NOLOCK)ON p.pid=oi.pid INNER JOIN dbo.company AS co WITH (NOLOCK)ON co.companyid = p.companyidGROUP BY o.orderid,c.customername,p.productname,p.price,oi.qty)AS result WHERE  result.billingRank = 3/* 60. Display all unique phones which are sold */SELECT DISTINCT(p.productname),p.priceFROM  dbo.orderd AS o WITH (NOLOCK)INNER JOIN dbo.orderitem AS oi WITH (NOLOCK)ON o.orderid=oi.orderidINNER JOIN dbo.product AS p WITH (NOLOCK)ON p.pid=oi.pid GROUP BY p.productname,p.price;

/* 61. Display all phones which are sold with the no. of quantity */SELECT p.productname,p.price,oi.qtyFROM  dbo.orderd AS o WITH (NOLOCK)INNER JOIN dbo.orderitem AS oi WITH (NOLOCK)ON o.orderid=oi.orderidINNER JOIN dbo.product AS p WITH (NOLOCK)ON p.pid=oi.pid GROUP BY p.productname,p.price ,oi.qty;/* 62. Name of the top priced phone */SELECT TOP 3 p.productname,p.price FROM dbo.product as pGROUP BY p.price,p.productnameORDER BY p.price DESC;



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