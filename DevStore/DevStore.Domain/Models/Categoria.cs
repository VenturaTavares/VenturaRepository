namespace DevStore.Domain
{
    public class Categoria
    {

        public int CategoriaID { get; set; }

        public string Nome { get; set; }

        public string Status { get; set; }

        public override string ToString()
        {
            return this.Nome;  
        }
    }
}