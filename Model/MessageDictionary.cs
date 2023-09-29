using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObligatoriskOpgave_28_08_2023.Model
{
    public sealed class MessageDictionary : Dictionary<string, IMessage>
    {
        // den her klasser er et rabit hole af dårlige beslutninger. jeg er 100% sikker på at det ikke er korrekt på nogle måder.


        public static MessageDictionary Instance { get { return Nested.instance; } }
        private MessageDictionary() { }



        private static Dictionary<string, IMessage> Messages = new Dictionary<string, IMessage>();

        public void RegisterMessage(IMessage message)
        {
            // Dictionary[key] = // Is both add and update? 
            string count = (Messages.Count + 1).ToString();
            Messages[count] = message;
        }
        public  Dictionary<string, IMessage> getMessage()
        {
            return  Messages;
        }
        public ref Dictionary<string, IMessage> RefgetMessage()
        {
            return ref Messages;
        }
        public ObservableCollection<IMessage> FilteredMessages(EMood mood)
        {
            ObservableCollection < IMessage > filtered = new ObservableCollection < IMessage >();
            foreach (var item in Messages)
            {
                if (item.Value.Mood == mood)
                {
                    filtered.Add(item.Value);
                }
                
            }
            return filtered;
        }

        private class Nested // https://stackoverflow.com/questions/47109574/c-sharp-singleton-dictionary-class He knows why everthing must be forced out of C#
        {
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static Nested()
            { }

            internal static readonly MessageDictionary instance = new MessageDictionary();
        }
    }
}
