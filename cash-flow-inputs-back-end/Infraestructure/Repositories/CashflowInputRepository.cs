using CashFlowInputs.API.Infraestructure.DBContext;
using CashFlowInputs.API.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CashFlowInputs.API.Infraestructure.Repositories;

public class CashFlowInputRepository : ICashFlowInputRepository
{
    private readonly CashFlowInputsDbContext _context;

    public CashFlowInputRepository(CashFlowInputsDbContext context)
    {
        _context = context;
    }

    public async Task<CashFlowInput> AddAsync(CashFlowInput cashflowInput)
    {
        _context.CashFlowInputs.Add(cashflowInput);
        await _context.SaveChangesAsync();
        return cashflowInput;
    }

    public async Task<CashFlowInput> UpdateAsync(CashFlowInput cashflowInput)
    {
        _context.CashFlowInputs.Update(cashflowInput);
        await _context.SaveChangesAsync();
        return cashflowInput;
    }

    public async Task<bool> DeleteAsync(long cashflowInputId)
    {
        var transaction = await _context.CashFlowInputs
            .FirstOrDefaultAsync(t => t.Id == cashflowInputId);

        if (transaction == null)
        {
            return false;
        }

        _context.CashFlowInputs.Remove(transaction);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<CashFlowInput?> GetByIdAsync(long cashflowInputId)
    {
        return await _context.CashFlowInputs
            .FirstOrDefaultAsync(t => t.Id == cashflowInputId);
    }
}