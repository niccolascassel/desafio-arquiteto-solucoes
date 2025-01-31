using CashFlowReport.API.Infraestructure.DBContext;
using CashFlowReport.API.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CashFlowReport.API.Infraestructure.Repositories;

public class CashFlowReportRepository : ICashFlowReportRepository
{
    private readonly CashFlowReportDbContext _context;

    public CashFlowReportRepository(CashFlowReportDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<CashFlowInput>> GetAllAsync(DateTime startDate, DateTime endDate)
    {
        return await _context.CashFlowInput
            .Where(c =>
                c.InputDateTime >= startDate && 
                c.InputDateTime <= endDate
            )
            .ToListAsync();
    }
}