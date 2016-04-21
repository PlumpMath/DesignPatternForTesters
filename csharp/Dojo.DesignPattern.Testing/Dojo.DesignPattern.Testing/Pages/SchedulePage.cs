using Dojo.DesignPattern.Testing.Template;
using OpenQA.Selenium;

namespace Dojo.DesignPattern.Testing.Pages
{
  public class SchedulePage : PageBase<SchedulePageMap>
  {
    public SchedulePage(IWebDriver driver) : base(driver)
    {
    }

    public SelectSeatPage SelectShowTime(string showTime, int seats)
    {
      this.Map.ShowTime.SelectByValue(showTime);
      this.Map.Seats.SelectByValue(seats.ToString());
      this.Map.Continue.Click();

      return new SelectSeatPage(this.Driver);
    }
  }
}