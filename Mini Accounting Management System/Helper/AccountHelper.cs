using Microsoft.Data.SqlClient;
using Mini_Accounting_Management_System.db.Tables;
using Mini_Accounting_Management_System.DTO;
using System.Data;


namespace Mini_Accounting_Management_System.Helper
{
    public class AccountHelper
    {
        public static List<AccountTypeDTO> GetAccountType(string connectionString)
        {
            var result = new List<AccountTypeDTO>();
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand("dbo.sp_GetAccountTypes", connection))
            {
                command.CommandType =CommandType.StoredProcedure;
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var accountType = new AccountTypeDTO
                        {
                            A_ID = reader.GetInt32(reader.GetOrdinal("A_ID")),
                            Acc_Type = reader.GetString(reader.GetOrdinal("Acc_type")),
                            TotalBalance = reader.GetDecimal(reader.GetOrdinal("TotalBalance"))
                        };
                        result.Add(accountType);
                    }
                }
            }
            return result;
        }
        public static List<SubAccountDTO> GetSubAccountsByType(string connectionString, int typeFilter)
        {
            var result = new List<SubAccountDTO>();

            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand("dbo.sp_GetSubAccountsByType", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TypeFilter", typeFilter);

                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add( new SubAccountDTO
                        {
                            P_ID = reader.GetInt32(reader.GetOrdinal("S_ID")),
                            Sub_Acc = reader.GetString(reader.GetOrdinal("Sub_Acc")),
                            Balance = reader.GetDecimal(reader.GetOrdinal("Balance"))
                        });
                        
                    }
                }
            }

            return result;
        }

        public static int InsertWholeAccount(string connection, string Type_acc)
        {
            int account = 0;
            using(var conn=new SqlConnection(connection))
            using (var cmd = new SqlCommand("dbo.sp_ManageAccounts", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Action", SqlDbType.NVarChar, 20).Value = "InsertType";

                cmd.Parameters.Add("@Acc_Type", SqlDbType.NVarChar, -1).Value = Type_acc;
                conn.Open();
                object result = cmd.ExecuteScalar();
                conn.Close();

                if (result!=null && result!=DBNull.Value)
                {
                    account = Convert.ToInt32(result);
                }


            }
            return account;
        }
        public static int InsertSubAccount(string connection, int Type_id, string Sub_acc_Name,decimal Balance)
        {
            int flag = 0;
            using (var conn = new SqlConnection(connection))
            using (var cmd = new SqlCommand("dbo.sp_ManageAccounts", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Action", SqlDbType.NVarChar, 20).Value = "InsertSub";

                cmd.Parameters.Add("@TypeP_ID", SqlDbType.Int).Value = Type_id;
                cmd.Parameters.Add("@Sub_Acc", SqlDbType.NVarChar, -1).Value = Sub_acc_Name;
                cmd.Parameters.Add("@Balance", SqlDbType.Decimal).Value = Balance;
                conn.Open();
                object result = cmd.ExecuteScalar();
                conn.Close();

                if (result != null && result != DBNull.Value)
                {
                    flag = Convert.ToInt32(result);
                }


            }
            return flag;
        }
    }
}
