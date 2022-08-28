-- Создать два представления, в основе которых лежат сложные запросы.

-- Достаточно ли маны на создание игрушек в 2022 году
CREATE VIEW rest AS
SELECT
	CASE WHEN m.sum_value IS NULL THEN 0 ELSE m.sum_value END - 
	CASE WHEN o.sum_value IS NULL THEN 0 ELSE o.sum_value END AS rest
FROM 
(SELECT
	SUM(oi.ore_value * m.mana_percent) AS sum_value
FROM
	ore_incomes oi 
JOIN
	mines m
	ON m.id = oi.mine_id 
WHERE
	date_part('year', oi.mined_at) = 2022) AS m
CROSS JOIN
(
SELECT
	sum(cost) AS sum_value
FROM
	orders o
WHERE
	order_year = 2022) AS o;

-- суммарная прибыль маны в разрезе года и шахты
CREATE VIEW mine_analitic AS
SELECT
	date_part('year', oi.mined_at) AS mine_year,
	m."name" AS mine,
	SUM(oi.ore_value * m.mana_percent) AS ore_value
FROM
	ore_incomes AS oi
JOIN
	mines m
	ON m.id = oi.mine_id
GROUP BY
	date_part('year', oi.mined_at),
	m."name"
ORDER BY 1, 2;
