using MiCamioncito.Models;

namespace WebMiCamioncito.Models
{
    public class ApiResult
    {
        public List<Pilot>? pilots { get; set; }
        public List<Vehicle>? vehicles { get; set; }
        public List<Client>? clients { get; set; }
        public List<Service>? services { get; set; }


        public List<Client>? client { get; set; }
        public List<Vehicle>? vehicle { get; set; }
        public List<Service>? service { get; set; }
        public List<Pilot>? pilot { get; set; }



        public List<Object>? objs { get; set; }
    }
}
