//-----------------------------------------------------------------------
// <copyright file="ConfirmationPage.cs" company="ShareKnowledge">
//     Copyright (c) ShareKnowledge. All rights reserved.
// </copyright>
// <author>Alejandro Perdomo</author>
//-----------------------------------------------------------------------

namespace DesignPatter.Testing.PageObjectPattern.ThreeLayerPageObject.Pages
{
  #region Imports

  using OpenQA.Selenium;

  #endregion Imports

  internal class ConfirmationPage
  {
    #region Attributes

    private readonly IWebDriver driver;
    private readonly ConfirmationMap map;

    #endregion Attributes

    #region Constructors

    public ConfirmationPage(IWebDriver driver)
    {
      this.driver = driver;
      this.map = new ConfirmationMap(this.driver);
    }

    #endregion Constructors

    #region Methods

    public EliteMoviePage Finish()
    {
      this.map.Finilize.Click();
      return new EliteMoviePage(this.driver);
    }

    #endregion Methods
  }
}
