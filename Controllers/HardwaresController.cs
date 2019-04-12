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
    [Route("api/Hardwares")]
    public class HardwaresController : Controller
    {
        DataAccessLayer objHardwareDataAccessLayer = new DataAccessLayer();

        // GET: api/Hardwares
        [HttpGet]
        public IEnumerable<Hardware> GetHardware()
        {
            return objHardwareDataAccessLayer.GetAllHardware();
        }

        // GET: api/Hardwares
        [HttpGet("GetHardwareTypes")]
        public IEnumerable<HardwareType> GetHardwareTypes()
        {
            return objHardwareDataAccessLayer.GetHardwareTypes();
        }


        // GET: api/Hardwares/5
        [HttpGet("{id}", Name = "GetHardware")]
        public Hardware GetHardware(int id)
        {
            return objHardwareDataAccessLayer.GetHardwareDetails(id);
        }

        // POST: api/Hardwares
        [HttpPost]
        public void Post([FromBody]Hardware objHardware)
        {
            objHardwareDataAccessLayer.AddHardware(objHardware);
        }

        // PUT: api/Hardwares/5
        [HttpPut]
        public void Put([FromBody]Hardware objHardware)
        {
            objHardwareDataAccessLayer.UpdateHardware(objHardware);
        }

        // DELETE: api/Hardwares/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            objHardwareDataAccessLayer.DeleteHardware(id);
        }
    }
}
