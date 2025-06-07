
namespace Hackathon2025.UI
{
    [Serializable]
    internal class NoConnectionStringRegisteredException : Exception
    {
        public NoConnectionStringRegisteredException() : base("Could not find a connection string for DefaultConnection in appSettings.json")
        {
        }

        public NoConnectionStringRegisteredException(string? message) : base(message)
        {
        }

        public NoConnectionStringRegisteredException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}