-- Создать триггер

-- Тригер выставляет штрафы, для упрощения ограничусь одним:
--Если подарить подарок плохому ребенку, Деда Мороза оштрафуют на сумму = удвоенному количеству очков рейтинга за заказ.

CREATE OR REPLACE FUNCTION create_penalty_for_delivery_trg()
RETURNS TRIGGER AS
$$
	DECLARE order_cost INT;
	BEGIN
		IF EXISTS(
			SELECT
				status_id
			FROM (
				SELECT
					csh.status_id
				FROM
					children_status_history csh
				JOIN (
					SELECT
						o.child_id,
						o.order_year
					FROM
						orders o
					WHERE
						o.id = NEW.order_id) o
					ON o.child_id = csh.child_id
						AND o.order_year = date_part('year', csh.date_begin)
				ORDER BY
					csh.date_begin DESC
				LIMIT 1) AS s
			WHERE
				status_id = 2) THEN
			order_cost := (SELECT o."cost" * 2 FROM orders AS o WHERE o.id = NEW.order_id);
			
			INSERT INTO penalties (order_id, amount, created_at)
			VALUES (NEW.order_id, order_cost, NOW());
		END IF;
		RETURN NEW;
	END;
$$
LANGUAGE PLPGSQL;

CREATE TRIGGER check_delivery_on_create BEFORE INSERT ON deliveries
	FOR EACH ROW
	EXECUTE FUNCTION create_penalty_for_delivery_trg();
