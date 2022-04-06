using Microsoft.Data.SqlClient;

using System.Data;

// using Models;

namespace DL;

public class DBRepository : IRepository
{
    private readonly string _connectionString;

    public DBRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    //retrieve products
    // public List<Product> GetAllProducts()
    // {
    //     List<Product> products = new List<Product>();

    //     SqlConnection connection = new SqlConnection(_connectionString);
    //     connection.Open();

    //     SqlCommand cmd = new SqlCommand("SELECT * FROM Product");
    //     SqlDataReader reader = cmd.ExecuteReader();

    //     while (reader.Read())
    //     {
    //         Product product= new Product();
    //         product.id = reader.GetInt32 (0);
    //         product.name = reader.GetString(1);
    //         product.cost = reader.GetDouble(2);
    //         products.Add(product);
    //     }
    //     reader.Close();
    //     connection.Close();

    //     return products;
    // }

    // public Store GetStoreInventory(Store currentStore)
    // {
    //     DataSet inventorySet = new DataSet();
    //     List<Product> storeInventory = new List<Product>();

    //     SqlConnection connection = new SqlConnection(_connectionString);
    //     SqlCommand cmd = new SqlCommand("SELECT StoreID, ProductID, Quantity FROM Inventory JOIN Product ON (ProductId) JOIN Store ON (StoreID) WHERE StoreID = @id; ",
    //     connection); cmd.Parameters.AddWithValue("@id", currentStore);

    //     SqlDataAdapter inventoryAdapter = new SqlDataAdapter(cmd);
    //     inventoryAdapter.Fill(inventorySet, "StoreInventoryTable");
    //     DataTable? storeInventoryTable = inventorySet.Tables["StoreInventoryTable"];
    //     if (storeInventoryTable != null && storeInventoryTable.Rows.Count > 0)
    //     {
    //         foreach (DataRow row in storeInventoryTable.Rows)
    //         {
    //             Product product = new Product();

    //             product.id = (int)row["ProductID"];
    //             product.productName = (string)row["ProductName"];
    //             product.cost = (double)row["Price"];

    //             storeInventory.Add(product);
    //         }
    //     }
    //     currentStore.StoreInventory = storeInventory;
    //     return currentStore;
    // }
    public List<Product> GetInventory(Store getInv)
    {

        List<Product> inv = new List<Product>();

        using SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();

        using SqlCommand cmd = new SqlCommand("SELECT * FROM Inventory WHERE storeID = @storeId", connection);
        cmd.Parameters.AddWithValue("@storeId", getInv.ID);

        SqlDataReader read = cmd.ExecuteReader();

        while (read.Read())
        {
            Product tempPro = GetProduct(read.GetInt32(2));
            inv.Add(tempPro);
        }

        read.Close();
        connection.Close();

        List<Product> SortedList = inv.OrderBy(o => o.id).ToList();

        return SortedList;
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
        Customer returnCustomer = new Customer();
        using SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();

        using SqlCommand cmd = new SqlCommand("SELECT * FROM Customers WHERE username = @username", connection);

        cmd.Parameters.AddWithValue("@username", customer.user);

        cmd.ExecuteScalar();
        connection.Close();

        return customer;
        //         SqlDataReader read = cmd.ExecuteReader();

        // if(read.Read())
        // {
        //     int tempID = read.GetInt32(0);
        //     string name = read.GetString(1);
        //     string pass = read.GetString(2);

        //     returnCust.Id = tempID;
        //     returnCust.Name = name;
        //     returnCust.Pass= pass;

        // }

        // read.Close();
        // connection.Close();

        // return returnCust;
    }
    public Product CreateProduct(Product newPlant)
    {
        using SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();

        using SqlCommand cmd = new SqlCommand("Insert INTO Products (productName, price) OUTPUT INSERTED.Id Values (@productName, @price)", connection);
        cmd.Parameters.AddWithValue("@productName", newPlant.productName);
        cmd.Parameters.AddWithValue("@price", newPlant.Price);
        cmd.ExecuteScalar();
        connection.Close();
        return newPlant;
    }
    public Product GetProduct(int id)
    {
        Product temp = new Product();
        using SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();
        using SqlCommand cmd = new SqlCommand("SELECT * FROM Products WHERE id =@productId", connection);
        cmd.Parameters.AddWithValue("@productId", id);
        SqlDataReader read = cmd.ExecuteReader();
        if (read.Read())
        {
            int tempID = read.GetInt32(0);
            string name = read.GetString(1);
            double price = read.GetDouble(2);
            id = tempID;
            temp.productName = name;
            temp.Price = price;
        }
        return temp;
    }

    // public List<Store> GetStores()
    // {
    //     throw new NotImplementedException();
    // }

    public Order UpdateOrders(Order updateOrder)
    {
        throw new NotImplementedException();
    }
    // public List<Product> GetInventory(Store getInv)
    // {
    //     List<Product> inv = new List<Product>();

    //     using SqlConnection = new SqlConnection(_connectionString);
    //     connection.Open();

    //     using SqlCommand cmd = new SqlCommand("SELECT * FROM Inventory WHERE storeID = @storeId", connection);
    //     cmd.Parameters.AddWithValue("@storeId", getInv.ID);
    //     SqlDataReader read = cmd.ExecuteReader();

    //     while (read.Read())
    //     {
    //         Product tempPro = GetProduct(read.GetInt32(2));
    //         inv.Add(tempPro);
    //     }
    //     read.Close();
    //     ConnectionState.Close();

    //     List<Product> sortedList = inv.OrderBy(o => o.id).ToList();

    //     return sortedList;

// public Order UpdateOrders(Order updateOrder)
// {
//     using SqlConnection connection = new SqlConnection(_connectionString);
//     connection.Open();

//     using SqlCommand cmd = new SqlCommand("INSERT INTO Orders(dateCreated, total, storeID, customerID) OUTPUT INSERTED.Id VALUES (@date, @total, @storeID, @customerID)", connection);

//     // cmd.Parameters.AddWithValue("@date", updateOrder.DateCreated);
//     cmd.Parameters.AddWithValue("@total", updateOrder.Total());
//     cmd.Parameters.AddWithValue("@storeID", updateOrder.StoreID);
//     cmd.Parameters.AddWithValue("@customerID", updateOrder.CustID);

//     try
//     {
//         updateOrder.Id = (int)cmd.ExecuteScalar();
//     }
//     catch (Exception e)
//     {
//         Console.WriteLine(e.Message);
//     }

//     connection.Close();

//     return updateOrder;

    public List<Store> GetStores()
    {
        List<Store> allStores = new List<Store>();
        using SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();
        using SqlCommand cmd = new SqlCommand("SELECT * FROM Stores", connection);
        SqlDataReader read = cmd.ExecuteReader();
        while (read.Read())
        {
            int id = read.GetInt32(0);
            string city = read.GetString(1);
            Store tempStore = new Store
            {
                ID = id,
                StoreLocation = city
            };
            allStores.Add(tempStore);
        }
        read.Close();
        connection.Close();
        return allStores;
    }
}


//     public List<Store> GetStores()
// {
//     throw new NotImplementedException();
// }
