using System.Collections.Generic;
using System.Linq;
using Reggora.Api.Storage;

namespace Reggora.Api.Entity
{
    public abstract class Entity
    {
        public readonly Dictionary<string, object> Fields = new Dictionary<string, object>();
        public readonly List<string> DirtyFields = new List<string>();

        public bool Dirty()
        {
            return DirtyFields.Any();
        }

        public void Clean()
        {
            DirtyFields.Clear();
        }

        public void UpdateFromRequest(Dictionary<string, dynamic> fields)
        {
            foreach (KeyValuePair<string, dynamic> entry in fields)
            {
                if (Fields.TryGetValue(entry.Key, out var temp))
                {
                    if (temp is EntityField<dynamic> field)
                    {
                        field.Value = entry.Value;
                    }
                }
            }
        }

        protected void BuildField<T>(ref EntityField<T> field, string name)
        {
            field = new EntityField<T>(name, propertyName => DirtyFields.Add(propertyName));
            Fields.Add(name, field);
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