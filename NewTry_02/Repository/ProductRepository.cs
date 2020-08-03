using Microsoft.AspNetCore.SignalR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using NewTry_02.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewTry_02.Repository
{
    public class ProductRepository : IProductRepository
    {
        string connectionString = "";
        private readonly IHubContext<SignalServer> context;
        public ProductRepository(IConfiguration configuration, IHubContext<SignalServer> context)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
            this.context = context;
        }

        //public ProductRepository()
        //{
        //    connectionString = "Server=DESKTOP-H517618\\SQLEXPRESS;Database=ProductList;Trusted_Connection=True;MultipleActiveResultSets=True";
            
        //}
        public List<Product> GetAllProducts()
        {
            var products = new List<Product>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                //SqlDependency class is used to register events related to changes taking place in the database to event handlers.
                SqlDependency.Start(connectionString);

                string commandText = "select * from product";

                SqlCommand cmd = new SqlCommand(commandText, conn);
                SqlDependency dependency = new SqlDependency(cmd);
                dependency.OnChange += new OnChangeEventHandler(dpChangeNotification);

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Product product = new Product
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        ProductName = reader["ProductName"].ToString(),
                        Quantity = Convert.ToInt32(reader["Quantity"]),
                        UnitPrice = Convert.ToInt32(reader["UnitPrice"])
                    };
                    products.Add(product);
                }
            }
            return products;
        }

        private void dpChangeNotification(object sender, SqlNotificationEventArgs e)
        {
            //the following method will notify all clients
            context.Clients.All.SendAsync("refreshProducts");
        }
    }
}
