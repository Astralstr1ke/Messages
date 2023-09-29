using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ObligatoriskOpgave_28_08_2023.Model.Decorator
{
    internal class MessageDuplicateCheck : MessageDecorator
    {
        public IMessage message;

        //Checks if the full message occurs anywhere all messages og deletes dupelicate entries
        private bool CheckDuplicate()
        {
            int count = 0;
            foreach (KeyValuePair<string,IMessage> item in MessageDictionary.Instance) 
            {
                if (message.OriginalMessage == item.Value.OriginalMessage)
                {
                    count++;
                }
            }
            if (count >= 2) 
            {
                for (int i = 0; i < count-1; i++)
                {
                    RemoveInstance();
                }

                return true;
            }
            else
            {
                return false;
            }

        }
        private bool RemoveInstance()
        {
            if (CheckDuplicate() == false)
            {
                return false;
            }

            else
            {
                try
                {
                    MessageDictionary.Instance.Remove(message.Mood.ToString(), out message);

                    return true;

                }
                catch (Exception)
                {

                    return false;
                }

            }



        }
    }
}

