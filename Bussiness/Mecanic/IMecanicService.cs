using ModelDesignFirst_L1;
using System.Collections.Generic;

namespace Business
{
    public interface IMecanicService
    {
        void Create(Mecanic mecanic);
        IEnumerable<Mecanic> ReadAll();
        Mecanic FindById(int mecanicId);
        void Delete(int mecanicId);
    }
}
