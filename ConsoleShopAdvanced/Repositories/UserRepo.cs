using System.Collections.Generic;
using ConsoleShopAdvanced.Models;

namespace ConsoleShopAdvanced.Repositories
{
    public static class UserRepo
    {
        private static List<User> _users;

        public static IEnumerable<User> Users => _users;

        static UserRepo()
        {
            _users = new List<User>();
            
            var array = new User[]
            {
                new User {Login = "user1", Password = "pass1"},
                new User {Login = "user2", Password = "pass2"},
                new User {Login = "user3", Password = "pass3"}
            };
        }
        

        public static void RegisterUser(User user) =>
            _users.Add(user);
    }
}