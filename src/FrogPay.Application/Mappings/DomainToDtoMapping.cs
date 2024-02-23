using AutoMapper;
using src.FrogPay.Application.DTOs;
using src.FrogPay.Domain.Entities;

namespace src.FrogPay.Application.Mappings;
public class DomainToDtoMapping : Profile
{
    public DomainToDtoMapping()
    {
        CreateMap<Pessoa, PessoaDto>();
        CreateMap<Pessoa, PessoaCriacaoDto>();
        CreateMap<Pessoa, PessoaEdicaoDto>();
        CreateMap<Endereco, EnderecoDto>();
        CreateMap<Loja, LojaDto>();
        CreateMap<DadosBancarios, DadosBancariosDto>();
    }
}