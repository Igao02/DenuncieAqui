using DenuncieAqui.Domain.Repositories;
using DenuncieAqui.Infrastructure.Data;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Net.Sockets;
using System.Reflection.Metadata;

namespace DenuncieAqui.Application.UseCases.InstitutionUseCase;

public class InstitutionUseCase
{
    private readonly IInstitutionRepository _institutionRepository;
    private readonly ApplicationDbContext _context;
    private readonly AuthenticationStateProvider _authenticationStateProvider;
    private readonly UserManager<ApplicationUser> _userManager;

    public InstitutionUseCase(IInstitutionRepository institutionRepository, ApplicationDbContext context, AuthenticationStateProvider authenticationStateProvider, UserManager<ApplicationUser> userManager)
    {
        _institutionRepository = institutionRepository;
        _authenticationStateProvider = authenticationStateProvider;
        _context = context;
        _userManager = userManager;
    }

    public async Task<IEnumerable<Institution>> GetInstitutionsAsync()
    {
        var institutions = await _institutionRepository.GetListAsync();

        return institutions;
    }

    public async Task<Institution?> GetAsync(Guid id)
    {
        var institution = await _institutionRepository.GetAsync(id);

        return institution;
    }

    public async Task<Institution> CreateInstitutionAsync(Institution institution, string corporateName, string document, string address)
    {
        var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
        var user = authState.User;

        if (user.Identity == null || !user.Identity.IsAuthenticated)
        {
            throw new UnauthorizedAccessException("Usuário não autenticado.");
        }

        var userName = user.Identity.Name;

        // Cria a nova instituição
        var institutions = new Institution
        {
            CorporateName = corporateName,
            Document = document,
            Address = address,
            CreationDate = DateTime.Now,
            UserName = userName!
        };

        // Salva a instituição no banco de dados
        var createInstitution = await _institutionRepository.AddAsync(institutions);

        // Obtém o usuário atual pelo UserManager
        var appUser = await _userManager.FindByNameAsync(userName);
        if (appUser == null)
        {
            throw new Exception("Usuário não encontrado.");
        }

        // Verifica se o usuário já possui a role "PARTNER"
        if (!await _userManager.IsInRoleAsync(appUser, "PARTNER"))
        {
            // Adiciona a role "PARTNER" ao usuário
            var roleResult = await _userManager.AddToRoleAsync(appUser, "PARTNER");
            if (!roleResult.Succeeded)
            {
                throw new Exception("Erro ao adicionar a role PARTNER ao usuário.");
            }
        }

        return createInstitution;
    }


    public async Task DeleteInstitution(Guid id)
    {
        await _institutionRepository.DeleteAsync(id);
    }

    public async Task<Institution> UpdateAsync(Institution institution)
    {
        var update = await _institutionRepository.EditAsync(institution);

        return update;
    }

}
