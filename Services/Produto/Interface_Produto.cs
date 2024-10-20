using API.Services;
using API.Models;

namespace API.Services.Produto
{
    public interface Interface_Produto
    {
        Task<Response_Model<List<Model_Produtos>>> Listar_Produtos();
        Task<Response_Model<Model_Produtos>> Buscar_Produto_Id();
    }
}
