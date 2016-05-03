using Dojo.DesignPattern.Testing.Template;
using OpenQA.Selenium;

namespace Dojo.DesignPattern.Testing.Pages
{
  public class ConfirmationPage : PageBase<ConfirmationMap>
  {
    public ConfirmationPage(IWebDriver driver) : base(driver)
    {
    }

    public EliteMoviePage Confirm()
    {
      this.Map.Finalize.Click();
      return new EliteMoviePage(this.Driver);
    }
  }
}