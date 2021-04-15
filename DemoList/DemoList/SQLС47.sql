DECLARE @Colors TABLE(Name nvarchar(20))
INSERT INTO @Colors
VALUES ('green'),
('black'),
('yellow'),
('blue'),
('white'),
('red'),
('brown')


/*
	Я не додумалась и взяла решение отсюда: https://ru.stackoverflow.com/questions/1254665/
	Решение основано на идее, что А>B>C
*/

SELECT t1.Name color1, 
       t2.Name color2, 
       t3.Name color3, 
       t4.Name color4
FROM @Colors t1
JOIN @Colors t2 ON t2.Name > t1.Name
JOIN @Colors t3 ON t3.Name > t2.Name
JOIN @Colors t4 ON t4.Name> t3.Name;

