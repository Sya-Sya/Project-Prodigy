CREATE PROCEDURE proc_DeleteStudent
    @StudentId INT
AS
BEGIN
    DELETE FROM Student WHERE StudentId = @StudentId;

    IF @@ROWCOUNT > 0
        SELECT 'Student deleted successfully.' AS Message;
    ELSE
        SELECT 'No student found with that ID.' AS Message;
END
