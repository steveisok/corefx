namespace System.Configuration
{
  public class ConfigurationBuilderSettings : ConfigurationElement
  {
    private readonly ConfigurationProperty _propBuilders = new ConfigurationProperty((string) null, typeof (ProviderSettingsCollection), (object) null, ConfigurationPropertyOptions.IsDefaultCollection);
    private ConfigurationPropertyCollection _properties;

    public ConfigurationBuilderSettings()
    {
      _properties = new ConfigurationPropertyCollection();
      _properties.Add(this._propBuilders);
    }

    protected internal override ConfigurationPropertyCollection Properties
    {
      get
      {
        return _properties;
      }
    }

    [ConfigurationProperty("", IsDefaultCollection = true, Options = ConfigurationPropertyOptions.IsDefaultCollection)]
    public ProviderSettingsCollection Builders
    {
      get
      {
        return (ProviderSettingsCollection) this[_propBuilders];
      }
    }
  }
}