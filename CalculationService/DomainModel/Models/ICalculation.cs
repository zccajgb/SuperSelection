using System;

namespace DomainModel.Models
{
    public interface ICalculation
    {
        Guid CalculationID { get; }

        string Name { get; }

        Guid ActionUserId { get; }

        DateTime ActionDateTime { get; }
    }
}