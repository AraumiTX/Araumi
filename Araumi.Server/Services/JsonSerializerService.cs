using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

using Newtonsoft.Json;

using Araumi.Server.Converters;

namespace Araumi.Server.Services {
  public interface IJsonSerializerService {
    public JsonSerializerSettings SerializerSettings { get; }

    public Task<T> DeserializeJsonAsync<T>(MemoryStream stream);
  }

  [Service]
  public class JsonSerializerService : IJsonSerializerService {
    public JsonSerializerSettings SerializerSettings { get; } = new JsonSerializerSettings() {
      Converters = new List<JsonConverter>() {
        new IpAddressConverter()
      }
    };

    public async Task<T> DeserializeJsonAsync<T>(MemoryStream stream) {
      JsonSerializer serializer = JsonSerializer.Create(SerializerSettings);

      using TextReader reader = new StreamReader(stream);
      using JsonReader jsonReader = new JsonTextReader(reader);

      return serializer.Deserialize<T>(jsonReader)!;
    }
  }
}
