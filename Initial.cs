using System;
using System.Collections.Generic;
using System.Linq;

class Product
{
    public string Name { get; set; }
    public string Category { get; set; }
    public double Price { get; set; }

    public Product(string name, string category, double price)
    {
        Name = name;
        Category = category;
        Price = price;
    }
}

class Store
{
    private readonly List<Product> products = new();

    public void AddProduct(string name, string category, double price)
    {
        products.Add(new Product(name, category, price));
    }

    public void PrintReport()
    {
        Console.WriteLine("Store Report");
        Console.WriteLine("============");

        var sortedProducts = products
            .OrderBy(product => product.Category)
            .ThenBy(product => product.Price);

        foreach (var product in sortedProducts)
        {
            Console.WriteLine(
                $"{product.Name} | {product.Category} | ${product.Price:F2}"
            );
        }

        Console.WriteLine("============");
        Console.WriteLine($"Products: {products.Count}");
        Console.WriteLine($"Average Price: ${products.Average(p => p.Price):F2}");
        Console.WriteLine($"Total Value: ${products.Sum(p => p.Price):F2}");
    }
}

class Program
{
    static void Main()
    {
        var store = new Store();

        store.AddProduct("Laptop", "Electronics", 899.99);
        store.AddProduct("Keyboard", "Accessories", 79.50);
        store.AddProduct("Monitor", "Electronics", 249.99);
        store.AddProduct("Mouse", "Accessories", 39.99);
        store.AddProduct("Headphones", "Accessories", 129.99);

        store.PrintReport();
    }
}