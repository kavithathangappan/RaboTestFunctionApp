using AutoMapper;
using Rabo_Test_FunctionApp.Data;
using Rabo_Test_FunctionApp.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Rabo_Test_FunctionApp.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;
        private readonly IMapper _mapper;

        public UserService(IUserRepo userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;

        }
        public async Task<List<UserDTO>> FetchUsersAsync(DateTime lastModificationTime)
        {
            var users = await _userRepo.FetchUsersAsync(lastModificationTime);

            return _mapper.Map<List<UserDTO>>(users);
        }

    }

}