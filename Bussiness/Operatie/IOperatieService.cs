using ModelDesignFirst_L1;
using System.Collections.Generic;

namespace Business
{
    public interface IOperatieService
    {
        void Create(Operatie operatie);
        IEnumerable<Operatie> ReadAll();
        void Delete(int operatieId);
        Operatie FindById(int operatieId);
    }
}
