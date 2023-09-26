using Api01.Application.DTOs;
using Api01.Application.DTOs.Validations;
using Api01.Application.Services.Interfaces;
using Api01.Domain.Entities;
using Api01.Domain.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api01.Application.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public PersonService(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<ResultService<PersonDTO>> CreateAsync(PersonDTO personDTO)
        {
            if(personDTO == null)
            {
                return ResultService.Fail <PersonDTO>("Objeto deve ser informado");
            }

            var result = new PersonDTOValidator().Validate(personDTO);
            if (!result.IsValid) 
                return ResultService.RequestError<PersonDTO>("Problemas de validade!", result);

            var person = _mapper.Map<Person>(personDTO);
            var data = await _personRepository.CreateAsync(person);

            return ResultService.Ok<PersonDTO>(_mapper.Map<PersonDTO>(data));
        }
    }
}
