using Monolith.Application.Core.Abstractions.Authentication;
using Monolith.Application.Core.Abstractions.Data;
using Monolith.Application.Core.Abstractions.Messaging;
using Monolith.Domain.Users;

namespace Monolith.Application.Users.Commands.CreateUser;

internal sealed class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, string>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtProvider _jwtProvider;
    private readonly IUnitOfWork _unitOfWork;

    public CreateUserCommandHandler(IUserRepository userRepository, IJwtProvider jwtProvider, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _jwtProvider = jwtProvider;
        _unitOfWork = unitOfWork;
    }

    public async Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        bool IsEmailUnique = await _userRepository.IsEmailUniqueAsync(request.Email, cancellationToken);

        if(!IsEmailUnique)
        {
            return string.Empty;
        }

        User user = User.Create(request.Name, request.Bio, request.UserName, request.Email, request.Password);    

        await _userRepository.AddAsync(user, cancellationToken);

        string token = _jwtProvider.GenerateToken(user);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return token;
    }
}
