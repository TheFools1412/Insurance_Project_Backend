using Insurance_Project.Models;

namespace Insurance_Project.Service;

public interface InsuraceService
{
    public dynamic findAll();

    public bool Create(Insurance insurance);

    public bool Update(Insurance insurance);

    public bool Delete(int id);
    public dynamic find(int id);
}
