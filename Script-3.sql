-- Удаление таблиц в правильном порядке
DROP TABLE IF EXISTS Books;
DROP TABLE IF EXISTS Authors;
DROP TABLE IF EXISTS Genres;
DROP TABLE IF EXISTS Users;

-- Создание таблицы Users
CREATE TABLE Users (
    Id SERIAL PRIMARY KEY,
    Name CHARACTER VARYING(200) NOT NULL,
    Email CHARACTER VARYING(200) NOT NULL
);

-- Создание таблицы Authors
CREATE TABLE Authors (
    Id SERIAL PRIMARY KEY,
    Name CHARACTER VARYING(200) NOT NULL
);

-- Создание таблицы Genres
CREATE TABLE Genres (
    Id SERIAL PRIMARY KEY,
    Name CHARACTER VARYING(200) NOT NULL
);

-- Создание таблицы Books
CREATE TABLE Books (
    Id SERIAL PRIMARY KEY,
    UserId INTEGER, -- Книга может быть не привязана к пользователю
    AuthorId INTEGER NOT NULL,
    GenreId INTEGER NOT NULL,
    Title CHARACTER VARYING(200) NOT NULL,
    Year INTEGER NOT NULL,
    CONSTRAINT FK_Books_Users FOREIGN KEY (UserId) REFERENCES Users(Id) ON DELETE SET NULL, --Книга сохраняется, но отвязывается от пользователя
    CONSTRAINT FK_Books_Authors FOREIGN KEY (AuthorId) REFERENCES Authors(Id) ON DELETE CASCADE, -- Удаление автора или жанра приводит к удалению связанных книг
    CONSTRAINT FK_Books_Genres FOREIGN KEY (GenreId) REFERENCES Genres(Id) ON DELETE CASCADE
);

-- Вставка данных в таблицу Users
INSERT INTO Users (Name, Email) VALUES ('Иванов Иван Иванович', 'ivanov.ivan@mail.ru');
INSERT INTO Users (Name, Email) VALUES ('Бук Василий Петрович', 'vasya_buk@mail.ru');
INSERT INTO Users (Name, Email) VALUES ('Петрова Мария Петровна', 'masha_111@mail.ru');
INSERT INTO Users (Name, Email) VALUES ('Давыдова Екатерина Викторовна', 'davidova@mail.ru');
INSERT INTO Users (Name, Email) VALUES ('Юров Юрий Юрьевич', 'yura@mail.ru');

-- Вставка данных в таблицу Authors
INSERT INTO Authors (Name) VALUES ('James Bonn');
INSERT INTO Authors (Name) VALUES ('Kare Gray');
INSERT INTO Authors (Name) VALUES ('Voctor Faradei');
INSERT INTO Authors (Name) VALUES ('Mike Item');
INSERT INTO Authors (Name) VALUES ('Anna Karenina');

-- Вставка данных в таблицу Genres
INSERT INTO Genres (Name) VALUES ('Romance');
INSERT INTO Genres (Name) VALUES ('Novel');
INSERT INTO Genres (Name) VALUES ('Thriller');
INSERT INTO Genres (Name) VALUES ('Student book');
INSERT INTO Genres (Name) VALUES ('History');

-- Вставка данных в таблицу Books
INSERT INTO Books (UserId, Title, Year, AuthorId, GenreId) 
VALUES (1, 'Rose in the Worlds', 1992, 1, 1);
INSERT INTO Books (UserId, Title, Year, AuthorId, GenreId) 
VALUES (2, 'Never say never', 2005, 2, 2);
INSERT INTO Books (UserId, Title, Year, AuthorId, GenreId) 
VALUES (3, 'Chasing the beast', 2023, 3, 3);
INSERT INTO Books (UserId, Title, Year, AuthorId, GenreId) 
VALUES (4, 'C# for students', 1997, 4, 4);
INSERT INTO Books (UserId, Title, Year, AuthorId, GenreId) 
VALUES (5, 'My dear friend', 2001, 5, 5);













