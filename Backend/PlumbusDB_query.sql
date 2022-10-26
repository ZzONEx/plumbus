USE master
GO

--Удаляется существующая БД PlumbusDB--
IF EXISTS(SELECT name FROM master.sys.databases WHERE name = 'PlumbusDB')
BEGIN
	DROP DATABASE PlumbusDB
END

--Создается БД PlumbusDB--
CREATE DATABASE PlumbusDB
USE PlumbusDB
GO

--Создание таблиц--
CREATE TABLE Administrator(
id INT IDENTITY(1, 1) PRIMARY KEY,
username VARCHAR(30) NOT NULL,
password VARCHAR(20) NOT NULL,
);
CREATE TABLE Teacher(
id INT IDENTITY(1, 1) PRIMARY KEY,
username VARCHAR(30) NOT NULL,
password VARCHAR(20) NOT NULL,
);
CREATE TABLE Plant(
id INT IDENTITY(1, 1) PRIMARY KEY,
username VARCHAR(30) NOT NULL,
password VARCHAR(20) NOT NULL,
);
CREATE TABLE Employee(
id INT IDENTITY(1, 1) PRIMARY KEY,
names VARCHAR(255) NOT NULL,
);
CREATE TABLE Plumbus(
id INT IDENTITY(1, 1) PRIMARY KEY,
reject BIT NOT NULL,
creator INT NOT NULL,
);
CREATE TABLE Homework(
id INT IDENTITY(1, 1) PRIMARY KEY,
description VARCHAR(255) NOT NULL,
creation_time DATETIME NOT NULL,
);
CREATE TABLE Mark(
id INT IDENTITY(1, 1) PRIMARY KEY,
mark INT NOT NULL,
);
CREATE TABLE PupilMark(
id INT IDENTITY(1, 1) PRIMARY KEY, 
id_mark INT NOT NULL,
id_pupil INT NOT NULL,
);
CREATE TABLE Pupil(
id INT IDENTITY(1, 1) PRIMARY KEY,
username VARCHAR(30) NOT NULL,
password VARCHAR(20) NOT NULL,
pupil_group INT NOT NULL,
);
CREATE TABLE PupilGroup(
id INT IDENTITY(1, 1) PRIMARY KEY,
creation_date DATE NULL,
);

--Создание связей--
ALTER TABLE Plumbus 
ADD CONSTRAINT FK_PlumbusEmployee FOREIGN KEY (creator) REFERENCES Employee(id)
ON UPDATE CASCADE 
ON DELETE CASCADE;
ALTER TABLE Pupil
ADD CONSTRAINT FK_PupilPupilGroup FOREIGN KEY (pupil_group) REFERENCES PupilGroup(id)
ON UPDATE CASCADE 
ON DELETE CASCADE;
ALTER TABLE PupilMark
ADD CONSTRAINT FK_PupilMarkPupil FOREIGN KEY (id_pupil) REFERENCES Pupil(id)
ON UPDATE CASCADE 
ON DELETE CASCADE;
ALTER TABLE PupilMark
ADD CONSTRAINT FK_PupilMarkMark FOREIGN KEY (id_mark) REFERENCES Mark(id)
ON UPDATE CASCADE 
ON DELETE CASCADE;

--Создание триггера--
GO
CREATE TRIGGER set_datetime ON Homework
INSTEAD OF INSERT
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO Homework (description, creation_time) 
	VALUES ((SELECT description FROM inserted), CONVERT(smalldatetime, GETDATE()));
END
GO

PRINT '---------------------------------------'
PRINT '	  БД PlumbusDB успешно создана'
PRINT '---------------------------------------'