namespace CashFlowInputs.API.Application.DTOs;

public class CashFlowInputDto
{
    public long Id { get; set; }
    public string? Description { get; set; }
    public decimal Amount { get; set; }
    public DateTime InputDateTime { get; set; }
}