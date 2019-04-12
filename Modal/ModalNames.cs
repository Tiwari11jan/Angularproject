using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HardwareManagementSystem.Modal
{
    public class ModalNames
    {

    }

    public class HardwareAllocated
    {
        public int id { get; set; }        
        public int hardwareTypeId { get; set; }
        public string hardwareType { get; set; }
        public int userId { get; set; }
        public string name { get; set; }
        public DateTime allocationDate { get; set; }

    }
    public class Hardware
    {
        public int id { get; set; }
        public string make { get; set; }
        public string modelNo { get; set; }
        public string serialNo { get; set; }
        public DateTime purchaseDate { get; set; }
        public int Quantity { get; set; }
        public string vendorName { get; set; }
        public int hardwareTypeId { get; set; }
        public string hardwareType { get; set; }
    }


    public class HardwareType
    {
        public int hardwareTypeId { get; set; }
        public string hardwareType { get; set; }

    }


    public class users
    {
        public int userId { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string seatNo { get; set; }
        public int floorId { get; set; }
        public string floorNo { get; set; }
        public int userTypeId { get; set; }
        public string userType { get; set; }
    }

    public class floor
    {
        public int id { get; set; }
        public string floorNo { get; set; }
    }

    public class userTypeDetails
    {
        public int userTypeId { get; set; }
        public string userType { get; set; }
    }
}
