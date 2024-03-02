#region Sync version
using System.Runtime.CompilerServices;

void Calculate(decimal a, decimal b)
{
    Console.WriteLine($"Operation started in thread {Environment.CurrentManagedThreadId}");
    Console.WriteLine($"Result : {Sum(a, b)}");
    Console.WriteLine($"Operation finished in thread {Environment.CurrentManagedThreadId}");
}
#endregion

#region V2
void CalculateV2(decimal a, decimal b)
{
    Console.WriteLine($"Operation started in thread {Environment.CurrentManagedThreadId}");
    Task task = Task.Factory.StartNew(() =>
    {
        Sum(a, b);
    });

    TaskAwaiter awaiter = task.GetAwaiter();
    awaiter.OnCompleted(() =>
    {
        Console.WriteLine($"Operation finished in thread {Environment.CurrentManagedThreadId}");
    });

    Console.WriteLine($"Operation continues in thread {Environment.CurrentManagedThreadId}");
}
#endregion

#region V3
async Task CalculateV3(decimal a, decimal b)
{
    Console.WriteLine($"Operation started in thread {Environment.CurrentManagedThreadId}");
    Console.WriteLine($"Result : {await SumAsync(a, b)}");
    Console.WriteLine($"Operation finished in thread {Environment.CurrentManagedThreadId}");
}

async Task<decimal> SumAsync(decimal a, decimal b)
{
    await Task.Delay(TimeSpan.FromMilliseconds(1000));
    Console.WriteLine($"Sum running in thread {Environment.CurrentManagedThreadId}");
    return a + b;
}
#endregion

decimal Sum(decimal a, decimal b)
{
    Console.WriteLine($"Sum running in thread {Environment.CurrentManagedThreadId}");
    return a + b;
}

//Calculate(2, 3);
//CalculateV2(2, 3);
await CalculateV3(2, 3);