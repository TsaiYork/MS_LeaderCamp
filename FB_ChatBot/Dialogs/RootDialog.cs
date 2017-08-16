using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace FB_ChatBot.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);

            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;

            // calculate something for us to return
            int length = (activity.Text ?? string.Empty).Length;

            // return our reply to the user
            //await context.PostAsync($"You sent {activity.Text} which was {length} characters");
            if(activity.Text == "你好")
                await context.PostAsync($"Hello，我是AI公主，你可以問我關於領袖營的問題喔");
            else if(activity.Text == "你好漂亮")
                await context.PostAsync($"嘴巴真甜，給你一個讚");
            else if (activity.Text == "笨")
                await context.PostAsync($"已讀不回");
            else
                await context.PostAsync($"工程師還在賣肝開發中...");

            context.Wait(MessageReceivedAsync);
        }
    }
}