using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PDV.DataBase.Objetos;

namespace PDV.Pages.Shared
{
    public class _CadastrosModel : PageModel
    {
        public string msgSucesso { get; set; }
        public string msgErro { get; set; }
        public string op_cadastro { get; set; }

        public IEnumerable<Estados> TodosEstados()
        {
            return new Estados().ListarTodosEstados();
        }

        public void ValidaOpCadastro(string btnControle)
        {
            if (!string.IsNullOrEmpty(btnControle))
                btnControle = btnControle.ToLower();

            switch (btnControle)
            {
                case "novo":
                case "limpar":
                    op_cadastro = "n";
                    break;
                case "salvar":
                case "confirmar":
                    op_cadastro = "s";
                    break;
                case "editar":
                    op_cadastro = "e";
                    break;
                case "excluir":
                    op_cadastro = "d";
                    break;
            }
        }
    }
}
