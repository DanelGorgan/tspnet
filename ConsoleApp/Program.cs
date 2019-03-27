using ModelDesignFirst_L1;
using Persistence;
using Business;
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var autoContext = new AutoContext();

            var autoRepository = new AutoRepository<Auto>(autoContext);
            var clientRepository = new AutoRepository<Client>(autoContext);
            var sasiuRepository = new AutoRepository<Sasiu>(autoContext);
            var comandaRepository = new AutoRepository<Comanda>(autoContext);

            var autoService = new AutoService(autoRepository);
           
            var client = new Client
            {
                Adresa = "adresa de adresa",
                Nume = "Gorgan",
                Prenume = "Daniel-Mihai",
                Email = "danielgorganmiasid@gmail.com",
                Judet = "Iasi",
                Localitate = "Iasi"
            };

            //clientRepository.Add(client);

            // Find & Update 
            var ClientFind = clientRepository.FindById(1);
            //ClientFind.Nume = "Gorganus";

            // Delete
            //clientRepository.Delete(2);
            //clientRepository.Save();

            var Sasiu = new Sasiu
            {
                Denumire = "sasiu de sasiu",
                CodSasiu = "RO"
            };

            //sasiuRepository.Add(Sasiu);
            //sasiuRepository.Save();

            var SasiuFind = sasiuRepository.FindById(2);


            //var Comanda = new Comanda
            //{
            //    Descriere = "comanda noua"
            //};

            //comandaRepository.Add(Comanda);
            //comandaRepository.Save();


            var auto = new Auto
            {
                NumarAuto = "IS PUP 23",
                Client_Id = ClientFind.Id,
                Sasius_Id = SasiuFind.Id,
                SerieSasiu = "123"
            };

            //autoRepository.Add(auto);
            //autoRepository.Save();

        }
    }
}
