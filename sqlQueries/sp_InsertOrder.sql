/**
** @Version: 1.0
** @Date: 4/7/22
** @Dev: 68186
**/


/** if sp exist then we delete it**/

IF EXISTS(
   SELECT 1 FROM sys.objects WHERE type ='P' AND OBJECT_ID = OBJECT_ID('[dbo].[sp_InsertOrder]')
   )
BEGIN
     DROP PROC [dbo].[sp_InsertOrder]
END
GO

CREATE PROC [dbo].[sp_InsertOrder]
   @orderDate DATE,
   @customerId INT=null,
   @totalAmount FLOAT, 
   @orderId INT OUT,
   @aspNetCustomerId NVARCHAR(450) = null
AS
BEGIN
  
  DECLARE
 @orderStatus NVARCHAR(20)='NEW'

  --   IF NOT EXISTS(
	 --   SELECT 1 FROM dbo.customer as c WITH(NOLOCK)
		--WHERE c.customerid = @customerId
	 --)
	 --BEGIN
	 --   THROW 600001,'No SUCH CUSTOMER EXISTS',18
	 --END

	 INSERT INTO dbo.orderd
	 (
	   orderstatus,
	   orderdate,
	   customerid,
	   totalAmount,
	   aspCustomerId
	 )
	 VALUES
	 (
	   @orderStatus,
	   @orderDate,
	   @customerId,
	   @totalAmount,
	   @aspNetCustomerId
	 )
	 SET @orderId=@@IDENTITY

END
GO

--EXECuting the proc

DECLARE
     @newOrderID INT;
EXEC sp_InsertOrder '2022-07-04',1,12000,@newOrderID OUT;
SELECT @newOrderID;

