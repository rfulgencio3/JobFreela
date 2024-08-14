using JobFreela.Core.DTOs;
using JobFreela.Core.Services;
using System.Text;
using System.Text.Json;

namespace JobFreela.Infra.Payments;

public class PaymentService : IPaymentService
{
    private readonly IMessageBusService _service;
    private const string QUEUE_NAME = "payments";
    public PaymentService(IMessageBusService service)
    {
        _service = service;
    }
    public void ProcessPayment(PaymentInfoDTO paymentInfoDTO)
    {
        //Implementação de gateway de pagamento
        var paymentInfoJson = JsonSerializer.Serialize(paymentInfoDTO);
        var paymentInfoBytes = Encoding.UTF8.GetBytes(paymentInfoJson);

        _service.Publish(QUEUE_NAME, paymentInfoBytes);
    }
}
