using ModelDesignFirst_L1;
using System.Collections.Generic;

namespace Business
{
    public interface IImagineService
    {
        void Create(Imagine imagine);
        IEnumerable<Imagine> ReadAll();
        Imagine FindById(int imagineId);
        void Delete(int imagineId);
    }
}
