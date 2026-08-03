namespace ArtistPlatform.Application.Exceptions
{
    public class NotFoundExceptions : Exception
    {   
        public NotFoundExceptions(string entityName, Guid id) 
            : base($"The requested resource '{entityName}' with ID '{id}' was not found.")
        {
        }

        public NotFoundExceptions(string message) 
            : base(message)
        {
        }
    }
}
