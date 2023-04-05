using IDS328L.DTO;
using IDS328L.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace IDS328L.Services
{
    public interface IPersonaActividadServices
    {
        Response<PersonaActividadView> Get(int Operacion, int Id, bool Estado);
        Response Post(PersonaActividadEntities personaActividad);
        Response Put(PersonaActividadEntities personaActividad);
        Response Delete(int Id);
    }

    public class PersonaActividadServicies : IPersonaActividadServices
    {

        #region Entity Referencing Context
        private readonly FinalProjectContext Context;
        #endregion

        public PersonaActividadServicies(FinalProjectContext _Context)
        {
            Context = _Context;
        }



        #region This method return one record or a list of elements from personaactividadTable

        public Response<PersonaActividadView> Get(int Operacion, int Id, bool Estado)
        {
            var Result = new Response<PersonaActividadView>();
            try
            {
                if (Operacion == 0)
                {
                    Result.Errors.Add(string.Format(" Valor 'Operación' inválido."));
                }
                else
                {
                    var Data = Context.PersonaActividadViews.FromSqlRaw("[dbo].[PP_GetPersona_Actividad] {0},{1},{2}", Operacion, Id, Estado).ToList();
                    Result.DataList = Data;
                }
            }
            catch (Exception ex)
            {
                string Mensaje = ex.Message;
                Result.Errors.Add(string.Format("El método obtener actividad está presentando errores, favor verificar el log."));

            }
            return Result;
        }

        #endregion
        #region This method creates a record from the Persona_Actividad table
        public Response Post(PersonaActividadEntities PersonaActividadEntities)
        {
            var Result = new Response();

            try
            {
                if (PersonaActividadEntities.IdPersona == null || PersonaActividadEntities.IdActividad == null)
                {
                    Result.Errors.Add(string.Format(" Debe completar todos los campos requeridos (IdPersona, IdActividad)"));
                }
                else
                {
                    Context.Database.ExecuteSqlInterpolated($"[dbo].[PP_SetPersona_Actividad] 1,{PersonaActividadEntities.IdPersona},{PersonaActividadEntities.IdActividad},{PersonaActividadEntities.Id}");
                }
            }
            catch (Exception ex)
            {
                Result.Errors.Add(string.Format("Ha ocurrido un error insertando un nuevo registro en 'Persona_Actividad'"));
            }
            return Result;
        }

        #endregion

        #region This method edit a record from the PersonaActividad table
        public Response Put(PersonaActividadEntities PersonaActividadEntities)
        {
            var Result = new Response();

            try
            {
                if (PersonaActividadEntities.Id == null || PersonaActividadEntities.Id == 0)
                {
                    Result.Errors.Add(string.Format(" Debe ingresar un id válido"));
                }
                else
                {
                    Context.Database.ExecuteSqlInterpolated($"[dbo].[PP_SetPersona_Actividad] 2,{PersonaActividadEntities.IdPersona},{PersonaActividadEntities.IdActividad},{PersonaActividadEntities.Id}");
                }
            }
            catch (Exception ex)
            {
                Result.Errors.Add(string.Format("Ha ocurrido un error editando un nuevo registro en 'Persona_Actividad'"));
            }
            return Result;
        }
        #endregion

        #region
        public Response Delete(int Id)
        {
            var Result = new Response();

            try
            {
                if (Id == null || Id == 0)
                {
                    Result.Errors.Add(string.Format(" Debe ingresar un id válido"));
                }
                else
                {
                    var Error = new SqlParameter("@Message", SqlDbType.Int) { Direction = ParameterDirection.Output };
                    Context.Database.ExecuteSqlInterpolated($"[dbo].[PP_SetPersona_Actividad] 3, {""} ,'2001-01-01', {Id}");
                }
            }
            catch (System.Exception ex)
            {
                Result.Errors.Add(string.Format("Ha ocurrido un error inactivando un registro de 'Persona_Actividad '." + ex));
            }
            return Result;
        }

        #endregion

    }
}
