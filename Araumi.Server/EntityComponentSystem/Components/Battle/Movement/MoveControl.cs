namespace Araumi.Server.EntityComponentSystem.Components.Battle.Movement {
  public struct MoveControl {
    public float MoveAxis { get; set; }
    public float TurnAxis { get; set; }

    public MoveControl(float moveAxis, float turnAxis) {
      MoveAxis = moveAxis;
      TurnAxis = turnAxis;
    }
  }
}
