using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Reggora.Api.Requests;
using Reggora.Api.Storage;
using Reggora.Api.Util;

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
                if (Fields.TryGetValue(entry.Key, out var field))
                {
                    // do any conversion/casting from storage to object form (string -> date time)
                    var converted = field.GetType()
                        .GetMethod("ConvertIncoming", BindingFlags.Public | BindingFlags.Instance)
                        ?.Invoke(field, new object[] {entry.Value});
                    var fieldValue = field.GetType()
                        .GetField("_value", BindingFlags.NonPublic | BindingFlags.Instance);
                    try
                    {
                        // set the property on the field using reflection because we have no way to cast to a EntityField<dynamic> at compile time
                        fieldValue?.SetValue(field, converted);
                    }
                    catch (ArgumentException e)
                    {
                        throw new InvalidCastException(
                            $"Cannot cast '{entry.Value.GetType()}' to {fieldValue?.FieldType}!");
                    }
                }
            }
        }

        public Dictionary<string, dynamic> GetDirtyFieldsForRequest()
        {
            var dictionary = new Dictionary<string, dynamic>();

            foreach (var name in DirtyFields)
            {
                var field = Fields[name];
                // get the property on the field using reflection because we have no way to cast to a EntityField<dynamic> at compile time
                var fieldValue = field.GetType()
                    .GetField("_value", BindingFlags.NonPublic | BindingFlags.Instance);
                // do any conversion/casting from storage to object form (date time -> string)
                var converted = field.GetType()
                    .GetMethod("ConvertOutgoing", BindingFlags.Public | BindingFlags.Instance)?.Invoke(Fields[name], new[] {fieldValue?.GetValue(field)});

                dictionary.Add(name, converted);
            }

            return dictionary;
        }

        protected void BuildField<T>(ref EntityField<T> field, string name)
        {
            field = new EntityField<T>(name, propertyName => DirtyFields.Add(propertyName));
            Fields.Add(name, field);
        }

        protected void BuildField<T>(ref EntityField<T> field, string conversionType, string name)
        {
            field = new EntityField<T>(name, conversionType, propertyName => DirtyFields.Add(propertyName));
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