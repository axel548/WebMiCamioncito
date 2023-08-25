using MiCamioncito.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Net.Sockets;
using WebMiCamioncito.Models;
using WebMiCamioncito.Services;

namespace WebMiCamioncito.Controllers
{

    public class HomeController : Controller
    {
        private readonly IService_API _serviceApi;

        public HomeController(IService_API serviceApi)
        {
            _serviceApi = serviceApi;
        }

        public IActionResult Index()
        {
            return View();
        }








        // CLIENT
        public async Task<IActionResult> Clients()
        {
            List<Client> list = await _serviceApi.ListsClients();
            return View(list);
        }

        public async Task<IActionResult> FormClient(int idClient)
        {
            Client model_client = new Client();
            ViewBag.Accion = "New Client";
            if (idClient != 0)
            {
                model_client = await _serviceApi.GetClient(idClient);
                ViewBag.Accion = "Edit Client";
            }

            return View("~/Views/Home/Forms/FormClient.cshtml", model_client);
        }

        [HttpPost]
        public async Task<IActionResult> SaveClient(Client ob_client)
        {
            bool response;
            string route = "client";

            if (ob_client.IDClient == 0)
            {
                response = await _serviceApi.Create(route, ob_client);
            }
            else
            {
                response = await _serviceApi.Edit(route, ob_client);
            }

            if (response)
                return RedirectToAction("Clients");
            else
                return NoContent();
        }


        public async Task<IActionResult> DeleteClient(int idClient)
        {
            string route = "client";
            var response = await _serviceApi.Delete(route, idClient);

            if (response)
                return RedirectToAction("Clients");
            else
                return NoContent();
        }






        // PILOT
        public async Task<IActionResult> Pilots()
        {
            List<Pilot> list = await _serviceApi.ListsPilots();
            return View(list);
        }

        public async Task<IActionResult> FormPilot(int idPilot)
        {
            Pilot model_pilot = new Pilot();
            ViewBag.Accion = "New Pilot";
            if (idPilot != 0)
            {
                model_pilot = await _serviceApi.GetPilot(idPilot);
                ViewBag.Accion = "Edit Pilot";
            }

            return View("~/Views/Home/Forms/FormPilot.cshtml", model_pilot);
        }

        [HttpPost]
        public async Task<IActionResult> SavePilot(Pilot ob_pilot)
        {
            bool response;
            string route = "pilot";

            if (ob_pilot.idPilot == 0)
            {
                response = await _serviceApi.Create(route, ob_pilot);
            }
            else
            {
                response = await _serviceApi.Edit(route, ob_pilot);
            }

            if (response)
                return RedirectToAction("Pilots");
            else
                return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> DeletePilot(int idPilot)
        {
            string route = "pilot";
            var response = await _serviceApi.Delete(route, idPilot);

            if (response)
                return RedirectToAction("Pilots");
            else
                return NoContent();
        }











        // VEHICLES
        public async Task<IActionResult> Vehicles()
        {
            List<Vehicle> list = await _serviceApi.ListsVehicles();
            return View(list);
        }
        public async Task<IActionResult> FormVehicle(int idVehicle)
        {
            Vehicle model_vehicle = new Vehicle();
            ViewBag.Accion = "New Vehicle";
            if (idVehicle != 0)
            {
                model_vehicle = await _serviceApi.GetVehicle(idVehicle);
                ViewBag.Accion = "Edit Vehicle";
            }

            return View("~/Views/Home/Forms/FormVehicle.cshtml", model_vehicle);
        }

        [HttpPost]
        public async Task<IActionResult> SaveVehicle(Vehicle ob_vehicle)
        {
            bool response;
            string route = "vehicle";

            if (ob_vehicle.IDVehicle == 0)
            {
                response = await _serviceApi.Create(route, ob_vehicle);
            }
            else
            {
                response = await _serviceApi.Edit(route, ob_vehicle);
            }

            if (response)
                return RedirectToAction("Vehicles");
            else
                return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> DeleteVehicle(int idVehicle)
        {
            string route = "vehicle";
            var response = await _serviceApi.Delete(route, idVehicle);

            if (response)
                return RedirectToAction("Vehicles");
            else
                return NoContent();
        }






        // SERVICES
        public async Task<IActionResult> Services()
        {
            List<Service> list = await _serviceApi.ListsServices();
            return View(list);
        }

        public async Task<IActionResult> FormService(int idService)
        {
            Service model_service = new Service();
            ViewBag.Accion = "New Service";
            if (idService != 0)
            {
                model_service = await _serviceApi.GetService(idService);
                ViewBag.Accion = "Edit Vehicle";
            }

            return View("~/Views/Home/Forms/FormService.cshtml", model_service);
        }

        [HttpPost]
        public async Task<IActionResult> SaveService(Service ob_service)
        {
            bool response;
            string route = "service";

            if (ob_service.IDService == 0)
            {
                response = await _serviceApi.Create(route, ob_service);
            }
            else
            {
                response = await _serviceApi.Edit(route, ob_service);
            }

            if (response)
                return RedirectToAction("Services");
            else
                return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> DeleteService(int idService)
        {
            string route = "service";
            var response = await _serviceApi.Delete(route, idService);

            if (response)
                return RedirectToAction("Services");
            else
                return NoContent();
        }














        public async Task<IActionResult> Reportery()
        {
            return View();
        }


        public async Task<IActionResult> GetReportery(string startdate, string enddate)
        {
            var response = await _serviceApi.ListReportery(startdate, enddate);

            return View("~/Views/Home/Forms/TableReportery.cshtml", response);
        }








        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}