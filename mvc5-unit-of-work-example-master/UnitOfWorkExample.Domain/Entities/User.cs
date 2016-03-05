namespace UnitOfWorkExample.Domain.Entities
{
    public class User : IEntity
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Password { get; set; }
    }
}
