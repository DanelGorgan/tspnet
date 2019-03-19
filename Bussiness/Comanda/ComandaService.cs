using ModelDesignFirst_L1;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business
{
    public class ComandaService : IComandaService
    {
        private readonly IRepository<Comanda> comandaRepository;
        public ComandaService(IRepository<Comanda> comandaRepository)
        {
            this.comandaRepository = comandaRepository;
        }

        public void Create(Comanda comanda)
        {
            if (comanda != null)
            {
                throw new System.ArgumentNullException();
            }
            comanda.StareComanda = 0; // in asteptare
            comandaRepository.Add(comanda);
            comandaRepository.Save();
        }

        public void Delete(Comanda comanda)
        {
            if (comanda != null)
            {
                throw new System.ArgumentNullException();
            }
            comandaRepository.Delete(comanda);
            comandaRepository.Save();
        }

        public Comanda FindById(int comandaId)
        {
            if (!(comandaId > 0))
            {
                throw new System.ArgumentNullException();
            }
            var comanda = comandaRepository.FindById(comandaId);
            if (comanda == null)
            {
                return null; 
            }
            return comanda;
        }

        public void Update(Comanda comanda)
        {
            if (comanda != null)
            {
                throw new System.ArgumentNullException();
            }

            var comandaU = comandaRepository.Where(c => c.Id == comanda.Id).FirstOrDefault();

            comanda.Auto = comanda.Auto ==null ? comanda.Auto : comanda.Auto;
            comanda.Client = comanda.Client == null ? comanda.Client : comanda.Client;
            comanda.DataFinalizare = comanda.DataFinalizare == default(DateTime) ? comanda.DataFinalizare : comanda.DataFinalizare;
            comanda.DataProgramare = comanda.DataProgramare == default(DateTime) ? comanda.DataProgramare : comanda.DataProgramare;
            comanda.DataSystem = comanda.DataSystem == null ? comanda.DataSystem : comanda.DataSystem;
            comanda.Descriere = comanda.Descriere == null ? comanda.Descriere : comanda.Descriere;
            comanda.DetaliuComandas = comanda.DetaliuComandas == null ? comanda.DetaliuComandas : comanda.DetaliuComandas;
            comanda.KmBord = comanda.KmBord == default(int) ? comanda.KmBord : comanda.KmBord;
            comanda.StareComanda = comanda.StareComanda == default(int) ? comanda.StareComanda : comanda.StareComanda;
            comanda.ValoarePise = comanda.ValoarePise == default(int) ? comanda.ValoarePise : comanda.ValoarePise;
            comandaRepository.Save();
        }

        public IEnumerable<Comanda> ReadAll()
        {
            var comandas = comandaRepository.GetAll();
            if (comandas == null)
            {
                return null;
            }
            return comandas;
        }
    }
}
