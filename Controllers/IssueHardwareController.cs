using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HardwareManagementSystem.Modal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HardwareManagementSystem.Controllers
{
    [Produces("application/json")]
    [Route("api/IssueHardware")]
    public class IssueHardwareController : Controller
    {
        IssueHardwareDataAccessLayer objIssueHardwareDataAccessLayer = new IssueHardwareDataAccessLayer();

        // GET: api/IssueHardware
        [HttpGet]
        public IEnumerable<HardwareAllocated> GetIssueHardware()
        {
            return objIssueHardwareDataAccessLayer.GetAllIssueHardware();
        }

        // GET: api/IssueHardware/5
        [HttpGet("{id}", Name = "Get")]
        public List<HardwareAllocated> Get(int id)
        {
            return objIssueHardwareDataAccessLayer.GetUserAssignHardwareByUserId(id);
        }
        
        // POST: api/IssueHardware
        [HttpPost]               
        public void Post([FromBody] HardwareAllocated hardwareAllocated)
        {
          objIssueHardwareDataAccessLayer.AddIssueHardwarer(hardwareAllocated);

        }



        [HttpGet("GetAvailableHardwareTypes")]
        public IEnumerable<HardwareType> GetHardwareTypes()
        {
            return objIssueHardwareDataAccessLayer.GetAvailableHardwareType();
        }


        // PUT: api/IssueHardware/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {

        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            objIssueHardwareDataAccessLayer.DeleteIssueHardwarer(id);
        }


        ////[HttpGet("GetUserAssignHardware")]
        //[HttpGet("{Id}", Name = "GetUserAssignHardware")]      
        //public IEnumerable<HardwareAllocated> GetUserAssignHardware(int Id)
        //{
        //    return objIssueHardwareDataAccessLayer.GetUserAssignHardwareByUserId(Id);
        //}




    }
}
