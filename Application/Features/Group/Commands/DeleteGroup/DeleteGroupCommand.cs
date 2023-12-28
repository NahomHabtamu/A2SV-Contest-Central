using MediatR;

namespace Application.Features.Group.Commands.DeleteGroup;

public class DeleteGroupCommand : IRequest<Unit>
{
    public Guid GroupId { get; set; }
}