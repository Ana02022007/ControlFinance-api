using ControlFinance.Domain.Interfaces;

namespace ControlFinance.Application.Services
{
    public class PersonServices : IPersonServices
    {
        private readonly IPersonRepository _repository;
        public PersonServices(IPersonRepository repository)
        {
            _repository = repository;
        }

        public

    }
}
public interface IPersonServices
{
}