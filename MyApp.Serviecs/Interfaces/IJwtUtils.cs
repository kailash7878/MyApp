using MyApp.Serviecs.RequestModel;

namespace MyApp.Serviecs.Interfaces
{
    public interface IJwtUtils
    {
        public string GenerateJwtToken(User user);
        public int? ValidateJwtToken(string? token);
    }
}
