using System.Collections.Generic;
using System.Linq;
using Reggora.Api.Storage;

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

        public bool Dirty()
        {
            return DirtyFields.Any();
        }

        public void Clean()
        {
            DirtyFields.Clear();
        }

        protected void BuildField<T>(ref EntityField<T> field, string name)
        {
            field = new EntityField<T>(name, propertyName => DirtyFields.Add(propertyName));
        }

        protected void BuildRelationship<E>(ref EntityRelationship<E> relationship)
            where E : Entity, new()
        {
            relationship = new EntityRelationship<E>(new E());
        }

        protected void BuildManyRelationship<E, C, S>(ref EntityManyRelationship<E, C, S> relationship)
            where E : Entity
            where C : ApiClient<C>
            where S : Storage<E, C>, new()
        {
            relationship = new EntityManyRelationship<E, C, S>();
        }
    }
}