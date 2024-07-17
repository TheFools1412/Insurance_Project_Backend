using Insurance_Project.Models;
using Insurance_Project.Service;

namespace Insurance_Project.Service;

public class InsuranceServiceImpl : InsuraceService
{
    private DatabaseContext db;
    private IConfiguration configuration;

    public InsuranceServiceImpl(DatabaseContext _db, IConfiguration _configuration)
    {
        db = _db;
        configuration = _configuration;
    }

    public bool Create(Insurance insurance)
    {
        try
        {
            db.Insurances.Add(insurance);
            return db.SaveChanges() > 0;

        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public bool Delete(int id)
    {
        throw new NotImplementedException();
    }

    public dynamic find(int id)
    {
        return db.Insurances.Where(p => p.IdCustomer == id).Select(
            p => new
            {
                idCustomer = p.IdCustomer,
                idInsurance = p.IdInsurance,
                name = p.Name,
                optiondate = p.Optiondate,
                dateStart = p.DateStart,
                dateEnd = p.DateEnd,
                price = p.Price,
                typeInsurance = p.TypeInsurance,
                note = p.Note,
            }).ToList();
    }

    public dynamic findAll()
    {
        return db.Insurances.Select(p => new
        {
            idInsurance = p.IdInsurance,
            name = p.Name,
            optiondate = p.Optiondate,
            dateStart = p.DateStart,
            dateEnd = p.DateEnd,
            price = p.Price,
            idCustomer = p.IdCustomer,
            typeInsurance = p.TypeInsurance,
            note = p.Note,

        }).ToList();
    }

    public bool Update(Insurance insurance)
    {
        try
        {
            db.Entry(insurance).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return db.SaveChanges() > 0;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}
