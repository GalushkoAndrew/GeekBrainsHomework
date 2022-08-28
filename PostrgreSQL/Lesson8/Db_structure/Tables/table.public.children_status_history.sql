-- Изменение статуса ребенка во времени (хороший/плохой)
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
