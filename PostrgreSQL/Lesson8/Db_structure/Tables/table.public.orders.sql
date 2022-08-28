-- Заказы подарков
CREATE TABLE orders (
	id SERIAL PRIMARY KEY,
	gift_id INT NOT NULL,
	child_id INT NOT NULL,
	cost INT NOT NULL,
	logistic_shoulder INT NOT NULL,
	order_year INT NOT NULL
);

ALTER TABLE orders
ADD CONSTRAINT orders_gift_id_fk
FOREIGN KEY (gift_id)
REFERENCES gifts (id);

ALTER TABLE orders
ADD CONSTRAINT orders_child_id_fk
FOREIGN KEY (child_id)
REFERENCES children (id);
