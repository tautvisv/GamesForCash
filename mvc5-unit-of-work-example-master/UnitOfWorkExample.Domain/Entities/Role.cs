namespace UnitOfWorkExample.Domain.Entities
{
    public class Role : IEntity
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
    }
}
