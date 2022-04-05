using Microsoft.Data.SqlClient;

using System.Data;

namespace DL;

public class DBRepository : IRepository
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
        {
            Product product= new Product();
            product.id = reader.GetInt32 (0);
            product.name = reader.GetString(1);
            product.cost = reader.GetDouble(2);
            products.Add(product);
        }
        reader.Close();
        connection.Close();

        return products;
    }

    public Store GetStoreInventory(Store currentStore)
    {
        DataSet inventorySet = new DataSet();
        List<Product> storeInventory = new List<Product>();

        SqlConnection connection = new SqlConnection(_connectionString);
        SqlCommand cmd = new SqlCommand("SELECT StoreID, ProductID, Quantity FROM Inventory JOIN Product ON (ProductId) JOIN Store ON (StoreID) WHERE StoreID = @id; ",
        connection); cmd.Parameters.AddWithValue("@id", currentStore.ID);

        SqlDataAdapter inventoryAdapter = new SqlDataAdapter(cmd);
        inventoryAdapter.Fill(inventorySet, "StoreInventoryTable");
        DataTable? storeInventoryTable = inventorySet.Tables["StoreInventoryTable"];
        if (storeInventoryTable != null && storeInventoryTable.Rows.Count > 0)
        {
            foreach (DataRow row in storeInventoryTable.Rows)
            {
                Product product = new Product();

                product.id = (int)row["ProductID"];
                product.name = (string)row["ProductName"];
                product.cost = (double)row["Price"];

                storeInventory.Add(product);
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
        cmd.Parameters.AddWithValue("@username", newCustomer.user);
        cmd.Parameters.AddWithValue("@password", newCustomer.pass);

        newCustomer.Id = (int)cmd.ExecuteScalar();
        connection.Close();
        return newCustomer;
    }

    public int SigninCheck(Customer signin)
    {
        bool found = false;
        bool correct = false;

        using SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();

        using SqlCommand cmd = new SqlCommand("SELECT * FROM Customers WHERE Username = @username", connection);

        cmd.Parameters.AddWithValue("@username", signin.user);

        SqlDataReader read = cmd.ExecuteReader();
        if (read.HasRows)
            found = true;
        read.Close();

        using SqlCommand cmd2 = new SqlCommand("SELECT * FROM Customers WHERE username = @username AND password = @password", connection);

        cmd2.Parameters.AddWithValue("@username", signin.user);
        cmd2.Parameters.AddWithValue("@password", signin.pass);

        SqlDataReader read2 = cmd2.ExecuteReader();
        if (read2.HasRows)
            correct = true;
        read2.Close();
        //Username and password right
        if (correct)
            return 3;
        //Username right but password wrong
        if (found)
            return 2;
        //Wrong Username
        return 1;
    }

    public Customer GetCustomer(Customer customer)
    {
        using SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();

        using SqlCommand cmd = new SqlCommand("SELECT * FROM Customers WHERE username = @username", connection);

        cmd.Parameters.AddWithValue("@username", customer.user);

        cmd.ExecuteScalar();
        connection.Close();

        return customer;
    }
}