-- Задание 2
-- 2. Создать запрос, который для всех пользователей покажет количество загруженных фотографий и видеофайлов (отдельными столбцами), а также ранг каждого пользователя по этим значениям (также отдельно для фотографий и видеофайлов). Большие значения соответствуют более высокому рангу. Решить задание необходимо одним запросом с использованием оконных функций.

SELECT
	u.first_name,
	u.last_name,
	u.id,
	p.photo_count,
	v.video_count,
	DENSE_RANK() OVER (ORDER BY p.photo_count) AS photo_rank,
	DENSE_RANK() OVER (ORDER BY v.video_count) AS video_rank
FROM
	users u
LEFT JOIN
	(SELECT DISTINCT
		owner_id,
		COUNT(id) OVER (PARTITION BY owner_id) AS photo_count
	FROM
		photo) AS p
	ON p.owner_id  = u.id
LEFT JOIN
	(SELECT DISTINCT
		owner_id,
		COUNT(id) OVER (PARTITION BY owner_id) AS video_count
	FROM
		video) AS v
	ON v.owner_id  = u.id;