using System;

namespace Specs.Util
{
  public static class Errors
  {
    public static Exception DuplicateChild(string parentName, string childName) =>
      new InvalidOperationException("'" + parentName + "' already contains a child named '"
                                    + childName + "' !");

    public static Exception MountFailed(string objectName, string typeName) =>
      new InvalidOperationException("'" + objectName + " failed to create an instance of '" +
                                    typeName + "'");

    public static Exception InstanceNotFound(string objectName, string typeName) =>
      new InvalidOperationException("'" + objectName + " does not contain an instance of '" +
                                    typeName + "'");

    public static Exception InvalidUpdate(string typeName, string objectString) =>
      new InvalidOperationException("Attempted to Update '" + typeName + "' with invalid value '"
                                    + objectString + "'");
 
    public static Exception UnknownEnumValue<T>(T value) =>
      new InvalidOperationException("Unknown " + value.GetType() +
                                    " enum value: " + Enum.GetName(value.GetType(), value));


    public static Exception ParentNotInCache(string parentName, string childName) =>
      new InvalidOperationException("Parent '" + parentName +
                                    "' was not in the game object cache for '" + childName +
                                    "'. Was it created by a call to Mount()?");
  }
}