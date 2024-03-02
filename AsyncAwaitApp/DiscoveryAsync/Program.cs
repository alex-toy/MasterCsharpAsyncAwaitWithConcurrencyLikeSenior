async Task Execute(int duration = 3)
{
    Console.WriteLine("start Execute");
    await Task.Delay(TimeSpan.FromSeconds(duration));
    Console.WriteLine("end Execute");
}

Console.WriteLine("start of program");
//Execute();
//await Execute();
Task task = Execute();
Console.WriteLine("end of program");
await task;
Console.ReadLine();