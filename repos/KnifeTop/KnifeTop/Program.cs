using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace KnifeTop;

internal class Program
{
    public static async Task Main(string[] args)
    {
       
        var botClient = new TelegramBotClient("6725676176:AAEwgXS-TmW06DG6DQ_iJg9NNH2QDuAVoFA");

        botClient.StartReceiving(UpdateHandler, Error);

        Console.ReadLine();
    }

    private static async Task UpdateHandler(ITelegramBotClient botClient, Update update, CancellationToken token)
    {
        var message =  update.Message;

        if (message != null)
        {
            //InputFile inputFile = ;
            await botClient.SendTextMessageAsync(message.Chat.Id, "Hi");
            //await botClient.SendPhotoAsync(message.Chat.Id, inputFile);
            
        }
    }

    private static Task Error(ITelegramBotClient client, Exception exception, CancellationToken token)
    {
        throw new NotImplementedException();
    }
}
