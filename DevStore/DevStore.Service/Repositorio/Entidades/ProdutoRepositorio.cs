using DevStore.Domain;
using DevStore.Domain.Models;
using DevStore.Service.Interfaces.Entidades;

namespace DevStore.Service.Repositorio.Entidades
{
   public class ProdutoRepositorio : Repositorio<Produto>, IProdutoRepositorio
    {
    }
}
