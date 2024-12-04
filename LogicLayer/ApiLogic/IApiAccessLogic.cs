using Models;

namespace LogicLayer.ApiLogic
{
    public interface IApiAccessLogic
    {
        Task AddUser(NewUserModel model);
    }
}