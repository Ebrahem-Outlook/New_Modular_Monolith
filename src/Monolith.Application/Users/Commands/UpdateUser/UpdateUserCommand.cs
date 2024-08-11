using Monolith.Application.Core.Abstractions.Authentication;
using Monolith.Application.Core.Abstractions.Data;
using Monolith.Application.Core.Abstractions.Messaging;
using Monolith.Domain.Users;

namespace Monolith.Application.Users.Commands.UpdateUser;

public sealed record UpdateUserCommand(
    Guid UserId, 
    string Name, 
    string Bio) : ICommand<string>;

internal sealed class UpdateUserCommandHandler : ICommandHandler<UpdateUserCommand, string>
{
    private readonly IUserIdentifierProvider _userIdentifierProvider;
    private readonly IUserRepository _userRepository;
    private readonly IJwtProvider _jwtProvider;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateUserCommandHandler(IUserIdentifierProvider userIdentifierProvider, IUserRepository userRepository, IJwtProvider jwtProvider, IUnitOfWork unitOfWork)
    {
        _userIdentifierProvider = userIdentifierProvider;
        _userRepository = userRepository;
        _jwtProvider = jwtProvider;
        _unitOfWork = unitOfWork;
    }

    public async Task<string> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        if(request.UserId != _userIdentifierProvider.UserId)
        {
            return "BadRequest";
        }

        User? user = await _userRepository.GetUserByIdAsync(request.UserId, cancellationToken);

        if (user is null)
        {
            return "User does not exsit...";
        }

        user.UpdateUser(request.Name, request.Bio);

        await _userRepository.UpdateAsync(user, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return "Success";
    }
}
