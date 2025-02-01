using System.Net.Sockets;

public class Customer{
    private string _name;
    private Address _address;

    public Customer (string name, Address address){
        _name = name;
        _address = address;
    }

    public bool GetIsInUSA(){
        return _address.IsInUSA();
    }

    public string GetName(){
        return _name;
    }

    public string GetAddress(){
        return _address.ToString();
    }
}