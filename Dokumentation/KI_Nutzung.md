# KI-Nutzung im Projekt „Musikschule – Unterrichtsverwaltung“

## 1. Eingesetzte KI-Tools

In diesem Projekt habe ich folgende KI-Tools verwendet:

- **ChatGPT (OpenAI)** – für Texte, Anforderungen, Datenbankdesign,
  Beispielcode und allgemeine Ideen.
- **Bildgenerierung innerhalb von ChatGPT (DALL·E)** – zur Erstellung
  eines Beispiel-Wireframes für den Papierprototyp.

Andere KI-Tools wie Gemini oder GitHub Copilot wurden in diesem Projekt
nicht verwendet.

---

## 2. Einsatzbereiche der KI

Ich habe KI an mehreren Stellen des Projekts eingesetzt:

1. **Funktionale Anforderungen (Schritt 2)**
   - Sammlung und Formulierung möglicher Anforderungen an das System
     „Musikschule – Unterrichtsverwaltung“.
   - Hilfe bei der Auswahl und Priorisierung der fünf wichtigsten
     Anforderungen.

2. **Datenbank-Design (Schritt 3)**
   - Unterstützung beim Entwurf eines passenden Datenbankmodells
     (Tabellen, Beziehungen, Datentypen).

3. **Console-Prototyp (Schritt 5)**
   - Unterstützung beim Entwurf der Menüführung für die Konsole.
   - Hinweise zur Fehlerbehandlung und Strukturierung in mehrere
     Methoden.

4. **Papierprototyp (Schritt 4)**
   - Erstellung eines Beispiel-Wireframes als Bild, an dem ich mich beim
     Zeichnen orientiert habe.

---

## 3. Verwendete Prompts (mindestens 3 Beispiele)

### Prompt-Beispiel 1 – Funktionale Anforderungen

**Prompt:**

> „Ich habe ein Schulprojekt. Thema: 'Musikschule – Unterrichtsverwaltung'.  
> Bitte erstelle mindestens 10 sinnvolle funktionale Anforderungen für
> eine Software, mit der Musiklehrer ihre Schüler verwalten,
> Unterrichtstermine planen und Zahlungen verfolgen können. Formuliere
> jede Anforderung in einem vollständigen Satz.“

**Ergebnis / Nutzung:**

- Die KI hat 10 Anforderungen vorgeschlagen.
- Ich habe fünf davon ausgewählt, teilweise umformuliert und in der
  Datei `anforderungen_final.txt` übernommen.

---

### Prompt-Beispiel 2 – Datenbank-Design und SQL

**Prompt:**

> „Erstelle ein Datenbank-Design für das Thema 'Musikschule –
> Unterrichtsverwaltung'. Es soll Tabellen für Schüler, Lehrer und
> Unterrichtsstunden geben. Nutze MS SQL Server, definiere
> Primärschlüssel, Fremdschlüssel, passende Datentypen und füge pro
> Tabelle mindestens 5 Beispieldatensätze ein. Am Ende soll ein
> SELECT-Befehl mit JOIN eine Übersicht aller Unterrichtsstunden
> anzeigen.“

**Ergebnis / Nutzung:**

- Die KI hat ein Datenmodell mit den Tabellen `Schueler`, `Lehrer` und
  `Unterrichtsstunde` vorgeschlagen.
- Ich habe das Skript überprüft, kleinere Anpassungen vorgenommen
  (z.B. Namen, Datumswerte) und in `db_Musikschule.sql` gespeichert.

---

### Prompt-Beispiel 3 – Console-Prototyp in C#

**Prompt:**

> „Überprüfe {Zeile}“

**Ergebnis / Nutzung:**

- Die Ki hat mich auf Fehler hingewiesen und verbesserungsvorschläge gegeben.

---

### Prompt-Beispiel 4 – Papierprototyp / UI-Ideen

**Prompt:**

> „Ich brauche einen Papierprototyp für eine Anwendung
> 'Musikschule – Unterrichtsverwaltung'. Bitte beschreibe mir vier
> typische Screens (Startmenü, Schülerliste, Unterrichtsstunden planen,
> Zahlungsübersicht), damit ich sie auf Papier zeichnen kann. Beschreibe
> nur, welche Elemente (Buttons, Tabellen, Eingabefelder) wo ungefähr
> stehen sollen.“

**Ergebnis / Nutzung:**

- Die KI hat die Inhalte und Anordnung der vier Screens beschrieben.
- Ich habe mich beim Zeichnen der Papierprototyp-Screens an diesen
  Beschreibungen orientiert.

---

## 4. Beispiel mit mehreren Prompts (Verbesserung eines Prompts)

Für die funktionalen Anforderungen habe ich nicht direkt mit einem
perfekten Prompt angefangen, sondern den Prompt in zwei Schritten
verbessert.

### Erster Prompt (unspezifisch)

