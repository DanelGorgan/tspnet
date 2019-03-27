using ModelDesignFirst_L1;
using Persistence;
using System.Collections.Generic;
using System.Linq;

namespace Business
{
    public class AutoService : IAutoService
    {
        private readonly IRepository<Auto> autoRepository;
        public AutoService(IRepository<Auto> autoRepository)
        {
            this.autoRepository = autoRepository;
        }

        public void Create(Auto auto)
        {
            if (auto != null)
            {
                throw new System.ArgumentNullException();
            }

            autoRepository.Add(auto);
            autoRepository.Save();
        }

        public void Delete(int autoId)
        {
            if (autoId > 0)
            {
                throw new System.ArgumentNullException();
            }
            autoRepository.Delete(autoId);
            autoRepository.Save();
        }

        public Auto FindById(int autoId)
        {
            if (!(autoId > 0))
            {
                throw new System.ArgumentNullException();
            }
            var car = autoRepository.FindById(autoId);
            if (car == null)
            {
                return null;
            }
            return car;
        }

        public void Update(Auto auto)
        {
            if (auto == null)
            {
                throw new System.ArgumentNullException();
            }

            var car = autoRepository.Where(a => a.Id == auto.Id).FirstOrDefault();

            car.NumarAuto = auto.NumarAuto == null ? car.NumarAuto : auto.NumarAuto;
            car.SerieSasiu = auto.SerieSasiu == null ? car.SerieSasiu : auto.SerieSasiu;
            car.Sasius = auto.Sasius == null ? car.Sasius : auto.Sasius;

            autoRepository.Save();
        }

        public IEnumerable<Auto> ReadAll()
        {
            var autoes = autoRepository.GetAll();
            if (autoes == null)
            {
                return null;
            }
            return autoes;
        }
    }
}
