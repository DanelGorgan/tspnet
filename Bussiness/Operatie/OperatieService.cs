using ModelDesignFirst_L1;
using Persistence;
using System.Collections.Generic;
using System.Linq;

namespace Business
{
    public class OperatieService : IOperatieService
    {
        private readonly IRepository<Operatie> operatieRepository;
        public OperatieService(IRepository<Operatie> operatieRepository)
        {
            this.operatieRepository = operatieRepository;
        }

        public void Create(Operatie operatie)
        {
            if (operatie != null)
            {
                throw new System.ArgumentNullException();
            }

            operatieRepository.Add(operatie);
            operatieRepository.Save();
        }

        public void Delete(int operatieId)
        {
            if (operatieId > 0)
            {
                throw new System.ArgumentNullException();
            }
            operatieRepository.Delete(operatieId);
            operatieRepository.Save();
        }

        public void Update(Operatie operatie)
        {
            if (operatie == null)
            {
                throw new System.ArgumentNullException();
            }

            var operatieU = operatieRepository.Where(a => a.Id == operatie.Id).FirstOrDefault();

            operatieU.Denumire = operatie.Denumire == null ? operatieU.Denumire : operatie.Denumire;
            operatieU.DetaliuComanda = operatie.DetaliuComanda == null ? operatieU.DetaliuComanda : operatie.DetaliuComanda;
            operatieU.TimpExecutie = operatie.TimpExecutie == default(decimal) ? operatieU.TimpExecutie : operatie.TimpExecutie;

            operatieRepository.Save();
        }

        public IEnumerable<Operatie> ReadAll()
        {
            var operatiees = operatieRepository.GetAll();
            if (operatiees == null)
            {
                return null;
            }
            return operatiees;
        }

        public Operatie FindById(int operatieId)
        {

            if (!(operatieId > 0))
            {
                throw new System.ArgumentNullException();
            }
            var op = operatieRepository.FindById(operatieId);
            if (op == null)
            {
                return null;
            }
            return op;
        }
    }
}
