using Application.Contracts.Persistence;
using Application.Exceptions;
using AutoMapper;
using MediatR;

namespace Application.Features.Group.Commands.DeleteGroup;

public class DeleteGroupCommandHandler : IRequestHandler<DeleteGroupCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DeleteGroupCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(DeleteGroupCommand request, CancellationToken cancellationToken)
    {
        var group = await _unitOfWork.A2SVGroupRepository.GetByIdAsync(request.GroupId);
        
        if (group == null)
        {
            throw new NotFoundException(nameof(Group), request.GroupId);
        }
        
        await _unitOfWork.A2SVGroupRepository.DeleteAsync(group.Id);
        return Unit.Value;
        
    }
}