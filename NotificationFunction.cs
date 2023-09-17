using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Rabo_Test_FunctionApp.DTO;

namespace Rabo_Test_FunctionApp
{
    public class NotificationFunction
    {
        [FunctionName("NotificationFunction")]
        public async Task Run([ServiceBusTrigger("azqueuetest", Connection = "ServiceBusConnection")]Message message, ILogger log)
        {
            var result = Encoding.UTF8.GetString(message.Body);


            var users = JsonConvert.DeserializeObject<IEnumerable<UserDTO>>(result);

            log.LogInformation($"C# ServiceBus queue trigger function processed message: {message}");



        }
    }
}
