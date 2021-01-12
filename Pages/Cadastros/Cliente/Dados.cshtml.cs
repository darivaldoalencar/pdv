using Microsoft.AspNetCore.Mvc;
using PDV.DataBase.Negocio;
using PDV.Pages.Shared;

namespace PDV.Pages.Cadastros.Cliente
{
    public class DadosModel : _CadastrosModel
    {
        #region propriedades
        [BindProperty]
        public PDV.DataBase.Objetos.Clientes cliente { get; set; }
                
        protected ClientesN negocio { get { return new ClientesN(); } }
        #endregion

        #region cadastros
        private PDV.DataBase.Objetos.Clientes SalvarCliente(PDV.DataBase.Objetos.Clientes cliente)
        {
            if (cliente.id_cliente == -1)
            {
                if (negocio.Incluir(ref cliente))
                {
                    this.msgSucesso = "Cliente cadastrado com sucesso.";
                    return cliente;
                }
                else
                {
                    this.msgErro = string.Concat("Ocorreu um erro ao salvar cadastro.");
                    return null;
                }
            }
            else
            {
                return EditarCliente(cliente);
            }
        }
        private PDV.DataBase.Objetos.Clientes EditarCliente(PDV.DataBase.Objetos.Clientes cliente)
        {
            if (negocio.Alterar(ref cliente))
            {
                this.msgSucesso = "Cliente alterado com sucesso.";
                return cliente;
            }
            else
            {
                this.msgErro = string.Concat("Ocorreu um erro ao alterar cadastro.");
                return null;
            }
        }
        #endregion       

        public IActionResult OnPostCadastro(string btnControle)
        {
            base.ValidaOpCadastro(btnControle);

            if (cliente.id_cliente == null)
                cliente.id_cliente = -1;


            if (!ModelState.IsValid)
            {
                return Page();
            }

            switch (op_cadastro)
            {
                case "s":
                    SalvarCliente(cliente);
                    break;
            }

            return Page();
        }

        public IActionResult OnGet(int? id)
        {
            if (id != null)
            {
                if (cliente == null)
                    cliente = new PDV.DataBase.Objetos.Clientes();

                cliente.id_cliente = id;
                cliente = negocio.ListarUM(cliente);
            }

            return Page();
        }
    }
}
