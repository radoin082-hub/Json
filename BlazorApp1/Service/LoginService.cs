

using System.Text.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BlazorApp1.Service
{
    public class LoginService
    {
        private readonly List<User> Users;

        public LoginService()
        {
        
            var json = File.ReadAllText("C://Users//radoi/RiderProjects/ConsoleApp1/BlazorApp1/wwwroot/User.json");
            Users = JsonSerializer.Deserialize<List<User>>(json);
        }

        public User Authenticate(string email, string password)
        {
         
            return Users.FirstOrDefault(u => u.Email == email && u.Password == password);
        }
    }

    public class User
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
