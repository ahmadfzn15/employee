using System.ComponentModel.DataAnnotations;

namespace MVC.Models;
public class Employee
{
    public int Id { get; set; }
    [Required]
    public required string Nip { get; set; }
    [Required]
    public required string Name { get; set; }
    [Required]
    public required string Role { get; set; }
}
