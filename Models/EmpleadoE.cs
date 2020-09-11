using WebApiNetCoreMysql.Data;

namespace WebApiNetCoreMysql
{
    public class EmpleadoE
    {
        internal AccesoDB DB { get; set; }

        internal EmpleadoE(AccesoDB db)
        {
            DB = db;
        }
        
        public int Emp_Id { get; set; }
        public string Emp_Codigo { get; set; }
        public string Emp_ApePaterno { get; set; }
        public string Emp_ApeMaterno { get; set; }
        public string Emp_Nombres { get; set; }
        public string Emp_Telefono { get; set; }
    }
}