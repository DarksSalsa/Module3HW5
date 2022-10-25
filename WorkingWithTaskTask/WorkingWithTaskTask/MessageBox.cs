namespace Practice
{
    public class MessageBox
    {
        public event Action<State> WindowHandler;

        public async void Open()
        {
            Console.WriteLine("Window is open");
            await Task.Delay(3000);
            Console.WriteLine("Window was open by the user");
            if (Random.Shared.Next(1, 3) == 1)
            {
                WindowHandler.Invoke(State.Ok);
                return;
            }

            WindowHandler.Invoke(State.Cancel);
        }
    }
}
