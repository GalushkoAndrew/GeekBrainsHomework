-- Таблица сообщений
CREATE TABLE messages (
  id SERIAL PRIMARY KEY,
  from_user_id INT NOT NULL,
  to_user_id INT NOT NULL,
  body TEXT,
  is_important BOOLEAN,
  is_delivered BOOLEAN,
  created_at TIMESTAMP
);

ALTER TABLE messages
ADD CONSTRAINT messages_from_user_id_fk
FOREIGN KEY (from_user_id)
REFERENCES users (id);

ALTER TABLE messages
ADD CONSTRAINT messages_to_user_id_fk
FOREIGN KEY (to_user_id)
REFERENCES users (id);
