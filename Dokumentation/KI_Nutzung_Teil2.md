\# KI-Nutzung Teil II (Projektaufgaben 7–12)



\## 1. Eingesetztes KI-Tool

\- \*\*ChatGPT (OpenAI)\*\* wurde als Unterstützung bei Planung, Formulierungen und einzelnen Code-Teilen genutzt.



\## 2. Wofür ich KI verwendet habe



\### 2.1 Frontend (WPF / GUI)

Ich habe KI genutzt, um Ideen für die Oberfläche (Fensteraufbau, sinnvolle Steuerelemente und Layout) zu bekommen, z.B. für:

\- Hauptmenü (Navigation zu den Fenstern)

\- Unterrichtsfenster (Eingabefelder, ComboBoxen, DataGrid)

\- Zahlungsübersicht (Anzeige + Summen)



Die generierten Vorschläge habe ich an mein Projekt angepasst (Namen, Struktur, Validierung, Layout).



\### 2.2 Unit Tests

Ich habe KI genutzt, um Vorschläge für sinnvolle Unit-Tests zu erhalten, insbesondere für:

\- Berechnung des Betrags aus \*\*Dauer (Minuten)\*\* und \*\*Preis pro Stunde\*\*

\- Summenberechnung „Summe aller Stunden“ und „Summe offen“

\- Struktur von MSTest-Tests (TestClass/TestMethod)



Die Tests wurden anschließend von mir in Visual Studio eingebaut, getestet und bei Bedarf korrigiert.



\### 2.3 Texte und Dokumentation

Ich habe KI verwendet, um Textteile schneller zu erstellen bzw. zu verbessern, z.B.:

\- README-Abschnitte (Kurzbeschreibung, Nutzung, Screenshots/Screencast-Verlinkung)

\- Testfälle (`tests.md`) und Testprotokoll (`test\_protokoll.md`)

\- Erklärung für GitHub Actions (`github\_action.md`)



Alle Texte wurden von mir überprüft und an meine tatsächliche Implementierung angepasst.



---



\## 3. Beispiel-Prompts (mindestens 3)



\### Prompt 1 – GUI-Entwurf (WPF)

> „Erstelle mir Vorschläge für eine WPF-Oberfläche für eine Musikschule: Hauptmenü, Schülerverwaltung, Unterricht planen und Zahlungsübersicht. Welche Elemente (Buttons, DataGrid, Eingabefelder) sollen enthalten sein?“



\*\*Nutzung:\*\*  

Als Grundlage für die Anordnung der Elemente und Fenster-Struktur.



---



\### Prompt 2 – Unit-Tests (MSTest)

> „Schreibe mir 5 Unit-Tests (MSTest) für eine Klasse, die Beträge und Summen berechnet: Betrag = Dauer/60 \* PreisProStunde, SummeAlle, SummeOffen.“



\*\*Nutzung:\*\*  

Als Startpunkt für die Testmethoden, danach Anpassungen an meine Klassen/Namespaces.



---



\### Prompt 3 – Manuelle Testfälle dokumentieren

> „Formuliere zwei manuelle Testfälle für eine WPF-Anwendung (Schüler anlegen mit Pflichtfeldern, Unterrichtsstunde anlegen und Zahlungsübersicht prüfen) inklusive Vorbedingungen, Schritte und erwartetes Ergebnis.“



\*\*Nutzung:\*\*  

Als Basis für `Planungsdokumente/tests.md`.



---



\### Prompt 4 – README / Kurzanleitung

> „Schreibe einen kurzen README-Abschnitt: wie man das Programm nutzt, mit Einbindung von zwei Screenshots und einem Screencast-Link.“



\*\*Nutzung:\*\*  

Für den README-Abschnitt „Kurze Dokumentation“.



---



\## 4. Was ich übernommen, angepasst oder verworfen habe



\### Übernommen

\- Grundideen für GUI-Struktur (welche Fenster/Funktionen sinnvoll sind)

\- Grundstruktur der Unit-Tests (TestClass/TestMethod)

\- Textvorschläge für Dokumentationsabschnitte



\### Angepasst

\- XAML-Layout (Anordnung, Labels, Größen)

\- Validierungen (Pflichtfelder, Dauer-/Preis-Bereich, Auswahlprüfungen)

\- Testdaten und erwartete Ergebnisse (passend zu meiner Berechnungslogik)

\- Texte (auf mein Projekt, Dateien und tatsächliche Funktionen angepasst)



\### Verworfen

\- Zu komplexe Vorschläge (z.B. zusätzliche Rollenverwaltung, Benutzersystem, automatische E-Mail-Erinnerungen), da dies den Rahmen der Aufgabenstellung sprengen würde.



---



\## 5. Reflexion

Die KI hat mir vor allem geholfen,

\- schneller gute Entwürfe für GUI-Elemente und Layout zu finden,

\- Unit-Test-Ideen zu sammeln und korrekt zu strukturieren,

\- Dokumentationstexte schneller zu formulieren.



Trotzdem habe ich alle Ergebnisse kritisch geprüft und an meine Anwendung angepasst, da ich selbst verantwortlich bin, dass Code kompiliert, Tests korrekt sind und die Dokumentation zur tatsächlichen Implementierung passt.

