using Csla;
using System;

namespace BlazorChat.Data
{
  [Serializable]
  public class User : BusinessBase<User>
  {
    public static readonly PropertyInfo<string> IdProperty = RegisterProperty<string>(nameof(Id));
    public string Id
    {
      get => GetProperty(IdProperty);
      private set => LoadProperty(IdProperty, value);
    }

    public static readonly PropertyInfo<string> NameProperty = RegisterProperty<string>(nameof(Name));
    public string Name
    {
      get => GetProperty(NameProperty);
      set => SetProperty(NameProperty, value);
    }

    [Create]
    [RunLocal]
    private void Create(string name)
    {
      using (BypassPropertyChecks)
      {
        Id = Guid.NewGuid().ToString();
        Name = name;
      }
    }
  }
}