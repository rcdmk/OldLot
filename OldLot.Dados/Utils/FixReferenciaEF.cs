namespace OldLot.Dados.Utils
{
    /// <summary>
    /// Esta classe serve apenas para forçar o sistema de build a copiar a dependência do EntityFramework
    /// para o projeto que utilizar a camada de dados, sem referenciar diretamente a dependência no projeto.
    /// </summary>
    sealed class FixReferenciaEF
    {
        System.Data.Entity.SqlServer.SqlProviderServices garantirQueDllSejaCopiada = System.Data.Entity.SqlServer.SqlProviderServices.Instance;

        private FixReferenciaEF()
        {
        }
    }
}
