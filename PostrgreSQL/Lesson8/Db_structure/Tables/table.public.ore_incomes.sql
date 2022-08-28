-- Приход руды
CREATE TABLE ore_incomes (
	id SERIAL PRIMARY KEY,
	dwarf_id INT NOT NULL,
	mine_id INT NOT NULL,
	mined_at TIMESTAMP,
	ore_value INT NOT NULL
);

ALTER TABLE ore_incomes
ADD CONSTRAINT ore_incomes_dwarf_id_fk
FOREIGN KEY (dwarf_id)
REFERENCES dwarfs (id);

ALTER TABLE ore_incomes
ADD CONSTRAINT ore_incomes_mine_id_fk
FOREIGN KEY (mine_id)
REFERENCES mines (id);
