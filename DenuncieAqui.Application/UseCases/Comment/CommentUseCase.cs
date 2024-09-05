using DenuncieAqui.Domain.Entities;
using DenuncieAqui.Domain.Repositories;

namespace DenuncieAqui.Application.UseCases.CommentUseCase;

public class CommentUseCase
{
    private readonly ICommentRepository _commentRepository;

    public CommentUseCase(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
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

    public async Task<Comment> CreateAsync(Comment comment)
    {
        var createComment = await _commentRepository.AddAsync(comment);

        return createComment;
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

