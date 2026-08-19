namespace _05prob;

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        int imageCount = 50;
        int maxConcurrency = 4;

        SemaphoreSlim semaphore = new SemaphoreSlim(maxConcurrency);

        List<Task> tasks = new List<Task>();

        for (int i = 1; i <= imageCount; i++)
        {
            int imageNumber = i;

            tasks.Add(ProcessImageAsync(imageNumber, semaphore));
        }

        await Task.WhenAll(tasks);

        semaphore.Dispose();

        Console.WriteLine();
        Console.WriteLine("All images processed.");
    }

    static async Task ProcessImageAsync(
        int imageNumber,
        SemaphoreSlim semaphore)
    {
        Console.WriteLine($"Image {imageNumber} is waiting to enter the pipeline.");

        // Wait until one of the 4 slots becomes available
        await semaphore.WaitAsync();

        try
        {
            Console.WriteLine(
                $"Image {imageNumber} entered the pipeline."
            );

            Console.WriteLine(
                $"Image {imageNumber} is processing..."
            );

            // Simulate image processing
            await Task.Delay(2000);

            Console.WriteLine(
                $"Image {imageNumber} exited the pipeline."
            );
        }
        finally
        {
            // Give the slot back
            semaphore.Release();
        }
    }
}