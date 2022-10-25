using Practice;

public class Program
{
    public static async Task Main(string[] args)
    {
        var task = new TaskCompletionSource();
        var message = new MessageBox();
        message.WindowHandler += PrintToConsole;
        message.WindowHandler += x => task.SetResult();
        message.Open();
        await task.Task;
    }

    public static void PrintToConsole(State state)
    {
        if (state == State.Ok)
        {
            Console.WriteLine("OK - Operation was confirmed");
            return;
        }

        Console.WriteLine("Cancel - Operation was canceled");
    }
}