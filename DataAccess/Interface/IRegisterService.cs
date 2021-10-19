using DataAccess.Entities;

namespace DataAccess.Services
{
    public interface IRegisterService
    {
        void Insert(UserToAdd _obj);
    }
}