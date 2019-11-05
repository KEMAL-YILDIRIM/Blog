using System;

namespace Blog.Logic.Validators
{
    [AttributeUsage(AttributeTargets.Property)]
    public class RequiredAttribute : Attribute
    {
        //public static void Validate(object objectToCheck)
        //{
        //    var properties = new List<PropertyInfo>();
        //    var type = objectToCheck.GetType();
        //    foreach (var prop in type.GetProperties())
        //        if (prop.GetCustomAttributes(typeof(Required), true).Any())
        //            properties.Add(prop);

        //    foreach (var prop in properties)
        //    {
        //        object value = prop.GetValue(objectToCheck, null);
        //        //Validation logic here
        //        if (value == null)
        //            throw new Exception(string.Format("Value of property {0} on class {1} with instance hashcode : {2} is not set",
        //                prop.Name, objectToCheck.GetType().FullName, objectToCheck.GetHashCode()));
        //    }
        //}
    }
}