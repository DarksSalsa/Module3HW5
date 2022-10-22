public class Program
{
    public static void Main(string[] args)
    {
        var program = new Program();
        Console.WriteLine(program.WaitForReadersAsync().Result);
    }

    public async Task<string> ReadFromHelloAsync()
    {
        var file = new StreamReader("hello.txt");
        await Task.Delay(7000);
        return await file.ReadLineAsync();
    }

    public async Task<string> ReadFromWorldAsync()
    {
        var file = new StreamReader("world.txt");
        await Task.Delay(4000);
        return await file.ReadLineAsync();
    }

    public async Task<string> WaitForReadersAsync()
    {
        var list = new List<Task<string>>() { Task.Run(ReadFromHelloAsync), Task.Run(ReadFromWorldAsync) };
        var concat = Task.WhenAll(list).GetAwaiter().GetResult();
        return await Task.Run(() => concat[0] + concat[1]);
    }
}