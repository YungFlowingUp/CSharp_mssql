CREATE PROC P1 (@login varchar(15), @pass varchar(15), @rval int OUTPUT, @id int OUTPUT)
AS
DECLARE @realPass varchar(20)
IF NOT EXISTS (SELECT * FROM Accounts WHERE Логин = @login)
BEGIN
SET @rval = 2
PRINT('Такого логина не существует')
END
IF EXISTS (SELECT * FROM Accounts WHERE Логин = @login)
BEGIN
	SELECT @id = ID, @realPass = Пароль
	FROM Accounts 
	WHERE Логин = @login
IF (@realPass = @pass)
BEGIN
SET @rval = 1
PRINT('Вы успешно авторизированы')
END
ELSE 
BEGIN
SET @rval = 0
PRINT('Пароль не верный')
END
END
GO

CREATE PROC P2 (@login varchar(15), @er int OUTPUT)
AS
IF EXISTS (SELECT * FROM Accounts WHERE Логин = @login)
BEGIN
	SELECT Пароль, [Секретный вопрос], [Секретный ответ]
	FROM Accounts
	WHERE Логин = @login
SET @er = 0
END
ELSE
SET @er = 1
GO


CREATE PROC P3 (@login varchar(15), @pass varchar(15), @quest varchar(30),
				@answer varchar(15), @fam varchar(20), @name varchar(20),
				@otchestvo varchar(20), @sex varchar(7), @date date,
				@phone varchar(11), @er int OUTPUT, @id int OUTPUT)
AS
IF EXISTS (SELECT * FROM Accounts WHERE Логин = @login)
BEGIN
SET @er = 0
PRINT ('Такой логин уже существует')
END
IF EXISTS (SELECT * FROM Clients WHERE Телефон = @phone)
BEGIN
SET @er = 1
PRINT ('Такой телефон уже существует')
END
BEGIN
INSERT INTO Accounts VALUES
	(@login, @pass, @quest, @answer)
INSERT INTO Clients VALUES
	(@fam, @name, @otchestvo, @sex, @date, @phone)
SELECT @id = @@IDENTITY
SET @er = 2
PRINT('Успешная решистрация!')
END
GO

CREATE PROC P4 (@call varchar(15), @id int OUTPUT, @er int OUTPUT)
AS
IF NOT EXISTS (SELECT * FROM CallSign WHERE Позывной = @call)
SET @er = 0
ELSE
BEGIN
SELECT @id = ID
FROM CallSign
WHERE Позывной = @call
SET @er = 1
END
GO

CREATE PROC P5 (@id int OUTPUT, @clientid int, @callsign int,
				@outcity varchar(20), @outstreet varchar(20),
				@outhouse int,  @incity varchar(20), @instreet varchar(20),
				@inhouse int, @comment varchar(60), 
				@wayid int OUTPUT)
AS
DECLARE @stat varchar(11), @status varchar(11), @date date, @time time(0),
@waydateend date
SET @date = GETDATE()
SET @time = CONVERT(time(0), GETDATE(), 108)
SET @status = 'В процессе'
INSERT INTO Orders VALUES
	(@clientid, @callsign, @status, @date, @time, @outcity, @outstreet,
	 @outhouse, @incity, @instreet, @inhouse, @comment)
SELECT @id = @@IDENTITY
SELECT @wayid = ID, @waydateend = [Дата закрытия]
FROM Waybill
WHERE Позывной = @callsign AND [Дата открытия] = (SELECT TOP (1) [Дата открытия]
												  FROM Waybill
												  WHERE Позывной = @callsign
												  ORDER BY [Дата открытия] DESC)
IF (@waydateend IS NOT NULL)
BEGIN
INSERT INTO Waybill VALUES
	(@callsign, @date, @time, null, null, default, null)
SET @wayid = @@IDENTITY
END
GO

CREATE PROC neword (@orderid int OUTPUT, @clientid int,
				@outcity varchar(20), @outstreet varchar(20),
				@outhouse int,  @incity varchar(20), @instreet varchar(20),
				@inhouse int, @comment varchar(60), @callsign int)
