using AutoMapper;
using CashFlowReport.API.Application.DTOs;
using CashFlowReport.API.Domain.Models;

namespace CashFlowReport.API.Application.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CashFlowInputDto, CashFlowInput>();
    }
}