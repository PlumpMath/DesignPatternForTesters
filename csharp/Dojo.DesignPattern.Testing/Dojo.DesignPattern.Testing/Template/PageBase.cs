using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Dojo.DesignPattern.Testing.Template
{
  public class PageBase<T> where T : BasePageElementMap, new()
  {
    #region Constructors

    public PageBase(IWebDriver driver)
    {
      this.Driver = driver;
      this.Map = new T();
      this.Map.Driver = this.Driver;
    }

    #endregion Constructors

    #region Properties

    protected IWebDriver Driver { get; }

    protected T Map { get; }

    #endregion Properties
  }
}