> „Nenne mir ein paar Anforderungen für eine Software für eine
> Musikschule.“

**Problem:**

- Die Antwort war sehr allgemein und teilweise unscharf formuliert.
- Einige Anforderungen waren eher technische Hinweise als klare
  funktionale Anforderungen.

### Verbesserter Prompt

> „Ich habe ein Schulprojekt. Thema: 'Musikschule – Unterrichtsverwaltung'.  
> Bitte erstelle mindestens 10 sinnvolle **funktionale Anforderungen**
> für eine Software, mit der Musiklehrer ihre Schüler verwalten,
> Unterrichtstermine planen und Zahlungen verfolgen können. Formuliere
> jede Anforderung in einem vollständigen Satz und achte darauf, dass
> sie aus Sicht des Systems beschrieben ist.“

**Verbesserung:**

- Die Anforderungen waren danach deutlich konkreter und
  konsistenter formuliert.
- Es war klarer, dass jede Anforderung eine Funktion des Systems
  beschreiben soll.
- Die so erzeugte Liste konnte ich fast direkt als Grundlage für
  `ki_anforderungen_roh.txt` verwenden.

Dieses Beispiel zeigt, dass es sich lohnt, den Prompt gezielt zu
verbessern, wenn das erste Ergebnis noch nicht gut genug ist.

---

## 5. Umgang mit KI-generierten Inhalten

Ich bin mit den KI-Ergebnissen nicht einfach unkritisch umgegangen,
sondern habe unterschieden zwischen **übernommen**, **modifiziert** und
**verworfen**.

### Übernommene Inhalte

- Grundstruktur der funktionalen Anforderungen.
- Das Datenbankmodell mit den drei Tabellen `Schueler`, `Lehrer` und
  `Unterrichtsstunde` inklusive Primär- und Fremdschlüsseln.
- Vorschlag für die vier wichtigsten Screens des Papierprototyps.

### Modifizierte Inhalte

- Formulierungen der Anforderungen (sprachlich überarbeitet,
  an Schulniveau und meine eigene Schreibweise angepasst).
- Datentypen und Spaltennamen im SQL-Skript (z.B. deutsche Bezeichnungen
  wie `SchuelerID`, `DatumUhrzeit`).
- Teile des C#-Codes (z.B. Texte der Konsolenausgaben,
  Menübezeichnungen, Kommentare).

### Verworfen / nicht übernommen

- Einzelne KI-Vorschläge, die nicht zu meinem Thema oder zum
  Zeitumfang des Projekts passten.
- Zu komplexe Erweiterungen (z.B. automatische Erinnerungen per E-Mail)
  wurden bewusst weggelassen, um den Rahmen des Projekts nicht zu
  sprengen.
- Teile der generierten Antworten, die sich wiederholt haben oder
  nur allgemeine Tipps waren, habe ich nicht in die Abgabe übernommen.

---

## 6. Reflexion: Was habe ich durch den KI-Einsatz gelernt?

Durch den Einsatz von KI in diesem Projekt habe ich mehrere Dinge
gelernt:

1. **KI ist ein gutes Brainstorming-Tool**, ersetzt aber keine eigene
   Planung. Die ersten Vorschläge helfen beim Start, müssen aber auf das
   konkrete Projekt zugeschnitten werden.

2. **Gute Prompts sind entscheidend.**  
   Wenn ein Prompt zu allgemein ist, sind auch die Ergebnisse ungenau.
   Durch das Nachschärfen der Prompts (z.B. genaue Vorgaben,
   Sprache, Anzahl der Anforderungen) wird die Qualität der Antworten
   deutlich besser.

3. **Ergebnisse müssen immer kritisch geprüft werden.**  
   Obwohl die KI syntaktisch korrekten Code und sinnvolle Texte liefert,
   muss ich als Entwickler prüfen, ob:
   - der Code wirklich kompiliert,
   - die Datentypen passen,
   - die Inhalte zum Aufgabenblatt und zur Benotungsvorgabe passen.

4. **KI spart Zeit bei Routineaufgaben**, z.B. beim Schreiben von
   Beispiel-SQL, beim Erstellen von Standard-Texten oder beim Entwurf
   eines Console-Menüs. Die gewonnene Zeit kann ich in Verständnis,
   Testen und eigene Ideen investieren.

5. **Verantwortung bleibt beim Menschen.**  
   Am Ende bin ich verantwortlich für das, was ich abgebe. Die KI ist
   ein Werkzeug; die Entscheidung, was ich übernehme, ändere oder
   verwerfe, treffe ich selbst.

Insgesamt hat mir der KI-Einsatz geholfen, strukturierter und schneller
zu arbeiten. Gleichzeitig habe ich gelernt, dass ich die Ergebnisse
immer reflektiert überprüfen muss, um ein sauberes und verständliches
Projekt abzugeben.
