using System;
using System.Linq;

namespace Araumi.Server.Protocol.Exceptions {
  public class InvalidPacketHeaderException : Exception {
    public byte[] ExpectedData { get; }
    public byte[] ActualData { get; }

    public bool IsHttp { get; }

    public override string Message => $"Invalid packet header. Expected data: {GetHex(ExpectedData)}. Actual data: {GetHex(ActualData)}.";

    public InvalidPacketHeaderException(byte[] expectedData, byte[] actualData, bool isHttp, Exception? innerException = null) : base(null, innerException) {
      ExpectedData = expectedData;
      ActualData = actualData;
      IsHttp = isHttp;
    }

    public static string GetHex(byte[] data) => string.Join(" ", data.Select((octet) => $"{octet:x2}"));
  }
}
