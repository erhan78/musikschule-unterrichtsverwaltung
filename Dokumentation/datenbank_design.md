# Datenbank-Design Musikschule – Unterrichtsverwaltung

## 1. Überblick

Die Datenbank soll Musiklehrern helfen, ihre Schüler, Unterrichtsstunden
und den Zahlungsstatus der Stunden zu verwalten. Dazu wurden drei
Tabellen modelliert: `Lehrer`, `Schueler` und `Unterrichtsstunde`.

## 2. Tabellen und Spalten

### Tabelle `Lehrer`

- `LehrerID` (INT, PK, IDENTITY)
- `Vorname`, `Nachname`: Namen des Lehrers
- `Email`, `Telefon`: Kontaktdaten
- `Fachgebiet`: beschreibt, welche Instrumente der Lehrer hauptsächlich unterrichtet

Begründung: Mehrere Lehrer können im System verwaltet werden. Die IDENTITY-Spalte
vereinfacht das Anlegen neuer Lehrer.

### Tabelle `Schueler`

- `SchuelerID` (INT, PK, IDENTITY)
- `Vorname`, `Nachname`: Namen des Schülers
- `Email`, `Telefon`: Kontaktdaten
- `Instrument`: Instrument, das der Schüler hauptsächlich lernt

Begründung: Jeder Schüler erhält eine eindeutige ID. Das Instrument ist als
einfaches Textfeld ausreichend, weil keine komplexe Instrumentenverwaltung
benötigt wird.

### Tabelle `Unterrichtsstunde`

- `UnterrichtsID` (INT, PK, IDENTITY)
- `SchuelerID`: Fremdschlüssel auf `Schueler`
- `LehrerID`: Fremdschlüssel auf `Lehrer`
- `DatumUhrzeit`: Zeitpunkt der Stunde
- `DauerMinuten`: Dauer der Stunde in Minuten
- `PreisProStunde`: Preis pro Stunde in Euro
- `Zahlungsstatus`: z.B. „offen“, „bezahlt“, „storniert“
- `Status`: z.B. „geplant“, „durchgeführt“, „abgesagt“

Begründung: Die Unterrichtsstunde verknüpft Schüler und Lehrer und enthält
zusätzlich Informationen zu Termin, Dauer und Bezahlung.

## 3. Beziehungen (1:n)

- Ein **Lehrer** kann viele **Unterrichtsstunden** geben, jede
  Unterrichtsstunde gehört genau zu einem Lehrer.
  → Beziehung `Lehrer (1) – (n) Unterrichtsstunde`

- Ein **Schueler** kann viele **Unterrichtsstunden** haben, jede
  Unterrichtsstunde gehört genau zu einem Schueler.
  → Beziehung `Schueler (1) – (n) Unterrichtsstunde`

Die 1:n-Beziehungen sind sinnvoll, weil eine Unterrichtsstunde immer genau
einen Lehrer und einen Schüler hat, aber Lehrer und Schüler im Laufe der
Zeit viele Stunden haben können.

## 4. Datentypen

- **INT + IDENTITY** für Primärschlüssel, um automatisch eindeutige IDs zu
  vergeben.
- **NVARCHAR** für Namen, Kontaktdaten und Status, da Text mit Umlauten
  unterstützt werden muss.
- **DATETIME2** für `DatumUhrzeit`, um Datum und Uhrzeit genau zu speichern.
- **DECIMAL(6,2)** für Geldbeträge (`PreisProStunde`), um Cent-genaue
  Beträge abbilden zu können.

## 5. Einsatz von KI

Für die Vorbereitung des Datenbank-Designs wurde ein KI-Tool (ChatGPT)
verwendet. Die KI half dabei,
- sinnvolle Tabellenstrukturen zu entwerfen,
- ein vollständiges SQL-Skript mit Beispieldaten zu erstellen.

Die endgültige Auswahl der Tabellen, Spalten und Datentypen sowie
Anpassungen an das Projektthema wurden eigenständig vorgenommen.
