-- Таблица видео
CREATE TABLE video (
  id SERIAL PRIMARY KEY,
  url VARCHAR(250) NOT NULL UNIQUE,
  owner_id INT NOT NULL,
  description VARCHAR(250) NOT NULL,
  uploaded_at TIMESTAMP NOT NULL,
  size INT NOT NULL
);

ALTER TABLE video
ADD CONSTRAINT video_owner_id_fk
FOREIGN KEY (owner_id)
REFERENCES users (id);
