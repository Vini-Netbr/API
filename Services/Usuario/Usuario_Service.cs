using API.Data;
using API.Dto.Produto;
using API.Dto.Usuario;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Services.Usuario
{
    public class Usuario_Service : Usuario_Interface
    {
        private readonly AppDbContext _context;

        public Usuario_Service(AppDbContext context)
        {
            _context = context;
        }

        public Task<Response_Model<List<Model_Usuario>>> Alterar_Usuario(Usuario_Alterar_Dto usuario_Alterar_Dto)
        {
            throw new NotImplementedException();
        }

        public async Task<Response_Model<Model_Usuario>> Buscar_Usuario_Id(string senha, string email)
        {
            Response_Model<Model_Usuario> resposta = new Response_Model<Model_Usuario>();

            try
            {
                // Busca um usuário que corresponda ao email e à senha fornecidos
                var usuario = await _context.Usuarios
                    .FirstOrDefaultAsync(u => u.Email == email && u.Senha == senha);

                if (usuario == null)
                {
                    resposta.Mensagem = "Nenhum usuário localizado";
                    resposta.Status = false; // O usuário não foi encontrado
                    return resposta;
                }

                // Se o usuário foi encontrado
                resposta.Dados = usuario; // Retorna o usuário encontrado
                resposta.Mensagem = "Usuário encontrado com sucesso";
                resposta.Status = true; // Indica que a operação foi bem-sucedida
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false; // Define o status como falso em caso de erro
                return resposta;
            }
        }


        public async Task<Response_Model<List<Model_Usuario>>> Criar_Usuario(Usuario_Criacao_Dto usuario_Criacao_Dto)
        {
            Response_Model<List<Model_Usuario>> resposta = new Response_Model<List<Model_Usuario>>();

            try
            {
                // Aqui estou acessando as propriedades do objeto passado como parâmetro (usuario_Criacao_Dto)
                var usuario = new Model_Usuario()
                {
                    Nome = usuario_Criacao_Dto.Nome,
                    Email = usuario_Criacao_Dto.Email,
                    Senha = usuario_Criacao_Dto.Senha,
                    Funcao = usuario_Criacao_Dto.Funcao,
                    
                };

                // Adiciona o novo usuário ao contexto do banco de dados
                _context.Add(usuario);
                await _context.SaveChangesAsync();

                // Recupera a lista de todos os usuários para retornar
                resposta.Dados = await _context.Usuarios.ToListAsync(); // Supondo que o DbSet seja 'Usuarios'
                resposta.Mensagem = "Usuário criado com sucesso!";
                return resposta;
            }
            catch (Exception ex)
            {
                // Captura qualquer exceção e define a mensagem de erro
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public Task<Response_Model<List<Model_Usuario>>> Deletar_Usuario(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<Response_Model<List<Model_Usuario>>> Listar_Usuarios()
        {
            throw new NotImplementedException();
        }
    }
}

