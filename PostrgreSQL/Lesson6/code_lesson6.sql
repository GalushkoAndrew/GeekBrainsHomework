-- функция
CREATE FUNCTION user_sended_max_messages(user_id INT)
RETURNS INT AS
$$
	SELECT
		from_user_id
	FROM messages m
	WHERE to_user_id = user_id
	GROUP BY from_user_id
	ORDER BY COUNT(id) DESC
	LIMIT 1;
$$
LANGUAGE SQL; 

-- процедура
CREATE OR REPLACE PROCEDURE check_owner_photo()
LANGUAGE PLPGSQL AS
$$
	DECLARE profile_row RECORD;
	BEGIN
		FOR profile_row IN
			SELECT p.*
			FROM profiles p
			JOIN photo p2
				ON p2.id = p.main_photo_id
			WHERE
				p2.owner_id <> p.user_id 
		LOOP
			UPDATE profiles SET main_photo_id = NULL WHERE id = profile_row.id;
		END LOOP;
		COMMIT;
	END;
$$

-- триггер
CREATE OR REPLACE FUNCTION check_owner_photo_to_user()
RETURNS TRIGGER AS
$$
	DECLARE is_owner_corresponds_to_user BOOLEAN;
	BEGIN
		IF NEW.main_photo_id = NULL THEN
			RETURN NEW;
		END IF;
		is_owner_corresponds_to_user := EXISTS(
			SELECT *
			FROM photo
			WHERE
				id = NEW.main_photo_id
				AND owner_id <> NEW.user_id);
		IF is_owner_corresponds_to_user THEN
			RAISE EXCEPTION 'Owner not corresponds to user';
		END IF;
		RETURN NEW;
	END;
$$
LANGUAGE PLPGSQL;

CREATE TRIGGER check_profile_on_insert BEFORE INSERT ON profiles
	FOR EACH ROW
	EXECUTE FUNCTION check_owner_photo_to_user();

-- проверка
-- ошибка
INSERT INTO profiles (user_id, main_photo_id, created_at, user_contacts)
SELECT 1, 3, now(), CAST('("55555", "dvbjngk@ghknm")' AS contacts);

-- успех
INSERT INTO profiles (user_id, main_photo_id, created_at, user_contacts)
SELECT 1, 1, now(), CAST('("55555", "dvbjngk@ghknm")' AS contacts);

-- представления
-- изменяемое
CREATE VIEW photo_view AS
SELECT *
FROM photo;

-- не изменяемое
CREATE VIEW photo_view_not_modified AS
WITH photos AS (
SELECT * FROM photo)
SELECT *
FROM photos;

-- проверка
SELECT * FROM photo_view ORDER BY id
SELECT * FROM photo_view_not_modified ORDER BY id

-- успех
UPDATE photo_view
SET description = description || '_added'
WHERE id < 10;

-- ошибка
UPDATE photo_view_not_modified
SET description = description || '_added'
WHERE id < 10;
