using CashFlowReport.API.Application.DTOs;

namespace CashFlowReport.API.Application.Services;

public interface ICashFlowReportService
{
    Task<IEnumerable<CashFlowInputDto>> GetCashFlowReportAsync(DateTime startDate, DateTime endDate);
}