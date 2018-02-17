using Specs.Core;
using Specs.Generated;
using UnityEngine;

namespace Specs.Unity
{
  public class CanvasRendererSpec : Spec<CanvasRenderer>
  {
    public override CanvasRenderer Mount(Res res, GameObject gameObject) =>
      gameObject.AddComponent<CanvasRenderer>();

    public override void Update(Res res, CanvasRenderer component)
    {
    }

    public override CanvasRenderer GetInstance(GameObject gameObject) =>
      gameObject.GetComponent<CanvasRenderer>();
  }
}