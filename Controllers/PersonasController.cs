using ApiPersonas.DAL;
using ApiPersonas.Models;
using ApiPersonas.Response;
using ApiPersonas.Utilerias;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ApiPersonas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        private readonly DataContext _context;

        public PersonasController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("ConsultaPersonas")]
        public async Task<ActionResult<List<tbl_personas>>> ConsultaPersonas()
        {
            ResponseGeneric<List<tbl_personas>> objResponse = new ResponseGeneric<List<tbl_personas>>();

            objResponse.Data = await _context.tbl_personas.ToListAsync();
            //var lspersonas = await _context.tbl_personas.ToListAsync();
            //return Ok(lspersonas);
            return Ok(objResponse.Data);
        }

        [HttpPost("AgregaPersonas")]
        public async Task<ResponseGeneric<tbl_personas>> AgregaPersonas(tbl_personas objPersonas)
        {
            ResponseGeneric<tbl_personas> objResponse = new ResponseGeneric<tbl_personas>();
            try
            {
                //valida nombre no sobrepase a 50 caracteres.
                if (!Utils.validacincuentaCaracteres( objPersonas.Nombre)) {

                    objResponse.codeMessage = "1";
                    objResponse.Message = "El nombre no puede ser mayor a cincuenta caracteres";

                    return objResponse;
                }
                // correos validos ejemplos:
                //"tony@example.com",
                //"tony.stark@example.net",
                //"tony@example.co.uk",
                //"tony@example",

                // correos invalidos ejemplos:
                //"tony.example.com",
                //"tony@stark@example.net",
                //"tony@.example.co.uk"

                //valida formato correcto de email.
                if (!Utils.formatoEmail(objPersonas.Email)){
                    objResponse.codeMessage = "2";
                    objResponse.Message = "Formato de correo invalido";

                    return objResponse;
                }

                //valida edad contenga solo letras
                if (!Utils.solonumeros(objPersonas.Edad)) {
                    objResponse.codeMessage = "3";
                    objResponse.Message = "Solo se permiten números";

                    return objResponse;
                }

                await _context.tbl_personas.AddAsync(objPersonas);
                await _context.SaveChangesAsync();
                objResponse.codeMessage = "OK";
                objResponse.Message = "El registro se agrego correctamente";
            }
            catch (Exception ex) { 
            
                objResponse.codeMessage = "10001";
                objResponse.Message = ex.Message + "|" + ex.InnerException + "|" +ex.StackTrace;
               
            
            }
           
            //return Ok(objPersonas);
            return objResponse;
            
        }

    }
}
