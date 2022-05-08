namespace My.Simple.Web.API.Interfaces
{
    public interface IJWTManager
    {
        string Authenticate(string userId, string password);
    }
}
