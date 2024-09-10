using DenuncieAqui.Domain.Entities;
using DenuncieAqui.Domain.Repositories;
using Microsoft.AspNetCore.Components.Authorization;

namespace DenuncieAqui.Application.UseCases.CommentUseCase;

public class CommentUseCase
{
    private readonly ICommentRepository _commentRepository;
    private readonly AuthenticationStateProvider _authenticationStateProvider;

    public CommentUseCase(ICommentRepository commentRepository, AuthenticationStateProvider authenticationStateProvider)
    {
        _commentRepository = commentRepository;
        _authenticationStateProvider = authenticationStateProvider;
    }

    public async Task<IEnumerable<Comment>> GetCommentsAsync()
    {
        var comments = await _commentRepository.GetListAsync();

        return comments;
    }

    public async Task<Comment?> GetAsync(Guid id)
    {
        var comment = await _commentRepository.GetAsync(id);

        return comment;
    }

    public async Task CreateCommentAsync(Guid reportId, string commentContent)
    {
        var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
        var user = authState.User;

        if (user.Identity == null || !user.Identity.IsAuthenticated)
        {
            throw new UnauthorizedAccessException("Usuário não autenticado.");
        }

        var userName = user.Identity.Name;

        var comments = new Comment
        {
            ReportId = reportId,
            UserName = userName,
            CommentContent = commentContent,
            CommentDate = DateTime.Now
        };

        await _commentRepository.AddAsync(comments);

    }

    public async Task DeleteCommentAsync(Guid id)
    {
        await _commentRepository.DeleteAsync(id);
    }

    public async Task<Comment> UpdateAsync(Comment comment)
    {
        var update = await _commentRepository.EditAsync(comment);
        return update;
    }
}

