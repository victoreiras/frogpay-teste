using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.FrogPay.Application.DTOs
{
    public class PessoaEdicaoDto
    {
        public Guid Id { get; set; }
        public PessoaDto PessoaDto { get; set; } 
    }
}