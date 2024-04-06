namespace SolidExamples.DependencyInversion;

public class PaymentProcessor
{
    public void ProcessPayment(string paymentDetails)
    {
        // Process the payment.
        Console.WriteLine("Processing payment.");
    }
}

public class NotificationService
{
    public void SendReceipt(string message)
    {
        // Send a receipt notification.
        Console.WriteLine("Sending receipt.");
    }
}

public class ShoppingCart
{
    private PaymentProcessor _paymentProcessor = new PaymentProcessor();
    private NotificationService _notificationService = new NotificationService();

    public void Checkout(string paymentDetails)
    {
        _paymentProcessor.ProcessPayment(paymentDetails);
        _notificationService.SendReceipt("Payment processed successfully.");
    }
}