using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SklepInternetowy.Helpers
{
    public static class PropertyUtil
    {
        /// <summary>
        /// Extension method for copying property values from one object to another. 
        /// Property must have the same type and name in order to be copied.
        /// </summary>
        /// <typeparam name="TargetType">Target type to which values will be copied.</typeparam>
        /// <typeparam name="SourceType">Source type to which values will be copied.</typeparam>
        /// <param name="targetObject">Target object to which values will be copied.</param>
        /// <param name="sourceObject">Source object to which values will be copied.</param>
        /// <returns>Target object.</returns>
        public static T CopyProperties<T, T2>(this T targetObject, T2 sourceObject)
        {
            foreach (var property in typeof(T).GetProperties().Where(p => p.CanWrite))
            {
                Func<PropertyInfo, bool> CheckIfPropertyExistInSource =
                    prop => string.Equals(property.Name, prop.Name, StringComparison.InvariantCultureIgnoreCase)
                    && prop.PropertyType.Equals(property.PropertyType);

                if (sourceObject.GetType().GetProperties().Any(CheckIfPropertyExistInSource))
                {
                    property.SetValue(targetObject, sourceObject.GetPropertyValue(property.Name), null);
                }
            }
            return targetObject;
        }
        private static object GetPropertyValue<T>(this T source, string propertyName)
        {
            return source.GetType().GetProperty(propertyName).GetValue(source, null);
        }
    }
}