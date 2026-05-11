# DiPaolo_Orario
Di Paolo Alessia 3AII
Creazione Classe in C# che rappresenti un orario in formato HH:MM:SS. 
Permette l'accettazione di valori al di fuori del formato solito e inoltre esegue diverse operazioni matematiche.
Nel seguente progetto ho lavorato con:
  Costruttori: Orario() che inizializza la classe a mezzanotte;
               Orario(int ore, int min, int sec) che mormalizza e assegna i valori, gestite come 24h;
               Orario(int secondiTotali) costruisce l'orario partendo dai secondi di inizio giornata.
  Property: ho creato delle classi privati per secondi, minuti e ore e poi prima di renderle pubbliche, ho costrutio Normalizza() funzione              che serve a impostare in maniera più leggebile l'orario nel formato standard.
  Operator: ho costrutio i vari operator per calcolare somma, sottrazione ect. Inoltre, ho formattato anche quelli di confronto.
  Metodi: overide string ToString(): restituisce il formato HH:MM:SS con l'aggiunta di 0 all'inizio di un numero singolo;
              es. 3:56:2 --> 03:56:02
           int ToSecondi(): restituisce il numero totale di secondi;
           Orario Aggiungi(int secondi):aggiunge il numero di secondi;
           Orario Aggiungi(int ore, int minuti, int secondi): aggiunge ore, minuti e secondi tutti insieme;
           static Orario Confronta(Orario a, Orario b): sistema e confronta con metodi booleani i due valori
L'output atteso saranno i due valori iniziali con relativi calcoli di somma, sottrazione e confonti.
Delle difficoltà principali nel sviluppare questo codice sono stati i costruttori. 
