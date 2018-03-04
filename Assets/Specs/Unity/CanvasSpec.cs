using Specs.Generated;
using Specs.Core;
using UnityEngine;

namespace Specs.Unity
{
  public interface ICanvasRenderMode
  {
    void SetParams(Res res, Canvas canvas);
  }

  public struct ScreenSpaceOverlayRenderMode : ICanvasRenderMode
  {
    public bool PixelPerfect { get; }
    public int SortingOrder { get; }
    public int TargetDisplay { get; }

    public ScreenSpaceOverlayRenderMode(
      bool pixelPerfect = false,
      int sortingOrder = 0,
      int targetDisplay = 0)
    {
      PixelPerfect = pixelPerfect;
      SortingOrder = sortingOrder;
      TargetDisplay = targetDisplay;
    }

    public void SetParams(Res res, Canvas canvas)
    {
      canvas.renderMode = RenderMode.ScreenSpaceOverlay;
      canvas.pixelPerfect = PixelPerfect;
      canvas.sortingOrder = SortingOrder;
      canvas.targetDisplay = TargetDisplay;
    }
  }

  public struct ScreenSpaceCameraRenderMode : ICanvasRenderMode
  {
    public bool PixelPerfect { get; }
    public CameraName? RenderingCamera { get; }
    public int SortingOrder { get; }

    public ScreenSpaceCameraRenderMode(
      bool pixelPerfect = false,
      CameraName? renderingCamera = null,
      int sortingOrder = 0)
    {
      PixelPerfect = pixelPerfect;
      RenderingCamera = renderingCamera;
      SortingOrder = sortingOrder;
    }

    public void SetParams(Res res, Canvas canvas)
    {
      canvas.renderMode = RenderMode.ScreenSpaceCamera;
      canvas.pixelPerfect = PixelPerfect;
      if (RenderingCamera.HasValue)
      {
        canvas.worldCamera = res.GetCamera(RenderingCamera.Value);
      }
      canvas.sortingOrder = SortingOrder;
    }
  }

  public struct WorldSpaceRenderMode : ICanvasRenderMode
  {
    public CameraName? EventCamera { get; }
    public string SortingLayer { get; }
    public int SortingOrder { get; }

    public WorldSpaceRenderMode(
      CameraName? eventCamera = null,
      string sortingLayer = null,
      int sortingOrder = 0)
    {
      EventCamera = eventCamera;
      SortingLayer = sortingLayer;
      SortingOrder = sortingOrder;
    }

    public void SetParams(Res res, Canvas canvas)
    {
      canvas.renderMode = RenderMode.WorldSpace;
      if (EventCamera.HasValue)
      {
        canvas.worldCamera = res.GetCamera(EventCamera.Value);
      }
      canvas.sortingLayerName = SortingLayer;
      canvas.sortingOrder = SortingOrder;
    }
  }

  public class CanvasSpec : BehaviourSpec<Canvas>
  {
    public ICanvasRenderMode RenderMode { get; }
    public AdditionalCanvasShaderChannels AdditionalShaderChannels { get; }

    public CanvasSpec(
      ICanvasRenderMode renderMode = null,
      AdditionalCanvasShaderChannels additionalShaderChannels = AdditionalCanvasShaderChannels.None)
    {
      RenderMode = renderMode ?? new ScreenSpaceOverlayRenderMode();
      AdditionalShaderChannels = additionalShaderChannels;
    }

    protected override void UpdateComponent(Res res, Canvas canvas)
    {
      RenderMode.SetParams(res, canvas);
      canvas.additionalShaderChannels = AdditionalShaderChannels;
    }
  }
}