using Insurance_Project.Models;
using Insurance_Project.Service;

namespace Insurance_Project.Service;

public class ContractServiceImpl : ContractService
{
    private DatabaseContext db;
    private IConfiguration configuration;

    public ContractServiceImpl(DatabaseContext _db, IConfiguration _configuration)
    {
        db = _db;
        configuration = _configuration;
    }

    public bool Create(Contract contract)
    {
        try
        {
            db.Contracts.Add(contract);
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

        return db.Contracts.Where(p => p.IdCustomer == id).Select(
            p => new
            {
                idCustomer = p.IdCustomer,
                id = p.Id,
                contractNumber = p.ContractNumber,
                dateStart = p.DateStart,
                dateEnd = p.DateEnd,
                idTypeInsurance = p.IdTypeInsurance,
                amountInsurance = p.AmountInsurance,
                premium = p.Premium,
                note = p.Note,
            }).ToList();
    }
    public dynamic FindID(int id)
    {

        return db.Contracts.Where(p => p.Id == id).Select(p => new
        {
            
            id = p.Id,
            idCustomer = p.IdCustomer,
            contractNumber = p.ContractNumber,
            dateStart = p.DateStart,
            dateEnd = p.DateEnd,
            idTypeInsurance = p.IdTypeInsurance,
            amountInsurance = p.AmountInsurance,
            premium = p.Premium,
            note = p.Note,

        }).ToList();

    }


    public dynamic findAll()
    {
        return db.Contracts.Select(p => new
        {
            id = p.Id,
            contractNumber = p.ContractNumber,
            dateStart = p.DateStart,
            dateEnd = p.DateEnd,
            idCustomer = p.IdCustomer,
            idTypeInsurance = p.IdTypeInsurance,
            amountInsurance = p.AmountInsurance,
            premium = p.Premium,
            note = p.Note,
        }).ToList();
    }

    public bool Update(Contract contract)
    {
        try
        {
            db.Entry(contract).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return db.SaveChanges() > 0;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}
