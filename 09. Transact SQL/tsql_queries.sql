USE TransactSqlHW
GO

--1. Write a stored procedure that selects the full names of all persons.
CREATE PROC dbo.usp_SelectFullNames
AS
	SELECT FirstName + ' ' + LastName AS FullName
	FROM Persons
GO

EXEC dbo.usp_SelectFullNames
GO

--2.Create a stored procedure that accepts a number as a parameter and returns all 
--  persons who have more money in their accounts than the supplied number.
CREATE PROC dbo.usp_PeopleThatHaveMoreMoneyThan(@money money)
AS
	Select *
	From Persons p
	join Accounts a on p.Id = a.PersonId
	Where a.Balance > @money
GO

EXEC dbo.usp_PeopleThatHaveMoreMoneyThan 500
GO

--3.Create a function that accepts as parameters – sum, yearly interest rate and number of months.
--It should calculate and return the new sum.
--Write a SELECT to test whether the function works as expected.
CREATE FUNCTION fn_CalculateBalance(@sum money, @yearlyInterestRate float, @months int)
RETURNS money
AS
	BEGIN
		RETURN @sum * POWER((1 + @yearlyInterestRate / 12), @months)
	END
GO

SELECT dbo.fn_CalculateBalance(a.Balance, 0.1, 24) AS TotalSum
FROM Accounts a
GO

--4.Create a stored procedure that uses the function from the previous example to give an 
--interest to a person's account for one month.
--It should take the AccountId and the interest rate as parameters.
CREATE PROC dbo.usp_CalculateInterestForMonth(@acountID int, @interestRate float)
AS
	SELECT dbo.fn_CalculateBalance(Balance, @interestRate, 1) - Balance AS InterestForMonth
	FROM Accounts
	WHERE Id = @acountID
GO

EXEC dbo.usp_CalculateInterestForMonth 3, 0.1
GO

--5.Add two more stored procedures WithdrawMoney(AccountId, money) and 
--DepositMoney(AccountId, money) that operate in transactions.
CREATE PROC dbo.usp_WithdrawMoney(@accountId int, @money money)
AS
	UPDATE Accounts
	SET Balance -= @money
	WHERE Id = @accountId
GO

CREATE PROC dbo.usp_DepositMoney(@accountId int, @money money)
AS
	UPDATE Accounts
	SET Balance += @money
	WHERE Id = @accountId
GO

EXEC dbo.usp_WithdrawMoney 1, 25

EXEC dbo.usp_DepositMoney 1, 50

SELECT Balance
FROM Accounts
WHERE Id = 1
GO

--6.Create another table – Logs(LogID, AccountID, OldSum, NewSum).
--Add a trigger to the Accounts table that enters a new entry into the 
--Logs table every time the sum on an account changes.
CREATE TRIGGER dbo.tr_BalanceUpdate ON Accounts FOR UPDATE
AS
	BEGIN
		INSERT INTO Logs
			SELECT d.Id, d.Balance, i.Balance
			From deleted d
			JOIN inserted i ON d.Id = i.Id
	END
GO

EXEC dbo.usp_WithdrawMoney 1, 25
GO

EXEC dbo.usp_DepositMoney 1, 25
GO

--7.Define a function in the database TelerikAcademy that returns all 
--Employee's names (first or middle or last name) and all town's names that 
--are comprised of given set of letters.
--Example: 'oistmiahf' will return 'Sofia', 'Smith', … but not 'Rob' and 'Guy'.
USE TelerikAcademy
GO

CREATE FUNCTION ufn_CheckName (@nameToCheck NVARCHAR(50),@letters NVARCHAR(50)) RETURNS INT
AS
BEGIN
        DECLARE @i INT = 1
		DECLARE @currentChar NVARCHAR(1)
        WHILE (@i <= LEN(@nameToCheck))
			BEGIN
				SET @currentChar = SUBSTRING(@nameToCheck,@i,1)
					IF (CHARINDEX(LOWER(@currentChar),LOWER(@letters)) <= 0) 
						BEGIN  
							RETURN 0
						END
				SET @i = @i + 1
			END
        RETURN 1
END
GO
CREATE FUNCTION ufn_CheckIfNameConsistsOfLetters (@searchString NVARCHAR(200)) 
RETURNS @T TABLE (Name nvarchar(200))
AS
BEGIN
DECLARE employeeCursor CURSOR READ_ONLY FOR
	(SELECT e.FirstName, e.LastName, t.Name FROM Employees e
		JOIN Addresses a ON e.AddressID = a.AddressID
		JOIN Towns t ON a.TownID=t.TownID)
