namespace Araumi.Server.EntityComponentSystem.Events.Battle.Movement {
  public struct DiscreteTankControl {
    private const int BitLeft = 0;
    private const int BitRight = 1;
    private const int BitDown = 2;
    private const int BitUp = 3;

    private const int BitWeaponLeft = 4;
    private const int BitWeaponRight = 5;

    public byte Control { get; set; }

    public int MoveAxis {
      get => GetBit(BitUp) - GetBit(BitDown);
      set => SetDiscreteControl(value, BitDown, BitUp);
    }

    public int TurnAxis {
      get => GetBit(BitRight) - GetBit(BitLeft);
      set => SetDiscreteControl(value, BitLeft, BitRight);
    }

    public int WeaponControl {
      get => GetBit(BitWeaponRight) - GetBit(BitWeaponLeft);
      set => SetDiscreteControl(value, BitWeaponLeft, BitWeaponRight);
    }

    private int GetBit(int bitNumber) {
      return Control >> bitNumber & 1;
    }

    private void SetBit(int bitNumber, int value) {
      int num = ~(1 << bitNumber);
      Control = (byte)(Control & num | (value & 1) << bitNumber);
    }

    private void SetDiscreteControl(int value, int negativeBit, int positiveBit) {
      SetBit(negativeBit, 0);
      SetBit(positiveBit, 0);
      if(value > 0) {
        SetBit(positiveBit, 1);
      } else if(value < 0) {
        SetBit(negativeBit, 1);
      }
    }
  }
}
