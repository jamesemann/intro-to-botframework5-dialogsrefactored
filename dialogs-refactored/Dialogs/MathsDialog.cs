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
    public class MathsDialog : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedStart);
        }
        public async Task MessageReceivedStart(IDialogContext context, IAwaitable<IMessageActivity> argument)
        {
            await context.PostAsync("do you want to add, square root, or squared?");

            context.Wait(MessageReceivedOperationChoice);
        }

        public async Task MessageReceivedOperationChoice(IDialogContext context, IAwaitable<IMessageActivity> argument)
        {
            var message = await argument;

            if (message.Text.ToLower().Equals("add", StringComparison.InvariantCultureIgnoreCase))
            {
                context.Call<object>(new AdditionDialog(), AfterChildDialogIsDone);
            }
            else if (message.Text.ToLower().Equals("square root", StringComparison.InvariantCultureIgnoreCase))
            {
                context.Call<object>(new SquareRootDialog(), AfterChildDialogIsDone);
            }
            else if (message.Text.ToLower().Equals("squared", StringComparison.InvariantCultureIgnoreCase))
            {
                context.Call<object>(new SquaredDialog(), AfterChildDialogIsDone);
            }
            else
            {
                context.Wait(MessageReceivedStart);
            }
        }

        private async Task AfterChildDialogIsDone(IDialogContext context, IAwaitable<object> result)
        {
            context.Wait(MessageReceivedStart);
        }
    }
}