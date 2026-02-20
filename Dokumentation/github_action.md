\# GitHub Action – Unit Tests



\## Ziel

Bei jedem Push und Pull Request sollen die Unit-Tests automatisch ausgeführt werden, damit Fehler früh erkannt werden.



\## Workflow-Datei

Die Workflow-Datei liegt unter:



`.github/workflows/dotnet-tests.yml`



\## Wann läuft der Workflow?

\- Bei jedem `push`

\- Bei jedem `pull\_request`



\## Was macht der Workflow?

1\. Repository auschecken (Checkout)

2\. .NET SDK installieren (Setup .NET)

3\. Abhängigkeiten wiederherstellen (`dotnet restore`)

4\. Build im Release-Modus (`dotnet build -c Release`)

5\. Unit-Tests ausführen (`dotnet test -c Release`)



\## Ergebnis

Das Ergebnis ist im GitHub-Tab \*\*Actions\*\* sichtbar. Bei Erfolg ist der Run grün, bei Fehlern rot.

