using System;

namespace DomainModel.Models
{
    public interface ICalculation
    {
        Guid CalculationId { get; }

        string Name { get; }

        Guid ActionUserId { get; }

        DateTime ActionDateTime { get; }
    }
}