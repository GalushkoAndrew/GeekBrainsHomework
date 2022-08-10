-- Таблица дружбы
CREATE TABLE friendship (
  id SERIAL PRIMARY KEY,
  requested_by_user_id INT NOT NULL,
  requested_to_user_id INT NOT NULL,
  status_id INT NOT NULL,
  requested_at TIMESTAMP,
  confirmed_at TIMESTAMP
);

ALTER TABLE friendship
ADD CONSTRAINT friendship_requested_by_user_id_fk
FOREIGN KEY (requested_by_user_id)
REFERENCES users (id);

ALTER TABLE friendship
ADD CONSTRAINT friendship_requested_to_user_id_fk
FOREIGN KEY (requested_to_user_id)
REFERENCES users (id);

ALTER TABLE friendship
ADD CONSTRAINT friendship_status_id_fk
FOREIGN KEY (status_id)
REFERENCES friendship_statuses (id);