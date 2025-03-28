namespace MidProjectDb
{
    public class User
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public int? FacultyId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
