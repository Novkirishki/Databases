--
-- File generated with SQLiteStudio v3.0.6 on Wed Oct 21 17:02:15 2015
--
-- Text encoding used: windows-1252
--
PRAGMA foreign_keys = off;
BEGIN TRANSACTION;

-- Table: Books
CREATE TABLE Books (Id INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE NOT NULL, Title STRING (50) NOT NULL, Author STRING (50) NOT NULL, PublishDate DATE NOT NULL, ISBN STRING (20) NOT NULL);
INSERT INTO Books (Id, Title, Author, PublishDate, ISBN) VALUES (1, 'Harry Potter', 'J.K.Rowling', '1997-12-02', 11111111111);
INSERT INTO Books (Id, Title, Author, PublishDate, ISBN) VALUES (2, 'It', 'Stephen King', '1990-06-15', 22222222222);
INSERT INTO Books (Id, Title, Author, PublishDate, ISBN) VALUES (3, 'Under The Dome', 'Sthphen King', '2012-12-12', 33333333333);
INSERT INTO Books (Id, Title, Author, PublishDate, ISBN) VALUES (4, 'Lord Of THe Rings', 'Tolkien', '1970-04-05', 44444444444);

COMMIT TRANSACTION;
PRAGMA foreign_keys = on;
