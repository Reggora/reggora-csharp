namespace Reggora.Api.Entity
{
    public abstract class ChildEntity : Entity
    {
        private readonly Entity _parent;

        public ChildEntity(Entity parent)
        {
            _parent = parent;
        }

        protected new void BuildField<T>(ref EntityField<T> field, string name)
        {
            field = new EntityField<T>(name, propertyName => _parent.DirtyFields.Add(propertyName));
        }
    }
}