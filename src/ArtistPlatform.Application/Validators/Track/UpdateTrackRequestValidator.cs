using ArtistPlatform.Application.DTOs.TrackDTOs;
using FluentValidation;

namespace ArtistPlatform.Application.Validators.Track
{
    public class UpdateTrackRequestValidator : AbstractValidator<UpdateTrackRequest>
    {
        public UpdateTrackRequestValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(100).WithMessage("Title cannot exceed 100 characters.");
            RuleFor(x => x.AudioUrl)
                .MaximumLength(200).WithMessage("Url cannot exceed 200 characters.");
        }
    }
}
