using Application.Contracts.Persistence;
using Application.Exceptions;
using Application.Features.Group.Commands.DeleteGroup;
using AutoMapper;
using MediatR;

namespace Application.Features.Location.Commands.DeleteLocation;

public class DeleteLocationCommandHandler : IRequestHandler<DeleteLocationCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DeleteLocationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(DeleteLocationCommand request, CancellationToken cancellationToken)
    {
        var group = await _unitOfWork.A2SVGroupRepository.GetByIdAsync(request.LocationId);
        
        if (group == null)
        {
            throw new NotFoundException(nameof(Group), request.LocationId);
        }
        
        await _unitOfWork.A2SVGroupRepository.DeleteAsync(group.Id);
        return Unit.Value;
        
    }
}