AS
DECLARE @date date, @time time
SET @date = GETDATE()
SET @time = CONVERT(time(0), GETDATE(), 108)
INSERT INTO Orders VALUES 
	(@callsign, @clientid, 'Выполнен', @date, @time, @outcity, @outstreet, @outhouse,
	@incity, @instreet, @inhouse, @comment)
SET @orderid = @@IDENTITY
GO

CREATE PROC completedrive (@callsign int)
AS
DECLARE @tempid int, @kolvo int, @money money
SELECT @tempid = MAX(ID)
FROM Waybill
WHERE Позывной = @callsign
SELECT @kolvo = [Количество выполненных заказов], @money = [Оплата работы]
FROM Waybill
WHERE ID = @tempid
UPDATE Waybill SET [Количество выполненных заказов] = @kolvo + 1, [Оплата работы] = @money + 600
WHERE ID = @tempid
GO

CREATE PROC stopdrive (@orderid int)
AS
UPDATE Orders SET Статус = 'Отменен' WHERE ID = @orderid-1
GO

CREATE PROC TakeOrder(@id int OUTPUT, @clientid int,
				@outcity varchar(20), @outstreet varchar(20),
				@outhouse int,  @incity varchar(20), @instreet varchar(20),
				@inhouse int, @comment varchar(60), @orderid int OUTPUT)
AS
DECLARE @callsign int, @date date, @time time(0), @waybilldate date, @tempid int
SET @date = GETDATE()
SET @time = CONVERT(time(0), GETDATE(), 108)
SELECT TOP (1) @callsign = ID 
FROM Drivers
WHERE [На больничном] = 'Не на больничном' AND 
	  [В отпуске] = 'Не в отпуске' AND
	  Уволен = 'Не уволен' AND
	  ID IN (SELECT ID
			FROM CallSign
			WHERE [Гос. номер] IN (SELECT [Гос. номер]
								   FROM Cars
								   WHERE [В ремонте] = 'Нет')) AND
	  ID IN (SELECT Позывной
			 FROM Orders
			 WHERE Статус <> 'В процессе')
ORDER BY ID DESC
INSERT INTO Orders VALUES 
	(@callsign, @clientid, 'В процессе', @date, @time, @outcity, @outstreet, @outhouse,
	@incity, @instreet, @inhouse, @comment)
SET @orderid = @@IDENTITY
SELECT @tempid = ID, @waybilldate = [Дата закрытия]
FROM Waybill
WHERE Позывной = @callsign AND ID = (SELECT MAX(ID)
									 FROM Waybill
									 WHERE Позывной = @callsign) 
IF(@waybilldate IS NULl)
SET @id = @tempid
IF(@date IS NOT NULL)
BEGIN
INSERT INTO Waybill VALUES
	(@callsign, @date, @time, null, null, default, null)
SET @id = @@IDENTITY
END
GO


CREATE PROC P5Finding (@id int OUTPUT)
AS
SELECT TOP (1) ID 
FROM Drivers
WHERE [На больничном] = 'Не на больничном' AND 
	  [В отпуске] = 'Не в отпуске' AND
	  Уволен = 'Не уволен' AND
	  ID IN (SELECT ID
			FROM CallSign
			WHERE [Гос. номер] IN (SELECT [Гос. номер]
								   FROM Cars
								   WHERE [В ремонте] = 'Нет')) AND
	  ID IN (SELECT Позывной
			 FROM Orders
			 WHERE Статус <> 'В процессе')
ORDER BY ID DESC
GO


CREATE PROC P6 (@wayid int, @orderid int)
AS
DECLARE @cof float, @money money, @staj int, @temp int,
@oldmoney money, @oldkolvo int, @oderid int, @callsign int
SET @temp = FLOOR(RAND()*(1000-400)+400)
SELECT @callsign = Позывной FROM Waybill WHERE ID = @wayid
UPDATE Orders SET Статус = 'Выполнен' WHERE ID = @orderid
SELECT @staj = Стаж FROM Drivers WHERE ID = @callsign
SELECT @cof = Ставка FROM WorkExperience WHERE ID = @staj
SET @money = @temp * @cof
SELECT @oldmoney = [Оплата работы], @oldkolvo = [Количество выполненных заказов] 
FROM Waybill WHERE ID = @wayid
UPDATE Waybill SET [Оплата работы] = @oldmoney + @money, 
				   [Количество выполненных заказов] = @oldkolvo + 1 
