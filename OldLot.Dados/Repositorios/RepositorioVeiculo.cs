using OldLot.Dados.Contextos;
using OldLot.Dominio.Entidades;
using OldLot.Dominio.Interfaces.Repositorios;

namespace OldLot.Dados.Repositorios
{
    public class RepositorioVeiculo : RepositorioBase<Veiculo>, IRepositorioVeiculo
    {
        public RepositorioVeiculo(ContextoOldLot dbContext) : base(dbContext)
        {

        }

        public override void Incluir(Veiculo entidade)
        {
            if (entidade != null)
            {
                if (entidade.Fabricante != null && entidade.Fabricante.Id != 0) Db.Fabricantes.Attach(entidade.Fabricante);
                if (entidade.Tipo != null && entidade.Tipo.Id != 0) Db.TiposDeVeiculo.Attach(entidade.Tipo);
            }

            base.Incluir(entidade);
        }

        public override void Atualizar(Veiculo entidade)
        {
            if (entidade != null)
            {
                if (entidade.Fabricante != null && entidade.Fabricante.Id != 0) Db.Fabricantes.Attach(entidade.Fabricante);
                if (entidade.Tipo != null && entidade.Tipo.Id != 0) Db.TiposDeVeiculo.Attach(entidade.Tipo);
            }

            base.Atualizar(entidade);
        }
    }
}
