//-----------------------------------------------------------------------
// <copyright file="AssignSeatPage.cs" company="ShareKnowledge">
//     Copyright (c) ShareKnowledge. All rights reserved.
// </copyright>
// <author>Alejandro Perdomo</author>
//-----------------------------------------------------------------------

namespace Testing.Ioc.Pages
{
  #region Imports

  using System.Collections.Generic;
  using System.Linq;
  using Entity;
  using Template;
  using Util;
  using Util.Interfaces;
  #endregion Imports

  public class AssignSeatPage : BasePage<AssignSeatMap>, IAssignSeatPage
  {
    #region Constructors

    public AssignSeatPage() : base()
    {
    }

    #endregion Constructors

    #region Methods

    public IConfirmationPage SelectSeats(ICollection<Seat> seats)
    {
      seats.ToList().ForEach(current => this.Map.Seat(current.Row, current.Column).Click());
      this.Map.Continue.Click();

      return PageFactory.Get<IConfirmationPage>();
    }

    #endregion Methods
  }
}