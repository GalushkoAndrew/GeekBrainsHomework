-- Создать два сложных запроса с использованием объединения JOIN и без использования подзапросов.

-- Гном, первым добывший руду в шахте Восточная
SELECT
	d."name"
FROM
	ore_incomes oi
JOIN
	dwarfs d
	ON d.id = oi.dwarf_id
JOIN
	mines m
	ON m.id = oi.mine_id
WHERE
	m."name" = 'Восточная'
ORDER BY
	oi.mined_at
LIMIT 1;

-- список детей, успевших стать плохими в течение 2022 года
SELECT DISTINCT
	c.first_name,
	c.last_name
FROM
	children c
JOIN
	children_status_history csh
	ON csh.child_id = c.id
JOIN
	child_statuses cs
	ON cs.id = csh.status_id
	AND cs."name" = 'Плохой'
WHERE
	date_part('year', csh.date_begin) = 2022;