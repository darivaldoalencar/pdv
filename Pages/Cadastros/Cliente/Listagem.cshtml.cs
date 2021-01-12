using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PDV.DataBase.Negocio;
using PDV.Pages.Shared;

namespace PDV.Pages.Cadastros.Cliente
{
    public class ListagemModel : _CadastrosModel
    {
        [BindProperty]
        public PDV.DataBase.Objetos.Clientes cliente { get; set; }

        [BindProperty]
        public string nomeBusca { get; set; }


        public IActionResult OnPostCadastro()
        {
            ClientesN negocio = new ClientesN();
            cliente = negocio.ListarUM(cliente);
            return Page();
        }

        public IActionResult OnGet(int? id)
        {
            if (id != null)
            {
                ClientesN negocio = new ClientesN();
                if (cliente == null)
                    cliente = new PDV.DataBase.Objetos.Clientes();

                cliente.id_cliente = id;
                cliente = negocio.ListarUM(cliente);

                negocio.Exluir(cliente);
            }

            return Page();
        }

        public List<PDV.DataBase.Objetos.Clientes> MostrarTodosClientes()        
        {
            ClientesN negocio = new ClientesN();
            PDV.DataBase.Objetos.Clientes cliente = new PDV.DataBase.Objetos.Clientes();

            if (cliente.Pessoa == null)
                cliente.Pessoa = new DataBase.Objetos.Pessoas();

            cliente.Pessoa.nm_pessoa = nomeBusca;
            return negocio.ListarTodos(cliente);
        }
    }
}
