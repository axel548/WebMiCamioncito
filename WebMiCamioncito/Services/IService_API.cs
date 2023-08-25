using MiCamioncito.Models;
using Newtonsoft.Json;
using WebMiCamioncito.Models;

namespace WebMiCamioncito.Services
{
    public interface IService_API
    {

        Task<bool> Create(string route, Object obj);
        Task<bool> Edit(string route, Object obj);
        Task<bool> Delete(string route, int ID);



        // CLIENTS
        Task<List<Client>> ListsClients();
        Task<Client> GetClient(int idClient);




        // VEHICLES
        Task<List<Vehicle>> ListsVehicles();
        Task<Vehicle> GetVehicle(int idVehicle);




        // PILOTS
        Task<List<Pilot>> ListsPilots();
        Task<Pilot> GetPilot(int idPilot);




        // SERVICES
        Task<List<Service>> ListsServices();
        Task<Service> GetService(int idService);




        // REPORTERY
        Task<(List<Pilot>, List<Vehicle>)> ListReportery(string startdate, string enddate);

        

    }
}