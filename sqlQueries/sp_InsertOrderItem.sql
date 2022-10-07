/**
** @Version: 1.0
** @Date: 4/7/22
** @Dev: 68186
**/


/** if sp exist then we delete it**/

IF EXISTS(
   SELECT 1 FROM sys.objects WHERE type ='P' AND OBJECT_ID = OBJECT_ID('[dbo].[sp_InsertOrderItem]')
   )
BEGIN
     DROP PROC [dbo].[sp_InsertOrderItem]
END
GO

CREATE PROC [dbo].[sp_InsertOrderItem]
  @pId INT,
  @qty INT,
  @orderID INT
AS
BEGIN
  IF NOT EXISTS(
    SELECT 1 FROM dbo.orderd as o WITH(NOLOCK)
	WHERE o.orderid=@orderID
  )
  BEGIN
    THROW 600002,'No SUCH ORDER EXISTS',18
  END

  IF @qty=0
  BEGIN
    THROW 600003,'invalid quantity',18
  END

   IF NOT EXISTS(
    SELECT 1 FROM dbo.product as p WITH(NOLOCK)
	WHERE p.pid=@pId
  )
  BEGIN
    THROW 600004,'invalid product',18
  END

  DECLARE 
  @total FLOAT

  SET @total =[dbo].[fn_getAmount](@pId,@qty)

  INSERT INTO dbo.orderitem
  (
  orderid,
  qty,
  amount,
  pid
  )VALUES
  (
  @orderID,
  @qty,
  @total,
  @pId
  )

END
GO



--SELECT * FROM dbo.orderitem;
EXEC sp_InsertOrderItem 1,2,2;
SELECT * FROM orderitem WHERE orderid=2;