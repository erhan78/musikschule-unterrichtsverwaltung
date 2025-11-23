-- Datenbank anlegen
IF DB_ID('MusikschuleDB') IS NULL
BEGIN
    CREATE DATABASE MusikschuleDB;
END;
GO

USE MusikschuleDB;
GO

-- Existierende Tabellen löschen
IF OBJECT_ID('dbo.Unterrichtsstunde', 'U') IS NOT NULL
    DROP TABLE dbo.Unterrichtsstunde;
IF OBJECT_ID('dbo.Schueler', 'U') IS NOT NULL
    DROP TABLE dbo.Schueler;
IF OBJECT_ID('dbo.Lehrer', 'U') IS NOT NULL
    DROP TABLE dbo.Lehrer;
GO

-- Tabelle Lehrer
CREATE TABLE dbo.Lehrer
(
    LehrerID      INT IDENTITY(1,1) PRIMARY KEY,
    Vorname       NVARCHAR(50)  NOT NULL,
    Nachname      NVARCHAR(50)  NOT NULL,
    Email         NVARCHAR(100) NULL,
    Telefon       NVARCHAR(30)  NULL,
    Fachgebiet    NVARCHAR(100) NOT NULL
);
GO

-- Tabelle Schueler
CREATE TABLE dbo.Schueler
(
    SchuelerID    INT IDENTITY(1,1) PRIMARY KEY,
    Vorname       NVARCHAR(50)  NOT NULL,
    Nachname      NVARCHAR(50)  NOT NULL,
    Email         NVARCHAR(100) NULL,
    Telefon       NVARCHAR(30)  NULL,
    Instrument    NVARCHAR(50)  NOT NULL
);
GO

-- Tabelle Unterrichtsstunde
CREATE TABLE dbo.Unterrichtsstunde
(
    UnterrichtsID   INT IDENTITY(1,1) PRIMARY KEY,
    SchuelerID      INT          NOT NULL,
    LehrerID        INT          NOT NULL,
    DatumUhrzeit    DATETIME2    NOT NULL,
    DauerMinuten    INT          NOT NULL,
    PreisProStunde  DECIMAL(6,2) NOT NULL,
    Zahlungsstatus  NVARCHAR(20) NOT NULL,  
    Status          NVARCHAR(20) NOT NULL,  
    CONSTRAINT FK_Unterricht_Schueler
        FOREIGN KEY (SchuelerID) REFERENCES dbo.Schueler(SchuelerID),
    CONSTRAINT FK_Unterricht_Lehrer
        FOREIGN KEY (LehrerID) REFERENCES dbo.Lehrer(LehrerID)
);
GO


-- Beispiel daten
INSERT INTO dbo.Lehrer (Vorname, Nachname, Email, Telefon, Fachgebiet) VALUES
('Anna',    'Meier',   'anna.meier@musikschule.de',   '0151-111111', 'Klavier'),
('Thomas',  'Schulz',  'thomas.schulz@musikschule.de','0151-222222', 'Gitarre'),
('Laura',   'Weber',   'laura.weber@musikschule.de',  '0151-333333', 'Violine'),
('Markus',  'Klein',   'markus.klein@musikschule.de', '0151-444444', 'Schlagzeug'),
('Julia',   'Hoffmann','julia.hoffmann@musikschule.de','0151-555555','Gesang');

INSERT INTO dbo.Schueler (Vorname, Nachname, Email, Telefon, Instrument) VALUES
('Max',     'Müller',     'max.mueller@example.com',     '0160-111111', 'Klavier'),
('Sophie',  'Schneider',  'sophie.schneider@example.com','0160-222222', 'Gitarre'),
('Leon',    'Fischer',    'leon.fischer@example.com',    '0160-333333', 'Violine'),
('Mia',     'Wagner',     'mia.wagner@example.com',      '0160-444444', 'Schlagzeug'),
('Ben',     'Becker',     'ben.becker@example.com',      '0160-555555', 'Gesang');

-- Unterrichtsstunden

INSERT INTO dbo.Unterrichtsstunde
    (SchuelerID, LehrerID, DatumUhrzeit, DauerMinuten, PreisProStunde, Zahlungsstatus, Status)
VALUES
(1, 1, '2025-01-10 15:00', 45, 40.00, 'bezahlt', 'durchgeführt'),
(2, 2, '2025-01-11 16:00', 60, 40.00, 'offen',   'geplant'),
(3, 3, '2025-01-12 17:00', 45, 40.00, 'bezahlt', 'durchgeführt'),
(4, 4, '2025-01-13 18:00', 30, 40.00, 'offen',   'geplant'),
(5, 5, '2025-01-14 19:00', 60, 40.00, 'bezahlt', 'durchgeführt'),
(1, 1, '2025-01-17 15:00', 45, 40.00, 'offen',   'geplant'),
(2, 2, '2025-01-18 16:00', 60, 40.00, 'bezahlt', 'durchgeführt');

-- Beispielausgabe
SELECT
    u.UnterrichtsID,
    u.DatumUhrzeit,
    u.DauerMinuten,
    u.PreisProStunde,
    u.Zahlungsstatus,
    u.Status,
    s.Vorname  AS SchuelerVorname,
    s.Nachname AS SchuelerNachname,
    l.Vorname  AS LehrerVorname,
    l.Nachname AS LehrerNachname
FROM dbo.Unterrichtsstunde u
JOIN dbo.Schueler s ON u.SchuelerID = s.SchuelerID
JOIN dbo.Lehrer  l ON u.LehrerID   = l.LehrerID
ORDER BY u.DatumUhrzeit;
