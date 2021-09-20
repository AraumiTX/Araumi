using System;
using System.Collections;

using Araumi.Server.Extensions;

using Serilog;

namespace Araumi.Server.Protocol {
  public abstract class AbstractMoveCodec {
    private static readonly ILogger Logger = Log.Logger.ForType<AbstractMoveCodec>();

    public static float ReadFloat(BitArray bits, ref int position, int size, float factor) {
      float val = (Read(bits, ref position, size) - (1 << size - 1)) * factor;
      if(PhysicsUtil.IsValidFloat(val)) return val;
      Logger.Warning("ReadFloat: invalid float: {Value}", val);
      return 0.0f;
    }

    public static void WriteFloat(
      BitArray bits,
      ref int position,
      float value,
      int size,
      float factor
    ) {
      int offset = 1 << size - 1;
      Write(bits, ref position, size, PrepareValue(value, offset, factor));
    }

    private static int PrepareValue(float val, int offset, float factor) {
      int num1 = (int)(val / (double)factor);
      int num2 = 0;
      if(num1 < -offset) {
        Logger.Warning("Value too small: {Value} (offset = {Offset}; factor = {Factor})", val, offset, factor);
      } else {
        num2 = num1 - offset;
      }
      if(num2 >= offset) {
        Logger.Warning("Value too big: {Value} (offset = {Offset}; factor = {Factor})", val, offset, factor);
        num2 = offset;
      }

      return num2;
    }

    private static int Read(BitArray bits, ref int position, int bitsCount) {
      if(bitsCount > 32) throw new Exception($"Cannot read more that 32 bit at once (requested: {bitsCount})");
      if(position + bitsCount > bits.Length) {
        throw new Exception($"BitArea is out of data: requested {bitsCount} bits, available: {bits.Length - position}");
      }
      int num = 0;
      for(int index = bitsCount - 1; index >= 0; --index) {
        if(bits.Get(position)) num += 1 << index;
        ++position;
      }

      return num;
    }

    private static void Write(BitArray bits, ref int position, int bitsCount, int value) {
      if(bitsCount > 32) throw new Exception($"Cannot write more that 32 bit at once (requested: {bitsCount})");
      if(position + bitsCount > bits.Length) {
        throw new Exception($"BitArea overflow attempt to write {bitsCount} bits, space available: {bits.Length - position}");
      }
      for(int index = bitsCount - 1; index >= 0; --index) {
        bool flag = (value & 1 << index) != 0;
        bits.Set(position, flag);
        ++position;
      }
    }
  }
}
