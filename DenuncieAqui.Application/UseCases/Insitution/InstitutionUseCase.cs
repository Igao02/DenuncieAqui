using DenuncieAqui.Domain.Repositories;
using DenuncieAqui.Infrastructure.Data;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace DenuncieAqui.Application.UseCases.InstitutionUseCase;

public class InstitutionUseCase
{
    private readonly IInstitutionRepository _institutionRepository;
    private readonly ApplicationDbContext _context;
    private readonly AuthenticationStateProvider _authenticationStateProvider;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public InstitutionUseCase(IInstitutionRepository institutionRepository, ApplicationDbContext context, AuthenticationStateProvider authenticationStateProvider, UserManager<ApplicationUser> userManager, IServiceScopeFactory serviceScopeFactory)
    {
        _institutionRepository = institutionRepository;
        _authenticationStateProvider = authenticationStateProvider;
        _context = context;
        _userManager = userManager;
        _serviceScopeFactory = serviceScopeFactory;
    }

    public async Task<IEnumerable<Institution>> GetInstitutionsAsync()
    {
        return await _institutionRepository.GetListAsync();
    }

    public async Task<Institution?> GetAsync(Guid id)
    {
        return await _institutionRepository.GetAsync(id);
    }

    public async Task<Institution> CreateInstitutionAsync(Institution institution, string corporateName, string document, string cep, string street, int numHome, string complement, string neighborhood, string uf)
    {
        var existingInstName = await _institutionRepository.GetByNameAsync(institution.CorporateName);

        if (existingInstName != null)
        {
            throw new InvalidOperationException("Uma instituição com esse nome já existe");
        }

        var existingInstDoc = await _institutionRepository.GetByDocAsync(institution.Document);

        if (existingInstDoc != null)
        {
            throw new InvalidOperationException("Uma instituição com esse documento já existe");
        }

        var userName = await GetAuthenticatedUserNameAsync();

        var institutions = new Institution
        {
            CorporateName = corporateName,
            Document = document,
            Cep = cep,
            Street = street,
            NumHome = numHome,
            CreationDate = DateTime.Now,
            UserName = userName,
            Complement = complement,
            Neighborhood = neighborhood,
            Uf = uf 
        };

        var createInstitution = await _institutionRepository.AddAsync(institutions);

        await CheckAndAssignPartnerRoleAsync(userName);

        return createInstitution;
    }

    public async Task DeleteInstitution(Guid id)
    {
        await _institutionRepository.DeleteAsync(id);
    }

    public async Task<Institution> UpdateAsync(Institution institution)
    {
        return await _institutionRepository.EditAsync(institution);
    }

    private async Task<string> GetAuthenticatedUserNameAsync()
    {
        var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
        var user = authState.User;

        if (user.Identity == null || !user.Identity.IsAuthenticated)
        {
            throw new UnauthorizedAccessException("Usuário não autenticado.");
        }

        return user.Identity.Name!;
    }

    private async Task CheckAndAssignPartnerRoleAsync(string userName)
    {
        var appUser = await _userManager.FindByNameAsync(userName);
        if (appUser == null)
        {
            throw new Exception("Usuário não encontrado.");
        }

        if (!await _userManager.IsInRoleAsync(appUser, "PARTNER"))
        {
            var roleResult = await _userManager.AddToRoleAsync(appUser, "PARTNER");
            if (!roleResult.Succeeded)
            {
                throw new Exception("Erro ao adicionar a role PARTNER ao usuário.");
            }
        }
    }

    public async Task<bool> CheckIfUserIsPartnerAsync()
    {
        bool _isPartner = false;

        var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
        var user = authState.User;

        if (user.Identity != null && user.Identity.IsAuthenticated)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            var appUser = await userManager.GetUserAsync(user);
            _isPartner = await userManager.IsInRoleAsync(appUser!, "PARTNER");
        }

        return _isPartner;
    }
}