OPEN employeeCursor
DECLARE @firstName NVARCHAR(200), 
@lastName NVARCHAR(200), 
@town NVARCHAR(200)
DECLARE @tempTable TABLE (Name nvarchar(200))
FETCH NEXT FROM employeeCursor INTO @firstName, @lastName, @town
WHILE @@FETCH_STATUS = 0
  BEGIN
        DECLARE @i INT = 1
		DECLARE @match nvarchar(200) = NULL
		DECLARE @currentChar NVARCHAR(1)
		IF (dbo.ufn_CheckName(@firstName, @searchString) = 1)
			BEGIN
				SET @match = @firstName
			END
		IF (dbo.ufn_CheckName(@lastName, @searchString) = 1)
			BEGIN
				SET @match = @lastName
			END
		IF (dbo.ufn_CheckName(@town, @searchString) = 1)
			BEGIN
				SET @match = @town
			END
		IF @match IS NOT NULL
			INSERT INTO @tempTable
			VALUES (@match)
	FETCH NEXT FROM employeeCursor INTO @firstName, @lastName, @town
  END
CLOSE employeeCursor
DEALLOCATE employeeCursor
INSERT INTO @T
SELECT DISTINCT Name FROM @tempTable
RETURN
END
GO

SELECT *
FROM ufn_CheckIfNameConsistsOfLetters('oistmiahf')

--8.Using database cursor write a T-SQL script that scans all employees 
--and their addresses and prints all pairs of employees that live in the same town.
DECLARE @nameFirstPerson AS nvarchar(70)
DECLARE @nameSecondPerson AS nvarchar(70)
DECLARE @townId AS int
DECLARE @cursor AS CURSOR

SET @cursor = CURSOR FOR
	SELECT e.FirstName + ' ' + e.LastName AS FullName, a.TownID, d.FullName
	FROM Addresses a
	JOIN Employees e ON a.AddressID = e.AddressID
	JOIN (SELECT e.FirstName + ' ' + e.LastName AS FullName, a.TownID
		  FROM Addresses a
		  JOIN Employees e ON a.AddressID = e.AddressID) d
		  ON d.TownID = a.TownID

OPEN @cursor
FETCH NEXT FROM @cursor INTO @nameFirstPerson, @townId, @nameSecondPerson

WHILE @@FETCH_STATUS = 0
BEGIN
 PRINT cast(@townId as VARCHAR (50)) + ' ' +  @nameFirstPerson + ' ' + @nameSecondPerson;
 FETCH NEXT FROM @cursor INTO @nameFirstPerson, @townId, @nameSecondPerson
END

CLOSE @cursor
DEALLOCATE @cursor

--9.*Write a T-SQL script that shows for each town a list of all employees that live in it.

CREATE TABLE #UsersTowns (ID INT IDENTITY, FullName NVARCHAR(50), TownName NVARCHAR(50))
INSERT INTO #UsersTowns
SELECT e.FirstName + ' ' + e.LastName, t.Name
                FROM Employees e
                        INNER JOIN Addresses a
                                ON a.AddressID = e.AddressID
                        INNER JOIN Towns t
                                ON t.TownID = a.TownID
                GROUP BY t.Name, e.FirstName, e.LastName
DECLARE @name NVARCHAR(50)
DECLARE @town NVARCHAR(50)
 
DECLARE employeeCursor CURSOR READ_ONLY FOR
        SELECT DISTINCT ut.TownName
                FROM #UsersTowns ut     
 
OPEN employeeCursor
FETCH NEXT FROM employeeCursor
	INTO @town
 
	WHILE @@FETCH_STATUS = 0
		BEGIN
			DECLARE @empName nvarchar(MAX);
			SET @empName = N'';
			SELECT @empName += ut.FullName + N', '
			FROM #UsersTowns ut
			WHERE ut.TownName = @town
			PRINT @town + ' -> ' + LEFT(@empName,LEN(@empName)-1);
			FETCH NEXT FROM employeeCursor INTO @town
		END
CLOSE employeeCursor
DEALLOCATE employeeCursor
DROP TABLE #UsersTowns

--10.Define a .NET aggregate function StrConcat that takes as input a sequence of 
--strings and return a single string that consists of the input strings separated by ','.
IF NOT EXISTS (
    SELECT value
    FROM sys.configurations
    WHERE name = 'clr enabled' AND value = 1
)
BEGIN
    EXEC sp_configure @configname = clr_enabled, @configvalue = 1
    RECONFIGURE
END
GO

-- Remove the aggregate and assembly if they're there
IF (OBJECT_ID('dbo.concat') IS NOT NULL) 
    DROP Aggregate concat; 
GO 

IF EXISTS (SELECT * FROM sys.assemblies WHERE name = 'concat_assembly') 
    DROP assembly concat_assembly; 
GO      

CREATE Assembly concat_assembly 
   AUTHORIZATION dbo 
   FROM 'C:\SqlStringConcatenation.dll' --- CHANGE THE LOCATION
   WITH PERMISSION_SET = SAFE; 
GO 

CREATE AGGREGATE dbo.concat ( 
    @Value NVARCHAR(MAX),
    @Delimiter NVARCHAR(4000) 
) 
    RETURNS NVARCHAR(MAX) 
    EXTERNAL Name concat_assembly.concat; 
GO 

SELECT dbo.concat(FirstName + ' ' + LastName, ', ')
FROM Employees
GO

DROP Aggregate concat; 
DROP assembly concat_assembly; 
GO