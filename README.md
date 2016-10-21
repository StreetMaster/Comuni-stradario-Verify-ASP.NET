# DemoVerifyASP.NET
Demo ASP.NET per l'utilizzo del ws soap VERIFY di verifica e normalizzazione indirizzi italiani di StreetMaster

Il progetto è sviluppato in C# - Framework 4.6.1

End point del servizio 
     http://ec2-46-137-97-173.eu-west-1.compute.amazonaws.com/smws/verify?wsdl

Per l'utilizzo registrarsi sul sito http://streetmaster.it e richiedere la chiave per il servizio VERIFY.
Il servizio permette di effettuare in maniera gratuita 250 chiamate mensili. 
Per volumi di utilizzo maggiori consultare nel sito i piani di utilizzo.
Se non viene utilizzata una chiave valida il servizio restituisce il codice di errore 997: chiave non riconosciuta

Il servizio verifica e corregge indirizzi italiani con una copertura a livello di singola strada su tutto il territorio nazionale.
La base dati di riferimento è costantemente aggiornata con le variazioni amministrative e postali ufficiali.
La versione FILL rispetto alla versione VERIFY correda l'output con molti dati aggiuntivi.
  
Output:
  - indirizzo verificato e corretto in tutti i suoi compomenti
  - score di riconoscimento comune e strada
  - matrice di flag di modifica tra input e output

Per ogni domanda o chiarimento manda una mail a supporto@streetmaster.it
