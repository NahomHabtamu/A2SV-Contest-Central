using Application.Contracts.Persistence;
using FluentValidation;

namespace Application.Features.Group.Commands.DeleteGroup;

public class DeleteGroupCommandValidator : AbstractValidator<DeleteGroupCommand>
{ 
    public DeleteGroupCommandValidator(IUnitOfWork unitOfWork)
    {
        RuleFor(x => x.GroupId)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull();
        
        // RuleFor(x => x.GroupId).MustAsync(async (id) =>
        //     {
        //         return await unitOfWork.A2SVGroupRepository.Exists(id);
        //     });
    }
}