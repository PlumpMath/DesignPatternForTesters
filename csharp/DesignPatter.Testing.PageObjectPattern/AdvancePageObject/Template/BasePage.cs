//-----------------------------------------------------------------------
// <copyright file="BasePage.cs" company="ShareKnowledge">
//     Copyright (c) ShareKnowledge. All rights reserved.
// </copyright>
// <author>Alejandro Perdomo</author>
//-----------------------------------------------------------------------

namespace DesignPatter.Testing.PageObjectPattern.AdvancePageObject.Template
{
  #region Imports

  using OpenQA.Selenium;

  #endregion Imports

  public class BasePage<T>
        where T : BasePageElementMap, new()
  {
    #region Constructors

    public BasePage(IWebDriver driver)
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
