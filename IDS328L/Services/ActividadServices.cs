using IDS328L.DTO;
using IDS328L.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace IDS328L.Services
{
    public interface IActividadServices
    {
        Response<ViewActividad> Get(int Operacion, int Id, bool Estado);
        Response Post(ActividadEntities ActividadEntities);
        Response Put(ActividadEntities ActividadEntities);
        Response Delete(int Id);
    }
    public class ActividadServices : IActividadServices
    {
        #region Entity Referencing Context
        private readonly FinalProjectContext Context;
        #endregion

        public ActividadServices(FinalProjectContext _Context)
        {
            Context = _Context;
        }

        #region This method return one record or List of Activities
        public Response<ViewActividad> Get(int Operacion, int Id, bool Estado)
        {
            var Result = new Response<ViewActividad>();
            try
            {
                if (Operacion == 0)
                {
                    Result.Errors.Add(string.Format(" Valor 'Operación' inválido."));
                }
                else 
                {
                    var Data = Context.ViewActividads.FromSqlRaw("[dbo].[PP_GetActividad] {0},{1},{2}", Operacion, Id, Estado).ToList();
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

        #region This method creates a record from the Actividad table
        public Response Post(ActividadEntities ActividadEntities)
        {
            var Result = new Response();

            try
            {
                if (ActividadEntities.Descripcion == null || ActividadEntities.FechaEjecutado == null)
                {
                    Result.Errors.Add(string.Format(" Debe completar todos los campos requeridos (Descripción, FechaEjecutado)"));
                }
                else
                {
                    Context.Database.ExecuteSqlInterpolated($"[dbo].[PP_SetActividad] 1,{ActividadEntities.Descripcion},{ActividadEntities.FechaEjecutado},{ActividadEntities.Id}");
                }
            }
            catch (Exception ex)
            {
                Result.Errors.Add(string.Format("Ha ocurrido un error insertando un nuevo registro en 'Actividad'"));
            }
            return Result;
        }
        #endregion

        #region This method edit a record from the Actividad table
        public Response Put(ActividadEntities ActividadEntities)
        {
            var Result = new Response();

            try
            {
                if (ActividadEntities.Id == null || ActividadEntities.Id == 0)
                {
                    Result.Errors.Add(string.Format(" Debe ingresar un id válido"));
                }
                else
                {
                    Context.Database.ExecuteSqlInterpolated($"[dbo].[PP_SetActividad] 2, {ActividadEntities.Descripcion} , {ActividadEntities.FechaEjecutado} , {ActividadEntities.Id}");
                }
            }
            catch (Exception ex)
            {
                Result.Errors.Add(string.Format("Ha ocurrido un error editando un nuevo registro en 'Actividad'"));
            }
            return Result;
        }
        #endregion

        #region This method is used to delete a Actividad record
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
                    Context.Database.ExecuteSqlInterpolated($"[dbo].[PP_SetActividad] 3, {""} ,'2001-01-01', {Id}");
                }
            }
            catch (System.Exception ex)
            {
                Result.Errors.Add(string.Format("Ha ocurrido un error inactivando un registro de 'Actividad'." + ex));
            }
            return Result;
        }
        #endregion
    }
}
