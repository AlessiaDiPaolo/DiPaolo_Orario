namespace Orario_DiPaolo;

class Program
{
    public class COrario
    {
        //dichiaro campi privati
        private int _ore;
        private int _minuti;
        private int _secondi;
        
        //rendo pubblica classe Ore
        public int Ore
        {
            get { return _ore; }
            set { _ore = value; Normalizza(); }
        }
        
        //rendo pubblica classe Minuti
        public int Minuti
        {
            get { return _minuti; }
            set { _minuti = value; Normalizza(); }
        }
        
        //rendo pubblica classe Secondi
        public int Secondi
        {
            get { return _secondi; }
            set { _secondi = value; Normalizza(); }
        }

        //classe per rendere leggibile secondi, minuti e ore
        private void Normalizza()
        {
            if (_secondi > 59)
            {
                _minuti += _secondi / 60;
                _secondi = _secondi % 60;
            }

            if (_minuti > 59)
            {
                _ore += _minuti / 60;
                _minuti = _minuti % 60;
            }
            else
            {
                _minuti = ((_minuti % 60) + 60) % 60;
            }

            if (_ore > 23)  _ore = _ore % 24;
        }

        //primo costruttore inzializzato a mezzanotte
        public COrario()
        {
            this.Ore = 0;
            this.Minuti = 0;
            this.Secondi = 0;
        }
        
        //secondo costruttore per normalizzare le ore
        public COrario(int Ore, int Minuti, int Secondi)
        {
            this.Secondi = Secondi;
            this.Minuti = Minuti;
            this.Ore = Ore;
            Normalizza();
        }

        //costruttore secondi totali
        public COrario(int SecondiTotali)
        {
            _secondi = SecondiTotali;
            _minuti = 0;
            _ore = 0;
            Normalizza();
        }

        //costruttore che formatta orario HH:MM:SS
        public override string ToString()
        {
            return $"{_ore:D2}:{_minuti:D2}:{_secondi:D2}";
        }
        
        //costruttore che normalizza e assegna i valori
        public int ToSecondi()
        {
            return (_ore * 3600) + (_minuti * 60) + _secondi;
        }

        //costruttore che gestisce i secondi
        public COrario Aggiungi(int Secondi)
        {
            int nuovoTotale = this.ToSecondi() + Secondi; 
            return new COrario(nuovoTotale);
        }

        //costruttore che sistema tutto l'orario
        public COrario Aggiungi(int ore, int minuti, int secondi)
        {
            int secondiDaAggiungere = (ore * 3600) + (minuti * 60) + secondi;
            return Aggiungi(secondiDaAggiungere);
        }
        
        //inizializzo l'operatore somma
        public static COrario operator +(COrario o1, COrario o2)
        {
            return new COrario(o1.ToSecondi() + o2.ToSecondi());
        }
        
        //inizializzo l'operatore sottrazione
        public static COrario operator -(COrario o1, COrario o2)
        {
            return new COrario(o1.ToSecondi() - o2.ToSecondi());
        }
        
        //inizializzo l'operatore moltiplicazione
        public static COrario operator *(COrario o1, COrario o2)
        {
            return new COrario(o1.ToSecondi() * o2.ToSecondi());
        }

        //inizializzo l'operatore divisione
        public static COrario operator /(COrario o1, COrario o2)
        {
            return new COrario(o1.Ore / o2.Ore);
        }
        
        //inizializzo l'operatore che crea confronti fra i due orari per capire chi prendere prima 
        private static int Compara(COrario a, COrario b)
        {
            int secA = a.ToSecondi();
            int secB = b.ToSecondi();

            if (secA > secB) return 1;
            if (secA < secB) return -1;
            return 0;
        }

        //operatore Confronta 
        public static COrario Confronta(COrario o1, COrario o2)
        {
                return (o1 > o2) ?  o1:  o2;
        }
        
        // Operatore di uguaglianza
        public static bool operator ==(COrario a, COrario b) 
            => Compara(a, b) == 0;

        // Operatore di diversità 
        public static bool operator !=(COrario a, COrario b) 
            => Compara(a, b) != 0;

        // Operatore maggiore
        public static bool operator >(COrario a, COrario b) 
            => Compara(a, b) > 0;

        // Operatore minore
        public static bool operator <(COrario a, COrario b) 
            => Compara(a, b) < 0;

        // Operatore maggiore o uguale
        public static bool operator >=(COrario a, COrario b) 
            => Compara(a, b) >= 0;

        // Operatore minore o uguale
        public static bool operator <=(COrario a, COrario b) 
            => Compara(a, b) <= 0;
        
    }
    //main
    static void Main(string[] args)
    {
        //inizializzazione orari
        COrario a = new COrario(8, 30, 0);
        COrario b = new COrario(1, 45, 30);

        Console.WriteLine($"Orario a: {a}");
        Console.WriteLine($"Orario b: {b}");
        Console.WriteLine();

        // operazioni aritmetiche
        Console.WriteLine($"a + b               = {a + b}");
        Console.WriteLine($"a - b               = {a - b}");
        
        COrario moltiplicato = new COrario(a.ToSecondi() * 3); 
        Console.WriteLine($"a * 3               = {moltiplicato}");
        Console.WriteLine();

        //confronti
        Console.WriteLine($"a == b              = {a == b}");
        Console.WriteLine($"a > b               = {a > b}");
        Console.WriteLine();

        //metodo
        Console.WriteLine($"a.Aggiungi(90)        = {a.Aggiungi(90)}    // secondi");
        Console.WriteLine($"a.Aggiungi(1, 5, 0)   = {a.Aggiungi(1, 5, 0)}    // ore+min+sec");
        Console.WriteLine();

        //metodo statico
        Console.WriteLine($"COrario.Confronta(a, b) = {COrario.Confronta(a, b)}");
        Console.WriteLine();

        //normalizzazione
        a.Minuti = 90; 
        Console.WriteLine($"a.Minuti = 90  -->  {a}    // setter normalizza");

        COrario testCostruttore = new COrario(1, 75, 90);
        Console.WriteLine($"new Orario(1, 75, 90) --> {testCostruttore}");

        Console.ReadLine(); 
    }
}