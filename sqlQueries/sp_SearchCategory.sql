/**
** @Version: 1.0
** @Date: 5/7/22
** @Dev: 68186
**/


/** if sp exist then we delete it**/
USE [db_shopon]
GO
IF EXISTS(
   SELECT 1 FROM sys.objects WHERE type ='P' AND OBJECT_ID = OBJECT_ID('[dbo].[sp_SearchCategory]')
   )
BEGIN
     DROP PROC [dbo].[sp_SearchCategory]
END
GO

CREATE PROC [dbo].[sp_SearchCategory]
       --@searchKey NVARCHAR(20)
	   @categoryID INT=null
AS
BEGIN
     --exception for invalid category
	 IF NOT EXISTS(
	    SELECT 1 FROM dbo.category as ca WITH(NOLOCK)
		WHERE ca.categoryid = @categoryID
	 )
	 BEGIN
	    THROW 600007,'INVALID CATEGORY',18
	 END

	 --creating temp table
     CREATE TABLE #temp
	 (
	 Pid INT,
	 ProductName VARCHAR(20),
	 Price FLOAT,
	 ImageUrl VARCHAR(40),
	 AvailableStatus CHAR(1),
	 CompanyId INT,
	 CompanyName VARCHAR(20),
	 CategoryId INT,
	 CategoryName VARCHAR(20)
	 );

	 If(@categoryID IS NULL)
	 BEGIN
	      INSERT INTO #temp
		  SELECT
		       p.pid,p.productname,p.price,p.imageUrl,p.availablestatus,
			   c.companyid,c.companyname,ca.categoryid,ca.category
		  FROM dbo.product AS p WITH(NOLOCK)
		  INNER JOIN dbo.company AS c WITH(NOLOCK)
		  ON p.companyid=c.companyid
		  INNER JOIN dbo.category AS ca WITH(NOLOCK)
		  ON p.categoryid=ca.categoryid
		  WHERE 
		  p.isDeleted=0;
	 END
	 ELSE
	   BEGIN
	        INSERT INTO #temp
		  SELECT
		       p.pid,p.productname,p.price,p.imageUrl,p.availablestatus,
			   c.companyid,c.companyname,ca.categoryid,ca.category
		  FROM dbo.product AS p WITH(NOLOCK)
		  INNER JOIN dbo.company AS c WITH(NOLOCK)
		  ON p.companyid=c.companyid
		  INNER JOIN dbo.category AS ca WITH(NOLOCK)
		  ON p.categoryid=ca.categoryid
		  WHERE 
		  p.isDeleted=0 AND ca.categoryid=@categoryID;
	   END

	   SELECT * FROM #temp;
	   DROP TABLE #temp;
END
GO

--TESTING SP
EXEC sp_SearchCategory 22;
EXEC sp_SearchCategory 2001;
EXEC sp_SearchCategory 2002;
EXEC sp_SearchCategory 2003;
EXEC sp_SearchCategory 2004;

SELECT * from dbo.category;