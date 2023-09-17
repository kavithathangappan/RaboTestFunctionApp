using System.Collections.Generic;

namespace Rabo_Test_FunctionApp.DTO
{
    public class UsersDTO
    {
        public List<UserDTO> Users { get; set; } 
    }
    public class UserDTO 
    {
        public int RecordId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }

        public string Email { get; set; }

        public string DataValue { get; set; }

        public bool NotificationFlag { get; set; }
    }
}
