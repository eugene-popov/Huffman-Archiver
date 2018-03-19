using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd
{
    class OnStateChangedEvent
    {

    }

    internal delegate void StateChangedEventHandler(object sender, StateChangedEventHandlerArgs args);

    internal class StateChangedEventHandlerArgs
    {
        private string EventInfo;
        public StateChangedEventHandlerArgs(string Text)
        {
            EventInfo = Text;
        }
        public string GetInfo()
        {
            return EventInfo;
        }
    }
}
