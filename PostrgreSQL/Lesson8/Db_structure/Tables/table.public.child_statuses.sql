-- Статусы детей
CREATE TABLE child_statuses (
	id SERIAL PRIMARY KEY,
	name VARCHAR(30) UNIQUE
);
