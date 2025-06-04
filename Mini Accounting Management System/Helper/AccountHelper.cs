using Microsoft.Data.SqlClient;
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
                            Acc_Type = reader.GetString(reader.GetOrdinal("Acc_type")),
                            TotalBalance = reader.GetDecimal(reader.GetOrdinal("TotalBalance"))
                        };
                        result.Add(accountType);
                    }
                }
            }
            return result;
        }
        public static List<SubAccountDTO> GetSubAccountsByType(string connectionString, string typeFilter)
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
                            P_ID = reader.GetInt32(reader.GetOrdinal("P_ID")),
                            Sub_Acc = reader.GetString(reader.GetOrdinal("Sub_Acc")),
                            Balance = reader.GetDecimal(reader.GetOrdinal("Balance"))
                        });
                        
                    }
                }
            }

            return result;
        }
    }
}
