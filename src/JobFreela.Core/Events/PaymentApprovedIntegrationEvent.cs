namespace JobFreela.Core.Events;

public record PaymentApprovedIntegrationEvent
{
    public int IdProject { get; set; }
}
