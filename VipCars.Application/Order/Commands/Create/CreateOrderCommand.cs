using MediatR;
using VipCars.Application.Order.Dto;

namespace VipCars.Application.Order.Commands.Create;

public record CreateOrderCommand(CreateOrderDto order) : IRequest<int>;
