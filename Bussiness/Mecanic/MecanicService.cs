using ModelDesignFirst_L1;
using Persistence;
using System.Collections.Generic;
using System.Linq;

namespace Business
{
    public class MecanicService : IMecanicService
    {
        private readonly IRepository<Mecanic> mecanicRepository;
        public MecanicService(IRepository<Mecanic> mecanicRepository)
        {
            this.mecanicRepository = mecanicRepository;
        }

        public void Create(Mecanic mecanic)
        {
            if (mecanic != null)
            {
                throw new System.ArgumentNullException();
            }

            mecanicRepository.Add(mecanic);
            mecanicRepository.Save();
        }

        public void Delete(int mecanicId)
        {
            if (mecanicId >0)
            {
                throw new System.ArgumentNullException();
            }
            mecanicRepository.Delete(mecanicId);
            mecanicRepository.Save();
        }

        public Mecanic FindById(int mecanicId)
        {
            if (!(mecanicId > 0))
            {
                throw new System.ArgumentNullException();
            }
            var mecanic = mecanicRepository.FindById(mecanicId);
            if (mecanic == null)
            {
                return null; 
            }
            return mecanic;
        }

        public void Update(Mecanic mecanic)
        {
            if (mecanic != null)
            {
                throw new System.ArgumentNullException();
            }
            var mecanicU = mecanicRepository.Where(m => m.Id == mecanic.Id).FirstOrDefault();

            mecanicU.Nume = mecanic.Nume == null ? mecanicU.Nume : mecanic.Nume;
            mecanicU.Prenume = mecanic.Prenume == null ? mecanicU.Prenume : mecanic.Prenume;
            mecanicU.DetaliuComanda = mecanic.DetaliuComanda == null ? mecanicU.DetaliuComanda : mecanic.DetaliuComanda;


            mecanicRepository.Save();
        }

        public IEnumerable<Mecanic> ReadAll()
        {
            var mecanics = mecanicRepository.GetAll();
            if (mecanics == null)
            {
                return null;
            }
            return mecanics;
        }
    }
}
