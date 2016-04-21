using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dojo.DesignPattern.Testing.Template;
using OpenQA.Selenium;

namespace Dojo.DesignPattern.Testing.Pages
{
  class EliteMoviePage : PageBase<EliteMovieMap>
  {
    public EliteMoviePage(IWebDriver driver) : base(driver)
    {
    }

    public SchedulePage SelectFilm(string filmName)
    {
      this.Map.SearchFilm.SendKeys("El Violinista del Diablo");
      this.Map.Film.Click();

      return new SchedulePage(this.Driver);
    }
  }
}
