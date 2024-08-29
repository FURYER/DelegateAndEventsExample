using System;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        // Пример работы с GetMax
        List<string> items = new List<string> { "apple", "banana", "cherry" };
        var maxItem = items.GetMax(item => item.Length);
        Console.WriteLine($"Max item by length: {maxItem}");

        // Пример работы с DirectoryScanner
        var scanner = new DirectoryScanner();
        scanner.FileFound += OnFileFound;

        scanner.ScanDirectory("S:\\"); // Укажите реальный путь

        Console.ReadLine();
    }

    private static void OnFileFound(object sender, FileArgs e)
    {
        Console.WriteLine($"File found: {e.FileName}");
        // Пример отмены поиска
        if (e.FileName.Contains("stop"))
        {
            e.Cancel = true;
        }
    }
}
