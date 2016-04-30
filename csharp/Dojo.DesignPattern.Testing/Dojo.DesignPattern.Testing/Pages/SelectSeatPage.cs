using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dojo.DesignPattern.Testing.Template;
using OpenQA.Selenium;

namespace Dojo.DesignPattern.Testing.Pages
{
  public class SelectSeatPage : PageBase<SelectSeatMap>
  {
    public SelectSeatPage(IWebDriver driver) : base(driver)
    {

    }

    public ConfirmationPage SelectSeats()
    {
      this.Map.FirstSeat.Click();
      this.Map.SecondSeat.Click();
      this.Map.ThirdSeat.Click();
      this.Map.Continue.Click();

      return new ConfirmationPage(this.Driver);
    }
  }
}
