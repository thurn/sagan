using System;

namespace Specs.Util
{
  public static class Errors
  {
    /// <summary>
    /// Throws an exception if the specified parameter's value is null OR equal to Unity's fake
    /// null.
    /// </summary>
    /// <typeparam name="T">The type of the parameter.</typeparam>
    /// <param name="value">The value of the argument.</param>
    /// <param name="parameterName">The name of the parameter to include in any thrown
    /// exception.</param>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="value"/> is
    /// <c>null</c></exception>
    public static void CheckNotNull<T>(T value, string parameterName)
      where T : class // ensures value-types aren't passed to a null checking method
    {
      // value.Equals(null) checks for Unity's fake null object.
      if (IsNullOrUnityNull(value))
      {
        throw new ArgumentNullException(parameterName);
      }
    }
 
    /// <summary>
    /// Throws an exception if the specified parameter's value is null. It passes through the
    /// specified value back as a return value.
    /// </summary>
    /// <typeparam name="T">The type of the parameter.</typeparam>
    /// <param name="value">The value of the argument.</param>
    /// <param name="parameterName">The name of the parameter to include in any thrown
    /// exception.</param>
    /// <returns>The value of the parameter.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="value"/> is <c>null</c>
    /// </exception>
    public static T CheckNotNullPassthrough<T>(T value, string parameterName)
      where T : class // ensures value-types aren't passed to a null checking method
    {
      CheckNotNull(value, parameterName);
      return value;
    }

    /// <summary>
    /// Returns true if a value is null or is equal to Unity's fake null value.
    /// </summary>
    /// <typeparam name="T">The type of the parameter.</typeparam>
    /// <param name="value">The value to check.</param>
    /// <returns>True if <paramref name="value"/> is null or equal to Unity's null.</returns>
    public static bool IsNullOrUnityNull<T>(T value) where T : class =>
      value == null || value.Equals(obj: null);

    public static Exception MountFailed(string objectName, string typeName) =>
      new InvalidOperationException("[MountFailed] '" + objectName + " failed to create an instance of '" +
                                    typeName + "'");

    public static Exception InstanceNotFound(string parentName, string childName) =>
      new InvalidOperationException("[InstanceNotFound] '" + parentName + " does not contain an instance of '" +
                                    childName + "'");

    public static Exception UnknownEnumValue<T>(T value) =>
      new InvalidOperationException("[UnknownEnumValue] Unknown " + value.GetType() +
                                    " enum value: " + Enum.GetName(value.GetType(), value));
    
    public static Exception InvalidName(string name) =>
      new ArgumentException("[InvalidName] '" + name + "' may not contain the character '/'.");

    public static Exception DuplicateChild(string parentName, string childName) =>
      new InvalidOperationException("[DuplicateChild] '" + parentName + "' contains two children named '" +
                                    childName + "'. Provide a 'specId' to differentiate them.");

  }
}