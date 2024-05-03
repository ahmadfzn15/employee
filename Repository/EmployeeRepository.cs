using Microsoft.EntityFrameworkCore;
using MVC.Models;

namespace MVC.Repository;

public class EmployeeRepository(ApplicationDbContext db) : IEmployeeRepository
{
    private readonly ApplicationDbContext _db = db;

    public List<Employee> GetData()
    {
        var res = _db.Employee.ToList();
        return res;
    }

    public Employee FindById(int id)
    {
        var res = _db.Employee.Find(id);
        return res!;
    }

    public bool AddData(Employee req)
    {
        var data = new Employee
        {
            Id = 1,
            Nip = req.Nip,
            Name = req.Name,
            Role = req.Role,
        };

        _db.Employee.Add(data);
        _db.SaveChanges();
        return true;
    }

    public bool EditData(int id, Employee req)
    {
        var existingEmployee = _db.Employee.FirstOrDefault(e => e.Id == id);
        if (existingEmployee != null)
        {
            existingEmployee.Nip = req.Nip;
            existingEmployee.Name = req.Name;
            existingEmployee.Role = req.Role;

            _db.Employee.Update(existingEmployee);
            _db.SaveChanges();
            return true;
        }
        else
        {
            return false;
        }
    }

}