using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.Serialization;

using Araumi.Server.Protocol.Commands;
using Araumi.Server.Services.Servers.Game;

namespace Araumi.Server.EntityComponentSystem.Core {
  public class Entity {
    public long Id { get; }
    public TemplateAccessor? TemplateAccessor { get; }
    public HashSet<Component> Components { get; }
    public List<Player> PlayerReferences { get; }

    public Entity() {
      Components = new HashSet<Component>(new HashCodeEqualityComparer<Component>());
      PlayerReferences = new List<Player>();
    }

    public Entity(long id) : this() {
      Id = id;
    }

    public Entity(params Component[] components) : this() {
      Components.UnionWith(components);
    }

    public Entity(TemplateAccessor? templateAccessor, params Component[] components) : this(components) {
      TemplateAccessor = templateAccessor;
    }

    public Entity(long id, TemplateAccessor? templateAccessor, params Component[] components) : this(templateAccessor, components) {
      Id = id;
    }

    public T? GetComponent<T>() where T : Component => GetComponent(typeof(T)) as T;

    public Component? GetComponent(Type type) {
      Components.TryGetValue((Component)FormatterServices.GetUninitializedObject(type), out Component? component);
      return component;
    }

    public bool HasComponent<T>() where T : Component => HasComponent(typeof(T));
    public bool HasComponent(Type type) => GetComponent(type) != null;

    public void AddComponent(Component component, Player? excludedFromSending = null) {
      if(!Components.Add(component)) throw new ArgumentException("Entity already contains component", component.GetType().FullName);

      foreach(Player player in PlayerReferences.Where((player) => player != excludedFromSending)) {
        player.Connection.QueueCommands(new ComponentAddCommand(this, component));
      }
    }

    public void AddOrChangeComponent(Component component, Player? excludedFromSending = null) {
      if(Components.Contains(component))
        ChangeComponent(component, excludedFromSending);
      else
        AddComponent(component, excludedFromSending);
    }

    public void TryAddComponent(Component component, Player? excludedFromSending = null) {
      if(!Components.Contains(component)) AddComponent(component, excludedFromSending);
    }

    public void ChangeComponent(Component component, Player? excludedFromSending = null) {
      if(!Components.Remove(component)) throw new ArgumentException($"Component {component.GetType()} does not exist");
      Components.Add(component);

      foreach(Player player in PlayerReferences.Where((player) => player != excludedFromSending)) {
        player.Connection.QueueCommands(new ComponentChangeCommand(this, component));
      }
    }

    public void ChangeComponent<T>() where T : Component {
      T component = GetComponent<T>() ?? throw new ArgumentException($"Component {typeof(T)} does not exist");
      ChangeComponent(component);
    }

    public void ChangeComponent<T>(Action<T> action) where T : Component {
      T component = GetComponent<T>() ?? throw new ArgumentException($"Component {typeof(T)} does not exist");
      action(component);
      ChangeComponent(component);
    }

    public void RemoveComponent<T>() where T : Component => RemoveComponent(typeof(T));

    public void RemoveComponent(Type type, Player? excludedFromSending = null) {
      if(!TryRemoveComponent(type, excludedFromSending)) throw new ArgumentException($"Component {type} does not exist");
    }

    public bool TryRemoveComponent<T>() where T : Component => TryRemoveComponent(typeof(T));

    public bool TryRemoveComponent(Type type, Player? excludedFromSending = null) {
      if(!Components.Remove((Component)FormatterServices.GetUninitializedObject(type))) return false;

      foreach(Player player in PlayerReferences.Where((player) => player != excludedFromSending)) {
        player.Connection.QueueCommands(new ComponentRemoveCommand(this, type));
      }

      return true;
    }
  }
}
