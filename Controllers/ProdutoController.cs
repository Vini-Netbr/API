using API.Models;
using API.Services.Produto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {

        private readonly Interface_Produto _interinterface_Produto;

        public ProdutoController(Interface_Produto interface_Produto) { 
        
            _interinterface_Produto = interface_Produto;

        }

        [HttpGet("Buscar Produtos")]

        public async Task<ActionResult<Response_Model<List<Model_Produtos>>>> Listar_Produtos()
        {
            var Produtos = await _interinterface_Produto.Listar_Produtos();
            return Ok(Produtos);
        }


    }
}
