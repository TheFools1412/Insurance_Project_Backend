using Insurance_Project.Models;
using Insurance_Project.Service;

namespace Insurance_Project.Service;

public class PaymentServiceImpl : PaymentService
{
    private DatabaseContext db;
    private IConfiguration configuration;

    public PaymentServiceImpl(DatabaseContext _db, IConfiguration _configuration)
    {
        db = _db;
        configuration = _configuration;
    }

  
    public dynamic FindID(int id)
    {

        return db.Payments.Where(p => p.IdContract == id).Select(p => new
        {

            idContract = p.IdContract,
            idCustomer = p.IdCustomer,
            nameCustomer = p.NameCustomer,
            datePayment = p.DatePayment,
            typePayment = p.TypePayment,
            amountPayment = p.AmountPayment,
            description = p.Description,
            statusPayment = p.StatusPayment,
            

        }).ToList();

    }


    public dynamic findAll()
    {
        return db.Payments.Select(p => new
        {
            idContract = p.IdContract,
            idCustomer = p.IdCustomer,
            nameCustomer = p.NameCustomer,
            datePayment = p.DatePayment,
            typePayment = p.TypePayment,
            amountPayment = p.AmountPayment,
            description = p.Description,
            statusPayment = p.StatusPayment,

        }).ToList();
    }

   
}
