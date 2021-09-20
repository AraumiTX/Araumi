using System;
using System.Collections;
using System.IO;
using System.Numerics;

using Araumi.Server.EntityComponentSystem.Components.Battle.Movement;

namespace Araumi.Server.Protocol {
  public class MovementCodec : AbstractMoveCodec {
    private const int MovementSize = 21;
    private const int PositionComponentBitsize = 17;
    private const int OrientationComponentBitsize = 13;
    private const int LinearVelocityComponentBitsize = 13;
    private const int AngularVelocityComponentBitsize = 13;

    private const float PositionFactor = 0.01f;
    private const float VelocityFactor = 0.01f;
    private const float AngularVelocityFactor = 0.005f;
    private const float OrientationPrecision = 2f / (1 << OrientationComponentBitsize);

    public static void Encode(BinaryWriter writer, Movement movement) {
      byte[] data = new byte[MovementSize];
      BitArray bits = new BitArray(data);

      int position = 0;
      WriteVector3(bits, ref position, movement.Position, PositionComponentBitsize, PositionFactor);
      WriteQuaternion(bits, ref position, movement.Orientation, OrientationComponentBitsize, OrientationPrecision);
      WriteVector3(bits, ref position, movement.Velocity, LinearVelocityComponentBitsize, VelocityFactor);
      WriteVector3(bits, ref position, movement.AngularVelocity, AngularVelocityComponentBitsize, AngularVelocityFactor);

      bits.CopyTo(data, 0);
      writer.Write(data);

      if(position != bits.Length) throw new InvalidOperationException("Movement encode mismatch");
    }

    public static Movement Decode(BinaryReader reader) {
      byte[] data = reader.ReadBytes(MovementSize);
      BitArray bits = new BitArray(data);

      int position = 0;

      Movement movement = new Movement() {
        Position = ReadVector3(bits, ref position, PositionComponentBitsize, PositionFactor),
        Orientation = ReadQuaternion(bits, ref position, OrientationComponentBitsize, OrientationPrecision),
        Velocity = ReadVector3(bits, ref position, LinearVelocityComponentBitsize, VelocityFactor),
        AngularVelocity = ReadVector3(bits, ref position, AngularVelocityComponentBitsize, AngularVelocityFactor)
      };

      if(position != bits.Length) throw new InvalidOperationException("Movement decode mismatch");

      return movement;
    }

    private static Vector3 ReadVector3(BitArray bits, ref int position, int size, float factor) {
      return new Vector3() {
        X = ReadFloat(bits, ref position, size, factor),
        Y = ReadFloat(bits, ref position, size, factor),
        Z = ReadFloat(bits, ref position, size, factor)
      };
    }

    private static Quaternion ReadQuaternion(BitArray bits, ref int position, int size, float factor) {
      Quaternion quaternion = new Quaternion() {
        X = ReadFloat(bits, ref position, size, factor),
        Y = ReadFloat(bits, ref position, size, factor),
        Z = ReadFloat(bits, ref position, size, factor)
      };
      quaternion.W = Sqrt((float)(1.0 - ((double)quaternion.X * quaternion.X +
                                         (double)quaternion.Y * quaternion.Y +
                                         (double)quaternion.Z * quaternion.Z)));
      if(double.IsNaN(quaternion.W)) quaternion.W = 0.0f;

      return quaternion;
    }

    private static float Sqrt(float value) => (float)Math.Sqrt(value);

    private static void WriteVector3(
      BitArray bits,
      ref int position,
      Vector3 value,
      int size,
      float factor
    ) {
      WriteFloat(bits, ref position, value.X, size, factor);
      WriteFloat(bits, ref position, value.Y, size, factor);
      WriteFloat(bits, ref position, value.Z, size, factor);
    }

    private static void WriteQuaternion(
      BitArray bits,
      ref int position,
      Quaternion value,
      int size,
      float factor
    ) {
      int num = value.W < 0.0 ? -1 : 1;

      WriteFloat(bits, ref position, value.X * num, size, factor);
      WriteFloat(bits, ref position, value.Y * num, size, factor);
      WriteFloat(bits, ref position, value.Z * num, size, factor);
    }
  }
}
