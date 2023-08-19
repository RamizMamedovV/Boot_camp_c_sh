public class BotTelegram
{
    string token;
    public Action<TelegramMessageModel> action;
    HttpClient hc;
    Thread thread;
    public BotTelegram(string token)
    {
        this.token = token;
        hc = new HttpClient();
        hc.BaseAddress = new Uri($"https://api.telegram.org/bot{token}/");

        thread = new Thread(GetUpdates);
    }

    private void GetUpdates()
    {
        long offset = 0;
        while (true)
        {
            string content = hc.GetStringAsync($"getUpdates?offset={offset}").Result;
            try
            {
                TelegramMessageModel[] ms = new JsonParser().GetMessage(content);
                if (ms.Length != 0)
                {
                    foreach (var item in ms)
                    {
                        System.Console.WriteLine(item);
                        action(item);
                    }
                    offset = ms[ms.Length - 1].updateId + 1;
                }
            }
            catch
            {
                System.Console.WriteLine("ERROR!!!");
            }
            Thread.Sleep(1000); // еслм чаще, то Телеграм может забанить
        }
    }

    public void SendMessage(long userId, string text)
    {

    }

    public void Start()
    {
        thread.Start();
    }
}