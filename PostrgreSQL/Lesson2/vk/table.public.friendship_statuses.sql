-- Таблица статусов дружбы
CREATE TABLE friendship_statuses (
  id SERIAL PRIMARY KEY,
  name VARCHAR(30) UNIQUE
);
