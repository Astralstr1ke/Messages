using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObligatoriskOpgave_28_08_2023.Model
{
    internal static class MessageConstrutor
    {
        public static IMessage ConstructMessage(int mood, string message)
        {
            IMessage Message = new Message();
            Message.Mood = (EMood)mood;
            Message.OriginalMessage = message;
            Message.ItemizedMessage = ItemizeMessage(message);
            MessageDictionary.Instance.RegisterMessage(Message); // doesn't look right, should i not go through the instance
            return Message;

        }

        private static List<string> ItemizeMessage(string message)
        {
            List<string> items = message.Split(' ').ToList();
            return items;
        }
    }
}
