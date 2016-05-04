//-----------------------------------------------------------------------
// <copyright file="ConfirmationMap.cs" company="ShareKnowledge">
//     Copyright (c) ShareKnowledge. All rights reserved.
// </copyright>
// <author>Alejandro Perdomo</author>
//-----------------------------------------------------------------------

namespace Dojo.DesignPattern.Testing.Pages
{
  using OpenQA.Selenium;
  using Template;

  public class ConfirmationMap : BasePageElementMap
  {
    public IWebElement Finalize =>
      this.Driver.FindElement(By.CssSelector(".btn"));
  }
}