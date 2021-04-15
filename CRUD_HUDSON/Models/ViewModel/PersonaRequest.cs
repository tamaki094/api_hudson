using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_HUDSON.Models.ViewModel
{
    public class PersonaRequest
    {
        public float Cantidad { get; set; }
        public string Nombre_Cliente { get; set; }
        public string Fecha_Entrega { get; set; }
        public int CP_Entrega { get; set; }
    }
}