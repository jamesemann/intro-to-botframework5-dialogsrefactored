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
    public class SquareRootDialog : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            await context.PostAsync("Provide one number:");

            context.Wait(MessageReceivedSquareRoot);
        }

        public async Task MessageReceivedSquareRoot(IDialogContext context, IAwaitable<IMessageActivity> argument)
        {
            var number = await argument;
            var num = double.Parse(number.Text);

            await context.PostAsync($"square root of {num} is {Math.Sqrt(num)}");

            context.Done<object>(new object());
        }
    }
}