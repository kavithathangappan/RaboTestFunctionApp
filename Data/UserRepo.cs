using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Rabo_Test_FunctionApp.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabo_Test_FunctionApp.Data
{
    public class UserRepo : IUserRepo
    {
        private readonly ApplicationDbContext _context;

        public UserRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CreateUser(Model.User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            _context.Users.Add(user);
            SaveChanges();
        }

        public IEnumerable<Model.User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public Model.User GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(p => p.RecordId == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public Task<List<User>> FetchUsersAsync(DateTime lastModificationTime)
        {
            var users = new List<User>();

            using (var connection = _context.Database.GetDbConnection())
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "dbo.FetchUser";
                    command.CommandType = CommandType.StoredProcedure;

                    // add parameter to command, which will be passed to the stored procedure
                    command.Parameters.Add(new SqlParameter("@LastModificationTime", lastModificationTime));


                    // execute the command
                    using (var rdr = command.ExecuteReader())
                    {
                        // iterate through results, printing each to console
                        while (rdr.Read())
                        {
                            users.Add(
                                new User
                                {
                                    RecordId = rdr.GetInt32("RecordId"),
                                    UserId = rdr.GetInt32("UserId"),
                                    DataValue = rdr.GetString("DataValue"),
                                    Email = rdr.GetString("Email"),
                                    UserName = rdr.GetString("UserName")
                                });
                        }
                    }

                }
            }
            return Task.FromResult(users);
        }

    }
}
