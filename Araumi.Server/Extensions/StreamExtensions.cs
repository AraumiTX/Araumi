using System.IO;

namespace Araumi.Server.Extensions {
	public static class StreamExtensions {
		public static void Rewind(this Stream stream) => stream.Position = 0;
	}
}
