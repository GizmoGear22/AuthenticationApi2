using Models;

namespace AuthenticationLayer
{
    public interface ITokenGeneration
    {
        string GenerateJSONToken(LoginModel model);
    }
}