WHERE ID = @wayid 
GO

CREATE PROC P6Stop (@orderid int)
AS
UPDATE Orders SET Статус = 'Отменен' WHERE ID = @orderid
GO

CREATE PROC P7 (@clientid int)
AS
DECLARE @fam varchar(20), @name varchar(20), 
		@otch varchar(20), @sex varchar(7), @birth date, 
		@phone varchar(11), @idcallsign int, @callsign varchar(15),
		@orderid int, @status varchar(11), @date date, @time time(0),
		@outcity varchar(20), @outstreet varchar(20),
		@outhouse int,  @incity varchar(20), @instreet varchar(20),
		@inhouse int, @comment varchar(60), @idtemp int, 
		@goodcounter int, @badcounter int, @inprogcounter int
SET @goodcounter = 0
SET @badcounter = 0
SET @inprogcounter = 0
SELECT @fam = Фамилия, @name = Имя, @otch = Отчество,
	   @sex = Пол, @birth = [Дата рождения], @phone = Телефон
FROM Clients
WHERE ID = @clientid
PRINT('-------------------------Данные клиента-------------------------')
PRINT('Клиент ' + @fam + ' ' + @name + ' '  + @otch)
PRINT('Пол    ' + @sex + '   Дата рождения ' + CONVERT(varchar(20), @birth))
PRINT('Контактный номер (+' + CONVERT(varchar(15), @phone + ')'))
PRINT('-------------------------Данные клиента-------------------------')
DECLARE C1 CURSOR SCROLL FOR SELECT * FROM Orders WHERE Клиент = @clientid
OPEN C1
FETCH FIRST FROM C1 INTO @orderid, @idcallsign, @idtemp, @status, @date, @time,
						 @outcity, @outstreet, @outhouse, @incity, @instreet,
						 @inhouse, @comment						  
WHILE @@FETCH_STATUS = 0
BEGIN
PRINT('~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~')
SELECT @callsign = Позывной FROM CallSign WHERE ID = @idcallsign  
PRINT('Позывной водителя - ' + @callsign)
PRINT('Статус заказа - ' + @status)
PRINT('Дата и время ' + CONVERT(varchar(25), @date) + ' | ' + CONVERT(varchar(25), @time))
PRINT('Точка отправления г.' + @outcity + ' ул.' + @outstreet + ' д.' + CONVERT(varchar(5), @outhouse))
PRINT('Точка назначения  г.' + @incity + ' ул.' + @instreet + ' д.' + CONVERT(varchar(5), @inhouse))
IF (@comment IS NOT NULL)
PRINT('Доп информация "' + @comment + '"')
IF (@status = 'Выполнен')
SET @goodcounter = @goodcounter + 1
IF (@status = 'Отменен')
SET @badcounter = @badcounter + 1
IF (@status = 'В процессе')
SET @inprogcounter = @inprogcounter + 1
FETCH NEXT FROM C1 INTO @orderid, @idcallsign, @idtemp, @status, @date, @time,
						 @outcity, @outstreet, @outhouse, @incity, @instreet,
						 @inhouse, @comment
END
CLOSE C1
DEALLOCATE C1
PRINT('~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~')
PRINT('')
PRINT('--------------------ИТОГИ--------------------')
PRINT('Количество успешно выполненных поездок ' + CONVERT(varchar(5), @goodcounter) + '!')
PRINT('Количество отмененных поездок ' + CONVERT(varchar(5), @badcounter))
IF (@inprogcounter <> 0)
PRINT('Вы сейчас едете в нашем такси!')
PRINT('--------------------ИТОГИ--------------------')
GO

CREATE PROC P8switch (@driverID int, @id int OUTPUT, @er int OUTPUT)
AS
DECLARE @date date
SELECT @id = ID, @date = [Дата закрытия]
FROM Waybill
WHERE Позывной = @driverID AND ID = (SELECT MAX(ID)
									 FROM Waybill
									 WHERE Позывной = @driverID)
