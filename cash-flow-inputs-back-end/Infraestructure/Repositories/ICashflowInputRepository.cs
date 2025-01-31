using CashFlowInputs.API.Domain.Models;

namespace CashFlowInputs.API.Infraestructure.Repositories;

public interface ICashFlowInputRepository
{
    Task<CashFlowInput> AddAsync(CashFlowInput cashflowInput);
    Task<CashFlowInput> UpdateAsync(CashFlowInput cashflowInput);
    Task<bool> DeleteAsync(long cashflowInputId);
    Task<CashFlowInput?> GetByIdAsync(long cashflowInputId);
}