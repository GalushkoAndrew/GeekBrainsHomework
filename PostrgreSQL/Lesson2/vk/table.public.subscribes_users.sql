-- Подписка на пользователя
CREATE TABLE subscribes_users (
  user_id INT NOT NULL,
  subscriber_id INT NOT NULL,
  created_at TIMESTAMP,
  PRIMARY KEY (user_id, subscriber_id)
);
