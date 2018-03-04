using Specs.Core;
using Specs.Generated;
using UnityEngine;

namespace Specs.Unity
{
  public class CanvasGroupSpec : ComponentSpec<CanvasGroup>
  {
    public float Alpha { get; }
    public bool IsInteractable { get; }
    public bool BlocksRaycasts { get; }
    public bool IgnoreParentGroups { get; }

    public CanvasGroupSpec(
      float alpha = 1.0f,
      bool isInteractable = true,
      bool blocksRaycasts = true,
      bool ignoreParentGroups = false)
    {
      Alpha = alpha;
      IsInteractable = isInteractable;
      BlocksRaycasts = blocksRaycasts;
      IgnoreParentGroups = ignoreParentGroups;
    }

    protected override void UpdateComponent(Res res, CanvasGroup canvasGroup)
    {
      canvasGroup.alpha = Alpha;
      canvasGroup.interactable = IsInteractable;
      canvasGroup.blocksRaycasts = BlocksRaycasts;
      canvasGroup.ignoreParentGroups = IgnoreParentGroups;
    }
  }
}