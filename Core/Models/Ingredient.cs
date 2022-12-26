using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Core.Models;

public class Ingredient
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Color { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
}
