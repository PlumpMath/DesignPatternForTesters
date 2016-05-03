using Dojo.DesignPattern.Testing.Template;
using OpenQA.Selenium;

namespace Dojo.DesignPattern.Testing.Pages
{
  public class SelectSeatMap : BasePageElementMap
  {
    public IWebElement Continue =>
      this.Driver.FindElement(By.CssSelector("button.btn:nth-child(2)"));

    public IWebElement Seat(int row, int colum)
    {
      return this.Driver.FindElement(By.CssSelector($"label[for='{row},{colum}']"));
    }

    public IWebElement SeatProperty(int row, int colum)
    {
      return this.Driver.FindElement(By.Id($"{row},{colum}"));
    }

  }
}