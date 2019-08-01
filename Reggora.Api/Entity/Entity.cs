using System.Collections.Generic;

namespace Reggora.Api.Entity
{
    public abstract class Entity
    {
        public readonly EntityField<string> Id;

        public readonly List<string> DirtyFields = new List<string>();

        public Entity()
        {
            BuildField(ref Id, nameof(Id));
        }

        protected void BuildField<T>(ref EntityField<T> field, string name)
        {
            field = new EntityField<T>(name, propertyName => DirtyFields.Add(propertyName));
        }
    }
}