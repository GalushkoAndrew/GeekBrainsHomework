-- Подписка на сообщество
CREATE TABLE subscribes_communities (
  community_id INT NOT NULL,
  subscriber_id INT NOT NULL,
  created_at TIMESTAMP,
  PRIMARY KEY (community_id, subscriber_id)
);

ALTER TABLE subscribes_communities
ADD CONSTRAINT subscribes_communities_community_id_fk
FOREIGN KEY (community_id)
REFERENCES communities (id);

ALTER TABLE subscribes_communities
ADD CONSTRAINT subscribes_communities_subscriber_id_fk
FOREIGN KEY (subscriber_id)
REFERENCES users (id);