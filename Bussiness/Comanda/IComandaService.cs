using ModelDesignFirst_L1;
using System.Collections.Generic;

namespace Business
{
    public interface IComandaService
    {
        void Create(Comanda comanda);
        IEnumerable<Comanda> ReadAll();
        Comanda FindById(int comandaId);
        void Delete(Comanda comanda);
    }
}
