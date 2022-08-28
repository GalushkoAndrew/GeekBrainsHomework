-- Штрафы
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
