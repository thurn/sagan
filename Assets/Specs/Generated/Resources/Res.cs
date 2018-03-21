using Specs.Util;
using UnityEngine;

namespace Specs.Generated.Resources
{
  public class Res : MonoBehaviour
  {
    public Sprite ImageBoxBackground;
    public Sprite ExampleImage;
    public Sprite WindowBackground;
    public Sprite WindowHeader;
    public Sprite TextFieldNormal;
    public Font EurostileBqBoldExtended;
    public Font RobotoRegular;

    public Material GetMaterial(MaterialName materialName)
    {
      throw Errors.UnknownEnumValue(materialName);
    }

    public Sprite GetSprite(SpriteName spriteName)
    {
      switch (spriteName)
      {
        case SpriteName.ExampleImage:
          return ExampleImage;

        case SpriteName.ImageBoxBackground:
          return ImageBoxBackground;

        case SpriteName.WindowBackground:
          return WindowBackground;

        case SpriteName.WindowHeader:
          return WindowHeader;

        case SpriteName.TextFieldNormal:
          return TextFieldNormal;

        default:
          throw Errors.UnknownEnumValue(spriteName);
      }
    }

    public Font GetFont(FontName fontName)
    {
      switch (fontName)
      {
        case FontName.EurostileBqBoldExtended:
          return EurostileBqBoldExtended;

        case FontName.RobotoRegular:
          return RobotoRegular;

        default:
          throw Errors.UnknownEnumValue(fontName);
      }
    }

    public Camera GetCamera(CameraName cameraName)
    {
      throw Errors.UnknownEnumValue(cameraName);
    }
  }
}