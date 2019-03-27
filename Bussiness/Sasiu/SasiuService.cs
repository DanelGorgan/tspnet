using ModelDesignFirst_L1;
using Persistence;
using System.Collections.Generic;
using System.Linq;

namespace Business
{
    public class SasiuService : ISasiuService
    {
        private readonly IRepository<Sasiu> sasiuRepository;
        public SasiuService(IRepository<Sasiu> sasiuRepository)
        {
            this.sasiuRepository = sasiuRepository;
        }

        public void Create(Sasiu sasiu)
        {
            if (sasiu != null)
            {
                throw new System.ArgumentNullException();
            }

            sasiuRepository.Add(sasiu);
            sasiuRepository.Save();
        }

        public void Delete(int sasiuId)
        {
            if (sasiuId > 0)
            {
                throw new System.ArgumentNullException();
            }
            sasiuRepository.Delete(sasiuId);
            sasiuRepository.Save();
        }

        public Sasiu FindById(int sasiuId)
        {
            if (!(sasiuId > 0))
            {
                throw new System.ArgumentNullException();
            }
            var sasiu = sasiuRepository.FindById(sasiuId);
            if (sasiu == null)
            {
                return null; 
            }
            return sasiu;
        }

        public void Update(Sasiu sasiu)
        {
            if (sasiu != null)
            {
                throw new System.ArgumentNullException();
            }

            var sasiuU = sasiuRepository.Where(s => s.Id == sasiu.Id).FirstOrDefault();

            sasiuU.CodSasiu = sasiu.CodSasiu == null ? sasiuU.CodSasiu : sasiu.CodSasiu;
            sasiuU.Denumire = sasiu.Denumire == null ? sasiuU.Denumire : sasiu.Denumire;

            sasiuRepository.Save();
        }

        public IEnumerable<Sasiu> ReadAll()
        {
            var sasius = sasiuRepository.GetAll();
            if (sasius == null)
            {
                return null;
            }
            return sasius;
        }
    }
}
