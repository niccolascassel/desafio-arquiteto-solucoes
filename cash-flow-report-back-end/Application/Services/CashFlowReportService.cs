using AutoMapper;
using CashFlowReport.API.Application.DTOs;
using CashFlowReport.API.Infraestructure.Repositories;

namespace CashFlowReport.API.Application.Services;

public class CashFlowReportService : ICashFlowReportService
{
    private readonly ICashFlowReportRepository _cashFlowReportRepository;
    private readonly IMapper _mapper;

    public CashFlowReportService(ICashFlowReportRepository cashFlowReportRepository, IMapper mapper)
    {
        _cashFlowReportRepository = cashFlowReportRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CashFlowInputDto>> GetCashFlowReportAsync(DateTime startDate, DateTime endDate)
    {
        startDate = startDate == default ? DateTime.MinValue : startDate;
        endDate = endDate == default ? DateTime.MaxValue : endDate;

        var cashflowInputs = await _cashFlowReportRepository.GetAllAsync(startDate, endDate);
        return _mapper.Map<IEnumerable<CashFlowInputDto>>(cashflowInputs);
    }
}