using MediatR;
using VipCars.Domain.Commands;

namespace VipCars.Application.User.Commands.Authenticate;

public record AuthenticateUserCommand(LoginCommand command) : IRequest<bool>;
