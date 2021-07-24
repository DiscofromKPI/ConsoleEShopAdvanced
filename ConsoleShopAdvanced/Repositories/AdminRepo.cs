using System.Collections.Generic;
using ConsoleShopAdvanced.Models;

namespace ConsoleShopAdvanced.Repositories
{
    public static class AdminRepo
    {
        private static List<Admin> _admins = new List<Admin>();

        public static IEnumerable<Admin> Admins => _admins;

        static AdminRepo()
        {
            _admins.Add(new Admin { Login = "admin", Password = "pass" });
        }
    }
}