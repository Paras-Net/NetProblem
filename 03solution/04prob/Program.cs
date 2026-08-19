namespace _04prob;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("IoT Sensor Data:");

        await foreach (double temperature in GetSensorData())
        {
            // Filter temperatures above 30°C
            if (temperature <= 30)
            {
                Console.WriteLine($"Temperature: {temperature}°C");
            }
        }

        Console.WriteLine("Finished reading sensor data.");
    }

    static async IAsyncEnumerable<double> GetSensorData()
    {
        Random random = new Random();

        for (int i = 0; i < 10; i++)
        {
            // Simulate sensor taking 500ms to provide data
            await Task.Delay(500);

            // Generate temperature between 20 and 35
            double temperature = random.Next(20, 36);

            yield return temperature;
        }
    }
}
