CREATE ROLE serovf LOGIN;
ALTER ROLE serovf WITH PASSWORD '123';
CREATE ROLE belovr LOGIN;
ALTER ROLE belovr WITH PASSWORD '234';

CREATE ROLE analysts;
CREATE ROLE testers;

GRANT analysts TO serovf;
GRANT testers TO belovr;

GRANT SELECT ON ALL TABLES IN SCHEMA public TO analysts;
GRANT ALL ON ALL TABLES IN SCHEMA public TO testers;
GRANT ALL ON ALL SEQUENCES IN SCHEMA public TO testers;

-- проверка
psql -Userovf -d vk

select * from users u;

update users
set first_name = 'Shay'
where id = 1;

-- и аналогичные запросы для
psql -Ubelovr -d vk
