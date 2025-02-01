using System.Text;

public class Order{
    private List<Product> _products;
    private Customer _customer;

    public Order (Customer customer){
        _customer = customer;
        _products = new List<Product>();
    }

    public double TotalPrice(){
    double total = 0;
    foreach (var product in _products)
    {
        total += product.GetPrice();
    }

    if (_customer.GetIsInUSA())
    {
        total += 5;
    }
    else
    {
        total += 35;
    }

    return total;
    }

    public string GetPackingLabel()
    {
        StringBuilder packingLabel = new StringBuilder();
        foreach (var product in _products)
        {
            packingLabel.AppendLine($"Name: {product.GetName()}, Product ID: {product.GetId()}");
        }
        return packingLabel.ToString();
    }

    public string GetShippingLabel()
    {
        return $"Name: {_customer.GetName()}, Address: {_customer.GetAddress()}";
    }
}