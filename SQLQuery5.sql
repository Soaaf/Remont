SELECT * FROM Remont WHERE n_mast IN
(SELECT n_mast FROM Master WHERE fio LIKE N'%Олейник%')