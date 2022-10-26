/*
-----------Техническое Задание-----------

1) Полное удаление ученика из БД:
DELETE FROM Pupil
WHERE id_pupil = <ИД_Ученика>

2) Если ученик экзамен сдал, то он уже становится работником. 
Данные об ученике удаляются, и создается доп. строка в таблице работников:
DELETE FROM Pupil
WHERE id = <ИД_Ученика>
INSERT INTO Employee (names) VALUES ('<Имя_Работника>')

3) Выборка логина и пароля Ученика и его оценки по ИД Ученика:
SELECT Pupil.id, username, password, mark 
FROM Pupil LEFT JOIN PupilMark
ON Pupil.id = PupilMark.id_pupil
LEFT JOIN Mark
ON PupilMark.id_mark = Mark.id
WHERE Pupil.id = <ИД_Ученика>

4) Выборка ИД Работника и кол-во произведённых, бракованных плюмбусов:
SELECT Employee.id, Employee.names, Plumbus.reject
FROM Employee LEFT JOIN Plumbus
ON Employee.id = Plumbus.creator
WHERE Employee.id = <ИД_Сотрудника>
*/