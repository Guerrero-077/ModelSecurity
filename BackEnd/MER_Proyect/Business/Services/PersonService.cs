using AutoMapper;
using Data.Interfaces;
using Entity.DTOs;
using Entity.DTOs.Select;
using Entity.Model;
using Microsoft.Extensions.Logging;
using Utilities.Exceptions;

namespace Business.Services
{
    public class PersonServices : BusinessGeneric<PersonSelectDto, PersonDto, Person>
    {
        public readonly IData<Person> _data;
        private readonly ILogger<PersonServices> _logger;

        public PersonServices(IData<Person> data, ILogger<PersonServices> logger, IMapper mapper)
            : base(data, mapper)
        {
            _logger = logger;
            _data = data;
        }


        protected override void ValidateDto(PersonDto dto)
        {
            if (dto == null)
            {
                throw new ValidationException("El objeto Person no puede ser nulo");
            }

            if (string.IsNullOrWhiteSpace(dto.first_name))
            {
                _logger.LogWarning("Se intentó crear/actualizar una persona con FirstName vacío");
                throw new ValidationException("first_name", "El FirstName de la persona es obligatorio");
            }
        }

        protected override async Task ValidateIdAsync(int id)
        {
            var entity = await _data.GetByIdAsync(id);

            if (entity == null)
            {
                _logger.LogWarning($"Se intentó operar con un ID inválido: {id}");
                throw new EntityNotFoundException($"No se encontró una persona con el ID {id}");
            }
        }
    }
}
