
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiNetCoreMysql.Data;

namespace WebApiNetCoreMysql.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        public AccesoDB Db { get; }


        public EmpleadoController(AccesoDB db)
        {
            Db = db;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {

                await Db.Connection.OpenAsync();
                var query = new EmpleadoDao(Db);
                var result = await query.Listar();
                return new OkObjectResult(result);
        }

    }
}