using MyApp.Serviecs.Interfaces;
using MyApp.Serviecs.RequestModel;
using MyApp.Serviecs.ResponseServiceModel;

namespace MyApp.Serviecs.Services
{
    public class UserServices : IUserService
    {
        public AuthenticateResponse? Authenticate(AuthenticateRequest model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User? GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
