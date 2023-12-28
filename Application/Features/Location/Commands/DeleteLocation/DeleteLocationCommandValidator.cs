using Application.Contracts.Persistence;
using Application.Features.Group.Commands.DeleteGroup;
using FluentValidation;

namespace Application.Features.Location.Commands.DeleteLocation;

public class DeleteLocationCommandValidator : AbstractValidator<DeleteLocationCommand>
{ 
    public DeleteLocationCommandValidator(IUnitOfWork unitOfWork)
    {
        RuleFor(x => x.LocationId)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull();
        
        // RuleFor(x => x.GroupId).MustAsync(async (id) =>
        //     {
        //         return await unitOfWork.A2SVGroupRepository.Exists(id);
        //     });
    }
}