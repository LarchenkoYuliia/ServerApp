using System.Data;

namespace ServerApp.Helper
{
    public class ManageHelper
    {
        private IUserRepository _userRepository;

        public ManageHelper()
        {
            _userRepository = new UserRepository();
        }

        public User Retrieve(int userId)
        {
            return _userRepository.Retrieve(userId);
        }

        public User Retrieve(string login)
        {
            return _userRepository.Retrieve(login);
        }

        public string RetrieveName(string login)
        {
             return _userRepository.RetrieveName(login);
        }

        public bool CheckUser(string login, string password)
        {
            return _userRepository.CheckUser(login, password);
        }

        public DataTable Retrieve()
        {
            return _userRepository.Retrieve();
        }

        public bool Create(User user)
        {
            return _userRepository.Create(user);
        }

        public void Delete(string login)
        {
            _userRepository.Delete(login);
        }
    }
}
