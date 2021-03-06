﻿using Specs.Core;
using Specs.Generated.Resources;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Specs.Unity
{
  public class StandaloneInputModuleSpec : BehaviourSpec<StandaloneInputModule>
  {
    public string HorizontalAxisName { get; }
    public string VerticalAxisName { get; }
    public string SubmitButtonName { get; }
    public string CancelButtonName { get; }
    public int InputActionsPerSecond { get; }
    public float RepeatDelay { get; }
    public bool ForceModuleToBeActive { get; }

    public StandaloneInputModuleSpec(
      string horizontalAxisName = "Horizontal",
      string verticalAxisName = "Vertical",
      string submitButtonName = "Submit",
      string cancelButtonName = "Cancel",
      int inputActionsPerSecond = 10,
      float repeatDelay = 0.5f,
      bool forceModuleToBeActive = false)
    {
      HorizontalAxisName = horizontalAxisName;
      VerticalAxisName = verticalAxisName;
      SubmitButtonName = submitButtonName;
      CancelButtonName = cancelButtonName;
      InputActionsPerSecond = inputActionsPerSecond;
      RepeatDelay = repeatDelay;
      ForceModuleToBeActive = forceModuleToBeActive;
    }

    protected override void UpdateComponent(Res res, StandaloneInputModule inputModule)
    {
      inputModule.horizontalAxis = HorizontalAxisName;
      inputModule.verticalAxis = VerticalAxisName;
      inputModule.submitButton = SubmitButtonName;
      inputModule.cancelButton = CancelButtonName;
      inputModule.inputActionsPerSecond = InputActionsPerSecond;
      inputModule.repeatDelay = RepeatDelay;
      inputModule.forceModuleActive = ForceModuleToBeActive;
    }
  }
}