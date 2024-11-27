create table "user" (
id SERIAL PRIMARY KEY, 
  name character varying(200) NOT NULL, 
  email character varying(200) NOT NULL
);

create table book (
id SERIAL PRIMARY KEY, 
user_id integer not null,
  title character varying(200) NOT NULL, 
  year integer NOT NULL,
  genre character varying(200) NOT NULL, 
  author character varying(200) NOT NULL, 
  CONSTRAINT book_fk FOREIGN KEY(user_id) REFERENCES "user"(id)
);

INSERT INTO "user" (name, email) VALUES ( 'Иванов Иван Иванович', 'ivanov.ivan@mail.ru');
INSERT INTO "user" (name, email) VALUES ( 'Бук Василий Петрович', 'vasya_buk@mail.ru');
INSERT INTO "user" (name, email) VALUES ( 'Петрова Мария Петровна', 'masha_111@mail.ru');
INSERT INTO "user" (name, email) VALUES ( 'Давыдова  Екатерина Викторовна', 'davidova@mail.ru');
INSERT INTO "user" (name, email) VALUES ( 'Юров Юрий Юрьевич', 'yura@mail.ru');


INSERT INTO book (user_id, title, year, genre, author) VALUES (1, 'Rose in the Worlds', 1992, 'Romance','James Bonn');
INSERT INTO book (user_id, title, year, genre, author) VALUES (2, 'Never say never', 2005, 'Novel', 'Kare Gray');
INSERT INTO book (user_id, title, year, genre, author) VALUES (3, 'Chasing the beast', 2023, 'Thriller', 'Voctor Faradei');
INSERT INTO book (user_id, title, year, genre, author) VALUES (4, 'C# for students', 1997, 'Student book', 'Mike Item');
INSERT INTO book (user_id, title, year, genre, author) VALUES (5, 'My dear friend', 2001, 'History', 'Anna Karenina');

drop table Users;











