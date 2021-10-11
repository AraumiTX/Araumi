using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;


namespace Araumi.Server.EntityComponentSystem.Components.Battle.Time {
  [TypeUid(1447751145383)]
  public class BattleTimeIndicatorComponent : Component {
    public string TimeText { get; set; }
    public float Progress { get; set; }

    public BattleTimeIndicatorComponent(string timeText, float progress) {
      TimeText = timeText;
      Progress = progress;
    }
  }
}
