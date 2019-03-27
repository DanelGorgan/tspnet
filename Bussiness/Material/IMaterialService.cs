using ModelDesignFirst_L1;
using System.Collections.Generic;

namespace Business
{
    public interface IMaterialService
    {
        void Create(Material material);
        IEnumerable<Material> ReadAll();
        Material FindById(int materialId);
        void Delete(int materialId);
    }
}
