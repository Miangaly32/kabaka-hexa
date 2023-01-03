namespace Core.Models;

public class MealHistory
{
    public int Id { get; set; }
    public int MealId {  get; set; }
    public Meal Meal { get; set; }
    public DateTime Date { get; set; }
}
