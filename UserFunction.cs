using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Rabo_Test_FunctionApp.DTO;
using Rabo_Test_FunctionApp.Service;

namespace Rabo_Test_FunctionApp
{
    
    public class UserFunction
    {
        private readonly IUserService _userService;
        private readonly ServiceBusClient _serviceBusClient;
        public UserFunction(IUserService userService, ServiceBusClient serviceBusClient)
        {
            _userService = userService;
            _serviceBusClient = serviceBusClient;
        }

        [FunctionName("UserFunction")]

        public  async Task Run([TimerTrigger("0 */1 * * * *")]TimerInfo myTimer, ILogger log)
        {

            
            try
            {
                var userList = await _userService.FetchUsersAsync(DateTime.Now);

                await SendMessage(userList);

                log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            }
            catch (Exception ex)
            {
                log.LogError(ex, "An error occurred while connecting to the SQL database.");
                throw;
            }
        }
        private async Task SendMessage(List<UserDTO> users)
        {
            //string sbConnectionString = Environment.GetEnvironmentVariable("ServiceBusConnection");
            string queueName = Environment.GetEnvironmentVariable("QueueName");

            // create the sender
            ServiceBusSender sender = _serviceBusClient.CreateSender(queueName);

            string json = JsonConvert.SerializeObject(users);

            // create a message that we can send. UTF-8 encoding is used when providing a string.
            ServiceBusMessage message = new ServiceBusMessage(Encoding.UTF8.GetBytes(json));

            // send the message
            await sender.SendMessageAsync(message);

        }
    }
}
