using ArtistPlatform.Application.DTOs.PostDTOs;
using FluentValidation;

namespace ArtistPlatform.Application.Validators.Post
{
    public class CreatePostRequestValidator : AbstractValidator<CreatePostRequest>
    {
        public CreatePostRequestValidator() 
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(200).WithMessage("Title cannot exceed 200 characters.");
            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Content is required.");
            RuleFor(x => x.ArtistId)
                .NotEmpty().WithMessage("ArtistId is required.");
        }
    }
}
