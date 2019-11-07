namespace DomainModel.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using DomainModel.ViewModels;

    public interface ISelectivityCalculationsRepository
    {
        IEnumerable<ICalculationViewModel> GetAllByUserID(Guid userID);
        ICalculationViewModel GetByID(Guid calcID);
    }
}