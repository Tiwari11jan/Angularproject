using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HardwareManagementSystem.Modal;

namespace HardwareManagementSystem.Controllers
{
    [Produces("application/json")]
    [Route("api/Users")]
    public class UsersController : Controller
    {
        DataAccessLayer objUsersDataAccessLayer = new DataAccessLayer();

        // GET: api/Users
        [HttpGet]
        public IEnumerable<users> GetUsers()
        {
            return objUsersDataAccessLayer.GetAllUsers();
        }

        // GET: api/Hardwares
        [HttpGet("GetUsersName")]
        public IEnumerable<users> GetUsersName()
        {
            return objUsersDataAccessLayer.GetAllUsersName();
        }

        
        // GET: api/Users
        [HttpGet("GetUsersTypes")]
        public IEnumerable<userTypeDetails> GetUsersTypes()
        {
            return objUsersDataAccessLayer.GetUsersTypes();
        }

        // GET: api/Users
        [HttpGet("GetFloorNo")]
        public IEnumerable<floor> GetFloorNo()
        {
            return objUsersDataAccessLayer.GetFloorNo();
        }


        // GET: api/Users/5
        [HttpGet("{id}", Name = "GetUsers")]
        public users GetUsers(int id)
        {
            return objUsersDataAccessLayer.GetUsersDetails(id);
        }



        // POST: api/Users
        [HttpPost]
        public void Post([FromBody]users objUsers)
        {
            objUsersDataAccessLayer.AddUser(objUsers);
        }

        // PUT: api/Users/5
        [HttpPut]
        public void Put([FromBody]users objUsers)
        {
            objUsersDataAccessLayer.UpdateUser(objUsers);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            objUsersDataAccessLayer.DeleteUser(id);
        }
    }
}
