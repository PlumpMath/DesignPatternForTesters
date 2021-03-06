//-----------------------------------------------------------------------
// <copyright file="GlobalSuppressions.cs" company="ShareKnowledge">
//     Copyright (c) ShareKnowledge. All rights reserved.
// </copyright>
// <author>Alejandro Perdomo</author>
//-----------------------------------------------------------------------

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Scope = "type", Target = "Testing.FluentPattern.Pages.AssignSeatMap", Justification = "It Instances in execution time")]
[assembly: SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Scope = "type", Target = "Testing.FluentPattern.Pages.ConfirmationMap", Justification = "It Instances in execution time")]
[assembly: SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Scope = "type", Target = "Testing.FluentPattern.Pages.EliteMovieMap", Justification = "It Instances in execution time")]
[assembly: SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Scope = "type", Target = "Testing.FluentPattern.Pages.SelectionScheduleMap", Justification = "It Instances in execution time")]
[assembly: SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Scope = "type", Target = "Testing.FluentPattern.Entity.ShowTime", Justification = "Create for deserealize Json")]
[assembly: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "Testing.FluentPattern", Justification = "Not is necesary have more pages")]
[assembly: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "Testing.FluentPattern.Template", Justification = "Page Object Pattern Template")]
[assembly: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "Testing.FluentPattern.Validation", Justification = "Are not necessary more API validations")]
[assembly: SuppressMessage("Microsoft.Design", "CA2210:AssembliesShouldHaveValidStrongNames", Justification = "It don't containt with WebDriver sign")]
[assembly: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "Testing.FluentPattern.Entity", Justification = "Not is necesary for this example")]
[assembly: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "Testing.FluentPattern.Util", Justification = "Example of Facede Pattern")]
