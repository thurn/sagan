using Specs.Core;
using Specs.Generated;
using UnityEngine;
using UnityEngine.UI;

namespace Specs.Unity
{
  public class GraphicRaycasterSpec : Spec<GraphicRaycaster>
  {
    public bool IgnoreReversedGraphics { get; }
    public GraphicRaycaster.BlockingObjects BlockingObjects { get; }

    public GraphicRaycasterSpec(
      bool ignoreReversedGraphics = true,
      GraphicRaycaster.BlockingObjects blockingObjects = GraphicRaycaster.BlockingObjects.None)
    {
      IgnoreReversedGraphics = ignoreReversedGraphics;
      BlockingObjects = blockingObjects;
    }

    protected override GraphicRaycaster Mount(Res res, GameObject gameObject)
      => gameObject.AddComponent<GraphicRaycaster>();

    protected override void Update(Res res, GraphicRaycaster graphicRaycaster)
    {
      graphicRaycaster.ignoreReversedGraphics = IgnoreReversedGraphics;
      graphicRaycaster.blockingObjects = BlockingObjects;
    }

    protected override GraphicRaycaster GetInstance(GameObject gameObject) =>
      gameObject.GetComponent<GraphicRaycaster>();
  }
}