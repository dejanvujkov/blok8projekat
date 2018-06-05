using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentApp.Models.Entities
{
    public class AppUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Approved { get; set; }
        public string ImagePath { get; set; }
        public string Email { get; set; }
        public UserType UserType { get; set; }

        public AppUser()
        {
            UserType = UserType.Client;
            Approved = false;
        }

        public AppUser(string username, string password, string name, string surname, string email) : this()
        {
            Username = username;
            Password = password;
            Name = name;
            Surname = surname;
            Email = email;
        }

        public AppUser(string username, string password, string name, string surname, string email, string imagePath) : this()
        {
            Username = username;
            Password = password;
            Name = name;
            Surname = surname;
            Email = email;
            ImagePath = imagePath;
        }

    }

    public enum UserType
    {
        Client = 1,
        Manager,
        Administrator
    }
}