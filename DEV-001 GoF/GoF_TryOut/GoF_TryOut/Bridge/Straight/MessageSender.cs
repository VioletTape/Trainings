using System;

namespace GoF_TryOut.Bridge.Straight {
    public interface IMessageSender
    {
        void SendMessage(Message message, bool isSystem);
    }
    // var fullBody = string.Format("{0}\nUser Comments: {1}", Body, UserComments);
    public class EmailSender : IMessageSender
    {
        public void SendMessage(Message message, bool isSystem)
        {
            var fullBody = message.Body;
            if (!isSystem)
            {
                fullBody = string.Format("{0}\nUser Comments: {1}", message.Body, message.UserComments);
            }
            Console.WriteLine("Email\n{0}\n{1}\n", message.Subject, fullBody);
        }
    }

    public class MSMQSender : IMessageSender
    {
        public void SendMessage(Message message, bool isSystem)
        {
            var fullBody = message.Body;
            if (!isSystem)
            {
                fullBody = string.Format("{0}\nUser Comments: {1}", message.Body, message.UserComments);
            }
            Console.WriteLine("MSMQ\n{0}\n{1}\n", message.Subject, fullBody);
        }
    }

    public class WebServiceSender : IMessageSender
    {
        public void SendMessage(Message message, bool isSystem)
        {
            var fullBody = message.Body;
            if (!isSystem)
            {
                fullBody = string.Format("{0}\nUser Comments: {1}", message.Body, message.UserComments);
            }
            Console.WriteLine("Web Service\n{0}\n{1}\n", message.Subject, fullBody);
        }
    }
}