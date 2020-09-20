using LJAF.Domain.Contract.Repositories;
using LJAF.Domain.Contract.Services;
using LJAF.Domain.Entity;

namespace LJAF.Infra.Data.Services
{
    public class BaseService<T> : IService<T> where T : BaseEntity
    {
        private readonly IRepository<T> _repository;

        public BaseService(IRepository<T> repository)
        {
            _repository = repository;
        }
    }
}
