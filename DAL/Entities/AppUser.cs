using Microsoft.AspNetCore.Identity;
public class AppUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime Date0 { get; set; } 
    public string Email { get; set; }
    // Constructor with default values
    public AppUser(string userName, string email) : base(userName)
    {
        Email = email;
        var nameParts = userName.Split('_');
        // Set FirstName and LastName based on the split parts
        FirstName = nameParts.Length > 0 ? nameParts[0] : string.Empty; // Default to empty if no first name
        LastName = nameParts.Length > 1 ? nameParts[1] : string.Empty;  // Default to empty if no last name
    }
}
