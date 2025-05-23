CREATE PROCEDURE proc_Admin
    @flag VARCHAR(10) = NULL,
	@id VARCHAR(10) = NULL,
    @Username VARCHAR(20) = NULL,
	@FullName VARCHAR(50) = NULL,
	@Email VARCHAR(255) = NULL,
	@PasswordHash VARCHAR(255) = NULL,
	@Rolel VARCHAR(255) = NULL,
	@IsActive BIT = NULL,
	@IsDeleted VARCHAR(5) = NULL,
	@IsBlocked VARCHAR(5) = NULL
AS
SET NOCOUNT ON;
BEGIN TRY
    DECLARE @additionalErrorMessage VARCHAR(100);

    BEGIN
        IF @flag = 'GS' --get students
        BEGIN
            Select  * from Student
        END
        ELSE IF @flag = 'GSI' -- get student by ID
        BEGIN
             Select  * from Student where StudentId = @id
        END
		ELSE IF @flag = 'BS' -- block student
        BEGIN
             UPDATE student set IsBlocked = 'Y' WHERE StudentId = @id
        END
		ELSE IF @flag = 'GB' -- get books
        BEGIN
             Select  * from Books
        END
		ELSE IF @flag = 'GBI' -- get books
        BEGIN
             Select  * from Books where BookID = @id
        END
		ELSE IF @flag = 'BB' -- Block books
        BEGIN
			 UPDATE Books set IsBlocked = 'Y' WHERE BookID = @id
        END
    END
END TRY
BEGIN CATCH  
    DECLARE @errorLogId BIGINT, 
            @errorMessage VARCHAR(MAX);
    
    INSERT INTO Logs (errorPage, errorMsg, errorDetails, createdBy, createdDate)
    SELECT 'API SP Error', 'Technical Error: ' + ERROR_MESSAGE() + ' at LINE: ' + CAST(ERROR_LINE() AS VARCHAR), 
           '[proc_GetOrderDetails]', @user, GETDATE();
    
    SET @errorLogId = SCOPE_IDENTITY();
    SET @additionalErrorMessage = 'Error Log ID: ' + CAST(@errorLogId AS VARCHAR);
    
    SELECT '999' AS ErrorCode, CONCAT('Technical Error Occurred: ', @additionalErrorMessage) AS errorMessage, @errorLogId AS Id;
END CATCH;
