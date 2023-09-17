

namespace Rabo_Test_FunctionApp.Model
{

    public  class User :AuditedEntity<int>
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email  { get; set; }
        public string DataValue { get; set; }

    }
}
