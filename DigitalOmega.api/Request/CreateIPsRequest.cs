using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace DigitalOmega.api.Request
{
    public class CreateIPsRequest 
    {
   
        public Guid? Id { get; set; }

    

        public string? IP { get; set; }

 
    }
}
