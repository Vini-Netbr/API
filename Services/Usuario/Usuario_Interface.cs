using API.Dto.Produto;
using API.Dto.Usuario;
using API.Models;

namespace API.Services.Usuario
{
    public interface Usuario_Interface
    {

        Task<Response_Model<List<Model_Usuario>>> Listar_Usuarios();
        Task<Response_Model<Model_Usuario>> Buscar_Usuario_Id(string Senha, string Email);

        Task<Response_Model<List<Model_Usuario>>> Criar_Usuario(Usuario_Criacao_Dto usuario_Criacao_Dto);

        Task<Response_Model<List<Model_Usuario>>> Alterar_Usuario(Usuario_Alterar_Dto usuario_Alterar_Dto);

        Task<Response_Model<List<Model_Usuario>>> Deletar_Usuario(int Id);

    }
}
