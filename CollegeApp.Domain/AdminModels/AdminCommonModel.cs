namespace CollegeApp.Domain.AdminModels;

public class AdminCommonModel : BaseFilter// admin related models
{
    public int AdminId { get; set; }
    public string FullName { get; set; }
    public string Username { get; set; }            // For login
    public string Email { get; set; }
    public string PasswordHash { get; set; }        // Hashed password
    public string Role { get; set; }                // Example: "SuperAdmin", "Librarian", "Student"
    public bool IsActive { get; set; }              // Soft delete or deactivation
}