using MediatR;

namespace Application.Features.Location.Commands.DeleteLocation;

public class DeleteLocationCommand : IRequest<Unit>
{
    public Guid LocationId { get; set; }
}