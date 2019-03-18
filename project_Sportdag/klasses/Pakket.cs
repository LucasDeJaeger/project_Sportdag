using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using project_Sportdag;

namespace project_Sportdag
{
    public class Pakket
    {
       

        // velden
        int _Id = 0;
        string _naam = "";
        List<leerling> _leerling = new List<leerling>();

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

        public List<leerling> PropLeerlig
        {
            get { return _leerling; }
            set { _leerling = value; }
        }

        // functies en methoden

        // constructors

        public Pakket(int ontvId, string ontvNaam, List<leerling> ontvLeerling)
        {
            _Id = ontvId;
            _naam = ontvNaam;
            _leerling = ontvLeerling;
        }
    }
}

