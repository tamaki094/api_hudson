//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CRUD_HUDSON.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Pedidos
    {
        public int Id_Pedido { get; set; }
        public Nullable<double> Cantidad { get; set; }
        public string Nombre_Cliente { get; set; }
        public Nullable<System.DateTime> Fecha_Pedido { get; set; }
        public Nullable<int> CP_Entrega { get; set; }
    }
}
