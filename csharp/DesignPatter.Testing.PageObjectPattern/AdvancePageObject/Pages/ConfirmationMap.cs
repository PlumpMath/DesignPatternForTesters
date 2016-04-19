//-----------------------------------------------------------------------
// <copyright file="ConfirmationMap.cs" company="ShareKnowledge">
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

  internal class ConfirmationMap : BasePageElementMap
  {
    #region Properties

    public IWebElement Finilize =>
        this.Driver.FindElement(By.CssSelector(".btn"));

    #endregion Properties
  }
}
