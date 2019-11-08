using System;
using System.Linq;
using System.Reflection;

namespace Blog.Logic.Validators
{
    public static class PropertyValidator
    {        

        /// To check the properties of a class for Null/Empty values
        /// </summary>
        /// <param name="referencedObject">The instance of the class</param>
        /// <returns>Result of the evaluation</returns>
        public static bool IsNullOrEmpty(object referencedObject)
        {
            try
            {
                //Step 1: Check if the incoming object has values or not.
                if (referencedObject == null)
                {
                    throw new NullReferenceException();
                }

                var _type = referencedObject.GetType();

                var _requiredProperties = _type.GetRuntimeProperties()
                    .Where(pi => pi.GetCustomAttributes<RequiredAttribute>(true).Any());

                //Step 2: Iterate over the properties and check for null values based on the type.
                foreach (PropertyInfo _propertyInfo in _requiredProperties)
                {
                    object _value = _propertyInfo.GetValue(referencedObject);
                    if (_value is null)
                    {
                        return false;
                        //throw new ArgumentNullException($"{_propertyInfo.Name} property is null.");
                    }
                    else if (_value is string)
                    {
                        if (String.IsNullOrEmpty((string)_value))
                        {
                            return false;
                            //throw new ArgumentNullException($"{_propertyInfo.Name} property is null.");
                        }
                    }
                    else if (_value is int)
                    {
                        if ((int)_value <= 0)
                        {
                            return false;
                            //throw new InvalidOperationException($"{_propertyInfo.Name} property is invalid.");
                        }
                    }
                }

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new SystemException();
            }
        }
    }
}

#region try-catch-db
//try
//{
//    using (DHYPContext _context = new DHYPContext())
//    {

//    }
//    return true;
//}
//catch (Exception e)
//{
//    string _error = e.ToString();
//    return false;
//}
#endregion