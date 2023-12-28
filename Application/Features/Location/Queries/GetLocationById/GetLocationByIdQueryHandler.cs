using Application.Contracts.Persistence;
using Application.DTOs.Location;
using Application.Exceptions;
using Application.Features.Location.Queries.GetAllLocations;
using AutoMapper;
using MediatR;

namespace Application.Features.Location.Queries.GetLocationById;

public class GetLocationByIdQueryHandler : IRequestHandler<GetLocationByIdQuery, LocationResponseDto>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public GetLocationByIdQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<LocationResponseDto> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
    {
        var location = await _unitOfWork.LocationRepository.GetByIdAsync(request.LocationId);
        
        if (location == null)
        {
            throw new NotFoundException(nameof(Location), request.LocationId);
        }   
        return _mapper.Map<LocationResponseDto>(location);
    }
}