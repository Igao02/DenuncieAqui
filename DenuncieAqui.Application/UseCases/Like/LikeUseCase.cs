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
        var likes = await _likeRepository.GetLikesAsync();

        return likes;
    }

    public async Task<Like?> GetLikeASync(Guid id)
    {
        var likes = await _likeRepository.GetAsync(id);

        return likes;
    }

    public async Task AddLikeAsync(Guid reportId)
    {
        var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
        var user = authState.User;

        if (user.Identity == null || !user.Identity.IsAuthenticated)
        {
            throw new UnauthorizedAccessException("Usuário não autenticado.");
        }

        var userName = user.Identity.Name;

        var like = new Like
        {
            LikeDate = DateTime.Now,
            UserName = userName,
            ReportId = reportId,
        };

        await _likeRepository.AddLikesAsync(like);

    }

    public async Task RemoveLike(Guid id)
    {
        await _likeRepository.RemoveLikesAsync(id);
    }

}

