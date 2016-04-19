//-----------------------------------------------------------------------
// <copyright file="AssignSeatPage.cs" company="ShareKnowledge">
//     Copyright (c) ShareKnowledge. All rights reserved.
// </copyright>
// <author>Alejandro Perdomo</author>
//-----------------------------------------------------------------------

namespace DesignPatter.Testing.PageObjectPattern.AdvancePageObject.Pages
{
  #region Imports

  using OpenQA.Selenium;
  using Template;

  #endregion Imports

  internal class AssignSeatPage : BasePage<AssignSeatMap>
  {
    #region Constructors

    public AssignSeatPage(IWebDriver driver) : base(driver)
    {
    }

    #endregion Constructors

    #region Methods

    public ConfirmationPage SelectSeats()
    {
      this.Map.FirstSeat.Click();
      this.Map.SecondSeat.Click();
      this.Map.ThirdSeat.Click();

      this.Map.Continue.Click();

      return new ConfirmationPage(this.Driver);
    }

    #endregion Methods
  }
}