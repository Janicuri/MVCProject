CREATE OR ALTER TRIGGER updatePlayer ON AspNetUsers AFTER UPDATE AS 
BEGIN

DECLARE @id VARCHAR(100)
DECLARE @username VARCHAR(50)

SELECT @id =Id, @username=UserName FROM inserted

SET @username = dbo.GiveUserName(@username)

UPDATE players
SET [Name] = @username where Id = @id

END

