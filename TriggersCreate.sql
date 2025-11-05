CREATE TRIGGER T1 ON Waybill
AFTER Insert, Update 
AS
DECLARE @id int, @startdate date, @enddate date
SELECT @id = ID, @enddate = [Дата закрытия]
FROM inserted
IF EXISTS (SELECT * FROM Waybill WHERE ID = @id)
BEGIN
	SELECT @startdate = [Дата открытия]
	FROM Waybill
	WHERE ID = @id
	IF (@startdate > @enddate)
	BEGIN
	PRINT('Дата закрытия не может превышать дату открытия')
	ROLLBACK TRAN
	END
END
GO


CREATE TRIGGER T2 ON Orders
AFTER Insert
AS
DECLARE @driverID int, @bolnich varchar(17), @otpysk varchar(15), @yvolen varchar(10)
SELECT @driverID = Позывной
FROM inserted
SELECT @bolnich = [На больничном], @otpysk = [В отпуске], @yvolen = Уволен
FROM Drivers
WHERE ID = @driverID
IF ((@bolnich = 'На больничном') OR (@otpysk = 'В отпуске') OR (@yvolen = 'Уволен'))
BEGIN
PRINT('Этот водитель не может принять заказ')
ROLLBACK TRAN
END
GO

CREATE TRIGGER T3 ON Fines
AFTER Insert, Update
AS
DECLARE @id int, @narush date, @oplata date
SELECT @id = ID, @oplata = [Дата платежа]
FROM inserted
IF EXISTS (SELECT * FROM Fines WHERE ID = @id)
BEGIN 
	SELECT @narush = [Дата нарушения]
	FROM Fines
	WHERE ID = @id
	IF (@narush > @oplata)
	BEGIN
	PRINT('Дата нарушения не может быть больше, чем Дата оплаты')
	ROLLBACK TRAN
	END
END
GO

CREATE TRIGGER T4 ON Clients
INSTEAD OF Delete
AS
DECLARE @id int
SELECT @id = ID FROM deleted
IF EXISTS (SELECT * FROM Orders WHERE ID = @id)
BEGIN
DECLARE @orderID int, @callsign int, @callsignVar varchar(20), @clientFam varchar(20),
		@clientName varchar(20), @date date, @time time(0)
SELECT @clientFam = Фамилия, @clientName = Имя
FROM Clients 
WHERE ID = @id
PRINT('-------------------------------------------------------------------------------')
PRINT('Удаление клиента: ' + @clientFam + @clientName)
PRINT('Также приведет к удалению следующей информации из таблицы Заказы')
DECLARE C1 CURSOR SCROLL FOR SELECT ID, Позывной, [Дата получения], [Время полученя] FROM Orders 
WHERE Клиент = @id
OPEN C1
FETCH FIRST FROM C1 INTO @orderID, @callsign, @date, @time
WHILE @@FETCH_STATUS = 0
BEGIN
SELECT @callsignVar = Позывной
FROM CallSign
WHERE ID = @callsign
PRINT('Заказ №' + CONVERT(varchar(10), @orderID))
PRINT('Клиента вез "' + @callsignVar + '"')
PRINT('Дата и время ' + CONVERT(varchar(25), @date) + ' | ' + CONVERT(varchar(25), @time))
FETCH NEXT FROM C1 INTO @orderID, @callsign, @date, @time
END
PRINT('-------------------------------------------------------------------------------')
CLOSE C1
DEALLOCATE C1
DELETE FROM Accounts WHERE ID = @id
DELETE FROM Orders WHERE Клиент = @id
DELETE FROM Clients WHERE ID = @id
END
GO

CREATE TRIGGER T5 ON Drivers
INSTEAD OF Update
AS
DECLARE @id int, @olddStaj int, @newstaj int, @fam varchar(20), @name varchar(20),
		@otchestvo varchar(20), @sex varchar(7), @birthdate date, @phone varchar(11), 
		@dateIn date, @bolnich varchar(17), @otpysk varchar(15), @yvolen varchar(10), 
		@dateYvolen date
SELECT @id = ID, @fam = Фамилия, @name = Имя, @otchestvo = Отчество, @sex = Пол, 
	   @birthdate = [Дата рождения], @phone = Телефон, @dateIn = [Дата приема],
	   @newstaj = Стаж, @bolnich = [На больничном], @otpysk = [В отпуске],
	   @yvolen = Уволен, @dateYvolen = [Дата увольнения] 
FROM inserted
SELECT @olddStaj = Стаж
FROM Drivers
WHERE ID = @id
UPDATE Drivers SET Фамилия = @fam, Имя = @name, Отчество = @otchestvo,
	   Пол = @sex, [Дата рождения] = @birthdate, Телефон = @phone, [Дата приема] = @dateIn,
	   Стаж = @newstaj, [На больничном] = @bolnich, [В отпуске] = @otpysk,
	   Уволен = @yvolen, [Дата увольнения] = @dateYvolen
WHERE ID = @id
IF (@olddStaj > @newstaj)
BEGIN
PRINT('Нельзя уменьшить стаж работы')
UPDATE Drivers SET Стаж = @olddStaj
WHERE ID = @id
END
IF (@dateIn < @dateYvolen)
BEGIN
PRINT('Дата увольнения не может быть раньше, чем дата приема на работу')
PRINT('В качестве даты увольнения была установлена сегодняшняя дата')
UPDATE Drivers SET [Дата увольнения] = GETDATE()
WHERE ID = @id
END
IF (@yvolen = 'Уволен')
BEGIN
PRINT('Так как водитель |' + @fam + ' ' + @name + ' ' + @otchestvo +
'| уволен, система автоматически поменяла значения в полях:')
PRINT('[На больничном] на "Не на больничном"')
PRINT('[В отпуске] на "Не в отпуске"')
UPDATE Drivers SET [На больничном] = 'Не на больничном', [В отпуске] = 'Не в отпуске'
WHERE ID = @id
END
