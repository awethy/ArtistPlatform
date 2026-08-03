using ArtistPlatform.Application.DTOs.ArtistDTOs;
using FluentValidation;


namespace ArtistPlatform.Application.Validators.Artist
{
    public class CreateArtistRequestValidator : AbstractValidator<CreateArtistRequest>
    {
        public CreateArtistRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");
            RuleFor(x => x.Bio)
                .MaximumLength(1000).WithMessage("Bio cannot exceed 1000 characters.");
        }
    }
}
