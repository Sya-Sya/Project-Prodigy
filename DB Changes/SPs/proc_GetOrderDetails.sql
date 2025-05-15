CREATE PROCEDURE proc_GetOrderDetails
    @flag VARCHAR(10) = NULL,
    @user VARCHAR(20) = NULL
AS
SET NOCOUNT ON;
BEGIN TRY
    DECLARE @additionalErrorMessage VARCHAR(100);

    BEGIN
        IF @flag IN ('u', 'c', 'd')
        BEGIN
            SELECT * 
            FROM Orders 
            WHERE [Status] = 
                CASE 
                    WHEN @flag = 'u' THEN 'Pending'
                    WHEN @flag = 'c' THEN 'Confirmed'
                    WHEN @flag = 'd' THEN 'Delivered'
                END;
        END
        ELSE
        BEGIN
            SELECT * FROM Orders;
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
