using ArtistPlatform.Application.DTOs.AlbumDTOs;
using FluentValidation;

namespace ArtistPlatform.Application.Validators.Album
{
    public class UpdateAlbumRequestValidator : AbstractValidator<UpdateAlbumRequest>
    {
        public UpdateAlbumRequestValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(100).WithMessage("Title cannot exceed 100 characters.");
            RuleFor(x => x.CoverUrl)
                .MaximumLength(200).WithMessage("Url cannot exceed 200 characters.");
        }
    }
}
