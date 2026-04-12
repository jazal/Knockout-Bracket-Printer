using System;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.AspNetCore.SignalR.Client;

internal class Program
{
    private static async Task Main(string[] args)
    {
        // await ABC();
    }

    private static async Task ABC()
    {
        int totalClients = 1000;

        List<HubConnection> connections = new();

        for (int i = 0; i < totalClients; i++)
        {
            var connection = new HubConnectionBuilder()
                .WithUrl("https://qbsf.qa/real-time/scoreHub")
                .WithAutomaticReconnect()
                .Build();

            connection.On<FlatDto>("ReceiveScoreUpdate", (dto) =>
            {
                Console.WriteLine($"ScoreA: {dto.ScoreA}, ScoreB: {dto.ScoreB}");
            });

            await connection.StartAsync();
            Console.WriteLine($"Connected client #{i}");

            Console.WriteLine("Connected to SignalR");

            // Join a group (e.g., table_1)
            int tableNo = 1;
            await connection.InvokeAsync("JoinTableGroup", tableNo);
            Console.WriteLine($"Joined group: table_{tableNo}");

            // Optional: throttle startup slightly to prevent crashing
            await Task.Delay(5);
        }
    }
}

public class FlatDto
{
    public int TableNo { get; set; }
    public bool IsGame { get; set; }
    public int ScoreA { get; set; }
    public int ScoreB { get; set; }
    public int[] PointsA { get; set; }
    public int[] PointsB { get; set; }
    public bool[] RemainingBalls { get; set; }
    // Add more as needed
}