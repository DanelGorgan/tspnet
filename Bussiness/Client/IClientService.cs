using ModelDesignFirst_L1;
using System.Collections.Generic;

namespace Business
{
    public interface IClientService
    {
        void Create(Client client);
        IEnumerable<Client> ReadAll();
        Client FindById(int clientId);
        void Delete(int clientId);
        Client GetClientAutoes(int clientId);
    }
}
