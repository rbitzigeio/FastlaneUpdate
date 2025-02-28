Lesen von verschiedenen Dateien. die in der Gesamtheit die Zugriffsberechtigung in Fastlane für Subscriptions definieren.
Dabei wird versucht die Parameter
- Subscription ID
- Subscription Name
- ADM (einer)
- ADM-Vertreter (mehrere)
- Resourcegruppen
- LS
  
zu interpretieren und in einer großen Liste, mit dem Identifier "Subscription ID", zu erzeugen.

Die Daten für ADM und Kontakte (ADM-Vertreter) kommen aus IT-AM und müssen zu Beginn des Exports aktualisiert werden.
D.h. Excel Sheet öffnen, in Tabelle klicken, rechte Maustaste "Aktualisieren".
Für das Excel Sheet ADM ist in der letzten Spalte noch ein SVERWEIS einzufügen.
Dabei erfolgt ein Mapping des Name des Applikationsverantwortlichen (Spalte U) auf die E-Mail Adresse innerhalb des Excel Sheets Mail.xlsx. Das Format des Applikationsverantwortlichen kommt aus dem AD Verzeichnis der DPDHL und ist im Format 
"Name, Vorname, Abteilung, Standort" abgelegt. 
Auf Grund der großen Anzahl der Daten innerhalb der iShareliste "ADM" und der Nutzung von CR-LF in
einzelnen Zellen, ist nach der Aktualisierung eine Reduktion der Daten auf die 4 Spalten
- ALMID
- Kurzname
- Applikationsverantwortlicher
- letzte Spalte mit E-Mail Adresse 
durchzuführen und in eine Datei im CSV-Format zu exportieren.
D.h. nach der Aktualisierung der Daten aus iShare ist diese Exceldatei zu speichern. Anschließend wird die Datei mit "Speichern unter" in ein CSV-Format überführt. In dieser CSV-Datei erfolgt die Löschung der überflüssigen Spalten, so dass nbur noch die 4 Spalten in der CSV-Datei übrig bleiben. 
Nach der Aktualisierung der Konakte aus dem iShare Folder, ist eine Ersetzung des Zeichens ";" innerhalb der Zellen notwendig. Bei einem Export der Exceldaten in eine CSV-Datei wird das Zeichen ";" als Trennzeichen interpretiert. Somit darf dieses Zeichen nicht innerhalb von Zellen erscheinen.

Die Daten für Subscptions und ResourceGroups kommen aus dem Azure Portal / Resource Graph Explorer und werden dort mit Hilfe zweier Queries erzeugt. 
Die Verbindung der Datentöpfe Azure und IT-AM erfolgt über die ALM-ID (ICTO, ITR oder SPL). Dabei ist zu beachten, dass 
für die Subscription der Infrastruktur (Plattform) das Namenskürzel "-infra-" im Subscriptionnamen genutzt wird. In IT-AM 
wird die Azure Infrastruktur unter der ID "SPL-3041" geführt. Bei der Query zur Verarbeitung der Subscriptions wird dieses 
Mapping berücktichtigt.
Die Ergebnisse der beiden Queries können als CSV Datei in das Download Verzeichnis exportiert werden. Anschließend sind diese Datei unter den Namen
- AzureResourceGraphResults-RBO_GET_SUBSCRIPTIONS.csv
- AzureResourceGraphResults-RBO_GET_RESOURCEGROUPS.csv
in dem Leseverzeichnis der Anwendung "FastlaneUpdate" abzuspeichern.

Die Ausführung der Applikation 