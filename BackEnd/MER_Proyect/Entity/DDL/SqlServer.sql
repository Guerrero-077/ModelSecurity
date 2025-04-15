CREATE DATABASE Piscicontrol;
GO
USE Piscicontrol;
GO

CREATE TABLE module
(
	[id] int IDENTITY(1,1) PRIMARY KEY,
	[name] Varchar(100) NOT NULL,
	[description] varchar(250),
	created_date DateTime DEFAULT CURRENT_TIMESTAMP,
	active bit,
	is_deleted bit
	
)

CREATE TABLE form
(
	[id] int IDENTITY(1,1) PRIMARY KEY,
	[name] varchar(100) NOT NULL,
	[description] NVARCHAR(MAX),
	created_date DateTime DEFAULT CURRENT_TIMESTAMP,
	active bit,
	is_deleted bit
)

CREATE TABLE permission 
(
	[id] INT IDENTITY(1,1) PRIMARY KEY,
	[name] varchar(100) NOT NULL,
	[description] NVARCHAR(MAX),
	active bit,
	is_deleted bit

)

CREATE TABLE rol
(
	[id] INT IDENTITY (1,1) PRIMARY KEY,
	[name] varchar(100) NOT NULL,
	[description] NVARCHAR(MAX),
	active bit,
	is_deleted bit

)

CREATE TABLE [user]
(
	[id] int IDENTITY(1,1) PRIMARY KEY,
	user_name VARCHAR(100) NOT NULL,
	email VARCHAR(100) NOT NULL UNIQUE, 
	[password] VARCHAR(100) NOT NULL,
	created_date DateTime DEFAULT CURRENT_TIMESTAMP,
	active bit,
	is_deleted bit,
	person_id int 

)
CREATE TABLE person
(
	[id] int IDENTITY(1,1) PRIMARY KEY,
	first_name VARCHAR(100) NOT NULL,
	last_name VARCHAR(100) NOT NULL, 
	phone_number VARCHAR(20) NOT NULL,
	active bit,
	is_deleted bit


)

-- Entidades Pivotes

CREATE TABLE form_module
(
	[id] int IDENTITY(1,1) PRIMARY KEY,
	module_id int,
	form_id int,
	is_deleted bit


)

CREATE TABLE rol_form_permission 
(
	[id] INT IDENTITY(1,1) PRIMARY KEY,
	rol_id INT,
	form_id INT, 
	permission_id INT,
	is_deleted bit

)

CREATE TABLE rol_user
(
	[id] int IDENTITY(1,1) PRIMARY KEY,
	rol_id int,
	user_id int,
	is_deleted bit

) 
-- Agregar Relaciones por medio de ALTER TABLE

-- form_module
ALTER TABLE form_module ADD CONSTRAINT FK_FormModule_Module FOREIGN KEY (module_id) REFERENCES module(id);
ALTER TABLE form_module ADD CONSTRAINT FK_FormModule_Form FOREIGN KEY (form_id) REFERENCES form(id);

-- rol_form_permission 
ALTER TABLE rol_form_permission ADD CONSTRAINT FK_RolFormPermission_Rol FOREIGN KEY (rol_id) REFERENCES rol(id);
ALTER TABLE rol_form_permission ADD CONSTRAINT FK_RolFormPermission_Form FOREIGN KEY (form_id) REFERENCES form(id);
ALTER TABLE rol_form_permission ADD CONSTRAINT FK_RolFormPermission_Permission FOREIGN KEY (permission_id) REFERENCES permission(id)

-- rol_user

ALTER TABLE rol_user ADD CONSTRAINT FK_RolUser_Rol FOREIGN KEY (rol_id) REFERENCES rol(id);
ALTER TABLE rol_user ADD CONSTRAINT FK_RolUser_User FOREIGN KEY (user_id) REFERENCES [user](id);

-- User 
ALTER TABLE [user] ADD CONSTRAINT FK_User_Person FOREIGN KEY (person_id) REFERENCES person(id) -- Relacion Uno a Uno