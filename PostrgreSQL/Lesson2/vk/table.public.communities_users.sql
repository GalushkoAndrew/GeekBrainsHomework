-- Таблица связи сообщества - пользователи
CREATE TABLE communities_users (
  community_id INT NOT NULL,
  user_id INT NOT NULL,
  created_at TIMESTAMP,
  PRIMARY KEY (community_id, user_id)
);

ALTER TABLE communities_users
ADD CONSTRAINT communities_users_community_id_fk
FOREIGN KEY (community_id)
REFERENCES communities (id);

ALTER TABLE communities_users
ADD CONSTRAINT communities_users_user_id_fk
FOREIGN KEY (user_id)
REFERENCES users (id);