//-----------------------------------------------------------------------
// <copyright file="BasePage.cs" company="ShareKnowledge">
//     Copyright (c) ShareKnowledge. All rights reserved.
// </copyright>
// <author>Alejandro Perdomo</author>
//-----------------------------------------------------------------------

namespace Testing.Ioc.Template
{
  #region Imports

  using OpenQA.Selenium;

  #endregion Imports

  public class BasePage<T>
        where T : BasePageElementMap, new()
  {
    #region Constructors

    public BasePage()
    {
      this.Map = new T();
    }

    #endregion Constructors

    #region Properties

    protected T Map { get; }

    #endregion Properties
  }
}
