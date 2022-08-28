CREATE TABLE child_statuses (
	id SERIAL PRIMARY KEY,
	name VARCHAR(30) UNIQUE
);

CREATE TABLE children (
	id SERIAL PRIMARY KEY,
	first_name VARCHAR(50) NOT NULL,
	last_name VARCHAR(50) NOT NULL,
	created_at TIMESTAMP
);

CREATE TABLE dwarfs (
	id SERIAL PRIMARY KEY,
	name VARCHAR(50) NOT NULL,
	ratio FLOAT NOT NULL
);

CREATE TABLE mines (
	id SERIAL PRIMARY KEY,
	name VARCHAR(50) NOT NULL,
	mana_percent FLOAT NOT NULL
);

CREATE TABLE elfs (
	id SERIAL PRIMARY KEY,
	name VARCHAR(50) NOT NULL,
	speed INT NOT NULL
);

CREATE TABLE gifts (
	id SERIAL PRIMARY KEY,
	name VARCHAR(50) NOT NULL
);

CREATE TABLE children_status_history (
	id SERIAL PRIMARY KEY,
	child_id INT NOT NULL,
	status_id INT NOT NULL,
	date_begin TIMESTAMP NOT NULL
);

ALTER TABLE children_status_history
ADD CONSTRAINT children_status_history_child_id_fk
FOREIGN KEY (child_id)
REFERENCES children (id);

ALTER TABLE children_status_history
ADD CONSTRAINT children_status_history_status_id_fk
FOREIGN KEY (status_id)
REFERENCES child_statuses (id);

CREATE TABLE orders (
	id SERIAL PRIMARY KEY,
	gift_id INT NOT NULL,
	child_id INT NOT NULL,
	cost INT NOT NULL,
	logistic_shoulder INT NOT NULL
);

ALTER TABLE orders
ADD CONSTRAINT orders_gift_id_fk
FOREIGN KEY (gift_id)
REFERENCES gifts (id);

ALTER TABLE orders
ADD CONSTRAINT orders_child_id_fk
FOREIGN KEY (child_id)
REFERENCES children (id);

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

CREATE TABLE deliveries (
	id SERIAL PRIMARY KEY,
	order_id INT NOT NULL,
	elf_id INT NOT NULL,
	delivered_at TIMESTAMP NOT NULL
);

ALTER TABLE deliveries
ADD CONSTRAINT deliveries_order_id_fk
FOREIGN KEY (order_id)
REFERENCES orders (id);

ALTER TABLE deliveries
ADD CONSTRAINT deliveries_elf_id_fk
FOREIGN KEY (elf_id)
REFERENCES elfs (id);

CREATE TABLE penalties (
	id SERIAL PRIMARY KEY,
	order_id INT NOT NULL,
	amount INT NOT NULL,
	created_at TIMESTAMP
);

ALTER TABLE penalties
ADD CONSTRAINT penalties_order_id_fk
FOREIGN KEY (order_id)
REFERENCES orders (id);
