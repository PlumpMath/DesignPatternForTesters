//-----------------------------------------------------------------------
// <copyright file="IEliteMovieValidator.cs" company="ShareKnowledge">
//     Copyright (c) ShareKnowledge. All rights reserved.
// </copyright>
// <author>Alejandro Perdomo</author>
//-----------------------------------------------------------------------

namespace Testing.Ioc.Validation.Interfaces
{
  #region Imports

  using Entity;

  #endregion Imports

  public interface IEliteMovieValidator
  {
    Reserve Reserve { get; set; }

    void VerifiesReserveSeats();
  }
}
