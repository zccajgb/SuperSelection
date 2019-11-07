using DomainModel.Documents.Commands;
using DomainModel.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitTests.ModelsTests.SelectivityCalculationTests
{
    [TestClass]
    public class When_Creating_From_Constructor : BaseTest
    {
        private List<Ligand> ligands;
        private List<Receptor> receptors;
        private CreateSelectivityCalculationCommand cmd;

        public When_Creating_From_Constructor()
        {
            this.ligands = new List<Ligand>()
            {
                new Ligand(1e-9m, 1, 0.5m, new List<decimal>() { 1m, 2m, 3m }),
                new Ligand(1e-9m, 1, 0.5m, new List<decimal>() { 4m, 5m, 6m }),
                new Ligand(1e-9m, 1, 0.5m, new List<decimal>() { 7m, 8m, 9m }),
            };

            this.receptors = new List<Receptor>()
            {
                new Receptor(1, 0.5m),
                new Receptor(1, 0.5m),
                new Receptor(1, 0.5m),
            };

            this.cmd = new CreateSelectivityCalculationCommand("test", default, this.ligands, this.receptors, 1m, 1m, 1m, default, default, default, default);
        }

        [TestMethod]
        public void Then_Chi_Matrix_Is_Correctly_Formed()
        {
            var sut = new SelectivityCalculation(this.cmd);

            var expectedChi = new decimal[][]
            {
                new decimal[] { 0, 0, 0, 1, 2, 3 },
                new decimal[] { 0, 0, 0, 4, 5, 6 },
                new decimal[] { 0, 0, 0, 7, 8, 9 },
                new decimal[] { 1, 4, 7, 0, 0, 0 },
                new decimal[] { 2, 5, 8, 0, 0, 0 },
                new decimal[] { 3, 6, 9, 0, 0, 0 },
            };

            foreach ((var actualRow, var expectedRow) in sut.Chi.Zip(expectedChi, (x, y) => (x, y)))
            {
                CollectionAssert.AreEquivalent(expectedRow, actualRow);
            }
        }
    }
}
