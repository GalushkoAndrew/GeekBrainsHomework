-- Подписка на пользователя
CREATE TABLE subscribes_users (
  user_id INT NOT NULL,
  subscriber_id INT NOT NULL,
  created_at TIMESTAMP,
  PRIMARY KEY (user_id, subscriber_id)
);

ALTER TABLE subscribes_users
ADD CONSTRAINT subscribes_users_user_id_fk
FOREIGN KEY (user_id)
REFERENCES users (id);

ALTER TABLE subscribes_users
ADD CONSTRAINT subscribes_users_subscriber_id_fk
FOREIGN KEY (subscriber_id)
REFERENCES users (id);