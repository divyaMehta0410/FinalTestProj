using DataAccessLayer.Repository;
using SharedProject.Models;
using System;

namespace BusinessLayer.Services
{
    public class UserServices
    {
        private readonly UserRepository userRepository;
        public UserServices()
        {
            userRepository = new UserRepository();
        }
        public bool AddUser(Users user)
        {
           var result = userRepository.CreateUser(user);
            return result > 0;
        }
        public bool isAdmin(Guid id)
        {
            return userRepository.isAdmin(id);
        }
        public Users GetUser(Guid userid)
        {
           return  userRepository.GetUser(userid);
        }

        public bool ValidateUser(string username, string userPassword)
        {
           return  userRepository.ValidateUser(username, userPassword);
        }



    }
}