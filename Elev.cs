using System;

namespace ClasaElevi
{
    public class Elev
    {
        private string nume;
        private string prenume;
        private int medie;

        public Elev(string nume, string prenume, int numarNote, int[] note)
        {
            this.nume = nume;
            this.prenume = prenume;

            int suma = 0;
            foreach(int nota in note)
            {
                suma += nota;
            }

            medie = (int)Math.Round((double)suma / numarNote,MidpointRounding.ToEven);
        
        }

        public int Medie
        { 
            get 
            { 
                return medie;
            }  
            private set
            { 
            }
        }

        public string NumeIntreg { get { return nume + " " + prenume; } private set { } }
    }
}