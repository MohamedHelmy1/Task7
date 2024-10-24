using System;
using System.Collections.Generic;
using System.Net.Mail;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    private List<Customer> _customers = new List<Customer>();
    private string customerFile = "customerFile1";

    public Customer(int Id=0,string Name=null)
    {
        this.Id = Id;
        this.Name = Name;
    }
    public override string ToString()
    {
        return $"{Id},{Name}";
    }
    public void AddCustomer(Customer customer)
    {
        using (StreamWriter writer = new StreamWriter(customerFile, append: true))
        {
            writer.WriteLine(customer.ToString());
        }
        Console.WriteLine("Customer added successfully.");
       
    }

    // Read
    public void GetCustomers()
    {
        if (File.Exists(customerFile))
        {
            var customers = File.ReadAllLines(customerFile);
            if (customers.Length != 0)
            {

                foreach (var line in customers)
                {
                    var parts = line.Split(',');

                    Console.WriteLine($"ID: {parts[0]}, Name: {parts[1]}");
                }
            }

        }

        
    }

    // Update
    public void UpdateCustomer(string id , string newName)
    {
       
            string[] lines = File.ReadAllLines(customerFile);
            using (StreamWriter stream = new StreamWriter(customerFile))
            {
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    if (parts[0] == id)
                    {
                        // Write updated record
                        stream.WriteLine($"{id},{newName}");
                    }
                    else
                    {
                        // Keep the original record
                        stream.WriteLine(line);
                    }
                }
            }
            Console.WriteLine("Record updated successfully.");
        
    }

    // Delete
    public void DeleteCustomer(string id)
    {
        string[] lines = File.ReadAllLines(customerFile);

        using (StreamWriter stream = new StreamWriter(customerFile))
        {
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts[0] != id) // Write only lines that don't match
                {
                    stream.WriteLine(line);
                }
            }
            Console.WriteLine("Record Deleted successfully.");

        }
    }
}

public class Customercustomer
{

    // Create
    

}

class Program
{
    static void Main(string[] args)
    {
        Customer customer = new Customer();

        // Adding Customers
        customer.AddCustomer(new Customer { Id = 1, Name = "John Doe" });
        customer.AddCustomer(new Customer { Id = 2, Name = "Jane Smith" });
        customer.AddCustomer(new Customer { Id = 3, Name = "Jane Smith" });
        customer.AddCustomer(new Customer { Id = 5, Name = "Jane Smith" });
        customer.AddCustomer(new Customer { Id = 7, Name = "Jane Smith" });

        // Reading Customers
        Console.WriteLine("Customer List:");
        customer.GetCustomers();

        // Updating a Customer
        customer.UpdateCustomer("5", "Mohamed");
       
        // Deleting a Customer
        customer.DeleteCustomer("1");

        // Reading Customers
        Console.WriteLine("Customer List:");
        customer.GetCustomers();
    }
}
