using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Models;
using Repositories;

namespace GamesForCashAPI.Controllers
{
    [RoutePrefix("api/Test")]
    public class EmptyController : ApiController
    {
        protected IUserRepository UserRepository;
        public EmptyController()
        {UserRepository=new UserRepository();
            
        }
        public EmptyController(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }
        [Route("Test")]
        public object GetTest()
        {
            string dbConn = ConfigurationManager.ConnectionStrings["juliusConnection"].ToString();
            //string connectionString = @"Data Source=88.222.22.232,3306; Database=tautvydasDb; User ID=tautvydas; Password=tautvydas";
            //SqlConnection cnn ;
            var cnn = new SqlConnection(dbConn);
            try
            {
                cnn.Open();

                cnn.Close();
            }
            catch (Exception ex)
            {

            }
            return 20;
        }

        [Route("Register")]
        public int PostRegisterUser(User user)
        {
            var id = UserRepository.Insert(user);
            return id;
        }
        [Route("Update")]
        public int PostUpdateUserInfo(User user)
        {
            var id = UserRepository.Update(user);
            return id;
        }
        [Route("Login/Name/{name}")]
        public object GetLogin([FromBody]string name, string password)
        {
            var id = UserRepository.Login(name, password);
            return id;
        }
        [Route("AllUsers")]
        public ICollection<User> GetAllUsers()
        {
            var id = UserRepository.List();
            return id;
        }
    }
}
