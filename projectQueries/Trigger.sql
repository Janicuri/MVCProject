CREATE OR ALTER TRIGGER insertPlayer ON AspNetUsers AFTER INSERT AS 
BEGIN

DECLARE @id VARCHAR(100)
DECLARE @username VARCHAR(50)

SELECT @id = Id,@username=UserName FROM inserted

SET @username = dbo.GiveUserName(@username)

INSERT INTO players([Name],IdentityUserId,Color,score,Bucks,CurrentItemUrl) VALUES(@username,@id,'red',0,0,'')

END

select * from AspNetUsers a
join players p on p.IdentityUserId = a.Id
