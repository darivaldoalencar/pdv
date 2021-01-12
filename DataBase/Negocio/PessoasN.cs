using PDV.DataBase.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PDV.DataBase.Negocio
{
    public class PessoasN
    {
        public PessoaContexto ctx;

        public List<Pessoas> ListarTodos(Pessoas pessoa)
        {
            this.ctx = new PessoaContexto();
            if (pessoa.id_pessoa > 0)
            {
                return ctx.Pessoa.Where(p => p.id_pessoa.Equals(pessoa.id_pessoa)).ToList();
            }
            else if (!string.IsNullOrEmpty(pessoa.nm_pessoa))
            {
                return ctx.Pessoa.Where(p => p.nm_pessoa.ToUpper().StartsWith(pessoa.nm_pessoa.ToUpper())).ToList();
            }

            return ctx.Pessoa.ToList();
        }

        public Pessoas ListarUM(Pessoas pessoa)
        {
            return ListarTodos(pessoa).FirstOrDefault();
        }

        public bool Exluir(Pessoas pessoa)
        {
            try
            {
                using (PessoaContexto ctx = new PessoaContexto())
                {
                    var result = ctx.Remove(pessoa);
                    ctx.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Alterar(ref Pessoas pessoa)
        {
            try
            {
                using (PessoaContexto ctx = new PessoaContexto())
                {
                    var result = ctx.Update(pessoa);
                    ctx.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Incluir(ref Pessoas pessoa)
        {
            try
            {
                pessoa.id_pessoa = null;
                using (PessoaContexto ctx = new PessoaContexto())
                {
                    ctx.Add(pessoa);
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
