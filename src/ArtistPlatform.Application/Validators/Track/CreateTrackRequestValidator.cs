using ArtistPlatform.Application.DTOs.TrackDTOs;
using FluentValidation;

namespace ArtistPlatform.Application.Validators.Track
{
    public class CreateTrackRequestValidator : AbstractValidator<CreateTrackRequest>
    {
        public CreateTrackRequestValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(100).WithMessage("Title cannot exceed 100 characters.");
            RuleFor(x => x.AudioUrl)
                .MaximumLength(200).WithMessage("Url cannot exceed 200 characters.");
            RuleFor(x => x.AlbumId)
                .NotEmpty().WithMessage("AlbumId is required.");
            RuleFor(x => x.ArtistId)
                .NotEmpty().WithMessage("ArtistId is required.");
        }
    }
}
