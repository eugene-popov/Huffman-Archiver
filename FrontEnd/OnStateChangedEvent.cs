namespace FrontEnd
{
    internal class OnStateChangedEvent
    {
    }

    internal delegate void StateChangedEventHandler(object sender, StateChangedEventHandlerArgs args);

    internal class StateChangedEventHandlerArgs
    {
        private readonly string EventInfo;

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