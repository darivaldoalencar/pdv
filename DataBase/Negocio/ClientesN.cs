using PDV.Comum;
using PDV.DataBase.Objetos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PDV.DataBase.Negocio
{
    public class ClientesN
    {
        public MySQLContextos ctx;

        public List<Clientes> ListarTodos(Clientes cliente)
        {
            this.ctx = new MySQLContextos();
            var query = from c in this.ctx.Clientes
                        join p in this.ctx.Pessoa on c.id_cliente equals p.id_pessoa
                        select new { c, p };

            if (cliente.id_cliente > 0)
            {
                query = from c in this.ctx.Clientes
                        join p in this.ctx.Pessoa on c.id_cliente equals p.id_pessoa
                        where c.id_cliente.Equals(cliente.id_cliente)
                        select new { c, p };
            }
            else if (cliente.Pessoa != null)
            {
                if (!string.IsNullOrEmpty(cliente.Pessoa.nm_pessoa))
                    query = from c in this.ctx.Clientes
                            join p in this.ctx.Pessoa on c.id_cliente equals p.id_pessoa
                            where p.nm_pessoa.ToUpper().StartsWith(cliente.Pessoa.nm_pessoa)
                            select new { c, p };
            }

            List<Clientes> lista = new List<Clientes>();
            foreach (var item in query)
            {
                lista.Add(new Clientes()
                {
                    id_cliente = item.c.id_cliente,
                    id_pessoa = item.c.id_pessoa,
                    dt_nascimento = item.c.dt_nascimento,
                    rg_rne = item.c.rg_rne,
                    cpf_cnpj = item.c.cpf_cnpj,
                    Pessoa = new Pessoas()
                    {
                        id_pessoa = item.p.id_pessoa,
                        nm_pessoa = item.p.nm_pessoa,
                        dt_cadastro = item.p.dt_cadastro,
                        dt_alterado = item.p.dt_alterado,
                        tp_pessoa = item.p.tp_pessoa,
                        nr_cep = item.p.nr_cep,
                        ds_complemento = item.p.ds_complemento,
                        obsr = item.p.obsr
                    }
                });
            }

            return lista;
        }

        public Clientes ListarUM(Clientes cliente)
        {
            return ListarTodos(cliente).FirstOrDefault();
        }

        public bool Exluir(Clientes cliente)
        {
            try
            {
                using (ClientesContext ctx = new ClientesContext())
                {
                    var result = ctx.Remove(cliente);
                    ctx.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Alterar(ref Clientes cliente)
        {
            try
            {
                using (ClientesContext ctx = new ClientesContext())
                {
                    var result = ctx.Update(cliente);
                    ctx.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Incluir(ref Clientes cliente)
        {
            try
            {
                cliente.id_cliente = null;
                using (ClientesContext ctx = new ClientesContext())
                {
                    ctx.Add(cliente);
                    ctx.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