IF(@date IS NULl)
SET @er = 0
IF(@date IS NOT NULL)
SET @er = 1
GO

CREATE PROC P8 (@driverID int, @id int, @er int, @newer int OUTPUT)
AS
DECLARE @date date, @time time(0)
SET @date = GETDATE()
SET @time = CONVERT(time(0), GETDATE(), 108)
IF (@er = 0)
BEGIN
UPDATE Waybill SET [Дата закрытия] = @date, [Время закрытия] = @time WHERE ID = @id
SET @newer = 1
END
IF (@er <> 0)
BEGIN
INSERT INTO Waybill VALUES (@driverID, @date, @time, null, null, default, null)
SET @newer = 0
END
GO

CREATE PROC P9 (@id int, @phone varchar(11), @nabol varchar(17), @otpysk varchar(15), 
				@yvolen varchar(10))
AS
DECLARE @date date
SELECT @date = [Дата увольнения]
FROM Drivers
WHERE ID = @id
IF (@yvolen = 'Уволен' AND @date IS NULL)
BEGIN
SET @date = GETDATE()
UPDATE Drivers SET Телефон = @phone, [На больничном] = @nabol,
				   [В отпуске] = @otpysk, Уволен = @yvolen,
				   [Дата увольнения] = @date WHERE ID = @id
END
ELSE
UPDATE Drivers SET Телефон = @phone, [На больничном] = @nabol,
				   [В отпуске] = @otpysk, Уволен = @yvolen
				   WHERE ID = @id
GO

CREATE PROC P10 (@gosnomer varchar(9))
AS
SELECT [Гос. номер], Класс, [Дата последнего тех. обслуживания], [В ремонте]
FROM Cars
WHERE [Гос. номер] = @gosnomer
GO

CREATE PROC P11 (@gosnomer varchar(9), @class int, @remont varchar(3))
AS
DECLARE @date date, @temp varchar(3)
SELECT @temp = [В ремонте]
FROM Cars
WHERE [Гос. номер] = @gosnomer
IF (@temp = 'Да' AND @remont = 'Нет')
BEGIN
SET @date = GETDATE()
UPDATE Cars SET Класс = @class, [Дата последнего тех. обслуживания] = @date,
				[В ремонте] = @remont WHERE [Гос. номер] = @gosnomer
END
ELSE
UPDATE Cars SET Класс = @class, [В ремонте] = @remont WHERE [Гос. номер] = @gosnomer
GO

CREATE PROC P12upd (@id int, @narush varchar(40), @cost money, @status varchar(3))
AS
DECLARE @date date, @temp varchar(3)
SELECT @temp = Оплачен
FROM Fines
WHERE ID = @id
IF (@temp = 'Нет' AND @status = 'Нет')
UPDATE Fines SET Стоимость = @cost, Оплачен = @status, Нарушение = @narush WHERE ID = @id
ELSE
SET @date = GETDATE()
UPDATE Fines SET Стоимость = @cost, Оплачен = @status, 
				 [Дата платежа] = @date, Нарушение = @narush WHERE ID = @id
GO

CREATE PROC P12ins (@callsign int, @gosnomer varchar(9), @narush varchar(40),
					@cost money, @datenarush date, @timenarush time(0),
					@status varchar(3), @dateplatej date)
AS
INSERT INTO Fines VALUES
	(@callsign, @gosnomer, @narush, @cost, @datenarush, @timenarush, @status, @dateplatej)
GO

CREATE PROC P14 (@callsign int, @ptc varchar(13), @vod varchar(10))
AS
UPDATE CallSign SET [Страховой номер машины] = @ptc,
					[Водительское удостоверение] = @vod
					WHERE ID = @callsign
GO

CREATE PROC incur 
AS
DECLARE @classid int, @class varchar(15), @cof float
DECLARE @gosnomer varchar(9), @marka varchar(15), @model varchar(20),
		@color varchar(15), @year int, @ptc varchar(10), 
		@dateteh date, @remont varchar(3), @tempclass int
