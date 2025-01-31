using CashFlowInputs.API.Application.DTOs;

namespace CashFlowInputs.API.Application.Services;

public interface ICashFlowInputService
{
    Task<CashFlowInputDto> CreateCashFlowInputAsync(CashFlowInputDto dto);
    Task<CashFlowInputDto> UpdateCashFlowInputAsync(CashFlowInputDto dto);
    Task<bool> DeleteCashFlowInputAsync(long cashFlowInputId);
    Task<CashFlowInputDto> GetCashFlowInputByIdAsync(long cashFlowInputId);
}