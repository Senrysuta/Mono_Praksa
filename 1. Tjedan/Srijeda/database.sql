CREATE TABLE Authors(
	AuthorID int NOT NULL PRIMARY KEY,
	FirstName varchar(255),
	LastName varchar(255),
);

CREATE TABLE Books(
	BookID int NOT NULL PRIMARY KEY,
	AuthorID int NOT NULL FOREIGN KEY REFERENCES Authors(AuthorID),
	Title varchar(255),
	PublishYear int,
);

INSERT INTO Authors VALUES
(1,'William','Shakespeare'),
(2,'Fjodor','Mihajlovič Dostojevski'),
(3,'Charles','Dickens'),
(4,'Miroslav','Krleža'),
(5,'Dante','Alighieri');

INSERT INTO Books VALUES
(1,1,'Romeo and Juliet',1593),
(2,1,'Hamlet',1602),
(3,2,'Crime and punishment',1866),
(4,2,'The Brothers Karamazov',1880),
(5,3,'Oliver Twist',1837),
(6,3,'The Haunted Man',1848),
(7,4,'Gospoda Glembajevi',1929),
(8,4,'U agoniji',1928),
(9,5,'Inferno',1472),
(10,5,'Purgatorio',1470);

SELECT * FROM Authors;

SELECT * FROM Books;

UPDATE Books SET Title = 'Zastave', PublishYear = 1969 WHERE BookID = 8

SELECT Title,PublishYear FROM Books WHERE BookID = 8;

ALTER TABLE Books ADD OriginalLanguage varchar(255);

UPDATE Books SET OriginalLanguage = 'English' WHERE AuthorID = 1 OR AuthorID = 3;
UPDATE Books SET OriginalLanguage = 'Russian' WHERE AuthorID = 2;
UPDATE Books SET OriginalLanguage = 'Croatian' WHERE AuthorID = 4;
UPDATE Books SET OriginalLanguage = 'Italian' WHERE AuthorID = 5;

ALTER TABLE Authors ADD CenturyOfWriting int;

ALTER TABLE Authors DROP COLUMN CenturyOfWriting;

DELETE FROM Books WHERE Title = 'The Haunted Man';

SELECT * FROM Books WHERE AuthorID = 3;

SELECT Title FROM Books
WHERE OriginalLanguage IN ('English');

SELECT COUNT(BookID) FROM Books;

SELECT COUNT(BookID) as NumberOfLangs FROM Books GROUP BY OriginalLanguage;

SELECT Title,OriginalLanguage,PublishYear FROM Books ORDER BY PublishYear;

SELECT COUNT(BookID)
FROM Books
GROUP BY OriginalLanguage
HAVING COUNT(AuthorID) < 3;

ALTER TABLE Books ADD ISBN varchar(255);

UPDATE Books SET ISBN = '9780671722852' WHERE BookID = 1;
UPDATE Books SET ISBN = '9780743477123' WHERE BookID = 2;
UPDATE Books SET ISBN = '9780679734505' WHERE BookID = 3;
UPDATE Books SET ISBN = '9781250788450' WHERE BookID = 4;
UPDATE Books SET ISBN = '9780141439747' WHERE BookID = 5;
UPDATE Books SET ISBN = '9780679734505' WHERE BookID = 6;
UPDATE Books SET ISBN = '9788642706443' WHERE BookID = 7;
UPDATE Books SET ISBN = '9780679734505' WHERE BookID = 8;
UPDATE Books SET ISBN = '9780451531391' WHERE BookID = 9;
UPDATE Books SET ISBN = '9780385497008' WHERE BookID = 10;

CREATE INDEX index_ISBN ON Books (ISBN);

