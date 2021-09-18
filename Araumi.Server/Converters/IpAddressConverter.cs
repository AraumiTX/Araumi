using System;
using System.Net;

using Newtonsoft.Json;

namespace Araumi.Server.Converters {
  public class IpAddressConverter : JsonConverter<IPAddress> {
    public override void WriteJson(JsonWriter writer, IPAddress? address, JsonSerializer serializer) {
      writer.WriteValue(address?.MapToIPv4().ToString());
    }

    public override IPAddress? ReadJson(
      JsonReader reader,
      Type objectType,
      IPAddress? existingValue,
      bool hasExistingValue,
      JsonSerializer serializer
    ) {
      string? value = (string?)reader.Value;
      return value != null ? IPAddress.Parse(value).MapToIPv4() : null;
    }
  }
}
