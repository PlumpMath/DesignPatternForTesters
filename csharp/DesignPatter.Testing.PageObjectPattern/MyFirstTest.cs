//-----------------------------------------------------------------------
// <copyright file="MyFirstTest.cs" company="ShareKnowledge">
//     Copyright (c) ShareKnowledge. All rights reserved.
// </copyright>
// <author>Alejandro Perdomo</author>
//-----------------------------------------------------------------------

namespace DesignPatter.Testing.PageObjectPattern
{
  #region Imports

  using NUnit.Framework;

  #endregion Imports

  [TestFixture]
  public class MyFirstTest
  {
    private int result;

    [Test]
    public void Test()
    {
      this.result = 5 + 3;
      Assert.AreEqual(8, this.result);
    }
  }
}
