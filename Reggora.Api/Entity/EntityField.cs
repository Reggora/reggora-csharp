using System;
using System.Collections.Generic;

namespace Reggora.Api.Entity
{
    public delegate void ChangedCallback(string propertyName);

    public class EntityField<T> : EntityField
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

        public string ToDate()
        {
            if (typeof(T) == typeof(DateTime))
            {
                if (_value == null)
                {
                    return "";
                }

                return ((DateTime) (object) _value).ToString("yyyy-MM-dd");
            }

            throw new InvalidCastException($"Cannot cast '{typeof(T)}' to '{typeof(DateTime)}'!");
        }
    }

    public partial class EntityField
    {
        public static int? IntFromString(string integer)
        {
            if (integer != null)
            {
                return Int32.Parse(integer);
            }

            return null;
        }
        
        
        public static DateTime? DateTimeFromString(string date)
        {
            if (date != null)
            {
                try
                {
                    return DateTime.Parse(date);
                }
                catch (FormatException)
                {
                }
            }

            return null;
        }
    }
}