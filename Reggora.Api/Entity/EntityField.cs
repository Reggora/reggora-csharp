using System.Collections.Generic;

namespace Reggora.Api.Entity
{
    public delegate void ChangedCallback(string propertyName);

    public class EntityField<T>
    {
        private readonly string _name;
        private T _value;
        private bool _set = false;
        private ChangedCallback _callback;

        public T Value
        {
            get => _value;

            set
            {
                if (_set == false || !EqualityComparer<T>.Default.Equals(_value, value))
                {
                    _set = true;
                    _callback.Invoke(_name);
                    _value = value;
                }
            }
        }

        public EntityField(string name, ChangedCallback callback)
        {
            _name = name;
            _callback = callback;
        }
    }
}