using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using HardwareManagementSystem.Modal;

namespace HardwareManagementSystem.Modal
{
    public class DataAccessLayer
    {
        string connectionString = "Data Source = .; Initial Catalog = dbHardwareMangementSystem; integrated security=true;";

       
        #region
        //To View all Items details
        //public IEnumerable<Vendor> GetAllVendors()
        //{                 
        //    try
        //    {
        //        List<Vendor> vendorItems = new List<Vendor>();
        //        using (SqlConnection con = new SqlConnection(connectionString))
        //        {
        //            SqlCommand cmd = new SqlCommand("select * from tblVendorDetails", con);
        //            con.Open();
        //            SqlDataReader rdr = cmd.ExecuteReader();
        //            while (rdr.Read())
        //            {
        //                Vendor vendor = new Vendor();
        //                vendor.id = Convert.ToInt32(rdr["id"]);
        //                vendor.vendorName = rdr["vendorName"].ToString();
        //                vendorItems.Add(vendor);
        //            }
        //            con.Close();
        //        }
        //        return vendorItems;
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}
        //To Add new Item record 
        //public int AddVendor(Vendor vendor)
        //{
        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(connectionString))
        //        {
        //            string Query = string.Format("insert into tblVendorDetails (vendorName) values ('{0}')", vendor.vendorName);
        //            SqlCommand cmd = new SqlCommand(Query, con);
        //            con.Open();
        //            cmd.ExecuteNonQuery();
        //            con.Close();
        //        }
        //        return 1;
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}
        //To Update the records of a particluar Item
        //public int UpdateVendor(Vendor vendor)
        //{
        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(connectionString))
        //        {
        //            string Query = string.Format("update tblVendorDetails set vendorName='{0}' where id={1}", vendor.vendorName, vendor.id);
        //            SqlCommand cmd = new SqlCommand(Query, con);
        //            con.Open();
        //            cmd.ExecuteNonQuery();
        //            con.Close();
        //        }
        //        return 1;
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}
        //Get the details of a particular Item
        //public Vendor GetVendorDetails(int id)
        //{
        //    try
        //    {
        //        Vendor vendor = new Vendor();
        //        using (SqlConnection con = new SqlConnection(connectionString))
        //        {
        //            string sqlQuery = "SELECT * FROM tblVendorDetails WHERE id= " + id;
        //            SqlCommand cmd = new SqlCommand(sqlQuery, con);
        //            con.Open();
        //            SqlDataReader rdr = cmd.ExecuteReader();
        //            while (rdr.Read())
        //            {
        //                vendor.id = Convert.ToInt32(rdr["id"]);
        //                vendor.vendorName = rdr["vendorName"].ToString();
        //            }
        //        }
        //        return vendor;
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}
        //To Delete the record on a particular Item
        //public int DeleteVendor(int id)
        //{
        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(connectionString))
        //        {
        //            SqlCommand cmd = new SqlCommand("delete from tblVendorDetails where id=" + id, con);
        //            con.Open();
        //            cmd.ExecuteNonQuery();
        //            con.Close();
        //        }
        //        return 1;
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}
        #endregion
        public IEnumerable<Hardware> GetAllHardware()
        {
            try
            {
                List<Hardware> hardwareItems = new List<Hardware>();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string Query = @"select a.id,a.make,a.modelNo,a.serialNo,a.purchaseDate,a.vendorName,a.Quantity,
                                     a.hardwareTypeId, c.hardwareType from tblHardwareDetails a inner join tblHardwareType c on a.hardwareTypeId = c.hardwareTypeId";

                    SqlCommand cmd = new SqlCommand(Query, con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Hardware hardware = new Hardware();
                        hardware.id = Convert.ToInt32(rdr["id"]);
                        hardware.make = rdr["make"].ToString();
                        hardware.modelNo = rdr["modelNo"].ToString();
                        hardware.serialNo = rdr["serialNo"].ToString();
                        hardware.purchaseDate = Convert.ToDateTime(rdr["purchaseDate"]);
                        hardware.Quantity = Convert.ToInt32(rdr["Quantity"]);
                        hardware.vendorName = rdr["vendorName"].ToString();
                        hardware.hardwareTypeId = Convert.ToInt32(rdr["hardwareTypeId"]);
                        hardware.hardwareType = rdr["hardwareType"].ToString();
                        hardwareItems.Add(hardware);
                    }
                    con.Close();
                }
                return hardwareItems;
            }
            catch
            {
                throw;
            }
        }

        //Get All HardwareType  Record
        public IEnumerable<HardwareType> GetHardwareTypes()
        {
            try
            {
                List<HardwareType> hardwareTypeList = new List<HardwareType>();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("select * from tblHardwareType order by hardwareType", con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        HardwareType htype = new HardwareType();
                        htype.hardwareTypeId = Convert.ToInt32(rdr["hardwareTypeId"]);
                        htype.hardwareType = rdr["hardwareType"].ToString();
                        hardwareTypeList.Add(htype);
                    }
                    con.Close();
                }
                return hardwareTypeList;
            }
            catch
            {
                throw;
            }
        }

        //To Add new Item record 
        public int AddHardware(Hardware hardware)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string Query = string.Format("insert into tblHardwareDetails (make, modelNo, serialNo, purchaseDate, vendorName, hardwareTypeId,Quantity) values ('{0}','{1}','{2}','{3}','{4}',{5} ,{6})", hardware.make, hardware.modelNo, hardware.serialNo, hardware.purchaseDate, hardware.vendorName, hardware.hardwareTypeId,hardware.Quantity);
                    SqlCommand cmd = new SqlCommand(Query, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return 1;
            }
            catch
            {
                throw;
            }
        }


        //To Update the records of a particluar Item
        public int UpdateHardware(Hardware hardware)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string Query = string.Format("update tblHardwareDetails set make='{0}', modelNo='{1}', serialNo='{2}', purchaseDate='{3}', vendorName='{4}', hardwareTypeId={5}, Quantity{6} where id={7}", hardware.make, hardware.modelNo, hardware.serialNo, hardware.purchaseDate, hardware.vendorName, hardware.hardwareTypeId,hardware.Quantity, hardware.id);
                    SqlCommand cmd = new SqlCommand(Query, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return 1;
            }
            catch
            {
                throw;
            }
        }
       
        
        //Get the details of a particular Item
        public Hardware GetHardwareDetails(int id)
        {
            try
            {
                Hardware hardware = new Hardware();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string sqlQuery = "SELECT * FROM tblHardwareDetails WHERE id= " + id;
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        hardware.id = Convert.ToInt32(rdr["id"]);
                        hardware.make = rdr["make"].ToString();
                        hardware.modelNo = rdr["modelNo"].ToString();
                        hardware.serialNo = rdr["serialNo"].ToString();
                        hardware.purchaseDate = Convert.ToDateTime(rdr["purchaseDate"]);
                        hardware.vendorName = rdr["vendorName"].ToString();
                        hardware.Quantity = Convert.ToInt32(rdr["Quantity"]);
                        hardware.hardwareTypeId = Convert.ToInt32(rdr["hardwareTypeId"]);
                    }
                }
                return hardware;
            }
            catch
            {
                throw;
            }
        }
        //To Delete the record on a particular Item
        public int DeleteHardware(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("delete from tblHardwareDetails where id=" + id, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return 1;
            }
            catch
            {
                throw;
            }
        }


        //................................................Get the details of All Users......................................................
        public IEnumerable<users> GetAllUsers()
        {
            try
            {
                List<users> usersItems = new List<users>();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string Query = @"select tblUsers.userId,tblUsers.name,tblUsers.email, tblUsers.seatNo, tblUsers.floorId, tblFloors.floorNo,
                                     tblUsers.userTypeId,tblUserType.userType from tblUsers 
                                     inner join tblUserType on tblUsers.userTypeId = tblusertype.userTypeId 
                                     inner join tblFloors on tblUsers.floorId = tblFloors.id";
                    SqlCommand cmd = new SqlCommand(Query, con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        users users = new users();
                        users.userId = Convert.ToInt32(rdr["userId"]);
                        users.name = rdr["name"].ToString();
                        users.email = rdr["email"].ToString();
                        users.seatNo = rdr["seatNo"].ToString();
                        users.floorId = Convert.ToInt32(rdr["floorId"]);
                        users.floorNo = rdr["floorNo"].ToString();
                        users.userTypeId = Convert.ToInt32(rdr["userTypeId"]);
                        users.userType = rdr["userType"].ToString();
                        usersItems.Add(users);
                    }
                    con.Close();
                }
                return usersItems;
            }
            catch
            {
                throw;
            }
        }

        //................................................Get the details of All Users Name......................................................
        public IEnumerable<users> GetAllUsersName()
        {
            try
            {
                List<users> usersItems = new List<users>();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string Query = @"SELECT userId,name FROM  tblUsers order by name";
                    SqlCommand cmd = new SqlCommand(Query, con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        users users = new users();
                        users.userId = Convert.ToInt32(rdr["userId"]);
                        users.name = rdr["name"].ToString();                                                                                
                        //users.userType = rdr["userType"].ToString();
                        usersItems.Add(users);
                    }
                    con.Close();
                }
                return usersItems;
            }
            catch
            {
                throw;
            }
        }


        public int AddUser(users users)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    string Query = string.Format("insert into tblUsers (name,email,seatNo,floorId,userTypeId) values ('{0}','{1}','{2}',{3},{4})", users.name, users.email, users.seatNo, users.floorId, users.userTypeId);
                    SqlCommand cmd = new SqlCommand(Query, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return 1;
            }
            catch
            {
                throw;
            }
        }



        //.................................To Update the records of a particluar Item..................................................................
        public int UpdateUser(users users)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string Query = string.Format("update tblUsers set name='{0}', email='{1}', seatNo='{2}', floorId={3}, userTypeId={4} where userId={5}", users.name, users.email, users.seatNo, users.floorId, users.userTypeId, users.userId);
                    SqlCommand cmd = new SqlCommand(Query, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return 1;
            }
            catch
            {
                throw;
            }
        }


        //Get the details of a particular Item
        public users GetUsersDetails(int id)
        {
            try
            {
                users users = new users();
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    string sqlQuery = @"select tblUsers.userId,tblUsers.name,tblUsers.email, tblUsers.seatNo, tblUsers.floorId, tblFloors.floorNo, 
                                     tblUsers.userTypeId,tblUserType.userType from tblUsers
                                     inner join tblUserType on tblUsers.userTypeId = tblusertype.userTypeId
                                     inner join tblFloors on tblUsers.floorId = tblFloors.id
                                     where tblUsers.userId =" + id;
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        users.userId = Convert.ToInt32(rdr["userId"]);
                        users.name = rdr["name"].ToString();
                        users.email = rdr["email"].ToString();
                        users.seatNo = rdr["seatNo"].ToString();
                        users.floorId = Convert.ToInt32(rdr["floorId"]);
                        users.floorNo = rdr["floorNo"].ToString();
                        users.userTypeId = Convert.ToInt32(rdr["userTypeId"]);
                        users.userType = rdr["userType"].ToString();
                    }
                }
                return users;
            }
            catch
            {
                throw;
            }
        }


        //To Delete the record on a particular Item
        public int DeleteUser(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("delete from tblUsers where userId=" + id, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return 1;
            }
            catch
            {
                throw;
            }
        }


        public IEnumerable<userTypeDetails> GetUsersTypes()
        {
            try
            {
                List<userTypeDetails> userTypeList = new List<userTypeDetails>();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("select * from tblUserType", con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        userTypeDetails usertype = new userTypeDetails();
                        usertype.userTypeId = Convert.ToInt32(rdr["userTypeId"]);
                        usertype.userType = rdr["userType"].ToString();
                        userTypeList.Add(usertype);
                    }
                    con.Close();
                }
                return userTypeList;
            }
            catch
            {
                throw;
            }

        }

        public IEnumerable<floor> GetFloorNo()
        {
            try
            {
                List<floor> floorList = new List<floor>();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("select * from tblFloors", con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        floor floorNo = new floor();
                        floorNo.id = Convert.ToInt32(rdr["id"]);
                        floorNo.floorNo = rdr["floorNo"].ToString();
                        floorList.Add(floorNo);
                    }
                    con.Close();
                }
                return floorList;
            }
            catch
            {
                throw;
            }

        }












      





    }

}
