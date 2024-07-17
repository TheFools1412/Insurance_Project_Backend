using Insurance_Project.Models;

namespace Insurance_Project.Service;

public interface ContractService
{
    public dynamic findAll();

    public bool Create(Contract contract);

    public bool Update(Contract contract);

    public bool Delete(int id);
    public dynamic find(int id);

    public dynamic FindID(int id);
}
