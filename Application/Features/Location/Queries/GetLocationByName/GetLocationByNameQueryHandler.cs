using Application.Contracts.Persistence;
using Application.DTOs.Location;
using Application.Exceptions;
using Application.Features.Location.Queries.GetAllLocations;
using AutoMapper;
using MediatR;

namespace Application.Features.Location.Queries.GetLocationByName;

public class GetLocationByNameQueryHandler : IRequestHandler<GetLocationsByNameQuery, List<LocationResponseDto>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public GetLocationByNameQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<List<LocationResponseDto>> Handle(GetLocationsByNameQuery request, CancellationToken cancellationToken)
    {
        var locations = await _unitOfWork.LocationRepository.GetByName(request.LocationName);
        
        if (locations == null)
        {
            throw new NotFoundException(nameof(Location), request.LocationName);
        }
        return _mapper.Map<List<LocationResponseDto>>(locations);
    }
}