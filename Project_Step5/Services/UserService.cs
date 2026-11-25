using Project_Step5.Interfaces;
using Project_Step5.Models;

namespace Project_Step5.Services
{
    public class UserService : IUserService
    {

        public List<User> GetUsers()
        {
            List<User> users = new List<User>()
            {
                new User
                {
                    Id = 1,
                    FirstName = "Rahul",
                    LastName = "Sharma",
                    Age = 29,
                    Email = "rahul.sharma@example.com"

                },
                new User
                {
                    Id = 1,
                    FirstName = "Priya",
                    LastName = "Reddy",
                    Age = 26,
                    Email = "priya.reddy@example.com"

                },
                new User
                {
                    Id = 1,
                    FirstName = "Arjun",
                    LastName = "Kumar",
                    Age = 32,
                    Email = "arjun.kumar@example.com"
                }
            };
            
            return users;
        }
    }
}
