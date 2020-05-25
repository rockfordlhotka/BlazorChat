using Csla;
using System;

namespace BlazorChat.Data
{
  [Serializable]
  public class SendChat : CommandBase<SendChat>
  {
    public static readonly PropertyInfo<string> NameProperty = RegisterProperty<string>(nameof(Name));
    public string Name
    {
      get => ReadProperty(NameProperty);
      set => LoadProperty(NameProperty, value);
    }

    public static readonly PropertyInfo<string> TextProperty = RegisterProperty<string>(nameof(Text));
    public string Text
    {
      get => ReadProperty(TextProperty);
      set => LoadProperty(TextProperty, value);
    }

    [Create]
    [RunLocal]
    private void Create(User user, string text)
    {
      Name = user.Name;
      Text = text;
    }

    [Execute]
    private void Execute()
    {
      var text = $"{Name}: {Text}";
      lock (App.Messages)
      {
        App.Messages.Add(text);
        while (App.Messages.Count > 20)
          App.Messages.RemoveAt(0);
      }
    }
  }
}
