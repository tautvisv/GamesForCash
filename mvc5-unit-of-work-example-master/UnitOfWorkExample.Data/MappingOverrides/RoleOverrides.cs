using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using UnitOfWorkExample.Domain.Entities;

namespace UnitOfWorkExample.Data.MappingOverrides
{
    public class RoleOverrides : IAutoMappingOverride<Role>
    {
        public void Override(AutoMapping<Role> mapping)
        {
        }
    }
}
