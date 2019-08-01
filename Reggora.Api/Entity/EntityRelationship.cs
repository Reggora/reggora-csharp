namespace Reggora.Api.Entity
{
    public class EntityRelationship<E>
        where E : Entity
    {
        public readonly E Entity;

        public EntityRelationship(E entity)
        {
            Entity = entity;
        }
    }
}