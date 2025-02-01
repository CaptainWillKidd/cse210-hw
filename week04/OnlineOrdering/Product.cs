public class Product{
    private string _name;
    private int _id;
    private int _quantity;
    private double _price;

    public Product(string name, int id, double price, int quantity) {
        _name = name;
        _id = id;
        _quantity = quantity;
        _price = price;
    }

    public string GetName() {
        return _name;
    }

    public int GetId() {
        return _id;
    }

    public int GetQuantity() {
        return _quantity;
    }

    public double GetPrice() {
        return _price;
    }

    public double GetTotalPrice() {
        return _quantity * _price;
    }
}