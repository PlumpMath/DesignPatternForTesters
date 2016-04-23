//-----------------------------------------------------------------------
// <copyright file="ConfirmationPage.cs" company="ShareKnowledge">
//     Copyright (c) ShareKnowledge. All rights reserved.
// </copyright>
// <author>Alejandro Perdomo</author>
//-----------------------------------------------------------------------

namespace Testing.Ioc.Pages
{
  #region Imports

  using Template;
  using Util;
  using Util.Interfaces;
  #endregion Imports

  public class ConfirmationPage : BasePage<ConfirmationMap>, IConfirmationPage
  {
    #region Constructors

    public ConfirmationPage() : base()
    {
    }

    #endregion Constructors

    #region Methods

    public IEliteMoviePage Finish()
    {
      this.Map.Finalize.Click();
      return PageFactory.Get<IEliteMoviePage>();
    }

    #endregion Methods
  }
}
