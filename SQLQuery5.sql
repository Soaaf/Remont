SELECT * FROM Remont WHERE n_mast IN
(SELECT n_mast FROM Master WHERE n_mast = 1)