using System.Diagnostics;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using MVC.Repository;

namespace MVC.Controllers;

public class EmployeeController(IEmployeeRepository employee) : Controller
{
    private readonly IEmployeeRepository _employee = employee;
    public IActionResult Index()
    {
        var res = _employee.GetData();

        return View(res);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Store(Employee req)
    {
        if (ModelState.IsValid)
        {
            _employee.AddData(req);
            return RedirectToAction("Index");
        }
        return View("Create");
    }

    public IActionResult Edit(int id)
    {
        var res = _employee.FindById(id);

        return View(res);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Update(int id, Employee req)
    {
        if (ModelState.IsValid)
        {
            _employee.EditData(id, req);
            return RedirectToAction("Index");
        }
        return View("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
