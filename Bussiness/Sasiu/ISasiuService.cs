using ModelDesignFirst_L1;
using System.Collections.Generic;

namespace Business
{
    public interface ISasiuService
    {
        void Create(Sasiu sasiu);
        IEnumerable<Sasiu> ReadAll();
        Sasiu FindById(int sasiuId);
        void Delete(int sasiuId);
    }
}
