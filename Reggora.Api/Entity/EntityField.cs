using System;
using System.Collections.Generic;
using Reggora.Api.Util;

namespace Reggora.Api.Entity
{
    public delegate void ChangedCallback(string propertyName);

    public class EntityField<T>
    {
        private readonly string _name;
        private readonly string _conversionType;
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
        
        public EntityField(string name, string conversionType, ChangedCallback callback)
        {
            _name = name;
            _conversionType = conversionType;
            _callback = callback;
        }

        public dynamic ConvertIncoming(dynamic value)
        {
            if (_conversionType != null)
            {
                if (typeof(T) == typeof(DateTime) || typeof(T) == typeof(DateTime?))
                {
                    return Utils.DateTimeFromString(value);
                }
                
                if (typeof(T) == typeof(Order.AllocationMode) || typeof(T) == typeof(Order.AllocationMode?))
                {
                    return Order.AllocationModeFromString(value);
                }

                if (typeof(T) == typeof(Order.PriorityType) || typeof(T) == typeof(Order.PriorityType?))
                {
                    return Order.PriorityTypeFromString(value);
                }

                if (typeof(T) == typeof(Product.Inspection) || typeof(T) == typeof(Product.Inspection?))
                {
                    return Product.InspectionFromString(value);
                }
            }

            return value;
        }
        
        public dynamic ConvertOutgoing(dynamic value)
        {
            if (_conversionType != null)
            {
                if (typeof(T) == typeof(DateTime) || typeof(T) == typeof(DateTime?))
                {
                    return Utils.DateToString(value);
                }

                if (typeof(T) == typeof(Order.AllocationMode) || typeof(T) == typeof(Order.AllocationMode?))
                {
                    return Order.AllocationModeToString(value);
                }
                
                if (typeof(T) == typeof(Order.PriorityType) || typeof(T) == typeof(Order.PriorityType?))
                {
                    return Order.PriorityTypeToString(value);
                }

                if (typeof(T) == typeof(Product.Inspection) || typeof(T) == typeof(Product.Inspection?))
                {
                    return Product.InspectionToString(value);
                }

            }

            return value;
        }
    }
}