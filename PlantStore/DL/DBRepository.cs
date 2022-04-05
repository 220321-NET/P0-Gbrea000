using Microsoft.Data.SqlClient;

using System.Data;

//using Models;

namespace DL;

public class DBRepository 
//public class DBRepository : IRepository 
{
    private readonly string _connectionString;

    public DBRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    //retrieve products
    public List<Product> GetAllProducts()
    {
        List<Product> products = new List<Product>();

        SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();

        SqlCommand cmd = new SqlCommand("SELECT * FROM Product");
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {}
        reader.Close();
        connection.Close();

        return products;
        {
            public Store GetStoreInventory(Store currentStore)
            {
                List<Product> storeInventory = new List<Product>();

                SqlConnection connection = new SqlConnection(_connectionString);
                SqlCommand cmd = new SqlCommand("SELECT StoreID, ProductID, Quantity FROM Inventory JOIN Product ON (ProductId) JOIN Store ON (StoreID) WHERE StoreID = @id; ", 
                connection); cmd.Parameters.AddWithValue(@id", currentStoreID);
                
                SqlDataAdapter inventoryAdapter = new SqlDataAdapter(cmd);

                inventoryAdapter.Fill(inventorySet, "StoreInventoryTable");
                DataTable? storeInventoryTable = inventorySet.Tables["StoreInventoryTable"];
                if(storeInventoryTable) != null && storeInventoryTable.Rows.Count > 0)
                {
                    foreach (DataRow row in storeInventoryTable.Rows)
                    {
                        Product product = new product();

                        product.id = (int)row["ProductID"];
                        product.name = (string)row["ProductName"];
                        product.cost = (double)row["Price"];

                        GetStoreInventory.Add(product);
                    }
                }
                currentStore.Inventory = storeInventory;
                return currentStore;
            }
            
            public Customer CreateCustomer(Customer newCustomer)
            {
                using SqlConnection connection = new SqlConnection(_connectionString);
                connection.Open();

                using SqlCommand cmd = new SqlCommand("INSERT INTO Customers(Username, Password) OUTPUT INNSERTED.Id Values (@username, @password)", connection);
                cmd.Parameters.AddWithValue("@username", new.username);
                cmd.Parameters.AddWithValue("@password", new.password);

                cmd.ExecuteScalar();
                connection.Close();
                return newCustomer;
            }

            public int SigninCheck (Customer signin)
            {
                bool found = false;
                bool correct = false;

                using SqlConnection connection = new SqlConnection(_connectionString);
                connection.Open();

                using SqlCommand cmd = new SqlCommand("SELECT * FROM Customers WHERE Username = @username", connection);

                cmd.Parameters.AddWithValue("@username", signin.Username);

                SqlDataReader read = cmd.ExecuteReader();
                if(read.HasRows)
                    found = true;
                read.Close();

                using SqlCommand cmd2 = new SqlCommand("SELECT * FROM Customers WHERE username = @username AND password = @password", connection);

                cmd2.Parameters.AddWithValue("@username", signin.User);
                cmd2.Parameters.AddWithValue("@password", signin.Pass);

                SqlDataReader read2 = cmd2.ExecuteReader();
                if(read2.HasRows)
                    correct = true;
                read2.Close();
            //Username and password right
                if(correct)
                    return 2;
            //Username right but Password wrong
                if(found)
                    return 1;
            //Wrong Username
                return 0;
            }

            public Customer GetCustomer(Customer customer)
            {
                using SqlConnection connection = new SqlConnection(_connectionString);
                connection.Open();

                using SqlCommand cmd = new SqlCommand("SELECT * FROM Customers Where username = @username", connection);

                cmd.Parameters.AddWithValue("@username", Username);

                cmd.ExecuteScalar();
                connection.Close();

                return customer;
            }
            // public List<Customer> GetAllCustomer()
            // {
            //     List<Customer> customers = new List<Customer>();

            //     SqlConnection connection = new SqlConnection(_connectionString);
            //     connection.Open();

            //     SqlCommand cmd = new SqlCommand("SELECT * FROM Customers", connection);
            //     SqlDataReader reader = cmd.ExecuteReader();

            //     while (reader.Read())
            //     {
            //         int id = reader.GetInt32(0);
            //         string userName = reader.GetString(1);
            //         string password = reader.GetString(2);

            //     }
            // } 
            // return Customer;
        }
        public List<Store> GetAllStores()
        {
            List<Store> store = new List<Store>();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand ("SELECT * FROM Store", connection);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int store.id = reader.GetInt32(0);
                string city = reader.GetString(1);
                int inventory.id = reader.GetInt32(2);

                store store = new store
                {
                    Store.ID = storeID
                    city = city
                    Inventory.ID = inventoryID
                };
                stores.Add(store);
            }
            reader.Close();
            connection.Close();
            return stores;
        }
        public customer CreateCustomer(Customer customerToAdd)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO Customers (Username, Password) Values (@username, @password)", connection);

            customerToAdd.Id= (int)cmd.ExecuteScalar();

            connection.Close();
            return userToAdd;
        }
    }
}