namespace Araumi.Server.Protocol {
	public class PhysicsUtil {
		public static bool IsValidFloat(float value) {
			return !(float.IsInfinity(value) || float.IsNaN(value));
		}
	}
}
