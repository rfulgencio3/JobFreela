using JobFreela.Core.DTOs;

namespace JobFreela.Core.Services;

public interface IPaymentService
{
    void ProcessPayment(PaymentInfoDTO paymentInfoDTO);
}
