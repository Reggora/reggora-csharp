namespace Reggora.Api.Entity.Lender
{
    public class Property : ChildEntity
    {
        public readonly EntityField<string> Address;
        public readonly EntityField<string> City;
        public readonly EntityField<string> State;
        public readonly EntityField<string> Zip;
        
        public Property(Entity parent) : base(parent)
        {
            BuildField(ref Address, nameof(Address));
            BuildField(ref City, nameof(City));
            BuildField(ref State, nameof(State));
            BuildField(ref Zip, nameof(Zip));
        }
    }
}