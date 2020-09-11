using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using WebApiNetCoreMysql.Data;
using MySqlConnector;

namespace WebApiNetCoreMysql.Data
{
    public class EmpleadoDao
    {
        public AccesoDB Db { get; }

        public EmpleadoDao()
        {

        }

        internal EmpleadoDao(AccesoDB db)
        {
            Db = db;
        }

        //Consultar a la bd
        public async Task<List<EmpleadoE>> Listar()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"SELECT * FROM Empleado";
            return await LeerTodo(await cmd.ExecuteReaderAsync());
        }

        //Proceso para lectura de Listado por entidad
        public async Task<List<EmpleadoE>> LeerTodo(DbDataReader dr)
        {
            var empleados = new List<EmpleadoE>();
            using (dr)
            {
                while (await dr.ReadAsync())
                {
                    var empleado = new EmpleadoE(Db)
                    {
                        Emp_Id = await dr.GetFieldValueAsync<int>(0),
                        Emp_Codigo = await dr.GetFieldValueAsync<string>(1),
                        Emp_ApePaterno = await dr.GetFieldValueAsync<string>(2),
                        Emp_ApeMaterno = await dr.GetFieldValueAsync<string>(3),
                        Emp_Nombres = await dr.GetFieldValueAsync<string>(4),
                        Emp_Telefono = await dr.GetFieldValueAsync<string>(5)
                    };
                    empleados.Add(empleado);
                }
            }
            return empleados;
        }
    }
}