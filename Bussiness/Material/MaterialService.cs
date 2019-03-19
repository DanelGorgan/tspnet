using ModelDesignFirst_L1;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business
{
    public class MaterialService : IMaterialService
    {
        private readonly IRepository<Material> materialRepository;
        public MaterialService(IRepository<Material> materialRepository)
        {
            this.materialRepository = materialRepository;
        }

        public void Create(Material material)
        {
            if (material != null)
            {
                throw new System.ArgumentNullException();
            }

            materialRepository.Add(material);
            materialRepository.Save();
        }

        public void Delete(Material material)
        {
            if (material != null)
            {
                throw new System.ArgumentNullException();
            }
            materialRepository.Delete(material);
            materialRepository.Save();
        }

        public Material FindById(int materialId)
        {
            if (!(materialId > 0))
            {
                throw new System.ArgumentNullException();
            }
            var material = materialRepository.FindById(materialId);
            if (material == null)
            {
                return null; 
            }
            return material;
        }

        public void Update(Material material)
        {
            if (material != null)
            {
                throw new System.ArgumentNullException();
            }

            var materialU = materialRepository.Where(m => m.Id == material.Id).FirstOrDefault();

            materialU.Cantitate = material.Cantitate == default(decimal) ? materialU.Cantitate : material.Cantitate;
            materialU.Denumire = material.Denumire == null ? materialU.Denumire : material.Denumire;
            materialU.Pret = material.Pret == default(int) ? materialU.Pret : material.Pret;
            materialU.DataAprovizionare = materialU.DataAprovizionare == default(DateTime) ? material.DataAprovizionare : materialU.DataAprovizionare;
            materialU.DetaliuComanda = material.DetaliuComanda == null ? materialU.DetaliuComanda : material.DetaliuComanda;

            materialRepository.Save();
        }

        public IEnumerable<Material> ReadAll()
        {
            var materials = materialRepository.GetAll();
            if (materials == null)
            {
                return null;
            }
            return materials;
        }
    }
}
