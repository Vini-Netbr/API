using API.Data;
using API.Dto.Produto;
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

        public async Task<Response_Model<List<Model_Produtos>>> Criar_Produto(Produto_Criacao_Dto produto_Criacao_Dto)
        {
            Response_Model<List<Model_Produtos>> resposta = new Response_Model<List<Model_Produtos>>();

            try
            {

                var Produto = new Model_Produtos()
                {

                    Produto = produto_Criacao_Dto.Produto,
                    Descricao= produto_Criacao_Dto.Descricao,
                    Preco= produto_Criacao_Dto.Preco,
                    Quantidade= produto_Criacao_Dto.Quantidade,
                    Imagem= produto_Criacao_Dto.Imagem,


            };

                _context.Add(Produto);
                await _context.SaveChangesAsync();

                resposta.Dados= await _context.Produtos.ToListAsync();
                resposta.Mensagem = "Produto Criado com secesso";
                return resposta;

            }  
            catch (Exception ex)
            {

                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;

            }
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

        public async Task<Response_Model<List<Model_Produtos>>> Alterar_Produto(Produto_Alterar_Dto produto_Alterar_Dto)
        {

            Response_Model<List<Model_Produtos>> resposta = new Response_Model<List<Model_Produtos>>();

            try
            {
                var Produto = await _context.Produtos.FirstOrDefaultAsync(ProdutoBanco=>ProdutoBanco.Id == produto_Alterar_Dto.Id);

                if (Produto == null)
                {
                    resposta.Mensagem = ("nenhum produto localizado");
                    resposta.Status = true;
                    return resposta;
                }

                Produto.Produto = produto_Alterar_Dto.Produto;
                Produto.Descricao = produto_Alterar_Dto.Descricao;
                Produto.Preco = produto_Alterar_Dto.Preco;
                Produto.Quantidade = produto_Alterar_Dto.Quantidade;
                Produto.Imagem = produto_Alterar_Dto.Imagem;

                _context.Update(Produto);
                await _context.SaveChangesAsync();

                resposta.Mensagem = ("Produto Alterado com sucesso");
                return resposta;



            }
            catch (Exception ex)
            {

                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;

            }

        }
        public async Task<Response_Model<List<Model_Produtos>>> Deletar_Produto(int Id)
        {

            Response_Model<List<Model_Produtos>> resposta = new Response_Model<List<Model_Produtos>>();

            try
            {

                var Produto = await _context.Produtos.FirstOrDefaultAsync(ProdutoBanco=>ProdutoBanco.Id==Id);

                if (Produto == null)
                {
                    resposta.Mensagem = ("nenhum produto localizado");
                    resposta.Status = true;
                    return resposta;
                }

                _context.Remove(Produto);
                await _context.SaveChangesAsync();

                resposta.Mensagem = ("Produto removido com sucesso");
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
