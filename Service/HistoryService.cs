using Insurance_Project.Models;

namespace Insurance_Project.Service;

public interface HistoryService
{
    public dynamic findAll();

    public dynamic FindID(int id);
}
