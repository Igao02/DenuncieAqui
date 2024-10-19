namespace DenuncieAqui.Domain.Repositories;

public interface IInstitutionRepository
{
    Task<Institution?> GetAsync(Guid id);

    Task<Institution> AddAsync(Institution institution);

    Task<Institution> EditAsync(Institution institution);

    Task DeleteAsync(Guid id);
}
