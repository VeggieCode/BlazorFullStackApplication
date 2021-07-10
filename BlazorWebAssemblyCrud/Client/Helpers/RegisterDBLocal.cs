using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorWebAssemblyCrud.Client.Helpers
{
    public class RegisterDBLocal
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public JsonElement Body { get; set; }
    }
    //Clase que envuelve a los registros
    public class RegistersDBLocal
    {
        public List<RegisterDBLocal> ObjectsToCreate { get; set; } = new List<RegisterDBLocal>();
        public List<RegisterDBLocal> ObjectsToDelete { get; set; } = new List<RegisterDBLocal>();

        public List<RegisterDBLocal> ObjectsToUpdate { get; set; } = new List<RegisterDBLocal>();

        public int PendingObjects()
        {
            var result = 0;
            result += ObjectsToCreate.Count;
            result += ObjectsToDelete.Count;
            result += ObjectsToUpdate.Count;
            return result;
        }
    }
}
