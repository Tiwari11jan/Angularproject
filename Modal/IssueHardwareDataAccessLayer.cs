using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace HardwareManagementSystem.Modal
{
    public class IssueHardwareDataAccessLayer
    {
        string connectionString = "Data Source = .; Initial Catalog = dbHardwareMangementSystem; integrated security=true;";

      
       // To View all Items details
        public IEnumerable<HardwareAllocated> GetAllIssueHardware()
        { 
            try
            {
                List<HardwareAllocated> hardwareAllocatedItems = new List<HardwareAllocated>();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("select b.id,c.name, a.hardwareType,b.allocationDate from tblHardwareType a inner join tblHardwareAllocated b on a.hardwareTypeId = b.hardwareTypeId inner join tblUsers c on b.userId = c.userId", con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        HardwareAllocated hardwareAllocated = new HardwareAllocated();
                        hardwareAllocated.id = Convert.ToInt32(rdr["id"]);
                        hardwareAllocated.name = rdr["name"].ToString();
                        hardwareAllocated.hardwareType = rdr["hardwareType"].ToString();                       
                        hardwareAllocated.allocationDate = Convert.ToDateTime(rdr["allocationDate"]);
                        hardwareAllocatedItems.Add(hardwareAllocated);
                    }
                    con.Close();
                }
                return hardwareAllocatedItems;
            }
            catch
            {
                throw;
            }
        }

       

        //Get All Available Hardware Data  
        public IEnumerable<HardwareType> GetAvailableHardwareType()
        {
            try
            {
                List<HardwareType> hardwareTypeList = new List<HardwareType>();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("select HT.hardwareTypeId,HT.hardwareType from tblHardwareType HT,tblHardwareDetails Hd where HT.hardwareTypeId=Hd.hardwareTypeId and (Hd.Quantity > 0) order by hardwareType", con);
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
        public int AddIssueHardwarer(HardwareAllocated hardwareAllocated)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    //string Query = string.Format("insert into tblHardwareAllocated (hardwareTypeId,userId,allocationDate) values ({0},{1},'{2}')", hardwareAllocated.hardwareTypeId,hardwareAllocated.userId,DateTime.Now);
                    SqlCommand cmd = new SqlCommand("PS_AllottingHardware", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@userId",hardwareAllocated.userId);
                    cmd.Parameters.AddWithValue("@hardwareTypeId",hardwareAllocated.hardwareTypeId);                   
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch(Exception ex)
            {
                throw;
            }
            return 1;
        }

        #region
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
        #endregion

        //To Delete the record on a particular Item
        public int DeleteIssueHardwarer(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("delete from tblHardwareAllocated where id=" + id, con);
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


        //............................Get All assign Hardware to a single User..............................
        public List<HardwareAllocated> GetUserAssignHardwareByUserId(int UserId)
        {
            List<HardwareAllocated> hardwareAllocatedItems = new List<HardwareAllocated>();
            try
            {
                
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("select b.id,c.name, a.hardwareType,b.allocationDate from tblHardwareType a inner join tblHardwareAllocated b on a.hardwareTypeId = b.hardwareTypeId inner join tblUsers c on b.userId = c.userId where b.userId=" + UserId, con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        HardwareAllocated hardwareAllocated = new HardwareAllocated();
                        hardwareAllocated.id = Convert.ToInt32(rdr["id"]);
                        hardwareAllocated.name = rdr["name"].ToString();
                        hardwareAllocated.hardwareType = rdr["hardwareType"].ToString();
                        hardwareAllocated.allocationDate = Convert.ToDateTime(rdr["allocationDate"]);
                        hardwareAllocatedItems.Add(hardwareAllocated);
                    }
                    con.Close();
                }
              
            }
            catch
            {
                throw;
            }
            return hardwareAllocatedItems;
        }

      





    }
}
