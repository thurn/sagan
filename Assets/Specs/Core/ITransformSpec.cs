using Specs.Generated;
using UnityEngine;

namespace Specs.Core
{
  public interface ITransformSpec
  {
    Transform MountTransform(Res res, GameObject gameObject);

    Transform GetTransformInstance(GameObject gameObject);

    void UpdateTransform(Res res, Transform instance);
  }
}