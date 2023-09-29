using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObligatoriskOpgave_28_08_2023.Model.Decorator
{
    internal abstract class MessageDecorator : IMessage
    {
        public IMessage StoredMessage { get; set; }
        public EMood Mood { get; set; }
        public string OriginalMessage { get; set; }
        public List<string> ItemizedMessage { get; set; }
    }
}
