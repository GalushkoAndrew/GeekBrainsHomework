-- Таблица пользователей
CREATE TABLE users (
  id SERIAL PRIMARY KEY,
  first_name VARCHAR(50) NOT NULL,
  last_name VARCHAR(50) NOT NULL,
  email VARCHAR(120) NOT NULL UNIQUE,
  phone VARCHAR(15) UNIQUE,
  main_photo_id INT,
  created_at TIMESTAMP
);

ALTER TABLE users
ADD CONSTRAINT users_main_photo_id_fk
FOREIGN KEY (main_photo_id)
REFERENCES photo (id);

ALTER TABLE users
ADD COLUMN user_contacts contacts;

UPDATE users
SET user_contacts = (phone, email);

UPDATE users
SET user_contacts.email = 'test@somemail.ru'
WHERE id = 21;
