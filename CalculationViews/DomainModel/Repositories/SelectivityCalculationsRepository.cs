namespace DomainModel.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using DomainModel.Entities;
    using DomainModel.Infrastructure;
    using DomainModel.ViewModels;
    using MongoDB.Driver;
    using MongoDB.Driver.Linq;

    public class SelectivityCalculationsRepository : ISelectivityCalculationsRepository
    {
        private readonly IMongoCollection<SelectivityCalculationsEntity> calculationViewModels;
        private IMapper mapper;

        public SelectivityCalculationsRepository(CalculationsDatabaseSettings settings, IMapper mapper)
        {
            this.mapper = mapper;

            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            this.calculationViewModels = database.GetCollection<SelectivityCalculationsEntity>(settings.CalculationsCollectionName);
        }

        public IEnumerable<ICalculationViewModel> GetAllByUserID(Guid userID)
        {
            var entities = this.calculationViewModels.Find(x => x.ActionUserID == userID)
                .ToList();
            var calcs = this.mapper.Map<IEnumerable<SelectivityCalculationViewModel>>(entities);

            return calcs;
        }

        public ICalculationViewModel GetByID(Guid calcID)
        {
            var entity = this.calculationViewModels.Find(x => x.CalculationID == calcID).First();
            var calc = this.mapper.Map<SelectivityCalculationViewModel>(entity);

            return calc;
        }

    }
}
