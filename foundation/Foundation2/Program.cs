using System;
using System.Collections.Generic;

class Address
{
    private string _street;
    private string _city;
    private string _state;
    private string _country;

    public Address(string street, string city, string state, string country)
    {
        _street = street;
        _city = city;
        _state = state;
        _country = country;
    }

    public bool IsInUSA()
    {
        return _country.ToLower() == "usa";
    }

    public override string ToString()
    {
        return $"{_street}\n{_city}, {_state}\n{_country}";
    }
}

class Customer
{
    private string _name;
    private Address _address;

    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    public bool LivesInUSA()
    {
        return _address.IsInUSA();
    }

    public string GetName()
    {
        return _name;
    }

    public string GetAddress()
    {
        return _address.ToString();
    }
}

class Product
{
    private string _productId;
    private string _name;
    private decimal _price;
    private int _quantity;

    public Product(string productId, string name, decimal price, int quantity)
    {
        _productId = productId;
        _name = name;
        _price = price;
        _quantity = quantity;
    }

    public decimal TotalCost()
    {
        return _price * _quantity;
    }

    public string GetProductId()
    {
        return _productId;
    }

    public string GetName()
    {
        return _name;
    }
}

class Order
{
    private Customer _customer;
    private List<Product> _products;
    private decimal _shippingCost;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
        _shippingCost = _customer.LivesInUSA() ? 5 : 35; // Set shipping cost based on customer's location
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public decimal CalculateTotal()
    {
        decimal total = _shippingCost;
        foreach (var product in _products)
        {
            total += product.TotalCost();
        }
        return total;
    }

    public string PackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (var product in _products)
        {
            label += $"{product.GetName()} (ID: {product.GetProductId()})\n";
        }
        return label;
    }

    public string ShippingLabel()
    {
        return $"Shipping Label:\n{_customer.GetName()}\n{_customer.GetAddress()}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create addresses
        Address address1 = new Address("12 Epworth", "Harare", "ZW", "Zimbabwe");
        Address address2 = new Address("456 Oak St", "Toronto", "ON", "Canada");

        // Create customers
        Customer customer1 = new Customer("Nyasha Ushewokunze", address1);
        Customer customer2 = new Customer("Lucy Mcnneil", address2);

        // Create products
        Product product1 = new Product("001", "Laptop", 999.99m, 1);
        Product product2 = new Product("002", "Mouse", 25.99m, 2);
        Product product3 = new Product("003", "Keyboard", 49.99m, 1);

        // Create orders
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Order order2 = new Order(customer2);
        order2.AddProduct(product2);
        order2.AddProduct(product3);

        // Display order details for Order 1
        Console.WriteLine(order1.PackingLabel());
        Console.WriteLine(order1.ShippingLabel());
        Console.WriteLine($"Total Price for Order 1: ${order1.CalculateTotal():F2}\n");

        // Display order details for Order 2
        Console.WriteLine(order2.PackingLabel());
        Console.WriteLine(order2.ShippingLabel());
        Console.WriteLine($"Total Price for Order 2: ${order2.CalculateTotal():F2}\n");
    }
}
