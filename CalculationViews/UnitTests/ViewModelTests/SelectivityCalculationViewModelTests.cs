using DomainModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using AutoFixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using System.Linq;

namespace UnitTests.ViewModelTests
{
    [TestClass]
    public class SelectivityCalculationViewModelTests : BaseTest
    {
        private SelectivityCalculationViewModel sut;

        public SelectivityCalculationViewModelTests()
        {
            this.sut = new SelectivityCalculationViewModel(
                default,
                default,
                this.Fixture.CreateMany<Ligand>(),
                this.Fixture.CreateMany<Receptor>(),
                default,
                default,
                default,
                default,
                default,
                new List<Decimal>() { 1, 2, 3, 4, 5, 6 },
                default,
                default,
                default,
                default,
                default,
                default,
                default
                );
        }

        [TestMethod]
        public void Then_Binding_Probabilities_For_Ligands_Are_Created_Correctly()
        {
            this.sut.SetBindingProbability();
            for (var i = 0; i < this.sut.Ligands.Count(); i++)
            {
                this.sut.Ligands.ElementAt(i).BindingProbability
                .Should().Be(this.sut.BindingProbability.ElementAt(i));
            }
        }

        [TestMethod]
        public void Then_Binding_Probabilities_For_Receptors_Are_Created_Correctly()
        {
            this.sut.SetBindingProbability();
            var bindingProbabilities = this.sut.BindingProbability.Skip(this.sut.Ligands.Count());
            for (var i = 0; i < this.sut.Receptors.Count(); i++)
            {
                this.sut.Receptors.ElementAt(i).BindingProbability
                .Should().Be(bindingProbabilities.ElementAt(i));
            }
        }
    }
}
