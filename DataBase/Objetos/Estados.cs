using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PDV.DataBase.Objetos
{
    public class Estados
    {
        public string cd_estado { get; set; }
        public string nm_estado { get; set; }

        public Estados[] ListarTodosEstados()
        {
            Estados[] estados = new Estados[] {
                new Estados { cd_estado = "ac", nm_estado = "Acre" },
                new Estados { cd_estado = "al", nm_estado = "Alagoas" },
                new Estados { cd_estado = "am", nm_estado = "Amazonas" },
                new Estados { cd_estado = "ap", nm_estado = "Amapá" },
                new Estados { cd_estado = "ba", nm_estado = "Bahia" },
                new Estados { cd_estado = "ce", nm_estado = "Ceará" },
                new Estados { cd_estado = "df", nm_estado = "Distrito Federal" },
                new Estados { cd_estado = "es", nm_estado = "Espírito Santo" },
                new Estados { cd_estado = "go", nm_estado = "Goiás" },
                new Estados { cd_estado = "ma", nm_estado = "Maranhão" },
                new Estados { cd_estado = "mg", nm_estado = "Minas Geais" },
                new Estados { cd_estado = "mt", nm_estado = "Mato Grosso" },
                new Estados { cd_estado = "ms", nm_estado = "Mato Grosso do Sul" },
                new Estados { cd_estado = "pa", nm_estado = "Pará" },
                new Estados { cd_estado = "pb", nm_estado = "Paraíba" },
                new Estados { cd_estado = "pe", nm_estado = "Pernambuco" },
                new Estados { cd_estado = "pi", nm_estado = "Piauí" },
                new Estados { cd_estado = "pr", nm_estado = "Paraná" },
                new Estados { cd_estado = "rj", nm_estado = "Rio de Janeiro" },
                new Estados { cd_estado = "rn", nm_estado = "Rio Grande do Norte" },
                new Estados { cd_estado = "ro", nm_estado = "Rondônia" },
                new Estados { cd_estado = "rr", nm_estado = "Roraima" },
                new Estados { cd_estado = "rs", nm_estado = "Rio Grande do Sul" },
                new Estados { cd_estado = "sc", nm_estado = "Santa Catarina" },
                new Estados { cd_estado = "se", nm_estado = "Sergipe" },
                new Estados { cd_estado = "sp", nm_estado = "São Paulo" },
                new Estados { cd_estado = "to", nm_estado = "Tocantins" }
            };
            return estados;
        }
    }
}
