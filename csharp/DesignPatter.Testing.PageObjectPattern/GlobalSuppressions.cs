//-----------------------------------------------------------------------
// <copyright file="GlobalSuppressions.cs" company="ShareKnowledge">
//     Copyright (c) ShareKnowledge. All rights reserved.
// </copyright>
// <author>Alejandro Perdomo</author>
//-----------------------------------------------------------------------

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Scope = "type", Target = "DesignPatter.Testing.PageObjectPattern.Entity.ShowTime", Justification = "Create for deserealize Json")]
[assembly: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "DesignPatter.Testing.PageObjectPattern.PageObject", Justification = "Not is necesary have more pages")]
[assembly: SuppressMessage("Microsoft.Design", "CA2210:AssembliesShouldHaveValidStrongNames", Justification = "It don't containt with WebDriver sign")]
[assembly: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "DesignPatter.Testing.PageObjectPattern.ThreeLayerPageObject", Justification = "Not is necesary have more pages")]
[assembly: SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Scope = "type", Target = "DesignPatter.Testing.PageObjectPattern.AdvancePageObject.Pages.ConfirmationMap", Justification = "It Instances in execution time")]
[assembly: SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Scope = "type", Target = "DesignPatter.Testing.PageObjectPattern.AdvancePageObject.Pages.AssignSeatMap", Justification = "It Instances in execution time")]
[assembly: SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Scope = "type", Target = "DesignPatter.Testing.PageObjectPattern.AdvancePageObject.Pages.SelectionScheduleMap", Justification = "It Instances in execution time")]
[assembly: SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Scope = "type", Target = "DesignPatter.Testing.PageObjectPattern.AdvancePageObject.Pages.EliteMovieMap", Justification = "It Instances in execution time")]
[assembly: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "DesignPatter.Testing.PageObjectPattern.AdvancePageObject", Justification = "This is an example")]
[assembly: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "DesignPatter.Testing.PageObjectPattern.AdvancePageObject.Template", Justification = "This is an example")]
[assembly: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "DesignPatter.Testing.PageObjectPattern.AdvancePageObject.Validation", Justification = "This is an example")]
[assembly: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "DesignPatter.Testing.PageObjectPattern", Justification = "This is an example")]