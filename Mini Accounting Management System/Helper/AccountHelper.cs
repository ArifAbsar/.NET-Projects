using ClosedXML.Excel;
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
                command.CommandType = CommandType.StoredProcedure;
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
                        result.Add(new SubAccountDTO
                        {
                            S_ID = reader.GetInt32(reader.GetOrdinal("S_ID")),
                            Sub_Acc = reader.GetString(reader.GetOrdinal("Sub_Acc")),
                            Balance = reader.GetDecimal(reader.GetOrdinal("Balance"))
                        });

                    }
                }
            }


            return result;
        }
        public static List<SubAccountDTO> GetSubAccounts(string connectionString)
        {
            var result = new List<SubAccountDTO>();

            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand("dbo.sp_GetAllSub", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new SubAccountDTO
                        {
                            S_ID = reader.GetInt32(reader.GetOrdinal("S_ID")),
                            Sub_Acc = reader.GetString(reader.GetOrdinal("Sub_Acc")),
                        });

                    }
                }
            }


            return result;
        }

        public static int InsertWholeAccount(string connection, string Type_acc)
        {
            int account = 0;
            using (var conn = new SqlConnection(connection))
            using (var cmd = new SqlCommand("dbo.sp_ManageAccounts", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Action", SqlDbType.NVarChar, 20).Value = "InsertType";

                cmd.Parameters.Add("@Acc_Type", SqlDbType.NVarChar, -1).Value = Type_acc;
                conn.Open();
                object result = cmd.ExecuteScalar();
                conn.Close();

                if (result != null && result != DBNull.Value)
                {
                    account = Convert.ToInt32(result);
                }


            }
            return account;
        }
        public static int InsertSubAccount(string connection, int Type_id, string Sub_acc_Name, decimal Balance)
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
        public static int DeleteSubAccount(string connection, int sub_id)
        {
            int flag = 0;
            using (var conn = new SqlConnection(connection))
            using (var cmd = new SqlCommand("dbo.sp_ManageAccounts", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Action", SqlDbType.NVarChar, 20).Value = "DeleteSub";
                cmd.Parameters.Add("@P_ID", SqlDbType.Int).Value = sub_id;
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
        public static List<Journal_VDTO> GetJournalVouchers(string connectionString)
        {
            var list = new List<Journal_VDTO>();
            using var conn = new SqlConnection(connectionString);
            using var cmd = new SqlCommand("sp_GetJournalVoucher", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            conn.Open();
            using var rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                list.Add(new Journal_VDTO
                {
                    J_ID = rdr.GetInt32(rdr.GetOrdinal("J_ID")),
                    ReferenceNo = rdr.GetString(rdr.GetOrdinal("ReferenceNo")),
                    SubAccountID = rdr.GetInt32(rdr.GetOrdinal("SubAccountID")),
                    VoucherDate = rdr.GetDateTime(rdr.GetOrdinal("VoucherDate")),
                    Debit = rdr.GetDecimal(rdr.GetOrdinal("Debit")),
                    Credit = rdr.GetDecimal(rdr.GetOrdinal("Credit")),
                });
            }
            return list;
        }
        public static List<Payment_VDTO> LoadPaymentVouchers(string connectionString)
        {
            var list = new List<Payment_VDTO>();
            using var conn = new SqlConnection(connectionString);
            using var cmd = new SqlCommand("sp_GetPaymentVouchers", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            conn.Open();
            using var rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                list.Add(new Payment_VDTO
                {
                    Pay_ID = rdr.GetInt32(rdr.GetOrdinal("Pay_ID")),
                    ReferenceNo = rdr.GetString(rdr.GetOrdinal("ReferenceNo")),
                    SubAccountID = rdr.GetInt32(rdr.GetOrdinal("SubAccountID")),
                    VoucherDate = rdr.GetDateTime(rdr.GetOrdinal("VoucherDate")),
                    Debit = rdr.GetDecimal(rdr.GetOrdinal("Debit")),
                    Credit = rdr.GetDecimal(rdr.GetOrdinal("Credit")),
                });
            }
            return list;
        }
        public static List<Reciept_VDTO> LoadReceiptVouchers(string connectionString)
        {
            var list = new List<Reciept_VDTO>();
            using var conn = new SqlConnection(connectionString);
            using var cmd = new SqlCommand("sp_GetReceiptVouchers", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            conn.Open();
            using var rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                list.Add(new Reciept_VDTO
                {
                    R_ID = rdr.GetInt32(rdr.GetOrdinal("R_ID")),
                    ReferenceNo = rdr.GetString(rdr.GetOrdinal("ReferenceNo")),
                    SubAccountID = rdr.GetInt32(rdr.GetOrdinal("SubAccountID")),
                    VoucherDate = rdr.GetDateTime(rdr.GetOrdinal("VoucherDate")),
                    Debit = rdr.GetDecimal(rdr.GetOrdinal("Debit")),
                    Credit = rdr.GetDecimal(rdr.GetOrdinal("Credit")),
                });
            }
            return list;
        }
        private static void InsertVoucher(
       char voucherType,
       string connectionString,
       string referenceNo,
       DateTime voucherDate,
       IEnumerable<(int SubAccountID, decimal Debit, decimal Credit)> lines
   )
        {
            using var conn = new SqlConnection(connectionString);
            conn.Open();
            using var tx = conn.BeginTransaction();
            try
            {
                foreach (var line in lines)
                {
                    using var cmd = new SqlCommand("dbo.sp_ManageVoucher", conn, tx)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@Action", "Insert");
                    cmd.Parameters.AddWithValue("@VoucherType", voucherType.ToString());
                    cmd.Parameters.AddWithValue("@VoucherID", DBNull.Value);
                    cmd.Parameters.AddWithValue("@ReferenceNo", referenceNo);
                    cmd.Parameters.AddWithValue("@SubAccountID", line.SubAccountID);
                    cmd.Parameters.AddWithValue("@VoucherDate", voucherDate);
                    cmd.Parameters.AddWithValue("@Debit", line.Debit);
                    cmd.Parameters.AddWithValue("@Credit", line.Credit);
                    cmd.ExecuteNonQuery();
                }
                tx.Commit();
            }
            catch
            {
                tx.Rollback();
                throw;
            }
        }
        public static void InsertJournalVoucher(
        string connectionString,
        string referenceNo,
        DateTime voucherDate,
        IEnumerable<(int SubAccountID, decimal Debit, decimal Credit)> lines
    )
        {
            InsertVoucher('J', connectionString, referenceNo, voucherDate, lines);
        }

        public static void InsertPaymentVoucher(
            string connectionString,
            string referenceNo,
            DateTime voucherDate,
            IEnumerable<(int SubAccountID, decimal Debit, decimal Credit)> lines
        )
        {
            InsertVoucher('P', connectionString, referenceNo, voucherDate, lines);
        }

        public static void InsertReceiptVoucher(
            string connectionString,
            string referenceNo,
            DateTime voucherDate,
            IEnumerable<(int SubAccountID, decimal Debit, decimal Credit)> lines
        )
        {
            InsertVoucher('R', connectionString, referenceNo, voucherDate, lines);
        }
        public static void DeleteJournalVoucher(string connString, int journalId)
        {
            using var conn = new SqlConnection(connString);
            conn.Open();
            using var tx = conn.BeginTransaction();
            using var cmd = new SqlCommand("dbo.sp_ManageVoucher", conn, tx)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@Action", "Delete");
            cmd.Parameters.AddWithValue("@VoucherType", "J");       // Journal
            cmd.Parameters.AddWithValue("@VoucherID", journalId);
            cmd.Parameters.AddWithValue("@ReferenceNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@SubAccountID", DBNull.Value);
            cmd.Parameters.AddWithValue("@VoucherDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@Debit", 0);
            cmd.Parameters.AddWithValue("@Credit", 0);
            cmd.ExecuteNonQuery();
            tx.Commit();
        }
        public static void DeletePaymentVoucher(string connString, int paymentId)
        {
            using var conn = new SqlConnection(connString);
            conn.Open();
            using var tx = conn.BeginTransaction();
            using var cmd = new SqlCommand("dbo.sp_ManageVoucher", conn, tx)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@Action", "Delete");
            cmd.Parameters.AddWithValue("@VoucherType", "P");       // Payment
            cmd.Parameters.AddWithValue("@VoucherID", paymentId);
            cmd.Parameters.AddWithValue("@ReferenceNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@SubAccountID", DBNull.Value);
            cmd.Parameters.AddWithValue("@VoucherDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@Debit", 0);
            cmd.Parameters.AddWithValue("@Credit", 0);
            cmd.ExecuteNonQuery();
            tx.Commit();
        }
        public static void DeleteReceiptVoucher(string connectionString, int receiptId)
        {
            using var conn = new SqlConnection(connectionString);
            conn.Open();
            using var tx = conn.BeginTransaction();
            using var cmd = new SqlCommand("dbo.sp_ManageVoucher", conn, tx)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@Action", "Delete");
            cmd.Parameters.AddWithValue("@VoucherType", "R");
            cmd.Parameters.AddWithValue("@VoucherID", receiptId);
            //can be null
            cmd.Parameters.AddWithValue("@ReferenceNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@SubAccountID", DBNull.Value);
            cmd.Parameters.AddWithValue("@VoucherDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@Debit", 0);
            cmd.Parameters.AddWithValue("@Credit", 0);

            cmd.ExecuteNonQuery();
            tx.Commit();
        }
        public static List<UserRoleDTO> GetAllUsersWithRoles(string connectionString)
        {
            var list = new List<UserRoleDTO>();

            using var conn = new SqlConnection(connectionString);
            using var cmd = new SqlCommand("dbo.sp_GetUsersWithRoles", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            conn.Open();
            using var rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                list.Add(new UserRoleDTO
                {
                    UserId = rdr.GetString(rdr.GetOrdinal("UserId")),
                    UserName = rdr.GetString(rdr.GetOrdinal("UserName")),
                    Email = rdr.GetString(rdr.GetOrdinal("Email")),
                    RoleName = rdr.GetString(rdr.GetOrdinal("RoleName"))
                });
            }

            return list;
        }
        public static List<RoleDTO> GetAllRoles(string connectionString)
        {
            var roles = new List<RoleDTO>();
            using var conn = new SqlConnection(connectionString);
            using var cmd = new SqlCommand("dbo.sp_GetAllRoles", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            conn.Open();
            using var rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                roles.Add(new RoleDTO
                {
                    RoleId = rdr.GetString(rdr.GetOrdinal("RoleId")),
                    RoleName = rdr.GetString(rdr.GetOrdinal("RoleName"))
                });
            }
            return roles;
        }
        public static void AssignUserRoleByName(
                   string connectionString,
                   string adminUserName,
                   string targetUserName,
                   string roleName
   )
        {
            using var conn = new SqlConnection(connectionString);
            using var cmd = new SqlCommand("dbo.sp_AssignUserRole", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@AdminUserName", adminUserName);
            cmd.Parameters.AddWithValue("@TargetUserName", targetUserName);
            cmd.Parameters.AddWithValue("@RoleName", roleName);

            conn.Open();
            cmd.ExecuteNonQuery();
        }
      
       
    public static (List<Journal_VDTO> Journals,
                           List<Payment_VDTO> Payments,
                           List<Reciept_VDTO> Receipts)
                GetAllVouchers(string connectionString)
       {
                var journals = new List<Journal_VDTO>();
                var payments = new List<Payment_VDTO>();
                var receipts = new List<Reciept_VDTO>();

                using var conn = new SqlConnection(connectionString);
                using var cmd = new SqlCommand("dbo.sp_GetAllVouchers", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                conn.Open();
                using var reader = cmd.ExecuteReader();

                
                while (reader.Read())
                {
                    journals.Add(new Journal_VDTO
                    {
                        
                        ReferenceNo = reader.GetString(reader.GetOrdinal("ReferenceNo")),
                        SubAccountID = reader.GetInt32(reader.GetOrdinal("SubAccountID")),
                        VoucherDate = reader.GetDateTime(reader.GetOrdinal("VoucherDate")),
                        Debit = reader.GetDecimal(reader.GetOrdinal("Debit")),
                        Credit = reader.GetDecimal(reader.GetOrdinal("Credit"))
                    });
                }

               
                if (reader.NextResult())
                {
                    while (reader.Read())
                    {
                        payments.Add(new Payment_VDTO
                        {
                            
                            ReferenceNo = reader.GetString(reader.GetOrdinal("ReferenceNo")),
                            SubAccountID = reader.GetInt32(reader.GetOrdinal("SubAccountID")),
                            VoucherDate = reader.GetDateTime(reader.GetOrdinal("VoucherDate")),
                            Debit = reader.GetDecimal(reader.GetOrdinal("Debit")),
                            Credit = reader.GetDecimal(reader.GetOrdinal("Credit"))
                        });
                    }
                }

                
                if (reader.NextResult())
                {
                    while (reader.Read())
                    {
                        receipts.Add(new Reciept_VDTO
                        {
                            
                            ReferenceNo = reader.GetString(reader.GetOrdinal("ReferenceNo")),
                            SubAccountID = reader.GetInt32(reader.GetOrdinal("SubAccountID")),
                            VoucherDate = reader.GetDateTime(reader.GetOrdinal("VoucherDate")),
                            Debit = reader.GetDecimal(reader.GetOrdinal("Debit")),
                            Credit = reader.GetDecimal(reader.GetOrdinal("Credit"))
                        });
                    }
                }

                return (journals, payments, receipts);
         }
        
        public static (byte[] Content, string FileName) ExportAllVouchers(
            List<Journal_VDTO> journalVouchers,
            List<Payment_VDTO> paymentVouchers,
            List<Reciept_VDTO> receiptVouchers
        )
        {
            using var workbook = new XLWorkbook();

            //Journals
            var ws1 = workbook.AddWorksheet("Journals");
            ws1.Cell(1, 1).Value = "ReferenceNo";
            ws1.Cell(1, 2).Value = "SubAccountID";
            ws1.Cell(1, 3).Value = "VoucherDate";
            ws1.Cell(1, 4).Value = "Debit";
            ws1.Cell(1, 5).Value = "Credit";

            int row = 2;
            foreach (var v in journalVouchers)
            {
                ws1.Cell(row, 1).Value = v.ReferenceNo;
                ws1.Cell(row, 2).Value = v.SubAccountID;
                ws1.Cell(row, 3).Value = v.VoucherDate;
                ws1.Cell(row, 4).Value = v.Debit;
                ws1.Cell(row, 5).Value = v.Credit;
                row++;
            }
            ws1.Columns().AdjustToContents();

            //Payments
            var ws2 = workbook.AddWorksheet("Payments");
            ws1.Cell(7, 1).Value = "ReferenceNo";
            ws1.Cell(7, 2).Value = "SubAccountID";
            ws1.Cell(7, 3).Value = "VoucherDate";
            ws1.Cell(7, 4).Value = "Debit";
            ws1.Cell(7, 5).Value = "Credit";

            row =8 ;
            foreach (var v in paymentVouchers)
            {
                ws1.Cell(row, 1).Value = v.ReferenceNo;
                ws1.Cell(row, 2).Value = v.SubAccountID;
                ws1.Cell(row, 3).Value = v.VoucherDate;
                ws1.Cell(row, 4).Value = v.Debit;
                ws1.Cell(row, 5).Value = v.Credit;
                row++;
            }
            ws2.Columns().AdjustToContents();

            //Receipts
            var ws3 = workbook.AddWorksheet("Receipts");
            ws1.Cell(14, 1).Value = "ReferenceNo";
            ws1.Cell(14, 2).Value = "SubAccountID";
            ws1.Cell(14, 3).Value = "VoucherDate";
            ws1.Cell(14, 4).Value = "Debit";
            ws1.Cell(14, 5).Value = "Credit";

            row = 15;
            foreach (var v in receiptVouchers)
            {
                ws1.Cell(row, 1).Value = v.ReferenceNo;
                ws1.Cell(row, 2).Value = v.SubAccountID;
                ws1.Cell(row, 3).Value = v.VoucherDate;
                ws1.Cell(row, 4).Value = v.Debit;
                ws1.Cell(row, 5).Value = v.Credit;
                row++;
            }
            ws3.Columns().AdjustToContents();

            using var ms = new MemoryStream();
            workbook.SaveAs(ms);
            var content = ms.ToArray();
            var fileName = $"Vouchers_{DateTime.Today}.xlsx";
            return (content, fileName);
        }
    }
}

