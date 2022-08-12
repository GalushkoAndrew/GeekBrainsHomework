-- Найти, кому принадлежат 10 самых больших видеофайлов. В отчёт вывести идентификатор видеофайла, имя владельца, фамилию владельца, URL основной фотографии пользователя, URL видеофайла, размер видеофайла.

-- Только на вложенных запросах
-- v1
SELECT
	v.id,
	(SELECT u.first_name FROM users u WHERE u.id = v.owner_id),
	(SELECT u.last_name FROM users u WHERE u.id = v.owner_id),
	(
		SELECT p.url
		FROM users u
		JOIN photo p
			ON p.id = u.main_photo_id
		WHERE u.id = v.owner_id) AS photo_url,
	v.url AS video_url,
	v."size"
FROM video v
JOIN users u 
	ON u.id = v.owner_id
LEFT JOIN photo p
	ON p.id = u.main_photo_id 
ORDER BY "size" DESC
LIMIT 10;

-- v2
SELECT
	v.id,
	u.first_name,
	u.last_name,
	u.photo_url,
	v.url AS video_url,
	v."size"
FROM video v
JOIN (
	SELECT
		u.id,
		u.first_name,
		u.last_name,
		p.url AS photo_url
	FROM users u 
	LEFT JOIN photo p
		ON p.id = u.main_photo_id) AS u
	ON u.id = v.owner_id
ORDER BY "size" DESC
LIMIT 10;

-- Через временную таблицу

CREATE TEMPORARY TABLE video_tmp(
	id INT NOT NULL,
	owner_id INT NOT NULL,
	url VARCHAR(250) NOT NULL,
	size INT NOT NULL);

insert into video_tmp(
	id,
	owner_id,
	url,
	size)
SELECT id,
	owner_id,
	url,
	size
FROM video
ORDER BY "size" DESC
LIMIT 10;

SELECT
	v.id,
	u.first_name,
	u.last_name,
	p.url AS photo_url,
	v.url AS video_url,
	v."size"
FROM video_tmp v
JOIN users u 
	ON u.id = v.owner_id
LEFT JOIN photo p
	ON p.id = u.main_photo_id;

-- Используя CTE
WITH video_tmp AS (
SELECT id,
	owner_id,
	url,
	size
FROM video
ORDER BY "size" DESC
LIMIT 10
)
SELECT
	v.id,
	u.first_name,
	u.last_name,
	p.url AS photo_url,
	v.url AS video_url,
	v."size"
FROM video_tmp v
JOIN users u 
	ON u.id = v.owner_id
LEFT JOIN photo p
	ON p.id = u.main_photo_id;

-- Через JOIN
SELECT
	v.id,
	u.first_name,
	u.last_name,
	p.url AS photo_url,
	v.url AS video_url,
	v."size"
FROM video v
JOIN users u 
	ON u.id = v.owner_id
LEFT JOIN photo p
	ON p.id = u.main_photo_id 
ORDER BY "size" DESC
LIMIT 10;
