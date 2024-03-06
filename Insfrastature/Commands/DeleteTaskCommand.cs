using MediatR;

namespace MandrilAPI
{
    public record DeleteTaskCommand(int Id) : IRequest<bool>;

}