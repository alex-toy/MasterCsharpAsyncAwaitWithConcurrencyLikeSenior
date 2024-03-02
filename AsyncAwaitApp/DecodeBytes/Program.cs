#region Sync version
void Calculate(decimal a, decimal b)
{
    Console.WriteLine($"Operation started in thread {Environment.CurrentManagedThreadId}");
    Console.WriteLine($"Result : {Sum(a, b)}");
    Console.WriteLine($"Operation finished in thread {Environment.CurrentManagedThreadId}");
}

decimal Sum(decimal a, decimal b)
{
    Console.WriteLine($"Sum running in thread {Environment.CurrentManagedThreadId}");
    return a + b;
}
#endregion

