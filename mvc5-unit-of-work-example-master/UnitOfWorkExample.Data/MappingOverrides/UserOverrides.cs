using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using UnitOfWorkExample.Domain.Entities;

namespace UnitOfWorkExample.Data.MappingOverrides
{
    public class UserOverrides : IAutoMappingOverride<User>
    {
        public void Override(AutoMapping<User> mapping)
        {
        }
    }
}
