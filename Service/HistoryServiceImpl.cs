using Insurance_Project.Models;
using Insurance_Project.Service;
using Microsoft.EntityFrameworkCore;

namespace Insurance_Project.Service;

public class HistoryServiceImpl : HistoryService
{
    private DatabaseContext db;
    private IConfiguration configuration;

    public HistoryServiceImpl(DatabaseContext _db, IConfiguration _configuration)
    {
        db = _db;
        configuration = _configuration;
    }



    public dynamic findAll()
    {
        return db.Histories.Select(p => new
        {
            id = p.Id,
            month = p.Month,
            year = p.Year,
            datepayment = p.DatePayment,
            amount = p.Amount,
            methodpayment = p.MethodPayment,
            idcontract = p.IdContract,
            note = p.Note,
        }).ToList();
    }

    public dynamic FindID(int id)
    {

        return db.Histories.Where(p => p.Id == id).Select(p => new
        {
			id = p.Id,
			month = p.Month,
			year = p.Year,
			datepayment = p.DatePayment,
			amount = p.Amount,
			methodpayment = p.MethodPayment,
			idcontract = p.IdContract,
			note = p.Note,
		}).FirstOrDefault();

    }

}
