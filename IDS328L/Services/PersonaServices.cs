using IDS328L.DTO;
using IDS328L.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace IDS328L.Services
{
    public interface IPersonaServices
    {
        Response<ViewPersona> Get(int Operacion, int Id, bool Estado);
        Response Post(PersonaEntities PersonaEntities);
        Response Put(PersonaEntities PersonaEntities);
        Response Delete(int Id);
    }
    public class PersonaServices : IPersonaServices
    {
        #region Entity Referencing Context
        private readonly FinalProjectContext Context;
        #endregion

        public PersonaServices(FinalProjectContext _Context)
        {
            Context = _Context;
        }

        #region This method return one record or List of Persons
        public Response<ViewPersona> Get(int Operacion, int Id, bool Estado)
        {
            var Result = new Response<ViewPersona>();
            try
            {
                if (Operacion == 0)
                {
                    Result.Errors.Add(string.Format(" Valor 'Operación' inválido."));
                }
                else
                {
                    var Data = Context.ViewPersonas.FromSqlRaw("[dbo].[PP_GetPersona] {0},{1},{2}", Operacion, Id, Estado).ToList();
                    Result.DataList = Data;
                }
            }
            catch (Exception ex)
            {
                string Mensaje = ex.Message;
                Result.Errors.Add(string.Format("El método obtener personas está presentando errores, favor verificar el log."));
            }
            return Result;
        }
        #endregion

        #region This method creates a record from the Persona table
        public Response Post(PersonaEntities PersonaEntities)
        {
            var Result = new Response();

            try
            {
                if (PersonaEntities.Nombre == null )
                {
                    Result.Errors.Add(string.Format(" Debe completar todos los campos requeridos (Nombre)"));
                }
                else if (PersonaEntities.Apellido == null)
                {
                    Result.Errors.Add(string.Format(" Debe completar todos los campos requeridos (Apellido)"));
                }
                if (PersonaEntities.Cedula == null)
                {
                    Result.Errors.Add(string.Format(" Debe completar todos los campos requeridos (Cedula)"));
                }
                if (PersonaEntities.Telefono == null)
                {
                    Result.Errors.Add(string.Format(" Debe completar todos los campos requeridos (Teléfono)"));
                }
                if (PersonaEntities.Direccion == null)
                {
                    Result.Errors.Add(string.Format(" Debe completar todos los campos requeridos (Dirección)"));
                }
                else
                {
                    Context.Database.ExecuteSqlInterpolated($"[dbo].[PP_SetPersona] 1,{PersonaEntities.Nombre},{PersonaEntities.Apellido},{PersonaEntities.Cedula},{PersonaEntities.Telefono},{PersonaEntities.Direccion},{PersonaEntities.Id}");
                }
            }
            catch (Exception ex)
            {
                Result.Errors.Add(string.Format("Ha ocurrido un error insertando un nuevo registro en 'Personas'"));
            }
            return Result;
        }
        #endregion

        #region This method edit a record from the Persona table
        public Response Put(PersonaEntities PersonaEntities)
        {
            var Result = new Response();

            try
            {
                if (PersonaEntities.Id == null || PersonaEntities.Id == 0)
                {
                    Result.Errors.Add(string.Format(" Debe ingresar un id válido"));
                }
                else
                {
                    Context.Database.ExecuteSqlInterpolated($"[dbo].[PP_SetPersona] 2, {PersonaEntities.Nombre}, {PersonaEntities.Apellido}, {PersonaEntities.Cedula},{PersonaEntities.Telefono},{PersonaEntities.Direccion},{PersonaEntities.Id}");
                }
            }
            catch (Exception ex)
            {
                Result.Errors.Add(string.Format("Ha ocurrido un error editando un nuevo registro en 'Persona'"));
            }
            return Result;
        }
        #endregion

        #region This method is used to delete a Persona record
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
                    Context.Database.ExecuteSqlInterpolated($"[dbo].[PP_SetPersona] 3, {""} ,{""},{""},{""},{""},{Id}");
                }
            }
            catch (System.Exception ex)
            {
                Result.Errors.Add(string.Format("Ha ocurrido un error inactivando un registro de 'Persona'." + ex));
            }
            return Result;
        }
        #endregion
    }// Esto es un cambio infovensivo
    // Otro
}
