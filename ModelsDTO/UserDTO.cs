using EMedicineBE.Models;

namespace EMedicineBE.ModelsDTO
{
    public class UserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public decimal Fund { get; set; }
        public string Type { get; set; }
        public int status { get; set; }
        public DateTime createdon { get; set; }

    }
}
