using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkOracle
{
    public partial class EMPLOYE
    {
        public override string ToString()
        {
            string s = this.NUMEMP + " - " + this.NOMEMP + " - " + this.PRENOMEMP + " - " + this.POSTE;
            if (this.PRIME != null)
            {
                s += this.PRIME + " - " + this.CODEPROJET;
                if (this.SUPERIEUR != null)
                    s += " - " + this.SUPERIEUR;
                s += '\n';
            }
            return s;
        }
    }
}
