using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;

namespace BLL.Services
{
    public class Meetings_Minutes_Details_Services
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["MeetContext"].ConnectionString;

        public void SaveMeetingMinutesDetails(int productServiceId, int quantity, string unit)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("Meeting_Minutes_Details_Save_SP", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Add parameters to the command
                    cmd.Parameters.Add(new SqlParameter("@ProductServiceId", SqlDbType.Int)).Value = productServiceId;
                    cmd.Parameters.Add(new SqlParameter("@Quantity", SqlDbType.Int)).Value = quantity;
                    cmd.Parameters.Add(new SqlParameter("@Unit", SqlDbType.NVarChar, 50)).Value = unit;

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public int SaveMeetingMinutesMaster(Meeting_Minutes_MasterDTO meetingData)
        {
            int masterId;
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MeetContext"].ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("Meeting_Minutes_Master_Save_SP", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CustomerType", meetingData.CustomerType);
                    cmd.Parameters.AddWithValue("@CustomerId", meetingData.Id);
                    cmd.Parameters.AddWithValue("@MeetDate", meetingData.MeetingDate);
                    cmd.Parameters.AddWithValue("@MeetTime", meetingData.MeetingTime);
                    cmd.Parameters.AddWithValue("@MeetingPlace", meetingData.MeetingPlace);
                    cmd.Parameters.AddWithValue("@AttendsFromClientSide", meetingData.AttendsFromClientSide);
                    cmd.Parameters.AddWithValue("@AttendsFromHostSide", meetingData.AttendsFromHostSide);

                    SqlParameter masterIdParam = new SqlParameter("@MasterId", SqlDbType.Int) { Direction = ParameterDirection.Output };
                    cmd.Parameters.Add(masterIdParam);

                    cmd.ExecuteNonQuery();
                    masterId = (int)masterIdParam.Value;
                }
            }
            return masterId;
        }

    }
}
