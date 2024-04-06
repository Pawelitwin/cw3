namespace SolidExamples.DependencyInversion;

public interface IPaymentProcessor
{
    void ProcessPayment(string paymentDetails);
}

public interface INotificationService
{
    void SendReceipt(string message);
}

public class PaymentProcessor : IPaymentProcessor
{
    public void ProcessPayment(string paymentDetails)
    {
        // Process the payment.
        Console.WriteLine("Processing payment.");
    }
}

public class NotificationService : INotificationService
{
    public void SendReceipt(string message)
    {
        // Send a receipt notification.
        Console.WriteLine("Sending receipt.");
    }
}

public class ShoppingCart
{
    private IPaymentProcessor _paymentProcessor;
    private INotificationService _notificationService;

    public ShoppingCart(IPaymentProcessor paymentProcessor, INotificationService notificationService)
    {
        _paymentProcessor = paymentProcessor;
        _notificationService = notificationService;
    }

    public void Checkout(string paymentDetails)
    {
        _paymentProcessor.ProcessPayment(paymentDetails);
        _notificationService.SendReceipt("Payment processed successfully.");
    }
}