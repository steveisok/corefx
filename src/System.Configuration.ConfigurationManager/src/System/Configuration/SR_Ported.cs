using System;
using System.Globalization;
using System.Resources;
using System.Threading;

//internal partial class SR
internal partial class SRPorted
{
  private static SRPorted loader;
  private ResourceManager resources;

  internal SRPorted()
  {
    this.resources = new ResourceManager("System.Configuration.ConfigurationManager", this.GetType().Assembly);
  }

  private static SRPorted GetLoader()
  {
    if (SRPorted.loader == null)
    {
      SRPorted sr = new SRPorted();
      Interlocked.CompareExchange<SRPorted>(ref SRPorted.loader, sr, (SRPorted) null);
    }
    return SRPorted.loader;
  }

  private static CultureInfo Culture
  {
    get
    {
      return (CultureInfo) null;
    }
  }

  public static ResourceManager Resources
  {
    get
    {
      return SRPorted.GetLoader().resources;
    }
  }

  public static string GetString(string name, params object[] args)
  {
    SRPorted loader = SRPorted.GetLoader();
    if (loader == null)
      return (string) null;
    string format = loader.resources.GetString(name, SRPorted.Culture);
    if (args == null || args.Length == 0)
      return format;
    for (int index = 0; index < args.Length; ++index)
    {
      string str = args[index] as string;
      if (str != null && str.Length > 1024)
        args[index] = (object) (str.Substring(0, 1021) + "...");
    }
    return string.Format((IFormatProvider) CultureInfo.CurrentCulture, format, args);
  }

  public static string GetString(string name)
  {
    SRPorted loader = SRPorted.GetLoader();
    if (loader == null)
      return (string) null;
    return loader.resources.GetString(name, SRPorted.Culture);
  }

  public static string GetString(string name, out bool usedFallback)
  {
    usedFallback = false;
    return SRPorted.GetString(name);
  }

  public static object GetObject(string name)
  {
    SRPorted loader = SRPorted.GetLoader();
    if (loader == null)
      return (object) null;
    return loader.resources.GetObject(name, SRPorted.Culture);
  }

	internal static string Format(string resourceFormat, params object[] args)
	{
		if (args != null) {
			return string.Format (CultureInfo.InvariantCulture, resourceFormat, args);
		}

		return resourceFormat;
	}

	internal static string Format(string resourceFormat, object p1)
	{
		return string.Format (CultureInfo.InvariantCulture, resourceFormat, p1);
	}

	internal static string Format(string resourceFormat, object p1, object p2)
	{
		return string.Format (CultureInfo.InvariantCulture, resourceFormat, p1, p2);
	}

	internal static string Format(string resourceFormat, object p1, object p2, object p3)
	{
		return string.Format (CultureInfo.InvariantCulture, resourceFormat, p1, p2, p3);
	}

	internal static string GetResourceString (string str) => str;

}
