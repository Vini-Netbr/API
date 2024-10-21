using API.Dto.Produto;
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

        [HttpGet("BuscarProdutos")]

        public async Task<ActionResult<Response_Model<List<Model_Produtos>>>> Listar_Produtos()
        {
            var Produtos = await _interinterface_Produto.Listar_Produtos();
            return Ok(Produtos);
        }

        [HttpPost("CriarProduto")]

        public async Task<ActionResult<Response_Model<List<Model_Produtos>>>> Criar_Poduto(Produto_Criacao_Dto produto_Criacao_Dto)
        {
            var Produtos = await _interinterface_Produto.Criar_Produto(produto_Criacao_Dto);
            return Ok(Produtos);
        }

        [HttpPut("EditarProdutos")]

        public async Task<ActionResult<Response_Model<List<Model_Produtos>>>> Alterar_Poduto(Produto_Alterar_Dto produto_Alterar_Dto)
        {
            var Produtos = await _interinterface_Produto.Alterar_Produto(produto_Alterar_Dto);
            return Ok(Produtos);
        }

        [HttpDelete("DeletarProdutos")]

        public async Task<ActionResult<Response_Model<List<Model_Produtos>>>> Deletar_Poduto(int Id )
        {
            var Produtos = await _interinterface_Produto.Deletar_Produto(Id);
            return Ok(Produtos);
        }

    }
}
