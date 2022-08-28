-- Задание 1
-- 1. Удалить пользователей, которые не имеют ни одной дружеской связи с подтвержденным статусом. Нужно удалить все данные, связанные с такими пользователями. Для решения используйте транзакцию.

-- предположим, подтвержденный статус в моей рандомной БД это "diam"
--SELECT * FROM friendship_statuses fs2 WHERE name = 'diam'

BEGIN;
CREATE TEMPORARY TABLE users_accepted (user_id INT);

-- выбираем пользователей, имеющих дружескую связь с подтвержденным статусом
WITH links AS (
SELECT
	f.requested_by_user_id,
	f.requested_to_user_id
FROM
	friendship f
WHERE
	f.status_id IN (SELECT id FROM friendship_statuses fs2 WHERE name = 'diam'))
INSERT INTO users_accepted(user_id)
SELECT
	requested_by_user_id AS user_id
FROM
	links
UNION
SELECT
	requested_to_user_id
FROM
	links;

CREATE TEMPORARY TABLE users_to_delete (id INT);

-- Пользователи без дружеской связи с подтвержденным статусом
INSERT INTO users_to_delete (id)
SELECT
	u.id
FROM
	users AS u
LEFT JOIN
	users_accepted AS d 
	ON d.user_id = u.id
WHERE
	d.user_id IS NULL;

-- Удаление
DELETE FROM video WHERE owner_id IN (SELECT id FROM users_to_delete);
DELETE FROM profiles WHERE user_id IN (SELECT id FROM users_to_delete);
DELETE FROM photo WHERE owner_id IN (SELECT id FROM users_to_delete);
DELETE FROM subscribes_communities WHERE community_id IN (SELECT id FROM communities WHERE creator_id IN (SELECT id FROM users_to_delete));
DELETE FROM communities_users WHERE community_id IN (SELECT id FROM communities WHERE creator_id IN (SELECT id FROM users_to_delete));
DELETE FROM communities WHERE creator_id IN (SELECT id FROM users_to_delete);
DELETE FROM friendship WHERE requested_by_user_id IN (SELECT id FROM users_to_delete) OR requested_to_user_id IN (SELECT id FROM users_to_delete);
DELETE FROM messages WHERE from_user_id IN (SELECT id FROM users_to_delete) OR to_user_id IN (SELECT id FROM users_to_delete);
DELETE FROM subscribes_users WHERE user_id IN (SELECT id FROM users_to_delete) OR subscriber_id IN (SELECT id FROM users_to_delete);
DELETE FROM users WHERE id IN (SELECT id FROM users_to_delete);
COMMIT;

