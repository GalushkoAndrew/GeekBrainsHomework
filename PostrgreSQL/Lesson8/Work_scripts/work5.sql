-- Создать два сложных (многотабличных) запроса с использованием подзапросов.

-- Гном, первым добывший руду в шахте Восточная
SELECT
	d."name"
FROM
	ore_incomes oi
JOIN
	dwarfs d
	ON d.id = oi.dwarf_id 
WHERE
	oi.mine_id IN (SELECT id FROM mines m WHERE m."name" = 'Восточная')
ORDER BY
	oi.mined_at
LIMIT 1;

-- список детей, успевших стать плохими в течение 2022 года
SELECT DISTINCT
	c.first_name,
	c.last_name
FROM
	children c
WHERE
	c.id IN (
		SELECT
			csh.child_id
		FROM
			children_status_history csh
		WHERE
			csh.status_id IN (SELECT id FROM child_statuses cs WHERE cs."name" = 'Плохой')
			AND date_part('year', csh.date_begin) = 2022
	);