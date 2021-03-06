//-----------------------------------------------------------------------
// <copyright file="GlobalSuppressions.cs" company="ShareKnowledge">
//     Copyright (c) ShareKnowledge. All rights reserved.
// </copyright>
// <author>Alejandro Perdomo</author>
//-----------------------------------------------------------------------

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Scope = "type", Target = "Testing.SingletonPattern.Pages.AssignSeatMap", Justification = "It Instances in execution time")]
[assembly: SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Scope = "type", Target = "Testing.SingletonPattern.Pages.ConfirmationMap", Justification = "It Instances in execution time")]
[assembly: SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Scope = "type", Target = "Testing.SingletonPattern.Pages.EliteMovieMap", Justification = "It Instances in execution time")]
[assembly: SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Scope = "type", Target = "Testing.SingletonPattern.Pages.SelectionScheduleMap", Justification = "It Instances in execution time")]
[assembly: SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Scope = "type", Target = "Testing.SingletonPattern.Entity.ShowTime", Justification = "Create for deserealize Json")]
[assembly: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "Testing.SingletonPattern", Justification = "Not is necesary have more pages")]
[assembly: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "Testing.SingletonPattern.Template", Justification = "Page Object Pattern Template")]
[assembly: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "Testing.SingletonPattern.Validation", Justification = "Are not necessary more API validations")]
[assembly: SuppressMessage("Microsoft.Design", "CA2210:AssembliesShouldHaveValidStrongNames", Justification = "It don't containt with WebDriver sign")]
[assembly: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "Testing.SingletonPattern.Entity", Justification = "Not is necesary for this example")]
[assembly: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "Testing.SingletonPattern.Util", Justification = "Example of Facede Pattern")]
