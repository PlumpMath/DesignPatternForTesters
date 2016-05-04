//-----------------------------------------------------------------------
// <copyright file="SchedulePageMap.cs" company="ShareKnowledge">
//     Copyright (c) ShareKnowledge. All rights reserved.
// </copyright>
// <author>Alejandro Perdomo</author>
//-----------------------------------------------------------------------

namespace Dojo.DesignPattern.Testing.Pages
{
  using OpenQA.Selenium;
  using OpenQA.Selenium.Support.UI;
  using Template;

  public class SchedulePageMap : BasePageElementMap
  {
    public SelectElement ShowTime =>
      new SelectElement(this.Driver.FindElement(By.Id("showTime")));

    public SelectElement Seats =>
      new SelectElement(this.Driver.FindElement(By.Name("seats")));

    public IWebElement Continue =>
      this.Driver.FindElement(By.CssSelector("input.btn"));
  }
}
