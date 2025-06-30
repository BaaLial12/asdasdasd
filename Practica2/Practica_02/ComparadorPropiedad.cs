using System;
using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Collections.Generic;
using PSS.lhm232.Practica_02;
using System.Collections;
namespace PSS.lhm232.Practica_02
{

    public class ComparadorPropiedad<T> : IComparer<T> where T : IComparable<T>
    {
        private string _nombrePropiedad;
        private PropertyDescriptor _propiedad;

        public string nombrePropiedad
        {
            get { return _nombrePropiedad; }
            set
            {
                _nombrePropiedad = value;
                _propiedad = GetProperty(value);
            }
        }

        public ComparadorPropiedad()
        {
        }

        public ComparadorPropiedad(string name)
        {
            _propiedad = GetProperty(name);
            if (_propiedad is null)
                throw new ArgumentException("Propiedad no existente");
            Type propertyType = Nullable.GetUnderlyingType(_propiedad.PropertyType) ?? _propiedad.PropertyType;
            bool assert = typeof(IComparable).IsAssignableFrom(propertyType);
            if (!assert)
                throw new ArgumentException("La propiedad " + name + " no es comparable");
        }

        public int Compare(T x, T y)
        {
            if (x == null && y == null)
                return 0;

            if (x == null)
                return -1;

            if (y == null)
                return 1;

            var valueX = _propiedad.GetValue(x) as IComparable;
            var valueY = _propiedad.GetValue(y) as IComparable;

            return valueX.CompareTo(valueY);
        }

        private PropertyDescriptor GetProperty(string name)
        {
            if (string.IsNullOrEmpty(name))
                return null;

            T item = (T)Activator.CreateInstance(typeof(T));
            PropertyDescriptor propName = null;
            foreach (PropertyDescriptor propDesc in TypeDescriptor.GetProperties(item))
            {
                if (propDesc.Name == name)
                {
                    propName = propDesc;
                    break;
                }
            }
            return propName;
        }
    }
}

