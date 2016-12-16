using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.Bot.Connector;

namespace dialogs_basic.Dialogs
{
    [Serializable]
    public class SquaredDialog : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            await context.PostAsync("Provide one number:");

            context.Wait(MessageReceivedSquared);
        }

        public async Task MessageReceivedSquared(IDialogContext context, IAwaitable<IMessageActivity> argument)
        {
            var activity = await argument;
            var num = double.Parse(activity.Text);

            await context.PostAsync($"{num} squared is {num * num}");

            context.Done<object>(new object());
        }
    }
}