//-----------------------------------------------------------------------
// <copyright file="ConfirmationPage.cs" company="ShareKnowledge">
//     Copyright (c) ShareKnowledge. All rights reserved.
// </copyright>
// <author>Alejandro Perdomo</author>
//-----------------------------------------------------------------------

namespace Testing.FacadePattern.Pages
{
  #region Imports

  using OpenQA.Selenium;
  using Template;

  #endregion Imports

  internal class ConfirmationPage : BasePage<ConfirmationMap>
  {
    #region Constructors

    public ConfirmationPage() : base()
    {
    }

    #endregion Constructors

    #region Methods

    public EliteMoviePage Finish()
    {
      this.Map.Finilize.Click();
      return new EliteMoviePage();
    }

    #endregion Methods
  }
}
