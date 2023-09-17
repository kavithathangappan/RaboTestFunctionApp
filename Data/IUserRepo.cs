using Rabo_Test_FunctionApp.Model;
using System;
using System.Collections.Generic;

using System.Threading.Tasks;

namespace Rabo_Test_FunctionApp.Data
{
    public interface IUserRepo
    {
        bool SaveChanges();

        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
        void CreateUser(User plat);
        Task<List<User>> FetchUsersAsync(DateTime lastModificationTime);
    }
}
