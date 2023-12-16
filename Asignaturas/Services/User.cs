using Asignaturas.Services.Interfaces;

namespace Asignaturas.Services
{
    public class User : IUser
    {
        private readonly ILogger<User> _logger;
        private readonly AsignaturesContext _dbContext;
        public User(ILogger<User> logger, AsignaturesContext dbContext)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public List<Models.User> Get()
        {
            List<Models.User> result = null;
            try
            {
                result = _dbContext.Users.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"error obteniendo data de user {ex.Message}");
            }
            return result;
        }

        public List<Models.User> GetUserByIdeentification(int identification)
        {
            List<Asignaturas.Models.User> result = null;
            try
            {
                result = _dbContext.Users.Where(x => x.IdentificationNumber == identification).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"error obteniendo data de user {ex.Message.ToString()}");
            }
            return result;
        }

        public bool CreateUser(Models.User user)
        {
            bool result = false;
            try
            {
                user.UserId = Guid.NewGuid();
                _dbContext.Users.Add(user);
                _dbContext.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"error obteniendo data de user {ex.Message.ToString()}");
            }
            return result;
        }

        public bool DeleteUser(Guid id)
        {
            bool result = false;
            try
            {
                Models.User user = _dbContext.Users.Find(id);
                if (user != null)
                {
                    _dbContext.Users.Remove(user);
                    _dbContext.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"error obteniendo data de user {ex.Message.ToString()}");
            }
            return result;
        }
    }
}
