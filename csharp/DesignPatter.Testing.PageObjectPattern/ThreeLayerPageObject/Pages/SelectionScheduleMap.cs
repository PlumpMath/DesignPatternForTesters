//-----------------------------------------------------------------------
// <copyright file="SelectionScheduleMap.cs" company="ShareKnowledge">
//     Copyright (c) ShareKnowledge. All rights reserved.
// </copyright>
// <author>Alejandro Perdomo</author>
//-----------------------------------------------------------------------

namespace DesignPatter.Testing.PageObjectPattern.ThreeLayerPageObject.Pages
{
  using System.Globalization;
  #region Imports

  using OpenQA.Selenium;
  using OpenQA.Selenium.Support.UI;

  #endregion Imports

  internal class SelectionScheduleMap
  {
    #region Attributes

    private readonly IWebDriver driver;

    #endregion Attributes

    #region Constructors

    public SelectionScheduleMap(IWebDriver driver)
    {
      this.driver = driver;
    }

    #endregion Constructors

    #region Properties

    public SelectElement Function =>
        new SelectElement(this.driver.FindElement(By.Id("showTime")));

    public SelectElement Seats =>
        new SelectElement(this.driver.FindElement(By.Name("seats")));

    public IWebElement Continue =>
        this.driver.FindElement(By.CssSelector("input.btn"));

    #endregion properties
  }
}
