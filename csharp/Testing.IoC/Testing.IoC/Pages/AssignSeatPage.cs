//-----------------------------------------------------------------------
// <copyright file="AssignSeatPage.cs" company="ShareKnowledge">
//     Copyright (c) ShareKnowledge. All rights reserved.
// </copyright>
// <author>Alejandro Perdomo</author>
//-----------------------------------------------------------------------

namespace Testing.Ioc.Pages
{
  #region Imports

  using System;
  using System.Collections.Generic;
  using System.Collections.ObjectModel;
  using System.Globalization;
  using System.Linq;
  using Entity;
  using OpenQA.Selenium;
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

      return ContainerFactory.Get<IConfirmationPage>();
    }

    public ICollection<Seat> BookedSeats()
    {
      List<Seat> bookedSeats = new List<Seat>();
      this.Map.BookedSeats
        .ToList()
        .ForEach(element => bookedSeats.Add(
          AssignSeatPage.ConvertToSeat(element.GetAttribute("id"))));

      return bookedSeats;
    }

    private static Seat ConvertToSeat(string position)
    {
      string[] axis = position.Split(',');

      return new Seat
      {
        Row = Convert.ToInt32(axis[0], CultureInfo.CurrentCulture),
        Column = Convert.ToInt32(axis[1], CultureInfo.CurrentCulture)
      };
    }

    #endregion Methods
  }
}