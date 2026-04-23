namespace FreezerInventory.Models;

public class FreezerItem
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public int Quantity { get; set; }
    public DateTime ExpiryDate { get; set; }
}