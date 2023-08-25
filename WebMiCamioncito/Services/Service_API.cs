using MiCamioncito.Models;
using Newtonsoft.Json;
using System;
using System.Net.Sockets;
using System.Text;
using WebMiCamioncito.Models;

namespace WebMiCamioncito.Services
{
    public class Service_API : IService_API
    {
        private static string _baseUrl;

        public Service_API()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            _baseUrl = builder.GetSection("ApiSettings:baseUrl").Value;
        }


        // METHODS
        public async Task<bool> Create(string route, Object obj)
        {
            bool response = false;
            var clientHttp = new HttpClient();
            clientHttp.BaseAddress = new Uri(_baseUrl);

            var content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
            var responseContent = await clientHttp.PostAsync($"{route}/create", content);


            if (responseContent.IsSuccessStatusCode)
            {
                response = true;
            }

            return response;
        }

        public async Task<bool> Edit(string route, Object obj)
        {
            bool response = false;
            var clientHttp = new HttpClient();
            clientHttp.BaseAddress = new Uri(_baseUrl);

            var content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
            var responseContent = await clientHttp.PutAsync($"{route}/update", content);


            if (responseContent.IsSuccessStatusCode)
            {
                response = true;
            }

            return response;
        }


        public async Task<bool> Delete(string route, int idClient)
        {
            bool response = false;
            var clientHttp = new HttpClient();
            clientHttp.BaseAddress = new Uri(_baseUrl);

            var responseContent = await clientHttp.DeleteAsync($"{route}/delete/{idClient}");

            if (responseContent.IsSuccessStatusCode)
            {
                response = true;
            }

            return response;
        }




        // CLIENTS
        public async Task<List<Client>> ListsClients()
        {
            List<Client> clients = new List<Client>();
            var clientHttp = new HttpClient();
            clientHttp.BaseAddress = new Uri(_baseUrl);
            var response = await clientHttp.GetAsync("client/lists");

            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(json_response);
                clients = apiResponse.result.clients;
            }

            return clients;
        }

        public async Task<Client> GetClient(int idClient)
        {
            Client client = new Client();
            var clientHttp = new HttpClient();
            clientHttp.BaseAddress = new Uri(_baseUrl);
            var response = await clientHttp.GetAsync($"client/list?id={idClient}");


            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(json_response);

                if (apiResponse.result.client.Count > 0)
                {
                    client = apiResponse.result.client[0];
                }
            }

            return client;
        }


        // VEHICLES

        public async Task<List<Vehicle>> ListsVehicles()
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            var clientHttp = new HttpClient();
            clientHttp.BaseAddress = new Uri(_baseUrl);
            var response = await clientHttp.GetAsync("vehicle/lists");

            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(json_response);
                vehicles = apiResponse.result.vehicles;
            }

            return vehicles;
        }

        public async Task<Vehicle> GetVehicle(int idVehicle)
        {
            Vehicle vehicle = new Vehicle();
            var clientHttp = new HttpClient();
            clientHttp.BaseAddress = new Uri(_baseUrl);
            var response = await clientHttp.GetAsync($"vehicle/list?id={idVehicle}");


            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(json_response);

                if (apiResponse.result.vehicle.Count > 0)
                {
                    vehicle = apiResponse.result.vehicle[0];
                }
            }

            return vehicle;
        }



        // PILOTS
        public async Task<List<Pilot>> ListsPilots()
        {
            List<Pilot> pilots = new List<Pilot>();
            var clientHttp = new HttpClient();
            clientHttp.BaseAddress = new Uri(_baseUrl);
            var response = await clientHttp.GetAsync("pilot/lists");

            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(json_response);
                pilots = apiResponse.result.pilots;
            }

            return pilots;
        }

        public async Task<Pilot> GetPilot(int idPilot)
        {

            Pilot pilot = new Pilot();
            var clientHttp = new HttpClient();
            clientHttp.BaseAddress = new Uri(_baseUrl);
            var response = await clientHttp.GetAsync($"pilot/list?id={idPilot}");


            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(json_response);

                if (apiResponse.result.pilot.Count > 0)
                {
                    pilot = apiResponse.result.pilot[0];
                }
            }

            return pilot;
        }


        // SERVICES
        public async Task<List<Service>> ListsServices()
        {
            List<Service> services = new List<Service>();
            var clientHttp = new HttpClient();
            clientHttp.BaseAddress = new Uri(_baseUrl);
            var response = await clientHttp.GetAsync("service/lists");

            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(json_response);
                services = apiResponse.result.services;
            }

            return services;
        }

        public async Task<Service> GetService(int idService)
        {
            Service service = new Service();
            var clientHttp = new HttpClient();
            clientHttp.BaseAddress = new Uri(_baseUrl);
            var response = await clientHttp.GetAsync($"service/list?id={idService}");


            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(json_response);

                if (apiResponse.result.service.Count > 0)
                {
                    service = apiResponse.result.service[0];
                }
            }

            return service;
        }





        // REPORTERY
        public async Task<(List<Pilot>, List<Vehicle>)> ListReportery(string startdate, string enddate)
        {
            List<Pilot> pilots = new List<Pilot>();
            List<Vehicle> vehicles = new List<Vehicle>();

            var clientHttp = new HttpClient();
            clientHttp.BaseAddress = new Uri(_baseUrl);
            var response = await clientHttp.GetAsync($"reportery/list?startdate={startdate}&enddate={enddate}");

            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(json_response);
                pilots = apiResponse.result.pilots;
                vehicles = apiResponse.result.vehicles;
            }

            return (pilots, vehicles);
        }
    }
}
