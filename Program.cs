﻿﻿internal class Program
{

    // Implementor
    public interface IMessageSender
    {
        void SendMessage(string subject, string body);
    }
    // ConcreteImplementor for Email
    public class EmailSender : IMessageSender
    {
        public void SendMessage(string subject, string body)
        {
            Console.WriteLine($"Email sent with subject: {subject} and body: {body}");
        }
    }

    // ConcreteImplementor for SMS
    public class SmsSender : IMessageSender
    {
        public void SendMessage(string subject, string body)
        {
            Console.WriteLine($"SMS sent with subject: {subject} and body: {body}");
        }
    }

    // Abstraction
    public abstract class Message
    {
        protected IMessageSender messageSender;

        public Message(IMessageSender messageSender)
        {
            this.messageSender = messageSender;
        }

        public abstract void Send(string subject, string body);
    }
    // Refined Abstraction for Order Message
    public class OrderMessage : Message
    {
        public OrderMessage(IMessageSender messageSender) : base(messageSender)
        {
        }
        public override void Send(string subject, string body)
        {
            //field kế thừa từ Message
            messageSender.SendMessage(subject, body);
        }
    }

    // Refined Abstraction for Payment Message
    public class PaymentMessage : Message
    {
        public PaymentMessage(IMessageSender messageSender) : base(messageSender)
        {
        }

        public override void Send(string subject, string body)
        {
            //field kế thừa từ Message
            messageSender.SendMessage(subject, body);
        }
    }
    private static void Main(string[] args)
    {
        IMessageSender emailSender = new EmailSender();
        IMessageSender smsSender = new SmsSender();

        Message orderMessage = new OrderMessage(emailSender);
        orderMessage.Send("Order Confirmation", "Your order has been confirmed!");

        Message paymentMessage = new PaymentMessage(smsSender);
        paymentMessage.Send("Payment Confirmation", "Your payment has been received!");
    }
}