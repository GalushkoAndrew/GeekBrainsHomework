-- Задание 3
-- 3. Для каждой группы (сообщества) найти средний размер видеофайлов, загруженных участниками группы, а также вывести идентификатор, имя и фамилию пользователя, который загрузил самый большой по размеру видеофайл. Решить задание необходимо одним запросом с использованием оконных функций.

WITH step1 AS (
SELECT DISTINCT
	c."name" AS community_name,
	FIRST_VALUE(u.id) OVER(PARTITION BY c.id ORDER BY v."size" DESC NULLS LAST) AS user_id,
	FIRST_VALUE(u.first_name) OVER(PARTITION BY c.id ORDER BY v."size" DESC NULLS LAST) AS user_first_name,
	FIRST_VALUE(u.last_name) OVER(PARTITION BY c.id ORDER BY v."size" DESC NULLS LAST) AS user_last_name,
	AVG(v."size") OVER (PARTITION BY c.id) AS avg_video_size
FROM
	communities c 
LEFT JOIN
	communities_users cu
	ON cu.community_id = c.id 
LEFT JOIN
	video v
	ON v.owner_id = cu.user_id
LEFT JOIN
	users u
	ON u.id = cu.user_id
)
SELECT
	t.community_name,
	CASE WHEN t.avg_video_size IS NOT NULL THEN t.user_id END AS user_id,
	CASE WHEN t.avg_video_size IS NOT NULL THEN t.user_first_name END AS user_first_name,
	CASE WHEN t.avg_video_size IS NOT NULL THEN t.user_last_name END AS user_last_name,
	t.avg_video_size
FROM
	step1 AS t
ORDER BY
	avg_video_size DESC NULLS LAST;
