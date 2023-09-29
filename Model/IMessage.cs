using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ObligatoriskOpgave_28_08_2023.Model
{
    public interface IMessage
    {
        public EMood Mood { get; set; }
        public string OriginalMessage { get; set; }
        public List<string> ItemizedMessage { get; set; }

    }
}
