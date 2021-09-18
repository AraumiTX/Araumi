using System;
using System.Collections.Generic;
using System.Linq;

namespace Araumi.Server.Protocol {
  public class OptionalMap {
    private readonly List<byte> _data;

    public int Length { get; private set; }
    public int Position { get; private set; }

    public OptionalMap() {
      _data = new List<byte>();
    }

    public OptionalMap(IEnumerable<byte> data, int length) {
      _data = data.ToList();
      Length = length;
    }

    public void Add(bool isNull) {
      if(Position >= Length) {
        _data.Add(0);
        Length += 8;
      }
      _data[Position / 8] |= (byte)(Convert.ToInt32(isNull) << (7 - Position++ % 8));
    }

    public bool Read() {
      if(Position >= Length)
        throw new IndexOutOfRangeException("Index was out of range. Must be non-negative and less than the size of the OptionalMap.");
      return Convert.ToBoolean((_data[Position / 8] >> (7 - Position++ % 8)) & 1);
    }

    public void Rewind() {
      Position = 0;
    }

    public byte[] GetBytes() => _data.ToArray();
  }
}
