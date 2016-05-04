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

    public PageBase(IWebDriver driver)
    {
      this.Driver = driver;
      this.Map = new T();
      this.Map.Driver = this.Driver;
    }

    #endregion Constructors

    #region Properties

    protected IWebDriver Driver { get; }

    protected T Map { get; }

    #endregion Properties
  }
}
