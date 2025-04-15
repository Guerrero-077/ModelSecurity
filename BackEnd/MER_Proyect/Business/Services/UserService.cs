using AutoMapper;
using Data.Interfaces;
using Entity.DTOs;
using Entity.DTOs.Select;
using Entity.Model;
using Microsoft.Extensions.Logging;
using Utilities.Exceptions;

namespace Business.Services
{
    public class UserService : BusinessGeneric<UserSelectDto, UserDto, User>
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<UserService> _logger;
        private readonly IMapper _mapper;


        public UserService(IUserRepository userRepository, ILogger<UserService> logger, IMapper mapper)
            : base(userRepository, mapper)
        {
            _userRepository = userRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserSelectDto>> GetAllWithPersonAsync()
        {
            var users = await _userRepository.GetAllJoinAsync();
            return _mapper.Map<IEnumerable<UserSelectDto>>(users);
        }

        public async Task<UserSelectDto?> GetByIdWithPersonAsync(int id)
        {
            var user = await _userRepository.GetByIdJoinAsync(id);
            return _mapper.Map<UserSelectDto>(user);
        }


        protected override void ValidateDto(UserDto dto)
        {
            if (dto == null)
            {
                throw new ValidationException("El objeto User no puede ser nulo");
            }

            if (string.IsNullOrWhiteSpace(dto.user_name))
            {
                _logger.LogWarning("Se intentó crear/actualizar una User con UserName vacío");
                throw new ValidationException("first_name", "El UserName de la User es obligatorio");
            }
        }

        protected override async Task ValidateIdAsync(int id)
        {
            var entity = await _userRepository.GetByIdAsync(id);

            if (entity == null)
            {
                _logger.LogWarning($"Se intentó operar con un ID inválido: {id}");
                throw new EntityNotFoundException($"No se encontró una User con el ID {id}");
            }
        }
    }
}
