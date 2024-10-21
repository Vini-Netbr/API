using API.Services;
using API.Models;
using API.Dto.Produto;

namespace API.Services.Produto
{
    public interface Interface_Produto
    {
        Task<Response_Model<List<Model_Produtos>>> Listar_Produtos();
        Task<Response_Model<Model_Produtos>> Buscar_Produto_Id();

        Task<Response_Model<List<Model_Produtos>>> Criar_Produto(Produto_Criacao_Dto produto_Criacao_Dto);

        Task<Response_Model<List<Model_Produtos>>> Alterar_Produto(Produto_Alterar_Dto produto_Alterar_Dto);

        Task<Response_Model<List<Model_Produtos>>> Deletar_Produto(int Id);
    }
}
