-- Таблица фотографий
CREATE TABLE photo (
  id SERIAL PRIMARY KEY,
  url VARCHAR(250) NOT NULL UNIQUE,
  owner_id INT NOT NULL,
  description VARCHAR(250) NOT NULL,
  uploaded_at TIMESTAMP NOT NULL,
  size INT NOT NULL
);

ALTER TABLE photo
ADD CONSTRAINT photo_owner_id_fk
FOREIGN KEY (owner_id)
REFERENCES users (id);

ALTER TABLE photo
ADD COLUMN metadata json;

UPDATE photo
SET metadata = json_build_object('id', id, 'url', url, 'size', size);
