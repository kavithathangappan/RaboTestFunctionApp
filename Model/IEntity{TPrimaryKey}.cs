
namespace Rabo_Test_FunctionApp.Model
{
    public interface IEntity<TPrimaryKey>
    {
        TPrimaryKey RecordId { get; set; }
        bool IsTransient();
    }
}
