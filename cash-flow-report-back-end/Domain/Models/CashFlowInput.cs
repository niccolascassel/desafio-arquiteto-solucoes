namespace CashFlowReport.API.Domain.Models;

public class CashFlowInput
{
    public long Id { get; set; }
    public string? Description { get; set; }
    public decimal Amount { get; set; }
    public DateTime InputDateTime { get; set; }
}