DECLARE @counter int
DECLARE C1 CURSOR SCROLL FOR SELECT * FROM Classes 
PRINT('---------------------------------------------------')
OPEN C1
FETCH FIRST FROM C1 INTO @classid, @class, @cof
WHILE @@FETCH_STATUS = 0
BEGIN
SET @counter = 0
PRINT('Код класса "' + CONVERT(varchar(3), @classid) + '"')
PRINT('Название класса "' + @class + '"')
PRINT('Коэфициент класса "' + CONVERT(varchar(8), @cof) + '"')
PRINT('~~~~~~~~~~~~~~~ Машины класса ' + @class + ' ~~~~~~~~~~~~~~')
DECLARE C2 CURSOR SCROLL FOR SELECT * FROM Cars WHERE Класс = @classid
OPEN C2
FETCH FIRST FROM C2 INTO @gosnomer, @marka, @model, @color,
						 @tempclass, @year, @ptc, @dateteh, @remont
WHILE @@FETCH_STATUS = 0
BEGIN
SET @counter = @counter + 1
PRINT(' !Машина №' + CONVERT(varchar(2), @counter) + ' в этом классе!')
PRINT('Гос. номер машины [' + @gosnomer + ']')
PRINT('Марка ' + @marka + ' | Модель ' + @model)
PRINT('Цвет ' + @color + ' | Год выпуска ' + CONVERT(varchar(5), @year))
PRINT('ПТС ['+ @ptc + ']')
PRINT('Дата последнего тех. обслуживания ' + CONVERT(varchar(16), @dateteh))
IF(@remont = 'Да')
PRINT('В данный момент находится на ремонте')
PRINT('')
FETCH NEXT FROM C2 INTO @gosnomer, @marka, @model, @color,
						@tempclass, @year, @ptc, @dateteh, @remont
END
CLOSE C2
DEALLOCATE C2
PRINT('~~~~~~~~~~~~~~~ Машины класса ' + @class + ' ~~~~~~~~~~~~~~')
FETCH NEXT FROM C1 INTO @classid, @class, @cof
END
CLOSE C1
DEALLOCATE C1
PRINT('---------------------------------------------------')
GO

CREATE PROC curcur
AS
DECLARE @driverid int, @fam varchar(20), @name varchar(20),
		@otchestvo varchar(20), @staj int, @sex varchar(7), 
		@birthdate date, @phone varchar(11), @dateIn date, 
		@bolnich varchar(17), @otpysk varchar(15), 
		@yvolen varchar(10), @dateYvolen date
DECLARE @fineid int, @callsign int, @gosnomer varchar(9), @narush varchar(40),
		@money money, @datenarush date, @timenarush time(0), @oplachen varchar(3),
		@dateoplachen date
DECLARE @counter int
DECLARE C1 CURSOR SCROLL FOR SELECT * FROM Drivers 
PRINT('---------------------------------------------------')
OPEN C1
FETCH FIRST FROM C1 INTO @driverid, @fam, @name, @otchestvo, 
					     @staj, @sex, @birthdate, @phone, @dateIn,
						 @bolnich, @otpysk, @yvolen, @dateYvolen
WHILE @@FETCH_STATUS = 0
BEGIN
PRINT('Код водителя "' + CONVERT(varchar(3), @driverid) + '"')
PRINT('Фамилия ' + @fam)
PRINT('Имя ' + @name)
IF(@otchestvo IS NOT NULL)
PRINT('Отчетсво ' + @otchestvo)
PRINT('Стаж ' + CONVERT(varchar(3), @staj))
PRINT('Пол ' + @sex + ' | Дата рождения ' + CONVERT(varchar(15), @birthdate))
PRINT('Контактный номер ' + @phone)
IF(@bolnich = 'На больничном')
PRINT('В данный момент на больничном')
IF(@otpysk = 'В отпуске')
PRINT('В данный момент в отпуске')
IF(@yvolen = 'Уволен')
PRINT('Уволен | Дата увольнения ' + CONVERT(varchar(15), @dateYvolen))
PRINT('~~~~~~~~~~~~~~~~~ Штрафы ~~~~~~~~~~~~~~~~~')
SET @counter = 0
DECLARE C2 CURSOR SCROLL FOR SELECT * FROM Fines WHERE Позывной = @driverid
OPEN C2
FETCH FIRST FROM C2 INTO @fineid, @callsign, @gosnomer, @narush, 
					     @money, @datenarush, @timenarush, @oplachen,
						 @dateoplachen
