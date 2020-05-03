using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasaElevi
{
    internal class Elevi
    {
        private Dictionary<Elev, int> elevi;

        public Elevi(Dictionary<Elev, int> elevi)
        {
            this.elevi = elevi;
        }

        public void SorteazaDupaMedie()
        {
            var items = from pair in elevi
                        orderby pair.Value descending
                        select pair;

            Dictionary<Elev, int> eleviNoi = new Dictionary<Elev, int>();
            foreach (var item in items)
            {
                
                eleviNoi.Add(item.Key, item.Value);
            }
            elevi.Clear();
            foreach(var item in eleviNoi)
            {
                elevi.Add(item.Key, item.Value);
            }
        }

        public void ScrieInFisier()
        {
            string[] lines = PuneEleviInLinii(elevi);

            System.IO.File.WriteAllLines(@"C:\Users\ALIN\source\repos\ClasaElevi\output.txt", lines);
        }

        private string[] PuneEleviInLinii(Dictionary<Elev, int> elevi)
        {
            StringBuilder[] lines = new StringBuilder[elevi.Count];
            for (int i = 0; i < lines.Length; i++)
            {
                lines[i] = new StringBuilder();
            }

            List<Elev> lista = elevi.Select(kvp => kvp.Key).ToList();
            List<int> listaMedii = elevi.Select(kvp => kvp.Value).ToList();

            for (int i = 0; i < lista.Count; i++)
            {
                lines[i].Append(lista[i].NumeIntreg + " " + lista[i].Medie);
            }

            string[] linesString = new string[elevi.Count];

            for (int i = 0; i < linesString.Length; i++)
            {
                linesString[i] = lines[i].ToString();
            }

            return linesString;
        }
    }
}