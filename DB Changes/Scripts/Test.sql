INSERT INTO Members (FullName, Email, PasswordHash)  
VALUES ('Bigay God', 'kale@hotsinglemale.com', HashPassword('MyPPBlackerthanyours@123'));

SELECT VerifyPassword('MyPPBlackerthanyours@123', PasswordHash) AS IsValid  
FROM Members  
WHERE Email = 'john@example.com';