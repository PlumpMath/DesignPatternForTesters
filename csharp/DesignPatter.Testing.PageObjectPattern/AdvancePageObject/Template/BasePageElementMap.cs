﻿//-----------------------------------------------------------------------
// <copyright file="BasePageElementMap.cs" company="ShareKnowledge">
//     Copyright (c) ShareKnowledge. All rights reserved.
// </copyright>
// <author>Alejandro Perdomo</author>
//-----------------------------------------------------------------------

namespace DesignPatter.Testing.PageObjectPattern.AdvancePageObject.Template
{
  #region Imports

  using OpenQA.Selenium;

  #endregion

  public class BasePageElementMap
  {
    #region Properties

    public IWebDriver Driver { get; set; }

    #endregion Properties
  }
}
