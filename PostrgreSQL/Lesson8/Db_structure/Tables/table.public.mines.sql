-- Шахты
CREATE TABLE mines (
	id SERIAL PRIMARY KEY,
	name VARCHAR(50) NOT NULL,
	mana_percent FLOAT NOT NULL
);
