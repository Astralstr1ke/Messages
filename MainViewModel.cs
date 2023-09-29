using ObligatoriskOpgave_28_08_2023.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObligatoriskOpgave_28_08_2023
{
    internal class MainViewModel
    {
        private int[] counts = new int[Enum.GetNames(typeof(EMood)).Length];

        public string SearchWord(String word)
        {
            foreach (KeyValuePair<string, IMessage> item in MessageDictionary.Instance.getMessage())
            {
                if (item.Value.OriginalMessage.Contains(word))
                {
                    counts[((int)item.Value.Mood)]++;
                }
            }
            return CheckLargest(word);

        }

        private string CheckLargest(string word)
        {
            int largest = 0;
            int index = 0;
            for (int i = 0; i < counts.Length; i++)
            {
                if (counts[i] > largest)
                {
                    largest = i;
                    index++;
                }
            }
            string outPut = word+" shows up the most, at "+largest+" times in "+ Enum.GetName(typeof(EMood), index);
            return outPut;
        }
    }


}

