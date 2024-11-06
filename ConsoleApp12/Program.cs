using ConsoleApp12;
using System;
using System.Collections.Generic;

class MainClass
{
    static void Main()
    {
        CreditCard card = new CreditCard("1234 5678 9012 3456", "Alex Shevt", new DateTime(2025, 12, 31), 1234, 500, 10); 

        // Добавляем подписчков для события OnReplenishment  
        card.OnReplenishment += SubscriberReplenishmentConsole;
        card.OnReplenishment += SubscriberReplenishmentFile;

        // Добавляем подписчков для события OnSpending  
        card.OnSpending += SubscriberReplenishmentConsole;
        card.OnSpending += SubscriberReplenishmentFile;

        // Добавляем подписчков для события OnStartCredit 
        card.OnStartCredit += SubscriberReplenishmentConsole;
        card.OnStartCredit += SubscriberReplenishmentFile;

        // Добавляем подписчков для события OnAccumulator   
        card.OnAccumulator += SubscriberReplenishmentConsole;
        card.OnAccumulator += SubscriberReplenishmentFile;

        // Добавляем подписчков для события OnPinChange 
        card.OnPinChange += SubscriberReplenishmentConsole;
        card.OnPinChange += SubscriberReplenishmentFile;

        card.OnShow += SubscriberReplenishmentConsole;
        card.ShowCard();

        Console.WriteLine();
        card.Replenishment(50);

        Console.WriteLine();
        card.Consumption(10);

        Console.WriteLine();
        card.Accumulator(40);

        Console.WriteLine();
        card.ChangePin(1254);

        Console.WriteLine();
        card.ShowCard();    
    }

    // Выводим текст на консоль
   private static void SubscriberReplenishmentConsole(string message) 
   {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine(message); 
        Console.ResetColor();
    }

    // Выводим текст в файл 
   private static void SubscriberReplenishmentFile(string messege) 
   {
        using (StreamWriter writer = new StreamWriter("file.txt", true))     
        { 
            writer.WriteLine(messege);
        }
   }
   
}