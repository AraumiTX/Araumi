using System;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;

using Serilog;

using ICSharpCode.SharpZipLib.Tar;
using ICSharpCode.SharpZipLib.GZip;

using Araumi.Server.Extensions;

namespace Araumi.Server.Services {
  public interface IClientConfigService {
    public Task Init();
    public MemoryStream GetArchiveStream();
  }

  [Service]
  public class ClientConfigService : IClientConfigService {
    private static readonly ILogger Logger = Log.Logger.ForType<ClientConfigService>();

    public bool IsCreated { get; private set; }

    private byte[]? _buffer;

    public ClientConfigService() {
      _buffer = null;
    }

    public async Task Init() {
      DirectoryInfo directory = new DirectoryInfo("Static/Config");

      Logger.Information("Generating config archives...");

      Stopwatch stopwatch = new Stopwatch();

      await using MemoryStream archiveStream = new MemoryStream();
      await using(GZipOutputStream gzip = new GZipOutputStream(archiveStream)) {
        await using TarOutputStream tar = new TarOutputStream(gzip, Encoding.UTF8);

        stopwatch.Start();
        foreach(FileInfo file in directory.EnumerateFiles("*.*", SearchOption.AllDirectories)) {
          string path = Path.GetRelativePath(directory.FullName, file.FullName).TrimStart('/');

          MemoryStream fileStream = await file.ReadAsync();
          TarEntry entry = TarEntry.CreateTarEntry(path);

          entry.Size = fileStream.Length;

          tar.PutNextEntry(entry);
          await fileStream.CopyToAsync(tar);

          tar.CloseEntry();
        }
        stopwatch.Stop();
      }

      _buffer = archiveStream.ToArray();
      IsCreated = true;

      Logger.Debug("Generated config archive in {Duration} ms", stopwatch.ElapsedMilliseconds);

      Logger.Information("Initialized");
    }

    public MemoryStream GetArchiveStream() {
      if(_buffer == null) throw new InvalidOperationException("Config archive is not created");
      return new MemoryStream(_buffer);
    }
  }
}
