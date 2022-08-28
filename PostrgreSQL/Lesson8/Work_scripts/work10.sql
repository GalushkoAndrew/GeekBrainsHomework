-- Для одного из запросов, созданных в пункте 6, провести оптимизацию. В качестве отчета приложить планы выполнения запроса, ваш анализ и показать действия, которые улучшили эффективность запроса

-- исходный подопытный запрос
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
	
-- Смотрим план выполнения запроса
EXPLAIN
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

-- стоимость запроса 7,96
-- В плане вижу 3 последовательных сканирования

-- сделал оценку с реальным выполнением запроса:
EXPLAIN ANALYZE
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
-- оценка:
-- подготовка 0,101
-- выполнение 1,102
-- реальное время выполнения Execution Time: 0.118 ms


-- Пробую их убрать, создав соответствующие индексы
CREATE INDEX mines_name_idx ON mines (name);
CREATE INDEX ore_incomes_dwarf_id_idx ON ore_incomes (dwarf_id);
CREATE INDEX ore_incomes_mine_id_idx ON ore_incomes (mine_id);

-- Вновь смотрю план запроса через EXPLAIN, ничего не изменилось
-- Смотрю через EXPLAIN ANALYZE, запрос отработал быстрее:
-- оценка:
-- подготовка 0,08
-- выполнение 0,081
-- реальное время выполнения Execution Time: 0.105 ms

-- Сложно сказать, действительно ли помогли индексы, т.к. объем данных слишком мал и скорость выполнения запроса больше зависит от загруженности сервера. Оценка с EXPLAIN не изменилась (ни в стоимости, ни в изменении способа поиска данных) и я склонен считать, что в данной ситуации лучшим решением будет удалить индексы и считать, что запрос выполняется лучшим образом без них.
-- Тем более, что запрос выполняется быстро и очевидных причин его ускорять не наблюдается
DROP INDEX mines_name_idx;
DROP INDEX ore_incomes_dwarf_id_idx;
DROP INDEX ore_incomes_mine_id_idx;
