//-----------------------------------------------------------------------
// <copyright file="BasePage.cs" company="ShareKnowledge">
//     Copyright (c) ShareKnowledge. All rights reserved.
// </copyright>
// <author>Alejandro Perdomo</author>
//-----------------------------------------------------------------------

namespace Testing.FacadePattern.Template
{
  #region Imports

  using OpenQA.Selenium;
  using Util;
  #endregion Imports

  public class BasePage<T>
        where T : BasePageElementMap, new()
  {
    #region Constructors

    public BasePage()
    {
      this.Driver = DriverSingleton.Instance.Browser;
      this.Map = new T();
    }

    #endregion Constructors

    #region Properties

    protected IWebDriver Driver { get; }

    protected T Map { get; }

    #endregion Properties
  }
}
