using CashFlowReport.API.Domain.Models;

namespace CashFlowReport.API.Infraestructure.Repositories;

public interface ICashFlowReportRepository
{
    Task<IEnumerable<CashFlowInput>> GetAllAsync(DateTime startDate, DateTime endDate);
}