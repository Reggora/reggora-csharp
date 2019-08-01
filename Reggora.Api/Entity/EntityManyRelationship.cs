using Reggora.Api.Storage;

namespace Reggora.Api.Entity
{
    public class EntityManyRelationship<E, C, S>
        where E : Entity
        where C : ApiClient<C>
        where S : Storage<E, C>, new()
    {
        public readonly Storage<E, C> Known;

        public EntityManyRelationship()
        {
            Known = StorageFactory.Create<S, E, C>();
        }
    }
}