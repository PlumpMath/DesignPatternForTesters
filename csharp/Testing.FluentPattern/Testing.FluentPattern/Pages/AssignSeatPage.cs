//-----------------------------------------------------------------------
// <copyright file="AssignSeatPage.cs" company="ShareKnowledge">
//     Copyright (c) ShareKnowledge. All rights reserved.
// </copyright>
// <author>Alejandro Perdomo</author>
//-----------------------------------------------------------------------

namespace Testing.FluentPattern.Pages
{
  #region Imports

  using System.Collections.Generic;
  using System.Linq;
  using Entity;
  using Template;

  #endregion Imports

  internal class AssignSeatPage : BasePage<AssignSeatMap>
  {
    #region Constructors

    public AssignSeatPage() : base()
    {
    }

    #endregion Constructors

    #region Methods

    public ConfirmationPage SelectSeats(ICollection<Seat> seats)
    {
      seats.ToList().ForEach(current => this.Map.Seat(current.Row, current.Column).Click());
      this.Map.Continue.Click();

      return new ConfirmationPage();
    }

    #endregion Methods
  }
}