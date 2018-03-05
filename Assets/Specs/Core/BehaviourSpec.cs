using UnityEngine;

namespace Specs.Core
{
  public abstract class BehaviourSpec<T> : ComponentSpec<T> where T: Behaviour
  {
  }
}