USE [newdb3]
GO

CREATE TABLE CUSTOMER
( 
	cId INT PRIMARY KEY IDENTITY,
	cName NVARCHAR(40)
);

CREATE TABLE BALANCE
(
	cId INT,
	Amount FLOAT,
	FOREIGN KEY (cId) REFERENCES CUSTOMER(cId)
);

CREATE TABLE CTRANSACTION
(
	cId INT,
	withdraw BIT,
	deposit BIT,
	dateOfTransaction DATE,
	Amount FLOAT
	FOREIGN KEY (cId) REFERENCES CUSTOMER(cId)
);

INSERT INTO CUSTOMER (cName)
VALUES
	('Danny');


--TEST CASES
INSERT INTO CTRANSACTION(cId,withdraw,deposit,dateOfTransaction,Amount)
VALUES
( 2,0,1,'2022-07-04',6000
);

INSERT INTO CTRANSACTION(cId,withdraw,deposit,dateOfTransaction,Amount)
VALUES
( 2,1,0,'2022-07-05',3000
);

INSERT INTO CTRANSACTION(cId,withdraw,deposit,dateOfTransaction,Amount)
VALUES
( 2,1,0,'2022-07-05',4000
);

INSERT INTO CTRANSACTION(cId,withdraw,deposit,dateOfTransaction,Amount)
VALUES
( 7,1,0,'2022-07-06',11000
);


SELECT * FROM CUSTOMER;
SELECT * FROM BALANCE;
SELECT * FROM CTRANSACTION;

