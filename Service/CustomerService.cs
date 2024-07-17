using Insurance_Project.Models;

namespace Insurance_Project.Service;

public interface CustomerService
{
    public dynamic findAll();

    public bool Create(Customer customer);

    public bool Update(Customer customer);

    public bool Delete(int id);
    public bool login(string email, string password);
    public dynamic Find(string email);
    public dynamic FindID(int id);
    public bool Exists(string email);

    public Customer findByEmailNoTracking(string email);
}
