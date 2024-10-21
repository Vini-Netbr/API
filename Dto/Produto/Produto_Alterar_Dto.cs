namespace API.Dto.Produto
{
    public class Produto_Alterar_Dto
    {
        public int Id { get; set; }
        public string Produto { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public string Imagem { get; set; }

    }
}
