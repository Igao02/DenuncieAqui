using DenuncieAqui.Domain.Entities;
using DenuncieAqui.Domain.Repositories;
using Microsoft.AspNetCore.Components.Authorization;

namespace DenuncieAqui.Application.UseCases.LikeUseCase;

public class LikeUseCase
{
    private readonly ILikeRepository _likeRepository;
    private readonly AuthenticationStateProvider _authenticationStateProvider;

    public LikeUseCase(ILikeRepository likeRepository, AuthenticationStateProvider authenticationStateProvider)
    {
        _likeRepository = likeRepository;
        _authenticationStateProvider = authenticationStateProvider;
    }

    public async Task<IEnumerable<Like>> GetLikesAsync()
    {
        return await _likeRepository.GetLikesAsync();
    }

    public async Task<Like?> GetLikeAsync(Guid id)
    {
        return await _likeRepository.GetAsync(id);
    }

    public async Task AddOrRemoveLikeAsync(Guid reportId)
    {
        var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
        var user = authState.User;

        if (user.Identity == null || !user.Identity.IsAuthenticated)
        {
            throw new UnauthorizedAccessException("Usuário não autenticado.");
        }

        var userName = user.Identity.Name;

        var existingLike = await _likeRepository.GetUserLikeAsync(userName, reportId);

        if (existingLike != null)
        {
            await _likeRepository.RemoveLikesAsync(existingLike.Id);
        }
        else
        {
            var newLike = new Like
            {
                LikeDate = DateTime.Now,
                UserName = userName,
                ReportId = reportId,
            };

            await _likeRepository.AddLikesAsync(newLike);
        }
    }

    public async Task RemoveLike(Guid id)
    {
        await _likeRepository.RemoveLikesAsync(id);
    }
}
