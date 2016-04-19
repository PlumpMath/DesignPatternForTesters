//-----------------------------------------------------------------------
// <copyright file="ConfirmationPage.cs" company="ShareKnowledge">
//     Copyright (c) ShareKnowledge. All rights reserved.
// </copyright>
// <author>Alejandro Perdomo</author>
//-----------------------------------------------------------------------

namespace DesignPatter.Testing.PageObjectPattern.PageObject.Pages
{
  #region Imports

  using OpenQA.Selenium;

  #endregion Imports

  internal class ConfirmationPage
  {
    #region Attributes

    private readonly IWebDriver driver;

    #endregion Attributes

    #region Constructors

    public ConfirmationPage(IWebDriver driver)
    {
      this.driver = driver;
    }

    #endregion Constructors

    #region Properties

    private IWebElement Finilize =>
        this.driver.FindElement(By.CssSelector(".btn"));

    #endregion Properties

    #region Methods

    public EliteMoviePage Finish()
    {
      this.Finilize.Click();
      return new EliteMoviePage(this.driver);
    }

    #endregion Methods
  }
}