WHILE @@FETCH_STATUS = 0
BEGIN
IF (@fineid IS NOT NULL)
BEGIN
SET @counter = @counter + 1
PRINT('Код штрафа "' + CONVERT(varchar(3), @fineid) + '"')
PRINT('Гос. номер машины [' + @gosnomer + ']')
PRINT('-------------Нарушение-------------')
PRINT(@narush)
PRINT('-------------Нарушение-------------')
PRINT('Стоимость ' + CONVERT(varchar(15), @money) + 'руб.')
PRINT('Дата нарушения ' + CONVERT(varchar(15), @datenarush) 
	  + ' | Время ' + CONVERT(varchar(15), @timenarush))
IF(@oplachen = 'Да')
PRINT('Оплачен датой ' + CONVERT(varchar(15), @dateoplachen))
END
ELSE
PRINT('------------- Штрафов нет -------------')
FETCH NEXT FROM C2 INTO @fineid, @callsign, @gosnomer, @narush, 
					     @money, @datenarush, @timenarush, @oplachen,
						 @dateoplachen
END
PRINT('----- Суммарное колличество штрафов {' + CONVERT(varchar(3), @counter) + '} -----')
PRINT('~~~~~~~~~~~~~~~~~ Штрафы ~~~~~~~~~~~~~~~~~')
CLOSE C2
DEALLOCATE C2
FETCH NEXT FROM C1 INTO @driverid, @fam, @name, @otchestvo, 
					     @staj, @sex, @birthdate, @phone, @dateIn,
						 @bolnich, @otpysk, @yvolen, @dateYvolen
END
PRINT('---------------------------------------------------')
CLOSE C1
DEALLOCATE C1
GO

CREATE PROC wrkexp
AS
DECLARE @wrkid int, @wrkname varchar(11), @staj int, @cof float
DECLARE @driverid int, @fam varchar(20), @name varchar(20),
		@otchestvo varchar(20), @tempstaj int, @sex varchar(7), 
		@birthdate date, @phone varchar(11), @dateIn date, 
		@bolnich varchar(17), @otpysk varchar(15), 
		@yvolen varchar(10), @dateYvolen date
DECLARE @date date, @time time(0), @status varchar(15)
DECLARE C1 CURSOR SCROLL FOR SELECT * FROM WorkExperience 
PRINT('---------------------------------------------------')
OPEN C1
FETCH FIRST FROM C1 INTO @wrkid, @wrkname, @staj, @cof
WHILE @@FETCH_STATUS = 0
BEGIN
PRINT('~~~~~~~~~~~~~ Код стажа №' + CONVERT(varchar(3), @wrkid) + ' ~~~~~~~~~~~~~')
PRINT('Название ' + @wrkname)
PRINT('Стаж в годах [' + CONVERT(varchar(3), @staj) + ']')
PRINT('Коэффициент оплаты {' + CONVERT(varchar(10), @cof) + '}')
PRINT('----- Водители со стажем [' + CONVERT(varchar(3), @staj) + '] -----')
DECLARE C2 CURSOR SCROLL FOR SELECT * FROM Drivers WHERE Стаж = @wrkid 
OPEN C2
FETCH FIRST FROM C2 INTO @driverid, @fam, @name, @otchestvo, 
					     @tempstaj, @sex, @birthdate, @phone, @dateIn,
						 @bolnich, @otpysk, @yvolen, @dateYvolen
