using Microsoft.OpenApi.Extensions;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Reflection;
using System.Resources;

namespace ASDP.FinalProject.Helpers
{
    public static class EnumHelper<T>
    where T : struct, Enum // This constraint requires C# 7.3 or later.
    {
        public static IList<T> GetValues(Enum value)
        {
            var enumValues = new List<T>();

            foreach (FieldInfo fi in value.GetType().GetFields(BindingFlags.Static | BindingFlags.Public))
            {
                enumValues.Add((T)Enum.Parse(value.GetType(), fi.Name, false));
            }
            return enumValues;
        }

        public static T Parse(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }

        public static IList<string> GetNames(Enum value)
        {
            return value.GetType().GetFields(BindingFlags.Static | BindingFlags.Public).Select(fi => fi.Name).ToList();
        }

        /*public static IList<string> GetDisplayValues(Enum value)
        {
            return GetNames(value).Select(obj => GetDisplayValue(Parse(obj))).ToList();
        }
*/
        private static string lookupResource(Type resourceManagerProvider, string resourceKey)
        {
            var resourceKeyProperty = resourceManagerProvider.GetProperty(resourceKey,
                BindingFlags.Static | BindingFlags.Public, null, typeof(string),
                new Type[0], null);
            if (resourceKeyProperty != null)
            {
                return (string)resourceKeyProperty.GetMethod.Invoke(null, null);
            }

            return resourceKey; // Fallback with the key name
        }

        public static string GetDisplayValue(T value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());

            var descriptionAttributes = fieldInfo.GetCustomAttributes(
                typeof(DisplayAttribute), false).FirstOrDefault() as DisplayAttribute;

            if (descriptionAttributes.ResourceType != null)
                return lookupResource(descriptionAttributes.ResourceType, descriptionAttributes.Name);

            if (descriptionAttributes == null) return string.Empty;
            return (descriptionAttributes != null) ? descriptionAttributes.Name : value.ToString();
        }
    }

}
