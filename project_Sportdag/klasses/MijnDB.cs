    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using project_Sportdag;
using System.Data.OleDb;

namespace project_Sportdag
{
    public class MijnDB
    {
        // velden
        static string _connectiePad = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\benjen.edu.local\Benedictuspoort$\Leerlingen en cursisten\Ledeberg\6\6IB\lucas.dejaeger\Documenten\informatica\_database\oef normalisatie\Sportdag1.accdb";
        OleDbConnection _conn = new OleDbConnection();

        // properties

        // functies en methoden
        public List<leerling> VraagLlnOp()
        {
            List<leerling> antwoord = new List<leerling>();

            string sql = "SELECT * FROM Leerling";
            OleDbCommand mijnCommando = new OleDbCommand(sql, _conn);
            OleDbDataReader mijnReader = mijnCommando.ExecuteReader();

            int id = 0, idPakket = 0;
            string naam = "";


            _conn.Open();

            while (mijnReader.Read())
            {
                id = Convert.ToInt32( mijnReader["Id"]) ;
                naam = Convert.ToString( mijnReader["Naam"]) ;
                idPakket = Convert.ToInt32( mijnReader["IdPakket"]) ;

                leerling nieuweLeerling = new leerling(id, naam, idPakket);
                antwoord.Add(nieuweLeerling);

            }

            _conn.Close();


            return antwoord;

            
        }

        public List<Pakket> VraagPakkettenOp()
        {
            List<Pakket> antwoord = new List<Pakket>();


            string sql = "SELECT * from Pakket";
            OleDbCommand mijnCommando = new OleDbCommand(sql, _conn);
            OleDbDataReader mijnReader = mijnCommando.ExecuteReader();

            int id = 0;
            string pakketNaam = "";
            List<leerling> leerlingen = new List<leerling>();

            _conn.Open();

            while(mijnReader.Read())
            {
                

                id = Convert.ToInt32(mijnReader["Id"]);
                pakketNaam = Convert.ToString(mijnReader["Pakketnaam"]);


                Pakket nieuwPakket  = new Pakket(id, pakketNaam, leerlingen);

                leerlingen = ZoekLlnVanPakket(id) ;

                antwoord.Add(nieuwPakket);
            }

            _conn.Close();


            return antwoord;
        }

        public List<leerling> ZoekLlnVanPakket(int ontvId)
        {
            List<leerling> antwoord = new List<leerling>();

            

            string sql = "SELECT * FROM Leerling WHERE IdPakket = " + Convert.ToString(ontvId);
            OleDbCommand mijnCommando = new OleDbCommand(sql, _conn);
            OleDbDataReader mijnReader = mijnCommando.ExecuteReader();

            int id = 0, idPakket = 0;
            string naam = "";


            _conn.Open();

            while (mijnReader.Read())
            {
                id = Convert.ToInt32(mijnReader["Id"]);
                naam = Convert.ToString(mijnReader["Naam"]);
                idPakket = Convert.ToInt32(mijnReader["IdPakket"]);

                leerling nieuweLeerling = new leerling(id, naam, idPakket);
                antwoord.Add(nieuweLeerling);

            }

            _conn.Close();

            return antwoord;
        }

        public void PakketToevoegen(string ontvNaam)
        {
            string sql = "INSERT INTO Pakket (PakketNaam) VALUES ('" + ontvNaam + "')";
            OleDbCommand mijnCommando = new OleDbCommand(sql, _conn);

            _conn.Open();

            mijnCommando.ExecuteNonQuery();

            _conn.Close();
        }

        public void LeerlingToevoegen(string ontvNaam)
        {
            string sql = "INSERT INTO Leerling (Naam) VALUES('" + ontvNaam + "')";
            OleDbCommand mijnCommando = new OleDbCommand(sql, _conn);

            _conn.Open();

            mijnCommando.ExecuteNonQuery();

            _conn.Close();
        }

        public void PakketVeranderen(int ontvId, string ontvNaam)
        {
            string sql = "UPDATE Pakket SET PakketNaam = '" + ontvNaam + "'WHERE Id =" + Convert.ToString(ontvId);
            OleDbCommand mijnCommando = new OleDbCommand(sql, _conn);

            _conn.Open();

            mijnCommando.ExecuteNonQuery();

            _conn.Close();
        }

        public void LeerlingVeranderen(int ontvId, string ontvNaam)
        {
            string sql = "UPDATE Leerling SET Naam = '" + ontvNaam + "'WHERE Id =" + Convert.ToString(ontvId); ;
            OleDbCommand mijnCommando = new OleDbCommand(sql, _conn);

            _conn.Open();

            mijnCommando.ExecuteNonQuery();

            _conn.Close();
        }

        public void PakketVerwijderen(int ontvId)
        {
            string sql = "DELETE FROM Pakket WHERE Id = " + Convert.ToString( ontvId);
            OleDbCommand mijnCommando = new OleDbCommand(sql, _conn);

            _conn.Open();

            mijnCommando.ExecuteNonQuery();

            _conn.Close();
        }

        public void LeerlingVerwijderen(int ontvId)
        {
            string sql = "DELETE FROM Leerling WHERE Id = " + Convert.ToString(ontvId); ;
            OleDbCommand mijnCommando = new OleDbCommand(sql, _conn);

            _conn.Open();

            mijnCommando.ExecuteNonQuery();

            _conn.Close();
        }

        public void KeuzeToevoegen(int ontvIdLln, int ontvIdPakket)
        {
            string sql = "INSERT INTO leerling (IdPakket) VALUES (" + Convert.ToString( ontvIdPakket )+ ")WHERE Id = " + Convert.ToString( ontvIdLln);
            OleDbCommand mijnCommando = new OleDbCommand(sql, _conn);

            _conn.Open();

            mijnCommando.ExecuteNonQuery();

            _conn.Close();
        }

        public void KeuzeVeranderen(int ontvIdLln, int ontvIdPakket)
        {
            string sql = "UPDATE Leerling SET IdPakket = " + Convert.ToString(ontvIdPakket ) + "WHERE Id =" + Convert.ToString(ontvIdLln); ;
            OleDbCommand mijnCommando = new OleDbCommand(sql, _conn);

            _conn.Open();

            mijnCommando.ExecuteNonQuery();

            _conn.Close();
        }

        // constructors

        public MijnDB ()
        {

        }
    }
}