namespace _03prob;

using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("Enter the keyword to search:");
        string keyword = Console.ReadLine();

        using CancellationTokenSource cts = new CancellationTokenSource();

        // Start listening for the C key
        Task cancellationTask = Task.Run(() =>
        {
            while (!cts.Token.IsCancellationRequested)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);

                    if (key.Key == ConsoleKey.C)
                    {
                        Console.WriteLine("\nCancellation requested...");
                        cts.Cancel();
                        break;
                    }
                }
            }
        });

        try
        {
            Console.WriteLine("Searching...");
            Console.WriteLine("Press 'C' to cancel.");

            string result = await SearchDatabaseAsync(
                keyword,
                cts.Token
            );

            Console.WriteLine(result);
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Search canceled.");
        }
        catch (HttpRequestException)
        {
            Console.WriteLine("A network error occurred while performing the search.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unexpected error: " + ex.Message);
        }
    }

    static async Task<string> SearchDatabaseAsync(
        string keyword,
        CancellationToken cancellationToken)
    {
        Console.WriteLine($"Searching for '{keyword}'...");

        // Simulate a 5-second database search
        await Task.Delay(5000, cancellationToken);

        // Mock result
        return $"Search completed. Results found for '{keyword}'.";
    }
}