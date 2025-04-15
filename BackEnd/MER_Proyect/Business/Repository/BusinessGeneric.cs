using AutoMapper;
using Business.Interfaces;
using Data.Interfaces;

public abstract class BusinessGeneric<TDtoGet, TDto, TEntity> : IBusiness<TDtoGet, TDto>
    where TEntity : class
{
    private readonly IData<TEntity> _data;
    private readonly IMapper _mapper;

    public BusinessGeneric(IData<TEntity> data, IMapper mapper)
    {
        _data = data;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TDtoGet>> GetAllAsync()
    {
        var entities = await _data.GetAllAsync();
        return _mapper.Map<IEnumerable<TDtoGet>>(entities);
    }

    public async Task<TDtoGet?> GetByIdAsync(int id)
    {
        await ValidateIdAsync(id);
        var entity = await _data.GetByIdAsync(id);
        return entity == null ? default : _mapper.Map<TDtoGet>(entity);
    }

    public async Task<TDto> CreateAsync(TDto dto)
    {
        ValidateDto(dto);
        var entity = _mapper.Map<TEntity>(dto);
        var created = await _data.CreateAsync(entity);
        return _mapper.Map<TDto>(created);
    }

    public async Task<bool> UpdateAsync(TDto dto)
    {
        ValidateDto(dto);
        var entity = _mapper.Map<TEntity>(dto);
        return await _data.UpdateAsync(entity);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        await ValidateIdAsync(id);
        return await _data.DeleteAsync(id);
    }

    public async Task<bool> DeleteLogicAsync(int id)
    {
        await ValidateIdAsync(id);
        return await _data.DeleteLogicalAsync(id);
    }
    // Método para restaurar lógicamente una entidad
    public async Task<bool> RestoreLogicAsync(int id)
    {
        await ValidateIdAsync(id);
        return await _data.RestoreLogicalAsync(id);
    }

    protected abstract void ValidateDto(TDto dto);
    protected abstract Task ValidateIdAsync(int id);
}
