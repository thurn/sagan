using Specs.Core;
using Specs.Generated;
using UnityEngine;

namespace Specs.Unity
{
  public class CanvasRendererSpec : Spec<CanvasRenderer>
  {
    protected override CanvasRenderer Mount(Res res, GameObject gameObject) =>
      gameObject.AddComponent<CanvasRenderer>();

    protected override void Update(Res res, CanvasRenderer component)
    {
    }

    protected override CanvasRenderer GetInstance(GameObject gameObject) =>
      gameObject.GetComponent<CanvasRenderer>();
  }
}