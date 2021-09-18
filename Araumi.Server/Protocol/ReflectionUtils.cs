using System;

namespace Araumi.Server.Protocol {
	public static class ReflectionUtils {
		public static bool IsNullable<T>() => IsNullable(typeof(T));

		public static bool IsNullable(Type type) {
			if(type.IsValueType) return IsNullableType(type);
			return true;
		}

		public static bool IsNullableType<T>() => IsNullableType(typeof(T));

		public static bool IsNullableType(Type type) {
			return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
		}
	}
}
