namespace DomainModel.ViewModels
{
    using System;

    public interface ICalculationViewModel
    {
        DateTime ActionDateTime { get; }

        Guid ActionUserID { get; }

        Guid CalculationID { get; }

        string Name { get; }
    }
}