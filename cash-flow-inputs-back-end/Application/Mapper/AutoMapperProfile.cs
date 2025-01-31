using AutoMapper;
using CashFlowInputs.API.Application.DTOs;
using CashFlowInputs.API.Domain.Models;

namespace CashFlowInputs.API.Application.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CashFlowInputDto, CashFlowInput>();
    }
}