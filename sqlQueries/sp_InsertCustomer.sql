/**
** @Version: 1.0
** @Date: 4/7/22
** @Dev: 68186
**/


/** if sp exist then we delete it**/

IF EXISTS(
   SELECT 1 FROM sys.objects WHERE type ='P' AND OBJECT_ID = OBJECT_ID('[dbo].[sp_InsertCustomer]')
   )
BEGIN
     DROP PROC [dbo].[sp_InsertCustomer]
END
GO

CREATE PROC [dbo].[sp_InsertCustomer]
  @customerId INT,
  @cName NVARCHAR(20),
  @mobileNo INT,
  @email NVARCHAR(20),
  @password NVARCHAR(20)
AS
BEGIN
IF EXISTS(
    SELECT 1 FROM dbo.customer as c WITH(NOLOCK)
	WHERE c.emailid= @email
  )
  BEGIN
    THROW 600005,'email already in use',18
  END

  INSERT INTO dbo.customer
  (
   customerid,
   customername,
   mobileno,
   emailid,
   [password]
  )VALUES
  (
   @customerId,
   @cName,
   @mobileNo,
   @email,
   @password
  )
END
GO



EXEC dbo.sp_InsertCustomer 22,'Sam',98756789,'Sam2@gmail.com','pass@123795'


  SELECT * FROM dbo.customer;

  EXEC sp_GetCustomerOrderDetails 1;