using Specs.Core;
using Specs.Generated.Model;

namespace Specs.Generated.Requests
{
  public sealed class ProduceUnitRequest : IRequest
  {
    public RequestType RequestType { get; }
    public UnitType UnitType { get; }

    public ProduceUnitRequest(UnitType unitType)
    {
      UnitType = unitType;
    }
  }
}