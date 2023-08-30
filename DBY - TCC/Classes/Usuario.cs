using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBY___TCC.Classes
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }

        // Permissões relacionadas a vendas
        public bool PermissaoRealizarVenda { get; set; }
        public bool PermissaoEditarVenda { get; set; }
        public bool PermissaoExcluirVenda { get; set; }

        // Permissões relacionadas a entregas
        public bool PermissaoEntrarTelaEntrega { get; set; }
        public bool PermissaoCadastrarEntrega { get; set; }
        public bool PermissaoEditarEntrega { get; set; }
        public bool PermissaoExcluirEntrega { get; set; }

        // Permissões relacionadas a produtos
        public bool PermissaoEntrarTelaProdutos { get; set; }
        public bool PermissaoCadastrarProduto { get; set; }
        public bool PermissaoCadastrarCategoria { get; set; }
        public bool PermissaoCadastrarMarca { get; set; }
        public bool PermissaoEditarProduto { get; set; }
        public bool PermissaoExcluirProduto { get; set; }

        // Permissões relacionadas a clientes
        public bool PermissaoEntrarTelaClientes { get; set; }
        public bool PermissaoCadastrarClientes { get; set; }
        public bool PermissaoEditarClientes { get; set; }
        public bool PermissaoExcluirClientes { get; set; }

        // Permissões relacionadas a faturamento
        public bool PermissaoEntrarTelaFaturamento { get; set; }
        public bool PermissaoCadastrarFaturamento { get; set; }
        public bool PermissaoEditarFaturamento { get; set; }
        public bool PermissaoExcluirFaturamento { get; set; }

        // Permissões relacionadas a estoque
        public bool PermissaoEntrarTelaEstoque { get; set; }
        public bool PermissaoCadastrarEstoque { get; set; }
        public bool PermissaoEditarEstoque { get; set; }
        public bool PermissaoExcluirEstoque { get; set; }

        // Permissões relacionadas a configurações
        public bool PermissaoEntrarTelaConfiguracoes { get; set; }
        public bool PermissaoFazerBackup { get; set; }
        public bool PermissaoAlterarPermissoesUsuarios { get; set; }
        public bool PermissaoAlterarParametrosGerais { get; set; }
    }
}
