using System.Collections.Generic;

namespace Araumi.Server.EntityComponentSystem.Core {
  public sealed class HashCodeEqualityComparer<T> : IEqualityComparer<T> where T : class {
    public bool Equals(T? left, T? right) {
      if(ReferenceEquals(left, right)) return true;
      if(ReferenceEquals(left, null)) return false;
      if(ReferenceEquals(right, null)) return false;
      if(left.GetType() != right.GetType()) return false;

      return left.GetHashCode() == right.GetHashCode();
    }

    public int GetHashCode(T? instance) {
      return instance != null ? instance.GetHashCode() : 0;
    }
  }
}
