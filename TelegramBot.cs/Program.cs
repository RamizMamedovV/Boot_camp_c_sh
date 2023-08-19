using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

// https://api.telegram.org/bot6574903644:AAGy5ukTAeNdI1KrQb28fRRfeXBp0wQL9ks/getMe

// формат Json - для передачи данных. есть ещё XML
// {
//     "ok": true,
//     "result": {
//         "id": 6574903644,
//         "is_bot": true,
//         "first_name": "Menim yeni bot",
//         "username": "ramizden_bot",
//         "can_join_groups": true,
//         "can_read_all_group_messages": false,
//         "supports_inline_queries": false
//     }
// }

                            // скачивать данные из интернета
// HttpClient hc = new();
// string contentObj = hc.GetStringAsync("https://translate.google.com/").Result;


                        // getme - узнаем о себе
// string token = File.ReadAllText("token.config");
// HttpClient hc = new();
// hc.BaseAddress = new Uri($"https://api.telegram.org/bot{token}/");

// получаем данные про свой аккаунт
// string contentObj = hc.GetStringAsync("getme").Result;  // рез от 8 до 19 строки

// JObject obj = JObject.Parse(contentObj);

// System.Console.WriteLine(obj["ok"]);
// System.Console.WriteLine($"first_name = {obj["result"]["first_name"]}");
// System.Console.WriteLine($"usrname = {obj["result"]["username"]}");


                        // принимаем месажи
// string token = File.ReadAllText("token.config");
// HttpClient hc = new();
// hc.BaseAddress = new Uri($"https://api.telegram.org/bot{token}/");
// 839626145 - "update_id": 839626144"+1 будет обнавлять до момента - ПРОЧИТАНО!
// чтобы каждый раз не скачивать старые записи. но старые гдето нужно хранить))
// int offset = 0;
// string contentObj = hc.GetStringAsync($"getUpdates?offset={offset}").Result;  // 

// JObject obj = JObject.Parse(contentObj);

// JArray messages = JArray.Parse(obj["result"].ToString());
// for (int i = 0; i < messages.Count; i++)
// {
//     Console.Write($"{messages[i]["message"]["from"]["last_name"]} -> ");
//     Console.WriteLine($"{messages[i]["message"]["text"]}");
// }



                        // используем все классы для общения
string token = File.ReadAllText("token.config");
BotTelegram bot = new BotTelegram(token);
void Updates(TelegramMessageModel msg)
{
    bot.SendMessage(msg.chatId, $"{msg.text}: получено");
}

bot.action = Updates;
bot.Start();
System.Console.WriteLine("+++");