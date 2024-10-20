using API.Data;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Services.Produto
{
    public class Service_Produto : Interface_Produto
    {

        private readonly AppDbContext _context;
        
        public Service_Produto(AppDbContext context)
        {
            _context = context;
        }

        public Task<Response_Model<Model_Produtos>> Buscar_Produto_Id()
        {
            throw new NotImplementedException();
        }

        public async Task<Response_Model<List<Model_Produtos>>> Listar_Produtos()
        {
            Response_Model<List<Model_Produtos>> resposta = new Response_Model<List<Model_Produtos>>();
            try
            {

                var Produtos = await _context.Produtos.ToListAsync();
                resposta.Dados= Produtos;
                resposta.Mensagem = "Todos os Produtos coletados";

                return resposta;

            }
            catch (Exception ex)
            {

                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;

            }
        }
    }
}
