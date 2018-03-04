using Specs.Core;
using Specs.Generated;
using UnityEngine.UI;

namespace Specs.Unity
{
  public class GraphicRaycasterSpec : BehaviourSpec<GraphicRaycaster>
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

    protected override void UpdateComponent(Res res, GraphicRaycaster graphicRaycaster)
    {
      graphicRaycaster.ignoreReversedGraphics = IgnoreReversedGraphics;
      graphicRaycaster.blockingObjects = BlockingObjects;
    }
  }
}