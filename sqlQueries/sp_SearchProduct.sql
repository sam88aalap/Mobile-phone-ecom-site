/**
** @Version: 1.0
** @Date: 5/7/22
** @Dev: 68186
**/

IF EXISTS(
   SELECT 1 FROM sys.objects WHERE type ='P' AND OBJECT_ID = OBJECT_ID('[dbo].[sp_SearchProduct]')
   )
BEGIN
     DROP PROC [dbo].[sp_SearchProduct]
END
GO

CREATE PROC [dbo].[sp_SearchProduct]
    @searchKey NVARCHAR(40)
AS
BEGIN
   SELECT 
     p.pid,p.productname,p.price,c.companyname
   FROM dbo.product as p WITH(NOLOCK)
   INNER JOIN dbo.company as c WITH(NOLOCK)
   ON p.companyid=c.companyid AND p.isDeleted=0
   WHERE c.companyname=@searchKey OR p.productname LIKE '%'+@searchKey+'%';
END
GO

--SELECT * FROM dbo.product;
--TEST CASES
EXEC sp_SearchProduct 'APPLE';
EXEC sp_SearchProduct 'Apple I-Pad Mini';
EXEC sp_SearchProduct 'iphone';
EXEC sp_SearchProduct 'Apple';
EXEC sp_SearchProduct 'Nokia';
EXEC sp_SearchProduct 'Lumia';