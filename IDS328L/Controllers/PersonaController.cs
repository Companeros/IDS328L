﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IDS328L.DTO;
using IDS328L.Services;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CORE_Api_Pymes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly IPersonaServices _IServices;

        #region Constructor
        public PersonaController(IPersonaServices service)
        {
            _IServices = service;
        }
        #endregion

        #region[HttpGet] search by Operacion, Id, Estado
        [HttpGet]
        public ActionResult Get(int Operacion = 1, int Id = 0, bool Estado = true)
        {
            var result = _IServices.Get(Operacion, Id, Estado);
            if (result.Succeded == false)
            {
                return BadRequest(result);
            }
            else
            {
                return Ok(result);
            }

        }
        #endregion

        #region[HttpPost] Persona Requests
        [HttpPost]
        public ActionResult Post(PersonaEntities PersonaEntities)
        {
            if (_IServices != null)
            {
                var result = _IServices.Post(PersonaEntities);

                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }
        #endregion

        #region [HttpPut] Persona Requests
        [HttpPut]
        public ActionResult Put(PersonaEntities PersonaEntities)
        {
            var result = _IServices.Put(PersonaEntities);

            if (result.Succeded == false)
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


            if (result.Succeded == false)
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
