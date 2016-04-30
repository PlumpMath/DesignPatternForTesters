using Dojo.DesignPattern.Testing.Template;
using OpenQA.Selenium;

namespace Dojo.DesignPattern.Testing.Pages
{
  public class ConfirmationMap : BasePageElementMap
  {
    public IWebElement Finalize =>
      this.Driver.FindElement(By.CssSelector(".btn"));
  }
}