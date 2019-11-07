namespace ApiGateway.Models.Validation
{
    using ApiGateway.Models.DomainModels;
    using FluentValidation;

    public class SelectivityCalculationValidator : AbstractValidator<SelectivityCalculation>
    {
        public SelectivityCalculationValidator()
        {
            this.RuleFor(x => x.Name).NotEmpty();
            this.RuleFor(x => x.Ligands).NotEmpty();
            this.RuleFor(x => x.Receptors).NotEmpty();
            this.RuleFor(x => x.Tolerance).NotEmpty();
            this.RuleFor(x => x.NanoparticleConc).NotEmpty();
            this.RuleFor(x => x.NanoparticleRadius).NotEmpty();
        }
    }
}
