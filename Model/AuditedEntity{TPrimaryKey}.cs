using System;


namespace Rabo_Test_FunctionApp.Model
{
    public class AuditedEntity<TPrimaryKey> : Entity<TPrimaryKey>, IHasCreationTime, IHasModificationTime
    {
        public virtual DateTime CreationTime { get; set; }
        public virtual DateTime? LastModificationTime { get; set; }
    }
}
