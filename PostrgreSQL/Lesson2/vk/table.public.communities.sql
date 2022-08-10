-- Таблица сообществ
CREATE TABLE communities (
  id SERIAL PRIMARY KEY,
  name VARCHAR(120) UNIQUE,
  creator_id INT NOT NULL,
  created_at TIMESTAMP
);

ALTER TABLE communities
ADD CONSTRAINT communities_creator_id_fk
FOREIGN KEY (creator_id)
REFERENCES users (id);

ALTER TABLE communities
ADD COLUMN members INT[];

UPDATE communities
SET members = ARRAY(
	SELECT ku.user_id
	FROM communities_users AS ku
	WHERE ku.community_id = id)
WHERE id = 3;
