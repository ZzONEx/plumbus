/*
-----------����������� �������-----------

1) ������ �������� ������� �� ��:
DELETE FROM Pupil
WHERE id_pupil = <��_�������>

2) ���� ������ ������� ����, �� �� ��� ���������� ����������. 
������ �� ������� ���������, � ��������� ���. ������ � ������� ����������:
DELETE FROM Pupil
WHERE id = <��_�������>
INSERT INTO Employee (names) VALUES ('<���_���������>')

3) ������� ������ � ������ ������� � ��� ������ �� �� �������:
SELECT Pupil.id, username, password, mark 
FROM Pupil LEFT JOIN PupilMark
ON Pupil.id = PupilMark.id_pupil
LEFT JOIN Mark
ON PupilMark.id_mark = Mark.id
WHERE Pupil.id = <��_�������>

4) ������� �� ��������� � ���-�� ������������, ����������� ���������:
SELECT Employee.id, Employee.names, Plumbus.reject
FROM Employee LEFT JOIN Plumbus
ON Employee.id = Plumbus.creator
WHERE Employee.id = <��_����������>
*/