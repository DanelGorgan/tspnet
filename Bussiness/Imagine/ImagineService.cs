using ModelDesignFirst_L1;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business
{
    public class ImagineService : IImagineService
    {
        private readonly IRepository<Imagine> imagineRepository;
        public ImagineService(IRepository<Imagine> imagineRepository)
        {
            this.imagineRepository = imagineRepository;
        }

        public void Create(Imagine imagine)
        {
            if (imagine != null)
            {
                throw new System.ArgumentNullException();
            }

            imagineRepository.Add(imagine);
            imagineRepository.Save();
        }

        public void Delete(int imagineId)
        {
            if (imagineId >0)
            {
                throw new System.ArgumentNullException();
            }
            imagineRepository.Delete(imagineId);
            imagineRepository.Save();
        }

        public Imagine FindById(int imagineId)
        {
            if (!(imagineId > 0))
            {
                throw new System.ArgumentNullException();
            }
            var imagine = imagineRepository.FindById(imagineId);
            if (imagine == null)
            {
                return null; 
            }
            return imagine;
        }

        public void Update(Imagine imagine)
        {
            if (imagine != null)
            {
                throw new System.ArgumentNullException();
            }
            var imagineU = imagineRepository.Where(i => i.Id == imagine.Id).FirstOrDefault();

            imagineU.Data = imagine.Data == default(DateTime) ? imagineU.Data : imagine.Data;
            imagineU.Descriere = imagine.Descriere == null ? imagineU.Descriere : imagine.Descriere;
            imagineU.DetaliuComanda = imagine.DetaliuComanda == null ? imagineU.DetaliuComanda : imagine.DetaliuComanda;
            imagineU.Foto = imagine.Foto == null ? imagineU.Foto : imagine.Foto;

            imagineRepository.Save();
        }

        public IEnumerable<Imagine> ReadAll()
        {
            var imagines = imagineRepository.GetAll();
            if (imagines == null)
            {
                return null;
            }
            return imagines;
        }
    }
}
