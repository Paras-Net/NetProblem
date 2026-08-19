namespace _01prob;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        string[] urls =
        {
            "https://www.google.com",
            "https://www.microsoft.com",
            "https://www.github.com"
        };

        using HttpClient client = new HttpClient();

        Stopwatch stopwatch = Stopwatch.StartNew();

        // Create tasks for all 3 downloads
        Task<string> task1 = client.GetStringAsync(urls[0]);
        Task<string> task2 = client.GetStringAsync(urls[1]);
        Task<string> task3 = client.GetStringAsync(urls[2]);

        // Wait for all downloads to complete
        string[] results = await Task.WhenAll(task1, task2, task3);

        stopwatch.Stop();

        // Display character count
        for (int i = 0; i < results.Length; i++)
        {
            Console.WriteLine(
                $"{urls[i]} -> {results[i].Length} characters"
            );
        }

        Console.WriteLine();
        Console.WriteLine("Total execution time: " 
                          + stopwatch.ElapsedMilliseconds + " ms");
    }
}