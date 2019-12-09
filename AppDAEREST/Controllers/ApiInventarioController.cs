using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AppDAEREST.Models;
using AppDAEREST.Data;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace AppDAEREST.Controllers
{
    [Produces("application/json")]
    public class ApiInventarioController : Controller
    {
        private readonly DBContext LoDBContext;
        
        public ApiInventarioController(DBContext PaDBContext)
        {
            LoDBContext = PaDBContext;
        }//Constructor
        #region apis anteriores
        //-------------------------------------------------------------------------------------------------------Api's acumulados------------------------------------------------------------------------------------
        //Get para todos
        [HttpGet]
        [Route("api/inventarios/inv_acumulados_list")]
        public IEnumerable<zt_inventarios_acumulados> ApiGetInv_Acumulados_List([FromQuery] int IdInventario)
        {
            var resultado = (
                            from acu in LoDBContext.zt_inventarios_acumulados
                            where acu.IdInventario == IdInventario
                            select acu
                            ).ToList();

            return (resultado);
        }
        //Post
        [HttpPost]
        [Route("api/inventarios/inv_acumuladosQ")]
        public async Task<IActionResult> ApiPostInv_Acumulados([FromQuery] int IdInventarioR, [FromQuery] string IdSKUR, [FromQuery] string IdUnidadMedidaR, [FromQuery] float CantidadTeoricaR, [FromQuery] float CantidadTeoricaCJAR, [FromQuery] float CantidadFisicaR, [FromQuery] float CantidadFisicaCJAR, [FromQuery] float DiferenciaR, [FromQuery] float DiferenciaCJAR, [FromQuery] string ReconteoR, [FromQuery] string ActivoR, [FromQuery] string BorradoR, [FromQuery] DateTime FechaRegR, [FromQuery] string UsuarioRegR, [FromQuery] DateTime FechaUltModR, [FromQuery] string UsuarioModR)
        {
            try
            {
                zt_inventarios_acumulados NF = new zt_inventarios_acumulados();
                NF.IdInventario = IdInventarioR;
                NF.IdSKU = IdSKUR;
                NF.IdUnidadMedida = IdUnidadMedidaR;
                NF.CantidadTeorica = CantidadTeoricaR;
                NF.CantidadTeoricaCJA = CantidadTeoricaCJAR;
                NF.CantidadFisica = CantidadFisicaR;
                NF.CantidadFisicaCJA = CantidadFisicaCJAR;
                NF.Diferencia = DiferenciaR;
                NF.DiferenciaCJA = DiferenciaCJAR;
                NF.Reconteo = ReconteoR;
                NF.Activo = ActivoR;
                NF.Borrado = BorradoR;
                NF.FechaReg = FechaRegR;
                NF.UsuarioReg = UsuarioRegR;
                NF.FechaUltMod = FechaUltModR;
                NF.UsuarioMod = UsuarioModR;
                LoDBContext.zt_inventarios_acumulados.Add(NF);
                LoDBContext.SaveChanges();
                return Ok("Inventario registrado");
            }
            catch (Exception e)
            {
                Dictionary<String, String> err = new Dictionary<string, string>();
                err.Add("err", "Post");
                return Ok(err);
            }
        }
        //Post
        [HttpPost]
        [Route("api/inventarios/inv_acumulados")]
        public async Task<IActionResult> ApiPostInv_AcumuladosB([FromBody] zt_inventarios_acumulados acu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            LoDBContext.zt_inventarios_acumulados.Add(acu);
            await LoDBContext.SaveChangesAsync();
            return CreatedAtAction("ApiGetAcumuladosConteosList", new { id = acu.IdSKU });
        }
        //Put
        [HttpPut]
        [Route("api/inventarios/inv_acumulados_update")]
        public async Task<IActionResult> ApiPutInv([FromQuery] int IdInventarioR, [FromQuery] string IdSKUR, [FromQuery] string IdUnidadMedidaR, [FromBody] zt_inventarios_acumulados acu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var temp = LoDBContext.zt_inventarios_acumulados.Find(IdInventarioR, IdSKUR, IdUnidadMedidaR);
            LoDBContext.zt_inventarios_acumulados.Update(acu);
            await LoDBContext.SaveChangesAsync();
            return CreatedAtAction("ApiGetAcumuladosConteosList", new { id = acu.IdSKU });
        }
        //Delete tarea 3
        [HttpDelete]
        [Route("api/inventarios/inv_acumulados_delete")]
        public async Task<IActionResult> ApiDelete_Acumulados([FromQuery] int IdInventario, [FromQuery] string IdSKU, [FromQuery] string IdUnidadMedida)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var objAcumulados = await LoDBContext.zt_inventarios_acumulados.FirstOrDefaultAsync(a => a.IdInventario == IdInventario && a.IdSKU == IdSKU && a.IdUnidadMedida == IdUnidadMedida); //&& c.IdAlmacen == IdAlmacen && c.IdUbicacion == IdUbicacion && c.NumConteo == NumConteo);
            //var II = objAcumulados.IdInventario;
            //var ISKU = objAcumulados.IdSKU;
            //var IUM = objAcumulados.IdUnidadMedida;
            //var resultado2 = LoDBContext.zt_inventarios_conteos.All(cont => cont.IdInventario == objAcumulados.IdInventario);
            //                        IdInventario = c.IdInventario,
            //                        IdAlmacen = c.IdAlmacen,
            //                        IdSKU = c.IdSKU,
            //                        IdUbicacion = c.IdUbicacion,
            //                        IdUnidadMedida = c.IdUnidadMedida,
            //                        NumConteo = c.NumConteo,
            //                        CodigoBarras = c.CodigoBarras,
            //                        CantidadFisica = c.CantidadFisica,
            //                        CantidadPZA = c.CantidadPZA,
            //                        Lote = c.Lote,
            //                        FechaReg = c.FechaReg,
            //                        UsuarioReg = c.UsuarioReg,
            //                        Activo = c.Activo,
            //                        Borrado = c.Borrado
            //});

            //SingleOrDefaultAsync(c => c.IdInventario == objAcumulados.IdInventario && c.IdSKU == objAcumulados.IdSKU);
            var resultado = (
                            from c in LoDBContext.zt_inventarios_conteos
                            where c.IdInventario == objAcumulados.IdInventario &&
                            c.IdSKU == objAcumulados.IdSKU
                            select new zt_inventarios_conteos
                            {
                                IdInventario = c.IdInventario,
                                IdAlmacen = c.IdAlmacen,
                                IdSKU = c.IdSKU,
                                IdUbicacion = c.IdUbicacion,
                                IdUnidadMedida = c.IdUnidadMedida,
                                NumConteo = c.NumConteo,
                                CodigoBarras = c.CodigoBarras,
                                CantidadFisica = c.CantidadFisica,
                                CantidadPZA = c.CantidadPZA,
                                Lote = c.Lote,
                                FechaReg = c.FechaReg,
                                UsuarioReg = c.UsuarioReg,
                                Activo = c.Activo,
                                Borrado = c.Borrado
                            }).ToList();

                            //from cont in LoDBContext.zt_inventarios_conteos
                            //join acu in LoDBContext.zt_inventarios_acumulados
                            //on new { cont.IdInventario, cont.IdSKU } equals new { objAcumulados.IdInventario, objAcumulados.IdSKU }
                            //where cont.IdInventario == objAcumulados.IdInventario &&
                            //cont.IdSKU == objAcumulados.IdSKU
                            //select new zt_inventarios_conteos
                            //{
                            //    IdInventario = cont.IdInventario,
                            //    IdAlmacen = cont.IdAlmacen,
                            //    IdSKU = cont.IdSKU,
                            //    IdUbicacion = cont.IdUbicacion,
                            //    IdUnidadMedida = cont.IdUnidadMedida,
                            //    NumConteo = cont.NumConteo,
                            //    CodigoBarras = cont.CodigoBarras,
                            //    CantidadFisica = cont.CantidadFisica,
                            //    CantidadPZA = cont.CantidadPZA,
                            //    Lote = cont.Lote,
                            //    FechaReg = cont.FechaReg,
                            //    UsuarioReg = cont.UsuarioReg,
                            //    Activo = cont.Activo,
                            //    Borrado = cont.Borrado
                            //}
                            //).ToList();

            if (objAcumulados == null)
            {
                return NotFound();
            }
            LoDBContext.zt_inventarios_acumulados.Remove(objAcumulados);
            LoDBContext.zt_inventarios_conteos.RemoveRange(resultado);
                //IEnumerable<zt_inventarios_conteos>
            await LoDBContext.SaveChangesAsync();
            return Ok(objAcumulados);
        }
        
        //------------------------------------------------------------------------------------------------------Api's conteos---------------------------------------------------------------------------------------
        //Get para un inventario (21)
        [HttpGet]
        [Route("api/inventarios/inv_conteos_list")]
        public IEnumerable<zt_inventarios_conteos> ApiGetInv_Conteos_List([FromQuery] int IdInventario)
        {
            var resultado = (
                            from cont in LoDBContext.zt_inventarios_conteos
                            where cont.IdInventario == IdInventario
                            select cont
                            ).ToList();
            return (resultado);
        }
        //Post 
        [HttpPost]
        [Route("api/inventarios/inv_conteos")]
        public async Task<IActionResult> ApiPostInv_Cont([FromBody] zt_inventarios_conteos cont)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            LoDBContext.zt_inventarios_conteos.Add(cont);
            await LoDBContext.SaveChangesAsync();
            return CreatedAtAction("ApiGetAcumuladosConteosList", new { id = cont.IdSKU });
        }
        //Put  
        [HttpPut]
        [Route("api/inventarios/inv_conteos_update")]
        public async Task<IActionResult> ApiPutAcumulados([FromQuery] int IdInventarioR, [FromQuery] string IdSKUR, [FromQuery] string IdUnidadMedidaR, [FromQuery] string IdAlmacen, [FromQuery] string IdUbicacion, [FromQuery] int NumConteo ,[FromBody] zt_inventarios_conteos cont)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var temp = LoDBContext.zt_inventarios_conteos.Find(IdInventarioR, IdSKUR, IdUnidadMedidaR, IdAlmacen, IdUbicacion, NumConteo);
            LoDBContext.zt_inventarios_conteos.Update(cont);
            //LoDBContext.zt_inventarios_acumulados[IdInventarioR] = acu;
            //LoDBContext.zt_inventarios_acumulados.Add(acu);
            await LoDBContext.SaveChangesAsync();
            return CreatedAtAction("ApiGetAcumuladosConteosList", new { id = cont.IdSKU });
        }
        //Delete de 1 conteo
        //Get prueba
        [HttpDelete]
        [Route("api/inventarios/inv_conteo")]
        public IEnumerable<zt_inventarios_conteos> ApiDeleteConteos([FromQuery] int IdInventario, [FromQuery] string IdSKU, [FromQuery] string IdUnidadMedida, [FromQuery] string IdAlmacen, [FromQuery] string IdUbicacion, [FromQuery] int NumConteo)
        {
            var res = (
                from cont in LoDBContext.zt_inventarios_conteos
                join acu in LoDBContext.zt_inventarios_acumulados
                on new { cont.IdInventario, cont.IdSKU} equals new { acu.IdInventario, acu.IdSKU}
                where cont.IdInventario == IdInventario &&
                cont.IdSKU == IdSKU &&
                cont.IdUnidadMedida == IdUnidadMedida &&
                cont.IdAlmacen == IdAlmacen &&
                cont.IdUbicacion == IdUbicacion &&
                cont.NumConteo == NumConteo
                select new zt_inventarios_conteos
                {
                    IdInventario = cont.IdInventario,
                    IdAlmacen = cont.IdAlmacen,
                    IdSKU = cont.IdSKU,
                    IdUbicacion = cont.IdUbicacion,
                    IdUnidadMedida = cont.IdUnidadMedida,
                    NumConteo = cont.NumConteo,
                    CodigoBarras = cont.CodigoBarras,
                    CantidadFisica = cont.CantidadFisica,
                    CantidadPZA = cont.CantidadPZA,
                    Lote = cont.Lote,
                    FechaReg = cont.FechaReg,
                    UsuarioReg = cont.UsuarioReg,
                    Activo = cont.Activo,
                    Borrado = cont.Borrado
                 }
                ).ToList();
            return (res);
        }
        //Delete - tarea 2 
        [HttpDelete]
        [Route("api/inventarios/inv_conteos_delete")]
        public async Task<IActionResult> ApiDeleteConteos2([FromQuery] int IdInventario, [FromQuery] string IdSKU, [FromQuery] string IdUnidadMedida, [FromQuery] string IdAlmacen, [FromQuery] string IdUbicacion, [FromQuery] int NumConteo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var conteoB = LoDBContext.zt_inventarios_conteos.Join(LoDBContext.zt_inventarios_acumulados, cont => new { cont.IdInventario, cont.IdSKU},
            //                                                                                             acu => new { acu.IdInventario, acu.IdSKU}, (cont, acu) => cont);

            //var conteoB = from x in LoDBContext.zt_inventarios_acumulados
            //              from y in LoDBContext.zt_inventarios_conteos
            //              .Where(y => y.IdInventario == x.IdInventario && y.IdSKU == y.IdSKU)
            //              select y;

            var objConteos = await LoDBContext.zt_inventarios_conteos.FirstOrDefaultAsync(c => c.IdInventario == IdInventario && c.IdSKU == IdSKU && c.IdUnidadMedida == IdUnidadMedida && c.IdAlmacen == IdAlmacen && c.IdUbicacion == IdUbicacion && c.NumConteo == NumConteo);
            //LoDBContext.zt_inventarios_conteos.Join(LoDBContext.zt_inventarios_acumulados, cont => new { cont.IdInventario, cont.IdSKU }, acu => new { acu.IdInventario, acu.IdSKU }, (cont, acu) => cont);
            
            if (objConteos == null)
            {
                return NotFound();
            }

            LoDBContext.zt_inventarios_conteos.Remove(objConteos);
            //LoDBContext.Remove(conteoB);
            //LoDBContext.zt_inventarios_conteos.Remove(conteoB);
            await LoDBContext.SaveChangesAsync();
            return Ok(objConteos);
        }

        //Post tarea 4
        [HttpPost]
        [Route("api/inventarios/inv_conteos_acumulados_update")]
        public async Task<IActionResult> ApiPostInv_Conteos_post_lunes([FromQuery] int IdInventario, [FromQuery] string IdSKU, [FromQuery] string IdUnidadMedida, [FromQuery] string IdAlmacen, [FromQuery] string IdUbicacion, [FromBody] zt_inventarios_conteos con)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var resultado = (
                      from conteos in LoDBContext.zt_inventarios_conteos
                      where conteos.IdInventario == IdInventario && 
                      conteos.IdSKU == IdSKU //&&
                      //conteos.IdUnidadMedida == IdUnidadMedida &&
                      //conteos.IdAlmacen == IdAlmacen &&
                      //conteos.IdUbicacion == IdUbicacion
                      select conteos
                      ).ToList();
            if (!resultado.Any())
            {
                con.NumConteo = 1;
                LoDBContext.zt_inventarios_conteos.Add(con);
                await LoDBContext.SaveChangesAsync();
                //cambiar var temp por un select
                //var temp = LoDBContext.zt_inventarios_acumulados.Find(IdInventario, IdSKU);
                var temp = await LoDBContext.zt_inventarios_acumulados.FirstOrDefaultAsync(a => a.IdInventario == con.IdInventario && a.IdSKU == con.IdSKU);
   
                temp.CantidadFisica += con.CantidadPZA;
                temp.Diferencia = temp.CantidadTeorica - temp.CantidadFisica;
                LoDBContext.zt_inventarios_acumulados.Update(temp);
                await LoDBContext.SaveChangesAsync();
            }
            else
            {
                var ultimo = resultado.Last(); 
                con.NumConteo = ultimo.NumConteo + 1;
                LoDBContext.zt_inventarios_conteos.Add(con);
                await LoDBContext.SaveChangesAsync();
                var temp = await LoDBContext.zt_inventarios_acumulados.FirstOrDefaultAsync(a => a.IdInventario == con.IdInventario && a.IdSKU == con.IdSKU);
                //var temp = LoDBContext.zt_inventarios_acumulados.Find(IdInventario, IdSKU, IdUnidadMedida);
                temp.CantidadFisica = temp.CantidadFisica + con.CantidadPZA;
                temp.Diferencia = temp.CantidadTeorica - temp.CantidadFisica;
                LoDBContext.zt_inventarios_acumulados.Update(temp);
                await LoDBContext.SaveChangesAsync();
            }
            return CreatedAtAction("ApiGetAcumuladosConteosList", new { id = con.IdSKU });
        }
        #region cochinada
        [HttpPost]
        [Route("api/inventarios/inv_conteos_acumulados_updateC")]
        public async Task<IActionResult> ApiPostInvConteos_Item([FromBody] zt_inventarios_conteos conteo)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var buscarConteo = (from cont in LoDBContext.zt_inventarios_conteos
                                where cont.IdInventario == conteo.IdInventario && cont.IdSKU == conteo.IdSKU && cont.IdAlmacen == conteo.IdAlmacen
                                && cont.IdUbicacion == conteo.IdUbicacion && cont.IdUnidadMedida == conteo.IdUnidadMedida
                                select cont.NumConteo).ToList();
            var nc = buscarConteo.Count;
            conteo.NumConteo = nc + 1;
            LoDBContext.zt_inventarios_conteos.Add(conteo);
            await LoDBContext.SaveChangesAsync();
            double totalPZA = 0;
            var resultadoConteo = (from cont in LoDBContext.zt_inventarios_conteos
                                   where cont.IdInventario == conteo.IdInventario && cont.IdSKU == conteo.IdSKU
                                   select cont).GroupBy(p => new { p.IdInventario, p.IdSKU, p.IdAlmacen, p.IdUbicacion, p.IdUnidadMedida })
                                   .Select(g => g.LastOrDefault());
            foreach (var element in resultadoConteo)
            {

                totalPZA = totalPZA + (double)element.CantidadPZA;
            }
            var objAcumulado = await LoDBContext.zt_inventarios_acumulados.FirstOrDefaultAsync(c => c.IdInventario == conteo.IdInventario && c.IdSKU == conteo.IdSKU);
            if (objAcumulado == null)
            {
                return NotFound();
            }

            objAcumulado.CantidadFisica = totalPZA;
            objAcumulado.Diferencia = objAcumulado.CantidadTeorica - objAcumulado.CantidadFisica;

            LoDBContext.zt_inventarios_acumulados.Update(objAcumulado);
            await LoDBContext.SaveChangesAsync();
            return CreatedAtAction("Reg acumulado:", new { objAcumulado });
        }
        #endregion cochinada

        //---------------------------------------------------------------------------------------------Apis compuestas-----------------------------------------------------------------------------------------------
        [HttpGet]
        [Route("api/inventarios/inv_conteos_sku_list")]
        public IEnumerable<zt_inv_conteos_acumulados> ApiGetInv_Conteos_Sku_List([FromQuery] int IdInventario, [FromQuery] string IdSKU)
        {
            //Todos los conteos de un mismo SKU enviado como parametro y mismo inventario
            var resultado = (
                            from cont in LoDBContext.zt_inventarios_conteos
                            join acu in LoDBContext.zt_inventarios_acumulados
                            on new { cont.IdInventario, cont.IdSKU} equals new { acu.IdInventario, acu.IdSKU}
                            where cont.IdInventario == IdInventario &&
                            cont.IdSKU == IdSKU
                            select new zt_inv_conteos_acumulados
                            {
                                IdInventario = cont.IdInventario,
                                IdAlmacen = cont.IdAlmacen,
                                IdSKU = cont.IdSKU,
                                IdUbicacion = cont.IdUbicacion,
                                IdUnidadMedida = cont.IdUnidadMedida,
                                NumConteo = cont.NumConteo,
                                CantidadTeorica = acu.CantidadTeorica,
                                CantidadTeoricaCJA = acu.CantidadTeoricaCJA,
                                Diferencia = acu.Diferencia,
                                CantidadFisica = cont.CantidadFisica,
                                CantidadFisicaPZA = cont.CantidadPZA
                            }
                            ).ToList();
            return (resultado);
        }
        //Get compuesto - tarea 1
        [HttpGet]
        [Route("api/inventarios/inv_conteos_sku")]
        public IEnumerable<zt_inv_conteos_acumulados2> ApiGetInv_Conteos([FromQuery] int IdInventario, [FromQuery] string IdSKU)
        {
            var resultado = (
                           from cont in LoDBContext.zt_inventarios_conteos
                           join acu in LoDBContext.zt_inventarios_acumulados
                           on new { cont.IdInventario, cont.IdSKU } equals new { acu.IdInventario, acu.IdSKU }
                           where cont.IdInventario == IdInventario &&
                           cont.IdSKU == IdSKU
                           select new zt_inv_conteos_acumulados2
                           {
                               IdInventario = cont.IdInventario,
                               IdSKU = cont.IdSKU,
                               IdUnidadMedida = cont.IdUnidadMedida,
                               IdAlmacen = cont.IdAlmacen,
                               IdUbicacion = cont.IdUbicacion,
                               NumConteo = cont.NumConteo,
                               CantidadTeorica = acu.CantidadTeorica,
                               CantidadTeoricaCJA = acu.CantidadTeoricaCJA,
                               CantidadFisica = acu.CantidadFisica,
                               CantidadFisicaCJA = acu.CantidadFisicaCJA,
                               Diferencia = acu.CantidadTeorica - acu.CantidadFisica,
                               DiferenciaCJA = acu.CantidadTeoricaCJA - acu.CantidadFisicaCJA,
                               Reconteo = acu.Reconteo,
                               Activo = acu.Activo,
                               Borrado = acu.Borrado,
                               FechaReg = acu.FechaReg,
                               UsuarioReg = acu.UsuarioReg,
                               FechaUltMod = acu.FechaUltMod,
                               UsuarioMod = acu.UsuarioMod,
                               CodigoBarras = cont.CodigoBarras,
                               Lote = cont.Lote
                           }).ToList();
            return (resultado);
        }
        #endregion

        #region proyecto
        //Get de persona
        [HttpGet]
        [Route("api/usuario")]
        public IEnumerable<zt_usuario_persona> ApiGetUsuario([FromQuery] string Usuario)
        {
            var resultado = (
                            from u in LoDBContext.cat_usuarios
                            join p in LoDBContext.rh_cat_personas 
                            on new { u.IdPersona } equals new { p.IdPersona }
                            where u.Usuario == Usuario
                            select new zt_usuario_persona
                            {
                                IdPersona = u.IdPersona,
                                Nombre = p.Nombre+" "+p.ApPaterno+" "+p.ApMaterno,
                                Usuario = u.Usuario
                            }
                            ).ToList();

            return (resultado);
        }

        //Obtener nombre, usuario y correo principal
        [HttpGet]
        [Route("api/usuario/correo")]
        public IEnumerable<zt_usuario_persona> ApiGeUsuario2([FromQuery] string Usuario)
        {
            var resultado = (
                            from u in LoDBContext.cat_usuarios
                            join p in LoDBContext.rh_cat_personas on u.IdPersona equals p.IdPersona
                            join d in LoDBContext.rh_cat_dir_web on u.IdPersona equals d.ClaveReferencia
                            join s in LoDBContext.seg_expira_claves on u.IdUsuario equals s.IdUsuario
                            where u.Usuario == Usuario && d.Principal == "S" && d.IdTipoGenDirWeb == 10 && d.IdGenDirWeb == 3
                            select new zt_usuario_persona
                            {
                                IdPersona = u.IdPersona,
                                Nombre = p.Nombre + " " + p.ApPaterno + " " + p.ApMaterno,
                                Usuario = u.Usuario,
                                Correo = d.DireccionWeb,
                                IdUsuario = u.IdUsuario,
                                Auto = s.ClaveAutoSys
                            }
                            ).ToList();

            return (resultado);
        }
        //Reiniciar contraseña
        [HttpPost]
        [Route("api/usuario/reiniciar")]
        public async Task<IActionResult> ApiPostReinicio([FromQuery] int IdUsuario)
        {
            var resultado = (
                      from usuarios in LoDBContext.cat_usuarios
                      where usuarios.IdUsuario == IdUsuario
                      select usuarios
                      ).ToList();
            var ultimo = resultado.FirstOrDefault();
            try
            {
                seg_expira_claves NF = new seg_expira_claves();
                NF.IdClave = ultimo.IdUsuario+1;
                NF.IdUsuario = ultimo.IdUsuario;
                NF.FechaExpiraIni = System.DateTime.Today;
                NF.FechaExpiraFin = System.DateTime.Today.AddDays(365);
                NF.Actual = "N";
                NF.Clave = "1234";
                NF.ClaveAutoSys = "S";
                NF.FechaReg = System.DateTime.Today;
                NF.UsuarioReg = ultimo.Usuario;
                NF.Activo = "N";
                NF.Borrado = "N";
                LoDBContext.seg_expira_claves.Add(NF);
                //LoDBContext.SaveChanges();
                await LoDBContext.SaveChangesAsync();
                //---
                var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
                var client = new SendGridClient("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");
                var from = new EmailAddress("marcogp97@gmail.com","Marco");
                var to = new EmailAddress("maangaraype@ittepic.edu.mx","Marco");
                var subject = "Reiniciando contraseña";
                var plainTextContent = "Se ha restablecido su contraseña a 1234";
                var htmlContent = "<strong> Se ha reiniciado su contraseña a 1234, por favor  cambie su contraseña! </strong>";
                var msg = MailHelper.CreateSingleEmail(
                        from,
                        to,
                        subject,
                        plainTextContent,
                        htmlContent
                    );
                var response = await client.SendEmailAsync(msg);
                //--
                return Ok("Inventario registrado");
            }
            catch (Exception e)
            {
                Dictionary<String, String> err = new Dictionary<string, string>();
                err.Add("err", "Post");
                return Ok(err);
            }
        }
        //Cambio de contraseñas
        [HttpPost]
        [Route("api/usuario/cambiar")]
        public async Task<IActionResult> ApiPostCambio([FromQuery] int IdUsuario, [FromQuery] string Contrasena)
        {
            var resultado = (
                      from usuarios in LoDBContext.cat_usuarios
                      where usuarios.IdUsuario == IdUsuario
                      select usuarios
                      ).ToList();
            var ultimo = resultado.FirstOrDefault();

            var segUlt = (
                    from s in LoDBContext.seg_expira_claves
                   
                    select s
                ).ToList();
            var ultimoSeg = segUlt.LastOrDefault();
            try
            {
                seg_expira_claves NF = new seg_expira_claves();
                NF.IdClave = ultimoSeg.IdClave + 1;
                NF.IdUsuario = ultimo.IdUsuario;
                NF.FechaExpiraIni = System.DateTime.Today;
                NF.FechaExpiraFin = System.DateTime.Today.AddDays(365);
                NF.Actual = "S";
                NF.Clave = Contrasena;
                NF.ClaveAutoSys = "N";
                NF.FechaReg = System.DateTime.Today;
                NF.UsuarioReg = ultimo.Usuario;
                NF.Activo = "S";
                NF.Borrado = "N";
                LoDBContext.seg_expira_claves.Add(NF);
                LoDBContext.SaveChanges();
                //await LoDBContext.SaveChangesAsync();
                //---
                var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
                var client = new SendGridClient("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");
                var from = new EmailAddress("marcogp97@gmail.com", "Marco");
                var to = new EmailAddress("maangaraype@ittepic.edu.mx", "Marco");
                var subject = "Se ha cambiado su contraseña";
                var plainTextContent = "Su contraseña";
                var htmlContent = "<strong> Tu contraseña ha sido cambiada </strong>";
                var msg = MailHelper.CreateSingleEmail(
                        from,
                        to,
                        subject,
                        plainTextContent,
                        htmlContent
                    );
                var response = await client.SendEmailAsync(msg);
                //--
                return Ok("Inventario registrado");
            }
            catch (Exception e)
            {
                Dictionary<String, String> err = new Dictionary<string, string>();
                err.Add("err", "Post");
                return Ok(err);
            }
        }
        #endregion
        public IActionResult Index()
        {
            return View();
        }
    }
}