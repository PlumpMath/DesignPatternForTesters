//-----------------------------------------------------------------------
// <copyright file="ConfirmationPage.cs" company="ShareKnowledge">
//     Copyright (c) ShareKnowledge. All rights reserved.
// </copyright>
// <author>Alejandro Perdomo</author>
//-----------------------------------------------------------------------

namespace Dojo.DesignPattern.Testing.Pages
{
  using OpenQA.Selenium;
  using Template;

  public class ConfirmationPage : PageBase<ConfirmationMap>
  {
    public EliteMoviePage Confirm()
    {
      this.Map.Finalize.Click();
      return new EliteMoviePage();
    }
  }
}