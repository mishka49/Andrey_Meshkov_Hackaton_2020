namespace Bomb
{
    public delegate void MessageHandler(string message);
    public delegate void ResultHandler();

    public class Event
    { 
        public static MessageHandler Message { get; set; }

        public static ResultHandler Result { get; set; }

        public static event ResultHandler End;

        public static event MessageHandler Notify;

        public static event MessageHandler Info;

        public Event(MessageHandler messageHandler, ResultHandler resultHandler)
        {
            Info += messageHandler;
            Notify += messageHandler;
            End += resultHandler;
            Message = messageHandler;
            Result = resultHandler;
        }

        public static void InvokeEventNotify(string message)
        {
            Notify?.Invoke(message);
        }

        public static void InvokeEventInfo(string message)
        {
            Info?.Invoke(message);
        }

        public static void InvokeEventEnd()
        {
            End?.Invoke();
        }
    }
}
