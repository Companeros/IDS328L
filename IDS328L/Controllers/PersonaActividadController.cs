using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IDS328L.DTO;
using IDS328L.Services;

namespace IDS328L.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaActividadController : ControllerBase
    {
        private readonly IPersonaActividadServices _IServices;
        #region Constructor
        public PersonaActividadController(IPersonaActividadServices service)
        {
            _IServices = service;
        }
        #endregion

        #region [HttpGet] search by Nombre, Id, Operacion
        [HttpGet]
        public ActionResult Get(int Operacion = 1, int Id = 0, bool Estado = true)
        {
            
            var result = _IServices.Get(Operacion, Id, Estado);
            if(result.Succeded == false)
            {
                return BadRequest(result);
            }
            else
            {
                return Ok(result);
            }
        }
        #endregion

        #region [HttpPost] PersonaActividad Requests
        [HttpPost]
        public ActionResult Post(PersonaActividadEntities PersonaActividadEntities)
        {
            if(_IServices != null)
            {
                var result = _IServices.Post(PersonaActividadEntities);
                if (result.Succeded)
                {

                return Ok(result);
                }
                else
                {
                    return BadRequest(result);
                }
            }
            else
            {
                return BadRequest("Error al ejecutar el servicio");
            }
        }
        #endregion

        #region [HttpPut] PersonaActividad Requests
        [HttpPut]
        public ActionResult Put(PersonaActividadEntities PersonaActividadEntities)
        {
            var result = _IServices.Put(PersonaActividadEntities);
            if (!result.Succeded)
            {
                return BadRequest(result);
            }
            else
            {
                return Ok(result);
            }
            
        }
        #endregion

        #region Delete by 
        [HttpDelete]
        public ActionResult Delete(int Id)
        {
            var result = _IServices.Delete(Id);
            if (!result.Succeded)
            {
                return BadRequest(result);
            }
            else
            {
                return Ok(result);
            }
            
        }
        #endregion
    }


}
