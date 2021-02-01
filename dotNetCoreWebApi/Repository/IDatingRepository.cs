using System.Collections.Generic;
using System.Threading.Tasks;
using dotNetCoreWebApi.Helpers;
using dotNetCoreWebApi.Models;

namespace dotNetCoreWebApi.Repository
{
    public interface IDatingRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<User> GetUser(int id);
        Task<PagedList<User>> GetUsers(UserParams userParams);
        Task<bool> SaveAll();
        Task<Like> GetLike(int userId, int recipientId);
    }
}