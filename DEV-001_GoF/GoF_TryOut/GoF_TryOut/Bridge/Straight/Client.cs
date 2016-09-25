using System;

namespace GoF_TryOut.Bridge.Straight {
    public class Client {
        public Client() {
            IMessageSender email = new EmailSender();
            IMessageSender queue = new MSMQSender();
            IMessageSender web = new WebServiceSender();

            var message = new Message();
            message.Subject = "Test Message";
            message.Body = "Hi, This is a Test Message";

            email.SendMessage(message, false);

            queue.SendMessage(message, false);

            web.SendMessage(message,false);

            var usermsg = new Message();
            usermsg.Subject = "Test Message";
            usermsg.Body = "Hi, This is a Test Message";
            usermsg.UserComments = "I hope you are well";

            email.SendMessage(usermsg, true);
        }
    }


   
}