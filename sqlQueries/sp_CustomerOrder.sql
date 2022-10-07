/**
** @Version: 1.0
** @Date: 4/7/22
** @Dev: 68186
**/


/** if sp exist then we delete it**/

IF EXISTS(
   SELECT 1 FROM sys.objects WHERE type ='P' AND OBJECT_ID = OBJECT_ID('[dbo].[sp_CustomerOrder]')
   )
BEGIN
     DROP PROC [dbo].[sp_CustomerOrder]
END
GO


CREATE PROCEDURE [dbo].[sp_CustomerOrder]
  @customerID INT /*parameter */
AS
BEGIN
/*LOGIC to print an exception if Customer id is invalid*/
     IF NOT EXISTS(
	        SELECT 1 FROM [dbo].[customer] AS c WITH(NOLOCK)
			WHERE c.customerid=@customerID
	 )
	 BEGIN
	      THROW 600001,'No SUCH CUSTOMER EXISTS',18
	 END

	 SELECT 
	      o.orderid,o.orderdate,
		  c.customerid,c.customername,
		  p.productname,p.price,
		  oi.qty, (p.price * oi.qty) Amount

	 FROM dbo.orderd as o WITH(NOLOCK)
	 INNER JOIN dbo.orderitem as oi WITH(NOLOCK)
	 ON o.orderid=oi.orderid
	 INNER JOIN dbo.product as p WITH(NOLOCK)
	 ON p.pid=oi.pid AND p.isDeleted=0
	 INNER JOIN dbo.customer as c WITH(NOLOCK)
	 ON c.customerid=o.customerid
	 WHERE o.customerid=@customerId; 
END
GO
/*Execute SP*/
EXEC sp_CustomerOrder 21;