//-----------------------------------------------------------------------
// <copyright file="EliteMoviePage.cs" company="ShareKnowledge">
//     Copyright (c) ShareKnowledge. All rights reserved.
// </copyright>
// <author>Alejandro Perdomo</author>
//-----------------------------------------------------------------------

namespace DesignPatter.Testing.PageObjectPattern.PageObject.Pages
{
  #region Imports

  using OpenQA.Selenium;

  #endregion Imports

  internal class EliteMoviePage
  {
    #region Attributes

    private readonly IWebDriver driver;

    #endregion Attributes

    #region Constructors

    public EliteMoviePage(IWebDriver driver)
    {
      this.driver = driver;
    }

    #endregion Constructors

    #region Properties

    private IWebElement SearchFilm =>
        this.driver.FindElement(By.CssSelector(".searchfield"));

    private IWebElement FirstFilm =>
        this.driver.FindElement(By.CssSelector("a.ng-scope:nth-child(1) > img:nth-child(1)"));

    #endregion Properties

    #region Methods

    public SelectionSchedulePage SelectFilm(string film)
    {
      this.SearchFilm.SendKeys(film);
      this.FirstFilm.Click();
      return new SelectionSchedulePage(this.driver);
    }

    #endregion Methods 
  }
}