CREATE TABLE profiles (
	id serial PRIMARY KEY,
	user_id INT NOT NULL,
	main_photo_id INT,
	created_at TIMESTAMP,
	user_contacts contacts
);

ALTER TABLE profiles
ADD CONSTRAINT profiles_user_id_fk
FOREIGN KEY (user_id)
REFERENCES users (id);

ALTER TABLE profiles
ADD CONSTRAINT profiles_main_photo_id_fk
FOREIGN KEY (main_photo_id)
REFERENCES photo (id);

INSERT INTO profiles (user_id, main_photo_id, created_at, user_contacts)
SELECT id, main_photo_id, created_at, user_contacts
FROM users;

ALTER TABLE users DROP COLUMN main_photo_id;
ALTER TABLE users DROP COLUMN created_at;
ALTER TABLE users DROP COLUMN user_contacts;
