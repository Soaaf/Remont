

SELECT n_avto, avg(sum) FROM Remont GROUP BY n_avto HAVING COUNT(*)>1

