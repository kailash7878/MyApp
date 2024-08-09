using MyApp.Serviecs.RequestModel;
using MyApp.Serviecs.ResponseServiceModel;

namespace MyApp.Serviecs.Interfaces
{
    public interface IUserService
    {
        AuthenticateResponse? Authenticate(AuthenticateRequest model);
        IEnumerable<User> GetAll();
        User? GetById(int id);
    }
}
