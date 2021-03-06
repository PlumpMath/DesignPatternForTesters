//-----------------------------------------------------------------------
// <copyright file="GlobalSuppressions.cs" company="ShareKnowledge">
//     Copyright (c) ShareKnowledge. All rights reserved.
// </copyright>
// <author>Alejandro Perdomo</author>
//-----------------------------------------------------------------------

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Scope = "type", Target = "Testing.FacadePattern.Pages.AssignSeatMap", Justification = "It Instances in execution time")]
[assembly: SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Scope = "type", Target = "Testing.FacadePattern.Pages.ConfirmationMap", Justification = "It Instances in execution time")]
[assembly: SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Scope = "type", Target = "Testing.FacadePattern.Pages.EliteMovieMap", Justification = "It Instances in execution time")]
[assembly: SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Scope = "type", Target = "Testing.FacadePattern.Pages.SelectionScheduleMap", Justification = "It Instances in execution time")]
[assembly: SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Scope = "type", Target = "Testing.FacadePattern.Entity.ShowTime", Justification = "Create for deserealize Json")]
[assembly: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "Testing.FacadePattern", Justification = "Not is necesary have more pages")]
[assembly: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "Testing.FacadePattern.Template", Justification = "Page Object Pattern Template")]
[assembly: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "Testing.FacadePattern.Validation", Justification = "Are not necessary more API validations")]
[assembly: SuppressMessage("Microsoft.Design", "CA2210:AssembliesShouldHaveValidStrongNames", Justification = "It don't containt with WebDriver sign")]
[assembly: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "Testing.FacadePattern.Entity", Justification = "Not is necesary for this example")]
[assembly: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "Testing.FacadePattern.Util", Justification = "Example of Facede Pattern")]