using System.Text;

public class Order{
    private List<Product> _products;
    private Customer _customer;

    public Order (Customer customer){
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
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
        string label = "Packing Label:\n";
        foreach (Product product in _products)
        {
            label += $"{product.GetName()} (ID: {product.GetId()})\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        return $"Name: {_customer.GetName()}, Address: {_customer.GetAddress()}";
    }
}