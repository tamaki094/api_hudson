using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Net.Http;
using CRUD_HUDSON.Models;
using System.Web.Http.Description;
using CRUD_HUDSON.Models.ViewModel;
using System.Web.Http.Cors;
using Newtonsoft.Json;

namespace CRUD_HUDSON.Controllers
{
    public class PedidoController : ApiController
    {
        private hudsonEntities db = new hudsonEntities();


        [HttpGet]
        public IQueryable<Pedidos> GetPedidos()
        {
            return db.Pedidos;
        }

        [ResponseType(typeof(Pedidos))]
        [HttpGet]
        public IHttpActionResult GetPedidos(int id)
        {
            Pedidos pedido = db.Pedidos.Find(id);
            if(pedido == null)
            {
                return NotFound();
            }

            return Ok(pedido);
        }

        [HttpPost]
        public IHttpActionResult Add(Models.ViewModel.PersonaRequest model)
        {
            using (Models.hudsonEntities bd = new Models.hudsonEntities())
            {
                var pedido = new Models.Pedidos();
                pedido.Cantidad = model.Cantidad;
                pedido.CP_Entrega = model.CP_Entrega;
                pedido.Nombre_Cliente = model.Nombre_Cliente;
                pedido.Fecha_Pedido = Convert.ToDateTime(model.Fecha_Entrega);

                bd.Pedidos.Add(pedido);
                bd.SaveChanges();
            }

            return Ok("Exito");
        }

        [HttpPost]
        [Route("~/api/Pedido/buscarPorNombre")]
        public IHttpActionResult FindByNombre_Cliente(Models.ViewModel.PersonaRequest model)
        {
            using (Models.hudsonEntities bd = new Models.hudsonEntities())
            {
                List<Pedidos> list_pedidos = (from a in bd.Pedidos
                                                   where a.Nombre_Cliente.Contains(model.Nombre_Cliente)
                                                   select a).ToList();

                int encontrados = list_pedidos.Count;
                if (list_pedidos.Count > 1)
                {
                    Mensaje msj = new Mensaje();
                    msj.tipo_mensaje = "Valores_Encontrados";
                    msj.valor = $"({encontrados})";
                    string jsonString = JsonConvert.SerializeObject(msj);
                    return Json(jsonString);
                }
                else
                {
                    Mensaje msj = new Mensaje();
                    msj.tipo_mensaje = "Resultado_Busqueda";
                    msj.valor = list_pedidos;
                    return Json(JsonConvert.SerializeObject(msj));
                }
            }

            
        }



        [ResponseType(typeof(Pedidos))]
        [HttpDelete]
        public IHttpActionResult DeletePedido(int id)
        {
            Pedidos pedido = db.Pedidos.Find(id);
            if(pedido == null)
            {
                return NotFound();
            }

            db.Pedidos.Remove(pedido);
            db.SaveChanges();


            return Ok(pedido);
        }


        [ResponseType(typeof(void))]
        [HttpPut]
        public IHttpActionResult PutPedido(int id, Pedidos pedido)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(id != pedido.Id_Pedido)
            {
                return BadRequest(ModelState);
            }

            db.Entry(pedido).State = System.Data.Entity.EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return StatusCode(System.Net.HttpStatusCode.NoContent);
        }


    }
}