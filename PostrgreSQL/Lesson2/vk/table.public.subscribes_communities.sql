-- Подписка на сообщество
CREATE TABLE subscribes_communities (
  community_id INT NOT NULL,
  subscriber_id INT NOT NULL,
  created_at TIMESTAMP,
  PRIMARY KEY (community_id, subscriber_id)
);