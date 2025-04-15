CREATE TABLE "user"
(
	id SERIAL PRIMARY KEY,
	user_name VARCHAR(100) nOT NULL ,
	email VARCHAR(100) NOT NULL UNIQUE,
	password VARCHAR(100) NOT NULL,
	created_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
	active BOOLEAN,
	is_deleted BOOLEAN,
	person_id INT UNIQUE
);

CREATE TABLE person
(
	id SERIAL PRIMARY KEY,
	first_name VARCHAR(100) NOT NULL,
	last_name VARCHAR(100) NOT NULL,
	phone_number VARCHAR(20) NOT NULL,
	active BOOLEAN,
	is_deleted BOOLEAN
);

CREATE TABLE rol_user
(
	id SERIAL PRIMARY KEY,
	rol_id INT,
	user_id INT,
	is_deleted BOOLEAN
);

CREATE TABLE rol
(
	id SERIAL PRIMARY KEY,
	name VARCHAR(100) NOT NULL,
	description TEXT,
	active BOOLEAN,
	is_deleted BOOLEAN
);

CREATE TABLE rol_form_permission
(
	id SERIAL PRIMARY KEY,
	rol_id INT,
	form_id INT,
	permission_id INT,
	is_deleted BOOLEAN
);

CREATE TABLE permission
(
	id SERIAL PRIMARY KEY,
	name VARCHAR(100) NOT NULL,
	description TEXT,
	active BOOLEAN,
	is_deleted BOOLEAN
);

CREATE TABLE form
(
	id SERIAL PRIMARY KEY,
	name VARCHAR(100) NOT NULL,
	description TEXT,
	created_Date TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
	active BOOLEAN,
	is_deleted BOOLEAN
);

CREATE TABLE form_module
(
	id SERIAL PRIMARY KEY,
	module_id INT,
	form_id INT,
	is_deleted BOOLEAN
);

CREATE TABLE module
(
	id SERIAL PRIMARY KEY,
	name VARCHAR(100) NOT NULL,
	description TEXT,
	created_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
	active BOOLEAN,
	is_deleted BOOLEAN
);



-- Relaciones

-- User - Person
ALTER TABLE "user" ADD CONSTRAINT FK_User_Person FOREIGN KEY (person_id) REFERENCES person(id);



-- RolUser - User - Rol
ALTER TABLE rol_user ADD CONSTRAINT FK_RolUser_User FOREIGN KEY (user_id) REFERENCES "user"(id);
ALTER TABLE rol_user ADD CONSTRAINT FK_RolUser_Rol FOREIGN KEY (rol_id) REFERENCES rol(id);


-- FormModule - Module -  Form

ALTER TABLE form_module ADD CONSTRAINT FK_FormModule_Module FOREIGN KEY (module_id) REFERENCES module(id);
ALTER TABLE form_module ADD CONSTRAINT FK_FormModule_Form FOREIGN KEY (form_id) REFERENCES form(id);

-- RolFormPermission - Rol- Form- permission

ALTER TABLE rol_form_permission ADD CONSTRAINT FK_RolFormPermission_Rol FOREIGN KEY (rol_id) REFERENCES rol(id);
ALTER TABLE rol_form_permission ADD CONSTRAINT FK_RolFormPermission_Form FOREIGN KEY (form_id) REFERENCES form(id);
ALTER TABLE rol_form_permission ADD CONSTRAINT FK_RolFormPermission_Permission FOREIGN KEY (permission_id) REFERENCES permission(id);