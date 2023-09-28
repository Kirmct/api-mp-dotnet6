using Api01.Application.DTOs;
using Api01.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api01.Application.Mappings
{
    public class DtoToDomainMapping : Profile
    {
        public DtoToDomainMapping() 
        {
            CreateMap<PersonDTO, Person>();
            CreateMap<ProductDTO, Product>();

        }
    }
}
