-- Создать пользовательскую функцию

-- функция возвращает true если входящий идентификатор шахты это идентификатор шахты Кузбасс
CREATE FUNCTION is_kuzbass_fn(mine_id INT)
RETURNS BOOLEAN AS $$
	BEGIN
		RETURN EXISTS(SELECT FROM mines m WHERE m.id = mine_id AND m."name" = 'Кузбасс');
	END;
$$ LANGUAGE PLPGSQL;
