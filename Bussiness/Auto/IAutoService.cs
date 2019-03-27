using ModelDesignFirst_L1;
using System.Collections.Generic;

namespace Business
{
    public interface IAutoService
    {
        void Create(Auto auto);
        IEnumerable<Auto> ReadAll();
        Auto FindById(int autoId);
        void Update(Auto auto);
        void Delete(int autoId);
    }
}
