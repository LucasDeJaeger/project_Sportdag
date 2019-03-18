using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using project_Sportdag;

namespace project_Sportdag
{
    public class leerling
    {
        // velden
        int _Id = 0;
        string _naam = "";
        int _IdPakket = 0;


        // properties
        public int PropId
        {
            get { return _Id; }
        }

        public string PropNaam
        {
            get { return _naam; }
            set { _naam = value; }
        }

        public int PropIdPakket
        {
            get { return _IdPakket; }
            set { _IdPakket = value; }
        }

        // functies en methoden

        // constructors

        public leerling (int ontvId, string ontvNaam, int ontvIdPakket)
        {
            _Id = ontvId;
            _naam = ontvNaam;
            _IdPakket = ontvIdPakket;
        }



    }
}
