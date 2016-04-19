//-----------------------------------------------------------------------
// <copyright file="AssignSeatMap.cs" company="ShareKnowledge">
//     Copyright (c) ShareKnowledge. All rights reserved.
// </copyright>
// <author>Alejandro Perdomo</author>
//-----------------------------------------------------------------------

namespace DesignPatter.Testing.PageObjectPattern.ThreeLayerPageObject.Pages
{
  #region Imports

  using OpenQA.Selenium;

  #endregion Imports

  internal class AssignSeatMap
  {
    #region Attributes

    private readonly IWebDriver driver;

    #endregion Attributes

    #region Constructors

    public AssignSeatMap(IWebDriver driver)
    {
      this.driver = driver;
    }

    #endregion Constructors

    #region Properties

    public IWebElement FirstSeat =>
        this.driver.FindElement(By.CssSelector("label[for='4,12']"));

    public IWebElement SecondSeat =>
        this.driver.FindElement(By.CssSelector("label[for='4,13']"));

    public IWebElement ThirdSeat =>
        this.driver.FindElement(By.CssSelector("label[for=\'4,14']"));

    public IWebElement Continue =>
        this.driver.FindElement(By.CssSelector("button.btn:nth-child(2)"));

    #endregion Properties
  }
}