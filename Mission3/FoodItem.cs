namespace Mission3;

public class FoodItems
{
    // setting information for each food item that is added
    public string Name { get; set; }
    public string Category { get; set; }
    public int Quantity { get; set; }
    public DateTime ExpirationDate { get; set; }
    
    public FoodItems(string name, string category, int quantity, DateTime expirationDate)
    {
        Name = name;
        Category = category;
        Quantity = quantity;
        ExpirationDate = expirationDate;
    }
    
    // turns the array into a string to be printed
    public override string ToString()
    {
        return $"{Name} (Category: {Category}, Quantity: {Quantity}, Expiration: {ExpirationDate.ToShortDateString()})";
    }
}