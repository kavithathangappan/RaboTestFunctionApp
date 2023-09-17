
using System;

using System.Threading.Tasks;

using Xunit;

using Rabo_Test_FunctionApp.Data;
using Moq;
using Rabo_Test_FunctionApp.Model;

using Rabo_Test_FunctionApp.Service;
using Rabo_Test_FunctionApp.DTO;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace Rabo_Test_FunctionApp.Test
{

    public class FunctionsTests
    {
        [Fact]
        public async Task FetchUsers_Returns_UserListDto()
        {
            var mockRepository = new Mock<IUserRepo>();
            var mockMapper = new Mock<IMapper>();

            var userList = new List<User>
            {
                new User { UserId = 1, UserName = "test1", Email = "testemail", DataValue = "testdata" , LastModificationTime = DateTime.Now }
            };

            var userDtoList = new List<UserDTO>
            {
                new UserDTO { UserId = 1, UserName = "test1", Email = "testemail", DataValue = "testdata" }
            };
            var mock = new Mock<UserRepo>();

            mockMapper.Setup(x => x.Map<List<UserDTO>>(It.IsAny<List<User>>()))
                .Returns(userDtoList);


            mockRepository.Setup(x => x.FetchUsersAsync(It.IsAny<DateTime>()))
              .Returns(Task.FromResult(userList));

            var instance = new UserService(mockRepository.Object, mockMapper.Object);

            var actual = await instance.FetchUsersAsync(DateTime.Now);


            //Assert  
            Assert.NotNull(instance);

            Assert.Equal(userList.FirstOrDefault().UserId, actual.FirstOrDefault().UserId);
        }

        [Fact]
        public async Task FetchUsers_Returns_Null()
        {
            var mockRepository = new Mock<IUserRepo>();
            var mockMapper = new Mock<IMapper>();

            var userList = new List<User>();

  
            var mock = new Mock<UserRepo>();

          

            mockRepository.Setup(x => x.FetchUsersAsync(It.IsAny<DateTime>()))
                        .Returns(Task.FromResult(userList));

            var instance = new UserService(mockRepository.Object, mockMapper.Object);

            var actual = await instance.FetchUsersAsync(DateTime.Now.AddDays(1));


            //Assert  
            Assert.Null(actual);


       
        }

    }
}