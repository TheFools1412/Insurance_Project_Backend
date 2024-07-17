using Insurance_Project.Models;
using Insurance_Project.Service;
using Microsoft.EntityFrameworkCore;

namespace Insurance_Project.Service;

public class CustomerServiceImpl : CustomerService
{
    private DatabaseContext db;
    private IConfiguration configuration;

    public CustomerServiceImpl(DatabaseContext _db, IConfiguration _configuration)
    {
        db = _db;
        configuration = _configuration;
    }

    public bool Create(Customer customer)
    {

        try
        {
            db.Customers.Add(customer);
            return db.SaveChanges() > 0;


        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public bool login(string email, string password)
    {
        var customer = db.Customers.Where(p => p.Email == email && p.Password == password).SingleOrDefault(p => p.Email == email);

        if (customer != null)
        {
            return true;
        }
        else
            return false;


    }


    public bool Delete(int id)
    {
        try
        {
            db.Customers.Remove(db.Customers.Find(id));
            return db.SaveChanges() > 0;
        }
        catch
        {
            return false;
        }
    }


    public dynamic findAll()
    {
        return db.Customers.Select(p => new
        {
            idCustomer = p.IdCustomer,
            nameCustomer = p.NameCustomer,
            birthday = p.Birthday,
            adress = p.Adress,
            phone = p.Phone,
            email = p.Email,
            username = p.Username,
            password = p.Password,
            identification = p.Identification,
            created = p.Created,/*
            profilePhoto = p.ProfilePhoto,*/
            profilePhoto = configuration["BaseUrl"] + "images/" + p.ProfilePhoto,
        }).ToList();
    }

    public bool Update(Customer customer)
    {
        try
        {
            db.Entry(customer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return db.SaveChanges() > 0;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public dynamic Find(string email)
    {
        return db.Customers.Where(p => p.Email == email).Select(p => new
        {
            idCustomer = p.IdCustomer,
            nameCustomer = p.NameCustomer,
            birthday = p.Birthday,
            adress = p.Adress,
            phone = p.Phone,
            email = p.Email,
            username = p.Username,
            password = p.Password,
            identification = p.Identification,
            created = p.Created,
            profilePhoto = configuration["BaseUrl"] + "images/" + p.ProfilePhoto,

        }).FirstOrDefault();
    }

    public dynamic FindID(int id)
    {

        return db.Customers.Where(p => p.IdCustomer == id).Select(p => new
        {
            idCustomer = p.IdCustomer,
            nameCustomer = p.NameCustomer,
            birthday = p.Birthday,
            adress = p.Adress,
            phone = p.Phone,
            email = p.Email,
            username = p.Username,
            password = p.Password,
            identification = p.Identification,
            created = p.Created,
            profilePhoto = configuration["BaseUrl"] + "images/" + p.ProfilePhoto,
        }).FirstOrDefault();

    }

    public bool Exists(string email)
    {
        return db.Customers.Count(p => p.Email == email) > 0;
    }

    public Customer findByEmailNoTracking(string email)
    {
        return db.Customers.AsNoTracking().SingleOrDefault(a => a.Email == email);
    }
}
