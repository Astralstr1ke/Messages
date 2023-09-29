using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Xml.Linq;

namespace ObligatoriskOpgave_28_08_2023.Model
{
    internal static class XMLWorker
    {
        static string FileName = "Happy.XML";


        public static void ReadMessages()
        {
            XElement reader = XElement.Load(FileName);

            foreach (int mood in Enum.GetValues<EMood>())
            {
                // WTF there is no reason this shit wont work, why does it return null. Even ChatGPT thinks this should work
                IEnumerable<XElement> Elements = (from e in reader.Descendants("Messages") where e.Element("mood")?.Value == Enum.GetName(typeof(EMood), mood) select e).ToList();
                

                foreach (XElement element in Elements)
                {
                    MessageConstrutor.ConstructMessage(mood, element.Value);
                }
                Console.ReadLine();
            }
        }
        public static void ReadMessages2()
        {
            EMood why = new EMood();
            foreach (string item in Enum.GetNames(why.GetType()))
            {
                string s = item+".XML";

                XElement reader = XElement.Load(s);


                XElement ElementMood = reader.Element("mood");
                List<XElement> elements = reader.Elements("message").ToList();
                int mood = (int)Enum.Parse(typeof(EMood), ElementMood.Value);

                for (int i = 1; i < elements.Count; i++)
                {
                    MessageConstrutor.ConstructMessage(mood, elements[i].Value);
                }
            }


        }
        public static ObservableCollection<IMessage> ConvertDictionaryToObverable() 
        { 
            ObservableCollection<IMessage> messages = new ObservableCollection<IMessage>(MessageDictionary.Instance.Values);
            return messages;

        }
        public static void WriteMessages() { }
        
    }
}
