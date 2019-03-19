using ModelDesignFirst_L1;
using System.Collections.Generic;

namespace Business
{
    public interface IDetaliuComandaService
    {
        void Create(DetaliuComanda detaliuComanda);
        IEnumerable<DetaliuComanda> ReadAll();
        DetaliuComanda FindById(int detaliuComandaId);
        void Delete(DetaliuComanda detaliuComanda);
    }
}
