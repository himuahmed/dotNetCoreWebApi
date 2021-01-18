using System.Collections.Generic;
using System.Threading.Tasks;
using dotNetCoreWebApi.Models;

namespace dotNetCoreWebApi.Repository
{
    public interface IDatingRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<User> GetUser(int id);
        Task<IEnumerable<User>> GetUsers();
        Task<bool> SaveAll();
    }
}