public class TelegramMessageModel
{
    public long updateId;
    public long chatId;
    public string text;
    public string firstName;

    public TelegramMessageModel(long updateId, long chatId, string firstName, string text)
    {
        this.updateId = updateId;
        this.chatId = chatId;
        this.firstName = firstName;
        this.text = text;
    }

    public override string ToString()
    {
        return$"{firstName} {text}  {chatId}  {updateId}";
    }
}