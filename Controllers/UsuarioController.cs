using API.Dto.Usuario;
using API.Services.Usuario;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.Dto.Produto;
using API.Services.Produto;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly Usuario_Interface _Usuario_Interface;

        public UsuarioController(Usuario_Interface usuario_Interface)
        {

            _Usuario_Interface = usuario_Interface;

        }

        [HttpPost("CadastrarUsuario")]
        public async Task<ActionResult<Response_Model<List<Model_Usuario>>>> Criar_Usuario(Usuario_Criacao_Dto usuario_Criacao_Dto)
        {
            // Chama o serviço para criar o usuário
            var resposta = await _Usuario_Interface.Criar_Usuario(usuario_Criacao_Dto);

            // Verifica se a criação foi bem-sucedida
            if (resposta.Status && resposta.Dados != null)
            {
                // Remove a senha dos usuários antes de retornar a resposta
                foreach (var usuario in resposta.Dados)
                {
                    usuario.Senha = null; // Remove a senha do usuário
                }

                return Ok(resposta); // Retorna a resposta sem as senhas
            }
            else
            {
                return BadRequest(resposta); // Retorna um erro se a criação falhar
            }
        }


        [HttpPost("LogarUsuario")]
        public async Task<ActionResult<Response_Model<Model_Usuario>>> Buscar_Usuario([FromBody] Usuario_Login_Dto usuario_Login_Dto)
        {
            // Chama o serviço para buscar o usuário com email e senha
            var resultado = await _Usuario_Interface.Buscar_Usuario_Id(usuario_Login_Dto.Senha, usuario_Login_Dto.Email);

            
            if (resultado.Status)
            {
                // Remove a senha antes de retornar o usuário
                if (resultado.Dados != null)
                {
                    resultado.Dados.Senha = null; 
                }

                return Ok(resultado); 
            }
            else
            {
                return BadRequest(resultado); 
            }
        }



    }
}
