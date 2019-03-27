using ModelDesignFirst_L1;
using Persistence;
using System.Collections.Generic;
using System.Linq;

namespace Business
{
    public class DetaliuComandaService : IDetaliuComandaService
    {
        private readonly IRepository<DetaliuComanda> detaliuComandaRepository;
        public DetaliuComandaService(IRepository<DetaliuComanda> detaliuComandaRepository)
        {
            this.detaliuComandaRepository = detaliuComandaRepository;
        }

        public void Create(DetaliuComanda detaliuComanda)
        {
            if (detaliuComanda != null)
            {
                throw new System.ArgumentNullException();
            }

            detaliuComandaRepository.Add(detaliuComanda);
            detaliuComandaRepository.Save();
        }

        public void Delete(int detaliuComandaId)
        {
            if (detaliuComandaId > 0)
            {
                throw new System.ArgumentNullException();
            }
            detaliuComandaRepository.Delete(detaliuComandaId);
            detaliuComandaRepository.Save();
        }

        public DetaliuComanda FindById(int detaliuComandaId)
        {
            if (!(detaliuComandaId > 0))
            {
                throw new System.ArgumentNullException();
            }
            var detaliuComanda = detaliuComandaRepository.FindById(detaliuComandaId);
            if (detaliuComanda == null)
            {
                return null; 
            }
            return detaliuComanda;
        }

        public void Update(DetaliuComanda detaliuComanda)
        {
            if (detaliuComanda != null)
            {
                throw new System.ArgumentNullException();
            }

            var comanda = detaliuComandaRepository.Where(c => c.Id == detaliuComanda.Id).FirstOrDefault();

            comanda.Comanda = detaliuComanda.Comanda == null ? comanda.Comanda : detaliuComanda.Comanda;
            comanda.Imagines = detaliuComanda.Imagines == null ? comanda.Imagines : detaliuComanda.Imagines;
            comanda.Materials = detaliuComanda.Materials == null ? comanda.Materials : detaliuComanda.Materials;
            comanda.Mecanics = detaliuComanda.Mecanics == null ? comanda.Mecanics : detaliuComanda.Mecanics;
            comanda.Operaties = detaliuComanda.Operaties == null ? comanda.Operaties : detaliuComanda.Operaties;

            detaliuComandaRepository.Save();
        }

        public IEnumerable<DetaliuComanda> ReadAll()
        {
            var detaliuComandas = detaliuComandaRepository.GetAll();
            if (detaliuComandas == null)
            {
                return null;
            }
            return detaliuComandas;
        }
    }
}
