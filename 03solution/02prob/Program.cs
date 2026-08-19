namespace _02prob;

using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("Starting file processing...");

        // Create Progress object
        Progress<int> progress = new Progress<int>(
            percentage =>
            {
                Console.WriteLine($"Progress: {percentage}%");
            });

        // Start processing
        await ProcessFiles(progress);

        Console.WriteLine("All files processed!");
    }

    static async Task ProcessFiles(IProgress<int> progress)
    {
        int totalFiles = 100;

        for (int i = 1; i <= totalFiles; i++)
        {
            // Simulate processing one file
            await Task.Delay(100);

            // Calculate percentage
            int percentage = i * 100 / totalFiles;

            // Report progress
            progress.Report(percentage);
        }
    }
}
