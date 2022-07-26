﻿using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        var test = new AwaitingTest();

        Console.WriteLine("Starting app");

        test.AwaitSequencially().Wait();
        test.AwaitInParallel().Wait();

        Console.WriteLine("Ending app");
    }
}

public class AwaitingTest
{
    public async Task AwaitSequencially()
    {
        var watch = new Stopwatch();

        Console.WriteLine("Starting sequencially async calls");

        watch.Start();

        await wait5sec();
        await wait5sec_2();
        await wait5sec_3();

        watch.Stop();

        Console.WriteLine($"finished sequencially async calls in {watch.ElapsedMilliseconds}");
    }

    public async Task AwaitInParallel()
    {
        var watch = new Stopwatch();

        Console.WriteLine("Starting parallel async calls");

        watch.Start();

        var a = wait5sec();
        var b = wait5sec_2();
        var c = wait5sec_3();

        Console.WriteLine("Doing other stuff");

        await a;
        await b;
        await c;

        watch.Stop();

        Console.WriteLine($"finished parallel async calls in {watch.ElapsedMilliseconds}");
    }

    private async Task wait5sec() => await Task.Delay(5000);
    private async Task wait5sec_2() => await Task.Delay(5000);
    private async Task wait5sec_3() => await Task.Delay(5000);
}

