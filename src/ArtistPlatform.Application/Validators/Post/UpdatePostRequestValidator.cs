using ArtistPlatform.Application.DTOs.PostDTOs;
using FluentValidation;

namespace ArtistPlatform.Application.Validators.Post
{
    public class UpdatePostRequestValidator : AbstractValidator<UpdatePostRequest>
    {
        public UpdatePostRequestValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(200).WithMessage("Title cannot exceed 200 characters.");
            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Content is required.");
        }
    }
}
