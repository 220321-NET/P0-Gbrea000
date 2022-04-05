using Models;
namespace BL;

public interface IPSBL
{
    Customer CreateCustomer(Customer newCustomer);
    int SigninCheck(Customer Signin);
    Customer GetCustomer(Customer customer);
}