
using Rabo_Test_FunctionApp.DTO;
using Rabo_Test_FunctionApp.Model;


namespace Rabo_Test_FunctionApp.Profile
{
    public  class UserProfile : AutoMapper.Profile
    {
        public UserProfile()
        {
            // Source -> Target
            CreateMap<User, UserDTO>();

        }
    }
}
