using Dojo.DesignPattern.Testing.Template;
using OpenQA.Selenium;

namespace Dojo.DesignPattern.Testing.Pages
{
  public class SelectSeatMap : BasePageElementMap
  {
    public IWebElement FirstSeat =>
      this.Driver.FindElement(By.CssSelector("label[for='4,12']"));

    public IWebElement SecondSeat =>
      Driver.FindElement(By.CssSelector("label[for='4,13']"));

    public IWebElement ThirdSeat =>
      this.Driver.FindElement(By.CssSelector("label[for=\'4,14']"));

    public IWebElement Continue =>
      this.Driver.FindElement(By.CssSelector("button.btn:nth-child(2)"));
  }
}