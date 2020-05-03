using System;
using System.Collections.Generic;
using System.Text;

namespace ClasaElevi
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\ALIN\source\repos\ClasaElevi\input.txt");

            Dictionary<Elev, int> elevi = new Dictionary<Elev, int>();

            for (int i = 0; i < lines.Length; i++)
            {
                char[] seps = { ' ' };

                StringBuilder nume = new StringBuilder();
                StringBuilder prenume = new StringBuilder();
                int numarNote = 0;
                int[] note;
                string[] tokens = lines[i].Split(seps, StringSplitOptions.RemoveEmptyEntries);

                nume.Append(tokens[0]);
                prenume.Append(tokens[1]);
                numarNote = int.Parse(tokens[2]);

                note = new int[numarNote];
                for (int j = 0; j < numarNote; j++)
                {
                    note[j] = int.Parse(tokens[j + 3]);
                }
              
                Elev elev = new Elev(nume.ToString(), prenume.ToString(), numarNote, note);

                elevi.Add(elev, elev.Medie);
            }

            Elevi elevii = new Elevi(elevi);

            elevii.SorteazaDupaMedie();
            elevii.ScrieInFisier();

        }
    }
}
