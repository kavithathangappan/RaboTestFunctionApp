using Rabo_Test_FunctionApp.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rabo_Test_FunctionApp.Service
{
    public interface IUserService
    {
        Task<List<UserDTO>> FetchUsersAsync(DateTime lastModificationTime);
    }
}
