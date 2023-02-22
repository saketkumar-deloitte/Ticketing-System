using System.ComponentModel.DataAnnotations;


namespace Ticketing_System.Models;
public class User
    {
        [Key]
        public int userId { get; set; }

        public String email { get; set; }

        public String password { get; set; }

        public String name { get; set; }

        public List<Role>? rolesList { get; set; }
  
    }