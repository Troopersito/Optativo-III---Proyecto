CREATE DATABASE SistemaBiblioteca;
USE SistemaBiblioteca;

CREATE TABLE USUARIOS(
id int auto_increment,
user VARCHAR(255) NOT NULL, 
password VARCHAR (255) NOT NULL,
primary key(id)
);
SELECT * FROM  USUARIOS;
 