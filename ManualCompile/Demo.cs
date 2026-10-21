using System;
using SEIMS.Events;
using SEIMS.Models;
using SEIMS.Services;

/// <summary>
/// Tiny console program used to prove that the core classes compile and run from the
/// command line with csc.exe - no Visual Studio needed (Question 6).
/// </summary>
public static class ManualCompileDemo
{
    public static void Main(string[] args)
    {
        Console.WriteLine("=== SEIMS manual compile demo ===");

        FileLogger logger = new FileLogger("manual_compile.log");
        LogHandler log = logger.AsHandler();          // delegate pointing at FileLogger.Write

        InventoryItem laptop = new InventoryItem("ITM-001", "Laptop HP ProBook", 2, 15, 3, 11999m, "Warehouse A - Shelf 1");
        PerishableItem milk = new PerishableItem("ITM-002", "Milk (1L)", 1, 42, 10, 12.50m,
            "Warehouse A - Shelf 3", DateTime.Today.AddDays(13), 2, 5);

        Console.WriteLine(laptop.GetItemDetails());
        Console.WriteLine();
        Console.WriteLine(milk.GetItemDetails());

        InventoryItem milkAsBase = milk;
        Console.WriteLine();
        Console.WriteLine("Describe() on PerishableItem reference : " + milk.Describe());
        Console.WriteLine("Describe() on InventoryItem reference  : " + milkAsBase.Describe());

        InventoryItem copy = milk.DeepCopy();
        copy.Tags.Add("promo");
        Console.WriteLine("Deep copy shares reference? " + ReferenceEquals(milk, copy) +
                          " | equal by value? " + milk.Equals(copy) +
                          " | tags " + milk.Tags.Count + "/" + copy.Tags.Count);

        Console.WriteLine("Objects created: " + InventoryItem.TotalCreated + ", alive: " + InventoryItem.ActiveInstances);

        laptop.Quantity = 3;
        if (laptop.Quantity < InventoryItem.CriticalThreshold)
        {
            string alert = "CRITICAL STOCK: " + laptop.Sku + " has only " + laptop.Quantity + " unit(s) left.";
            Console.WriteLine(alert);
            log(alert);                                // written to the plain text log file
        }

        Console.WriteLine();
        Console.WriteLine("Log file written to: " + logger.FilePath);
        foreach (string line in logger.ReadLast(5)) Console.WriteLine("  " + line);
    }
}
