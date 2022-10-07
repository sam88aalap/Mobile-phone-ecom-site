/**
** @Version: 1.0
** @Date: 4/7/22
** @Dev: 68186
**/


/** if sp exist then we delete it**/

IF EXISTS(
   SELECT 1 FROM sys.objects WHERE type ='F' AND OBJECT_ID = OBJECT_ID('[dbo].[fn_getAmount]')
   )
BEGIN
     DROP FUNCTION [dbo].[fn_getAmount]
END
GO

CREATE FUNCTION [dbo].[fn_getAmount]
(
 @pId INT,
 @qty INT
)
RETURNS FLOAT
AS
BEGIN
  DECLARE
    @price FLOAT,
    @total FLOAT

  SELECT @price = price FROM dbo.product AS p WITH(NOLOCK)
  WHERE p.pid=@pId

  SET @total = @qty * @price
  RETURN @total
END
GO

--executing function
SELECT dbo.fn_getAmount(1,2)