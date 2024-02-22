using AutoMapper;
using src.FrogPay.Application.DTOs;
using src.FrogPay.Domain.Entities;

namespace src.FrogPay.Application.Mappings;

public class DtoToDomainMapping : Profile
{
    public DtoToDomainMapping()
    {
        CreateMap<PessoaDto, Pessoa>();
    }
}