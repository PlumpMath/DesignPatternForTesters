//-----------------------------------------------------------------------
// <copyright file="PageBase.cs" company="ShareKnowledge">
//     Copyright (c) ShareKnowledge. All rights reserved.
// </copyright>
// <author>Alejandro Perdomo</author>
//-----------------------------------------------------------------------

namespace Dojo.DesignPattern.Testing.Template
{
  using OpenQA.Selenium;

  public class PageBase<T> where T : BasePageElementMap, new()
  {
    #region Constructors

    public PageBase()
    {
      this.Driver = WebDriver.Instance.Browser;
      this.Map = new T();
    }

    #endregion Constructors

    #region Properties

    protected IWebDriver Driver { get; }

    protected T Map { get; }

    #endregion Properties
  }
}
