namespace Asignaturas.Services.Interfaces
{
    public interface IUser
    {
        public List<Asignaturas.Models.User> Get();
        public List<Asignaturas.Models.User> GetUserByIdeentification(int identification);

        public bool CreateUser(Models.User user);
        public bool DeleteUser(Guid id);
    }
}
