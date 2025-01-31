using AutoMapper;
using CashFlowInputs.API.Application.DTOs;
using CashFlowInputs.API.Domain.Models;
using CashFlowInputs.API.Infraestructure.Repositories;

namespace CashFlowInputs.API.Application.Services;

public class CashFlowInputService : ICashFlowInputService
{
    private readonly ICashFlowInputRepository _cashflowInputRepository;
    private readonly IMapper _mapper;

    public CashFlowInputService(ICashFlowInputRepository cashflowInputRepository, IMapper mapper)
    {
        _cashflowInputRepository = cashflowInputRepository;
        _mapper = mapper;
    }

    public async Task<CashFlowInputDto> CreateCashFlowInputAsync(CashFlowInputDto dto)
    {
        var cashflowInput = new CashFlowInput
        {
            Description = dto.Description,
            Amount = dto.Amount,
            InputDateTime = dto.InputDateTime
        };

        var createdCashFlowInput = await _cashflowInputRepository.AddAsync(cashflowInput);

        return _mapper.Map<CashFlowInputDto>(createdCashFlowInput);
    }

    public async Task<CashFlowInputDto> UpdateCashFlowInputAsync(CashFlowInputDto dto)
    {
        var cashflowInput = await _cashflowInputRepository.GetByIdAsync(dto.Id);
                    
        cashflowInput.Description = dto.Description;
        cashflowInput.Amount = dto.Amount;
        cashflowInput.InputDateTime = dto.InputDateTime;

        var updatedCashFlowInput = await _cashflowInputRepository.UpdateAsync(cashflowInput);

        return _mapper.Map<CashFlowInputDto>(updatedCashFlowInput);
    }

    public async Task<bool> DeleteCashFlowInputAsync(long cashFlowInputId)
    {
        return await _cashflowInputRepository.DeleteAsync(cashFlowInputId);
    }

    public async Task<CashFlowInputDto> GetCashFlowInputByIdAsync(long cashFlowInputId)
    {
        var cashflowInput = await _cashflowInputRepository.GetByIdAsync(cashFlowInputId);
            
        return _mapper.Map<CashFlowInputDto>(cashflowInput);
    }
}