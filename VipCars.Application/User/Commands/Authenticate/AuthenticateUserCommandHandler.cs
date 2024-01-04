using MediatR;
using Microsoft.AspNetCore.Identity;
using VipCars.Domain.Exceptions;
using VipCars.Domain.Repositories;

namespace VipCars.Application.User.Commands.Authenticate;

public class AuthenticateUserCommandHandler : IRequestHandler<AuthenticateUserCommand, bool>
{
    private readonly IGenericRepository<Domain.Entities.User> _userRepository;
    private readonly IPasswordHasher<Domain.Entities.User> _passwordHasher;

    public AuthenticateUserCommandHandler(IGenericRepository<Domain.Entities.User> userRepository, IPasswordHasher<Domain.Entities.User> passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }
    
    public async Task<bool> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.FindAsync(x => x.Email == request.command.Email);
        if (user == null) return false;
        
        var result = _passwordHasher.VerifyHashedPassword(user,user.Password, request.command.Password);
        if (result != PasswordVerificationResult.Success) return false;
        return true;
    }
}