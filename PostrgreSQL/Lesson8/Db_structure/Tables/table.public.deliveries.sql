-- Доставки подарков
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