WHILE @@FETCH_STATUS = 0
BEGIN
PRINT('Фамилия ' + @fam)
PRINT('Имя ' + @name)
IF(@otchestvo IS NOT NULL)
PRINT('Отчетсво ' + @otchestvo)
PRINT('Стаж ' + CONVERT(varchar(3), @staj))
PRINT('Пол ' + @sex + ' | Дата рождения ' + CONVERT(varchar(15), @birthdate))
PRINT('Контактный номер ' + @phone)
PRINT('------- Краткая информация о заказах -------')
DECLARE C3 CURSOR SCROLL FOR SELECT [Дата получения], [Время полученя], Статус 
FROM Orders WHERE Позывной = @driverid
OPEN C3
FETCH FIRST FROM C3 INTO @date, @time, @status
WHILE @@FETCH_STATUS = 0
BEGIN
PRINT('Дата ' + CONVERT(varchar(15), @date) + ' | Время ' + CONVERT(varchar(15), @time))
PRINT('Статус {' + @status + '}')
FETCH NEXT FROM C3 INTO @date, @time, @status
END
CLOSE C3
DEALLOCATE C3
FETCH NEXT FROM C2 INTO @driverid, @fam, @name, @otchestvo, 
					     @tempstaj, @sex, @birthdate, @phone, @dateIn,
						 @bolnich, @otpysk, @yvolen, @dateYvolen
END
CLOSE C2
DEALLOCATE C2
PRINT('~~~~~~~~~~~~~ Код стажа №' + CONVERT(varchar(3), @wrkid) + ' ~~~~~~~~~~~~~')
FETCH NEXT FROM C1 INTO @wrkid, @wrkname, @staj, @cof
PRINT('')
END
PRINT('---------------------------------------------------')
CLOSE C1
DEALLOCATE C1
GO

CREATE PROC cls
AS
DECLARE @clientid int, @fam varchar(20), @name varchar(20),
		@otch varchar(20), @sex varchar(10), @birthdate date,
		@phone varchar(11)
DECLARE @status varchar(11), @date date, @time time(0)
DECLARE @gcounter int, @bcounter int
DECLARE C1 CURSOR SCROLL FOR SELECT * FROM Clients 
PRINT('---------------------------------------------------')
OPEN C1
FETCH FIRST FROM C1 INTO @clientid, @fam, @name, @otch,
						 @sex, @birthdate, @phone
WHILE @@FETCH_STATUS = 0
BEGIN
PRINT('~~~~~~~~~~~~ Клиент №' + CONVERT(varchar(3), @clientid) + ' ~~~~~~~~~~~~')
PRINT('Фамилия ' + @fam + ' Имя ' + @name)
IF(@otch IS NOT NULL)
PRINT('Отчество ' + @otch)
IF(@sex IS NOT NULL)
PRINT('Пол ' + @sex)
PRINT('Дата рождения ' + CONVERT(varchar(15), @birthdate))
PRINT('Телефон (+' + @phone + ')')
PRINT('--- Краткая информация о заказах ---')
SET @gcounter = 0
SET @bcounter = 0
DECLARE C2 CURSOR SCROLL FOR SELECT Статус, [Дата получения], [Время полученя] 
FROM Orders WHERE Клиент = @clientid 
OPEN C2
FETCH FIRST FROM C2 INTO @status, @date, @time
WHILE @@FETCH_STATUS = 0
BEGIN
PRINT('Дата ' + CONVERT(varchar(15), @date) + ' | Время ' + CONVERT(varchar(15), @time))
PRINT('Статус поездки {' + @status + '}')
IF (@status = 'Выполнен')
SET @gcounter = @gcounter + 1
IF(@status = 'Отменен')
SET @bcounter = @bcounter + 1
FETCH NEXT FROM C2 INTO @status, @date, @time
END
PRINT('--- Краткая информация о заказах ---')
PRINT('У клиента ' + @name + ' ' + @fam)
PRINT('Колличество успешных заказов')
PRINT('############# ' + CONVERT(varchar(3), @gcounter) + ' #############')
PRINT('Колличество отменных заказов')
PRINT('############# ' + CONVERT(varchar(3), @bcounter) + ' #############')
PRINT('')
CLOSE C2
DEALLOCATE C2
PRINT('~~~~~~~~~~~~ Клиент №' + CONVERT(varchar(3), @clientid) + ' ~~~~~~~~~~~~')
FETCH NEXT FROM C1 INTO @clientid, @fam, @name, @otch,
						 @sex, @birthdate, @phone
END
PRINT('---------------------------------------------------')
CLOSE C1
DEALLOCATE C1
GO

