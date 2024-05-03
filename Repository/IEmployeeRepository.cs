using MVC.Models;

namespace MVC.Repository;

public interface IEmployeeRepository
{
    List<Employee> GetData();
    bool AddData(Employee req);
    Employee FindById(int id);
    bool EditData(int id, Employee req);
}