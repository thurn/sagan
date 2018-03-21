using UnityEngine;
using UnityEngine.UI;
using Specs.Generated.Resources;
using Specs.Core;

namespace Specs.Unity
{
  public interface IImageType
  {
    void SetParams(Image image);
  }

  public struct SimpleImageType : IImageType
  {
    public bool PreserveAspectRatio { get; }

    public SimpleImageType(bool preserveAspectRatio = false)
    {
      PreserveAspectRatio = preserveAspectRatio;
    }

    public void SetParams(Image image)
    {
      image.type = Image.Type.Simple;
      image.preserveAspect = PreserveAspectRatio;
    }
  }

  public struct SlicedImageType : IImageType
  {
    public bool FillCenter { get; }

    public SlicedImageType(bool fillCenter = true)
    {
      FillCenter = fillCenter;
    }

    public void SetParams(Image image)
    {
      image.type = Image.Type.Sliced;
      image.preserveAspect = FillCenter;
    }
  }

  public struct TiledImageType : IImageType
  {
    public bool FillCenter { get; }

    public TiledImageType(bool fillCenter = true)
    {
      FillCenter = fillCenter;
    }

    public void SetParams(Image image)
    {
      image.type = Image.Type.Tiled;
      image.preserveAspect = FillCenter;
    }
  }

  public interface IFillMethod
  {
    void SetParams(Image image);
  }

  public struct FillMethodHorizontal : IFillMethod
  {
    public Image.OriginHorizontal Origin { get; }

    public FillMethodHorizontal(
      Image.OriginHorizontal origin = Image.OriginHorizontal.Left)
    {
      Origin = origin;
    }

    public void SetParams(Image image) => image.fillOrigin = (int)Origin;
  }

  public struct FillMethodVertical : IFillMethod
  {
    public Image.OriginVertical Origin { get; }

    public FillMethodVertical(
      Image.OriginVertical origin = Image.OriginVertical.Top)
    {
      Origin = origin;
    }

    public void SetParams(Image image) => image.fillOrigin = (int)Origin;
  }

  public struct FillMethodRadial90 : IFillMethod
  {
    public Image.Origin90 Origin { get; }

    public FillMethodRadial90(
      Image.Origin90 origin = Image.Origin90.BottomLeft)
    {
      Origin = origin;
    }

    public void SetParams(Image image) => image.fillOrigin = (int)Origin;
  }

  public struct FillMethodRadial180 : IFillMethod
  {
    public Image.Origin180 Origin { get; }

    public FillMethodRadial180(
      Image.Origin180 origin = Image.Origin180.Bottom)
    {
      Origin = origin;
    }

    public void SetParams(Image image) => image.fillOrigin = (int)Origin;
  }

  public struct FillMethodRadial360 : IFillMethod
  {
    public Image.Origin360 Origin { get; }

    public FillMethodRadial360(
      Image.Origin360 origin = Image.Origin360.Bottom)
    {
      Origin = origin;
    }

    public void SetParams(Image image) => image.fillOrigin = (int)Origin;
  }

  public struct FilledImageType : IImageType
  {
    public IFillMethod FillMethod { get; }
    public float FillAmount { get; }
    public bool FillClockwise { get; }
    public bool PreserveAspectRatio { get; }

    public FilledImageType(
      IFillMethod fillMethod = null,
      float fillAmount = 1.0f,
      bool fillClockwise = false,
      bool preserveAspectRatio = false)
    {
      FillMethod = fillMethod ?? new FillMethodHorizontal();
      FillAmount = fillAmount;
      FillClockwise = fillClockwise;
      PreserveAspectRatio = preserveAspectRatio;
    }

    public void SetParams(Image image)
    {
      image.type = Image.Type.Filled;
      image.fillAmount = FillAmount;
      image.fillClockwise = FillClockwise;
      image.preserveAspect = PreserveAspectRatio;

      FillMethod.SetParams(image);
    }
  }

  public class ImageSpec : BehaviourSpec<Image>
  {
    public SpriteName? SourceImage { get; }
    public Color Color { get; }
    public MaterialName? Material { get; }
    public bool IsRaycastTarget { get; }
    public IImageType ImageType { get; }

    public ImageSpec(
      SpriteName? sourceImage = null,
      Color? color = null,
      MaterialName? material = null,
      bool isRaycastTarget = false,
      IImageType imageType = null
      )
    {
      SourceImage = sourceImage;
      Color = color.GetValueOrDefault(Color.white);
      Material = material;
      IsRaycastTarget = isRaycastTarget;
      ImageType = imageType ?? new SimpleImageType();
    }

    protected override void UpdateComponent(Res res, Image image)
    {
      if (SourceImage.HasValue)
      {
        image.sprite = res.GetSprite(SourceImage.Value);
      }
      image.color = Color;
      if (Material.HasValue)
      {
        image.material = res.GetMaterial(Material.Value);
      }
      image.raycastTarget = IsRaycastTarget;

      ImageType.SetParams(image);
    }
  }
}