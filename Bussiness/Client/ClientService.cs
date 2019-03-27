using ModelDesignFirst_L1;
using Persistence;
using System.Collections.Generic;
using System.Linq;

namespace Business
{
    public class ClientService : IClientService
    {
        private readonly IRepository<Client> clientRepository;
        public ClientService(IRepository<Client> clientRepository)
        {
            this.clientRepository = clientRepository;
        }

        public void Create(Client client)
        {
            if (client != null)
            {
                throw new System.ArgumentNullException();
            }

            clientRepository.Add(client);
            clientRepository.Save();
        }

        public void Delete(int clientId)
        {
            if (clientId > 0)
            {
                throw new System.ArgumentNullException();
            }
            clientRepository.Delete(clientId);
            clientRepository.Save();
        }

        public Client FindById(int clientId)
        {
            if (!(clientId > 0))
            {
                throw new System.ArgumentNullException();
            }
            var client = clientRepository.FindById(clientId);
            if (client == null)
            {
                return null; 
            }
            return client;
        }

        public Client GetClientAutoes(int clientId)
        {
            if (!(clientId > 0))
            {
                throw new System.ArgumentOutOfRangeException();
            }
            var autoes = clientRepository.Where(c => c.Id == clientId).SelectMany(a => a.Autoes).ToList();

            var clientAutoes = new Client()
            {
                Autoes = autoes
            };
            return clientAutoes;
        }

        public IEnumerable<Client> ReadAll()
        {
            var clients = clientRepository.GetAll();
            if (clients == null)
            {
                return null;
            }
            return clients;
        }

        public void Update(Client client)
        {
            if (client != null)
            {
                throw new System.ArgumentNullException();
            }

            var clientU = clientRepository.Where(c => c.Id == client.Id).FirstOrDefault();

            clientU.Judet = client.Judet == null ? clientU.Judet : client.Judet;
            clientU.Localitate = client.Localitate == null ? clientU.Localitate : client.Localitate;
            clientU.Nume = client.Nume == null ? clientU.Nume : client.Nume;
            clientU.Telefon = client.Telefon == default(decimal) ? clientU.Telefon : client.Telefon;
            clientU.Adresa = client.Adresa == null ? clientU.Adresa : client.Adresa;
            clientU.Autoes = client.Autoes == null ? clientU.Autoes : client.Autoes ;
            clientU.Email = client.Email == null ? clientU.Email : client.Email;
            clientRepository.Save();
        }
    }

}
