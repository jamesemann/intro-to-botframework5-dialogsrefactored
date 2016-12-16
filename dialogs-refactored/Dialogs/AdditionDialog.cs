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
    public class AdditionDialog : IDialog<object>
    {
        protected int number1 { get; set; }

        public async Task StartAsync(IDialogContext context)
        {
            await context.PostAsync("Provide number one:");

            context.Wait(MessageReceivedAddNumber1);
        }

        public async Task MessageReceivedAddNumber1(IDialogContext context, IAwaitable<IMessageActivity> argument)
        {
            var numbers = await argument;
            // number one is persisted between messages automatically by bot framework dialog
            this.number1 = int.Parse(numbers.Text);
            await context.PostAsync("Provide number two:");

            context.Wait(MessageReceivedAddNumber2);
        }

        public async Task MessageReceivedAddNumber2(IDialogContext context, IAwaitable<IMessageActivity> argument)
        {
            var numbers = await argument;
            var number2 = int.Parse(numbers.Text);
            await context.PostAsync($"{this.number1} + {number2} is = {this.number1 + number2}");

            context.Done<object>(new object());
        }
    }
}