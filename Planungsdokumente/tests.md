\# Manuelle Testfälle – Musikschule Unterrichtsverwaltung



\## T01 – Schüler anlegen (Pflichtfelder + Speichern)



| \*\*ID:\*\* | \*\*T01\*\* |

|---|---|

| \*\*Beschreibung:\*\* | Neuen Schüler anlegen und prüfen, dass Pflichtfelder validiert werden und der Schüler gespeichert wird. |

| \*\*Vorbedingungen:\*\* | Programm läuft. Fenster „Schüler verwalten“ ist geöffnet. |

| \*\*Test-Schritte:\*\* | 1. Klicke auf \*\*Neu\*\*.<br>2. Lasse \*\*Vorname\*\* leer, fülle \*\*Nachname\*\* und \*\*Instrument\*\* aus.<br>3. Klicke \*\*Speichern\*\*.<br>4. Erwartete Fehlermeldung prüfen.<br>5. Fülle nun \*\*Vorname\*\*, \*\*Nachname\*\*, \*\*Instrument\*\* korrekt aus.<br>6. Klicke \*\*Speichern\*\*.<br>7. Prüfe, dass der Schüler in der Tabelle erscheint (mit neuer ID). |

| \*\*Erwartetes Resultat:\*\* | Bei leeren Pflichtfeldern erscheint eine Fehlermeldung und es wird nichts gespeichert. Bei gültigen Eingaben wird der Schüler gespeichert und in der Liste angezeigt. |



---



\## T02 – Unterrichtsstunde anlegen + Zahlungsübersicht (Summen korrekt)



| \*\*ID:\*\* | \*\*T02\*\* |

|---|---|

| \*\*Beschreibung:\*\* | Unterrichtsstunde anlegen und prüfen, dass Zahlungsübersicht die Summen (alle + offen) korrekt berechnet. |

| \*\*Vorbedingungen:\*\* | Programm läuft. Mindestens 1 Schüler und 1 Lehrer existieren (Seed-Daten reichen). |

| \*\*Test-Schritte:\*\* | 1. Öffne „Unterrichtsstunden planen“.<br>2. Wähle einen Schüler und Lehrer aus.<br>3. Setze Datum auf heute, Uhrzeit z.B. 15:00, Dauer \*\*60\*\*, Preis/Stunde \*\*40,00\*\*.<br>4. Setze Zahlungsstatus auf \*\*offen\*\* und speichere.<br>5. Lege eine zweite Stunde an (z.B. Dauer \*\*30\*\*, Preis/Stunde \*\*40,00\*\*) und setze Zahlungsstatus auf \*\*bezahlt\*\*.<br>6. Öffne „Zahlungsübersicht“ und wähle denselben Schüler.<br>7. Prüfe: Liste enthält beide Stunden.<br>8. Prüfe Summen: \*\*Summe aller Stunden\*\* = 60min\*40 + 30min\*40 = 40,00 + 20,00 = \*\*60,00 €\*\*; \*\*Davon offen\*\* = \*\*40,00 €\*\*. |

| \*\*Erwartetes Resultat:\*\* | Beide Stunden werden angezeigt. Summen stimmen exakt: Alle = 60,00 €, Offen = 40,00 €. |

