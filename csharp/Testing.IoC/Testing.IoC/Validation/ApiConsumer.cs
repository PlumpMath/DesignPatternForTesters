//-----------------------------------------------------------------------
// <copyright file="ApiConsumer.cs" company="ShareKnowledge">
//     Copyright (c) ShareKnowledge. All rights reserved.
// </copyright>
// <author>Alejandro Perdomo</author>
//-----------------------------------------------------------------------

namespace Testing.Ioc.Validation
{
  #region Imports

  using System;
  using System.Net;
  using Newtonsoft.Json;

  #endregion Imports

  public static class ApiConsumer
  {
    #region Methods

    public static T RequestGet<T>(Uri url)
    {
      T parsed = default(T);

      using (WebClient request = new WebClient())
      {
        string response = request.DownloadString(url);
        parsed = JsonConvert.DeserializeObject<T>(response);
      }

      return parsed;
    }

    #endregion Methods
  }
}
