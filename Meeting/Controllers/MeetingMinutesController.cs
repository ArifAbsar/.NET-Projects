using Meeting.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;

namespace Meeting.Controllers
{
    public class MeetingMinutesController : Controller
    {
        private readonly string _connectionString;

        public MeetingMinutesController()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public ActionResult Create()
        {
            var viewModel = new MeetingMinutesViewModel
            {
                Master = new MeetingMinutesMaster(),
                Details = new List<MeetingMinutesDetail>()
            };

            viewModel.CorporateCustomers = GetCorporateCustomers();
            viewModel.IndividualCustomers = GetIndividualCustomers();
            viewModel.ProductServices = GetProductServices();

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(MeetingMinutesViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            var masterId = SaveMeetingMinutesMaster(connection, transaction, viewModel.Master);

                            foreach (var detail in viewModel.Details)
                            {
                                SaveMeetingMinutesDetail(connection, transaction, masterId, detail);
                            }

                            transaction.Commit();
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }

                return RedirectToAction("Index");
            }

            viewModel.CorporateCustomers = GetCorporateCustomers();
            viewModel.IndividualCustomers = GetIndividualCustomers();
            viewModel.ProductServices = GetProductServices();

            return View(viewModel);
        }

        private List<CorporateCustomer> GetCorporateCustomers()
        {
            var customers = new List<CorporateCustomer>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT Id, Name FROM Corporate_Customer_Tbl", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            customers.Add(new CorporateCustomer
                            {
                                Id = (int)reader["Id"],
                                Name = (string)reader["Name"]
                            });
                        }
                    }
                }
            }

            return customers;
        }

        private List<IndividualCustomer> GetIndividualCustomers()
        {
            var customers = new List<IndividualCustomer>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT Id, Name FROM Individual_Customer_Tbl", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            customers.Add(new IndividualCustomer
                            {
                                Id = (int)reader["Id"],
                                Name = (string)reader["Name"]
                            });
                        }
                    }
                }
            }

            return customers;
        }

        private List<ProductService> GetProductServices()
        {
            var services = new List<ProductService>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT Id, ProductServiceName, Unit FROM Products_Service_Tbl", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            services.Add(new ProductService
                            {
                                Id = (int)reader["Id"],
                                ProductServiceName = (string)reader["ProductServiceName"],
                                Unit = (string)reader["Unit"]
                            });
                        }
                    }
                }
            }

            return services;
        }

        private int SaveMeetingMinutesMaster(SqlConnection connection, SqlTransaction transaction, MeetingMinutesMaster master)
        {
            using (var command = new SqlCommand("Meeting_Minutes_Master_Save_SP", connection, transaction))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@CustomerId", master.CustomerId);
                command.Parameters.AddWithValue("@CustomerType", master.CustomerType);
                command.Parameters.AddWithValue("@Date", master.Date);
                command.Parameters.AddWithValue("@MeetingPlace", master.MeetingPlace);
                command.Parameters.AddWithValue("@AttendsFromClientSide", master.AttendsFromClientSide);
                command.Parameters.AddWithValue("@AttendsFromHostSide", master.AttendsFromHostSide);
                command.Parameters.AddWithValue("@MeetingAgenda", master.MeetingAgenda);
                command.Parameters.AddWithValue("@MeetingDiscussion", master.MeetingDiscussion);
                command.Parameters.AddWithValue("@MeetingDecision", master.MeetingDecision);

                var outputId = new SqlParameter("@Id", SqlDbType.Int) { Direction = ParameterDirection.Output };
                command.Parameters.Add(outputId);

                command.ExecuteNonQuery();

                return (int)outputId.Value;
            }
        }

        private void SaveMeetingMinutesDetail(SqlConnection connection, SqlTransaction transaction, int masterId, MeetingMinutesDetail detail)
        {
            using (var command = new SqlCommand("Meeting_Minutes_Details_Save_SP", connection, transaction))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@MeetingMinutesMasterId", masterId);
                command.Parameters.AddWithValue("@ProductServiceId", detail.ProductServiceId);
                command.Parameters.AddWithValue("@Quantity", detail.Quantity);
                command.Parameters.AddWithValue("@Unit", detail.Unit);

                command.ExecuteNonQuery();
            }
        }
    }
}