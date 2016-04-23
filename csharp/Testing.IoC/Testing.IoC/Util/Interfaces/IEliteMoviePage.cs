//-----------------------------------------------------------------------
// <copyright file="IEliteMoviePage.cs" company="ShareKnowledge">
//     Copyright (c) ShareKnowledge. All rights reserved.
// </copyright>
// <author>Alejandro Perdomo</author>
//-----------------------------------------------------------------------

namespace Testing.Ioc.Util.Interfaces
{
  #region Imports

  using Pages;

  #endregion Imports

  public interface IEliteMoviePage
  {
    #region Methods

    ISelectionSchedulePage SelectFilm(string film);

    #endregion Methods 
  }
}
