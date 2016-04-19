//-----------------------------------------------------------------------
// <copyright file="AssignSeatPage.cs" company="ShareKnowledge">
//     Copyright (c) ShareKnowledge. All rights reserved.
// </copyright>
// <author>Alejandro Perdomo</author>
//-----------------------------------------------------------------------

namespace DesignPatter.Testing.PageObjectPattern.ThreeLayerPageObject.Pages
{
  #region Imports

  using OpenQA.Selenium;

  #endregion Imports

  internal class AssignSeatPage
  {
    #region Attributes

    private readonly IWebDriver driver;
    private readonly AssignSeatMap map;

    #endregion Attributes

    #region Constructors

    public AssignSeatPage(IWebDriver driver)
    {
      this.driver = driver;
      this.map = new AssignSeatMap(this.driver);
    }

    #endregion Constructors

    #region Methods

    public ConfirmationPage SelectSeats()
    {
      this.map.FirstSeat.Click();
      this.map.SecondSeat.Click();
      this.map.ThirdSeat.Click();

      this.map.Continue.Click();
      return new ConfirmationPage(this.driver);
    }

    #endregion Methods
  }
}