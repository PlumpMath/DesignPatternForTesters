//-----------------------------------------------------------------------
// <copyright file="BasePageElementMap.cs" company="ShareKnowledge">
//     Copyright (c) ShareKnowledge. All rights reserved.
// </copyright>
// <author>Alejandro Perdomo</author>
//-----------------------------------------------------------------------

namespace Testing.FacadePattern.Template
{
  #region Imports

  using OpenQA.Selenium;
  using Util;
  #endregion

  public class BasePageElementMap
  {
    public BasePageElementMap()
    {
      this.Driver = DriverSingleton.Instance.Browser;
    }
    #region Properties

    public IWebDriver Driver { get; }

    #endregion Properties
  }
}
