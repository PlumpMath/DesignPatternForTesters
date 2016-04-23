//-----------------------------------------------------------------------
// <copyright file="PageFactory.cs" company="ShareKnowledge">
//     Copyright (c) ShareKnowledge. All rights reserved.
// </copyright>
// <author>Alejandro Perdomo</author>
//-----------------------------------------------------------------------

namespace Testing.Ioc.Util
{
  #region Imports

  using System.Configuration;
  using static System.FormattableString;
  using Microsoft.Practices.Unity;
  using Microsoft.Practices.Unity.Configuration;
  using NUnit.Framework;

  #endregion  Imports

  public static class PageFactory
  {
    private static IUnityContainer container = Load();

    public static T Get<T>()
    {
      return container.Resolve<T>();
    }

    private static IUnityContainer Load()
    {
      ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap
      {
        ExeConfigFilename = Invariant($@"{TestContext.CurrentContext.TestDirectory}\unity.config")
      };

      Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
      UnityConfigurationSection unitySection = configuration.GetSection("unity") as UnityConfigurationSection;

      using (IUnityContainer result = new UnityContainer())
      {
        result.LoadConfiguration(unitySection);
        return result;
      }
    }
  }
}
