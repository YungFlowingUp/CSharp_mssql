USE Taxi;

CREATE TYPE staj_type 
FROM varchar(11)
GO

CREATE TYPE status_type 
FROM varchar(11)
GO

CREATE RULE staj_type_rule AS
@value in ('Стажер', 'Новичок', 'Бронзовый',
'Серебряный', 'Золотой', 'Платиновый')
GO
EXEC sp_bindrule staj_type_rule, staj_type 
GO

CREATE RULE status_type_rule AS
@value in ('Выполнен', 'В процессе', 'Отменен')
GO
EXEC sp_bindrule status_type_rule, status_type
GO

CREATE TABLE Classes
(ID int not null identity (1, 1),
Название varchar(15) not null check (Название in ('Эконом', 'Комфорт', 'Комфорт+', 'Люкс')),
Коэффициент float not null,
CONSTRAINT PK_Classes primary key (ID))
GO

CREATE TABLE WorkExperience
(ID int not null identity (1, 1),
Название staj_type not null,
[Стаж в годах] int not null,
Ставка float not null,
CONSTRAINT PK_WorkExperience primary key (ID))
GO

CREATE TABLE Accounts
(ID int not null identity (1, 1),
Логин varchar(15) not null UNIQUE,
Пароль varchar(15) not null, 
[Секретный вопрос] varchar(30) not null,
[Секретный ответ] varchar(15) not null,
CONSTRAINT [PK_Accounts] primary key (ID))
GO
 
CREATE TABLE Cars
([Гос. номер] varchar(9) not null check ([Гос. номер] LIKE 
'[АВЕКМНОРСТУХ][0-9][0-9][0-9][АВЕКМНОРСТУХ][АВЕКМНОРСТУХ][0-9][0-9]' OR
[Гос. номер] LIKE '[АВЕКМНОРСТУХ][0-9][0-9][0-9][АВЕКМНОРСТУХ][АВЕКМНОРСТУХ][1-9][0-9][0-9]'),
Марка varchar(15) not null,
Модель varchar(20) not null,
Цвет varchar(15) not null,
Класс int not null,
[Год выпуска] int not null check([Год выпуска] <= YEAR(GETDATE())),
ПТС varchar(10) not null check (ПТС LIKE 
'[0-9][0-9][АВЕКМНОРСТУХ][АВЕКМНОРСТУХ][0-9][0-9][0-9][0-9][0-9][0-9]') UNIQUE,
[Дата последнего тех. обслуживания] date check ([Дата последнего тех. обслуживания] <= GETDATE()),
[В ремонте] varchar(3) not null check ([В ремонте] in ('Да', 'Нет')),
CONSTRAINT PK_Cars primary key ([Гос. номер]))
GO

ALTER TABLE Cars
ADD CONSTRAINT FK_Cars_Classes foreign key (Класс) references Classes(ID)
GO

CREATE TABLE Clients
(ID int not null identity (1, 1),
Фамилия varchar(20) not null,
Имя varchar(20) not null,
Отчество varchar(20),
Пол varchar(7) check (Пол IN ('Мужской', 'Женский')),
[Дата рождения] date not null check ([Дата рождения] between '1965-01-01' and GETDATE()),
Телефон varchar(11) not null check (Телефон NOT LIKE '%[^0-9]%') UNIQUE,
CONSTRAINT PK_Clients primary key (ID))
GO

ALTER TABLE Clients
ADD CONSTRAINT FK_Clients_Accounts foreign key (ID) references Accounts(ID)
GO

CREATE TABLE CallSign
(ID int not null identity (1, 1),
Позывной varchar(15) not null,
[Гос. номер] varchar(9) not null check ([Гос. номер] LIKE 
'[АВЕКМНОРСТУХ][0-9][0-9][0-9][АВЕКМНОРСТУХ][АВЕКМНОРСТУХ][0-9][0-9]' OR
[Гос. номер] LIKE '[АВЕКМНОРСТУХ][0-9][0-9][0-9][АВЕКМНОРСТУХ][АВЕКМНОРСТУХ][1-9][0-9][0-9]'),
[Страховой номер машины] varchar(13) not null check ([Страховой номер машины] LIKE 
'[А][А][А][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]' OR
[Страховой номер машины] LIKE 
'[В][В][В][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]' OR
[Страховой номер машины] LIKE 
'[Е][Е][Е][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]' OR
[Страховой номер машины] LIKE 
'[К][К][К][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]' OR
[Страховой номер машины] LIKE 
'[М][М][М][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]' OR
[Страховой номер машины] LIKE 
'[Н][Н][Н][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]' OR
[Страховой номер машины] LIKE 
'[О][О][О][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]' OR
[Страховой номер машины] LIKE 
'[Р][Р][Р][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]' OR
[Страховой номер машины] LIKE 
'[С][С][С][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]' OR
[Страховой номер машины] LIKE 
'[Т][Т][Т][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]' OR
[Страховой номер машины] LIKE 
'[У][У][У][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]' OR
[Страховой номер машины] LIKE 
'[Х][Х][Х][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]') UNIQUE,
[Водительское удостоверение] varchar(10) not null check ([Водительское удостоверение] LIKE
'[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]') UNIQUE,
CONSTRAINT PK_Call_sign primary key (ID))
GO

ALTER TABLE CallSign
ADD CONSTRAINT FK_CallSign_Cars foreign key ([Гос. номер]) references Cars([Гос. номер])
GO

CREATE TABLE Fines
(ID int not null identity (1, 1),
Позывной int not null,
[Гос. номер] varchar(9) not null check ([Гос. номер] LIKE 
'[АВЕКМНОРСТУХ][0-9][0-9][0-9][АВЕКМНОРСТУХ][АВЕКМНОРСТУХ][0-9][0-9]' OR
[Гос. номер] LIKE '[АВЕКМНОРСТУХ][0-9][0-9][0-9][АВЕКМНОРСТУХ][АВЕКМНОРСТУХ][0-9][0-9][0-9]'),
Нарушение varchar(40) not null,
Стоимость money,
[Дата нарушения] date not null check ([Дата нарушения] between '2012-01-01' and GETDATE()),
[Время нарушения] time(0) not null,
Оплачен varchar(3) not null check (Оплачен in ('Да', 'Нет')),
[Дата платежа] date check ([Дата платежа] between '2012-01-01' and GETDATE()),
CONSTRAINT PK_Fines primary key (ID))
GO

ALTER TABLE Fines
ADD CONSTRAINT FK_Fines_CallSign foreign key (Позывной) references CallSign(ID)
GO

CREATE TABLE Orders
(ID int not null identity (1, 1),
Позывной int not null,
Клиент int not null,
Статус status_type not null,
[Дата получения] date not null check ([Дата получения] between '2012-01-01' and GETDATE()),
[Время полученя] time(0) not null,
[Город отправления] varchar(20) not null,
[Улица отправления] varchar(20) not null,
[Дом отправления] int not null,
[Город назначения] varchar(20) not null,
[Улица назначения] varchar(20) not null,
[Дом назначения] int not null,
[Комментарии к заказу] varchar(60),
CONSTRAINT PK_Orders primary key (ID))
GO

ALTER TABLE Orders
ADD CONSTRAINT FK_Orders_CallSign foreign key (Позывной) references CallSign(ID)
GO

ALTER TABLE Orders
ADD CONSTRAINT FK_Orders_Clients foreign key (Клиент) references Clients(ID)
GO

CREATE TABLE Waybill
(ID int not null identity (1, 1),
Позывной int not null,
[Дата открытия] date not null check ([Дата открытия] between '2012-01-01' and GETDATE()),
[Время открытия] time(0) not null,
[Дата закрытия] date check ([Дата закрытия] between '2012-01-01' and GETDATE()),
[Время закрытия] time(0),
[Количество выполненных заказов] int not null default(0),
[Оплата работы] money,
CONSTRAINT PK_Waybill primary key (ID))
GO

ALTER TABLE Waybill
ADD CONSTRAINT FK_Waybill_CallSign foreign key (Позывной) references CallSign(ID)
GO

CREATE TABLE Drivers
(ID int not null identity (1, 1),
Фамилия varchar(20) not null,
Имя varchar(20) not null,
Отчество varchar(20),
Стаж int not null,
Пол varchar(7) not null check (Пол IN ('Мужской', 'Женский')),
[Дата рождения] date not null check ([Дата рождения] between '1965-01-01' and GETDATE()),
Телефон varchar(11) not null check (Телефон NOT LIKE '%[^0-9]%') UNIQUE,
[Дата приема] date not null check ([Дата приема] between '2012-01-01' and GETDATE()),
[На больничном] varchar(17) not null check ([На больничном] IN ('На больничном', 'Не на больничном')),
[В отпуске] varchar(15) not null check ([В отпуске] IN ('В отпуске', 'Не в отпуске')),
Уволен varchar(10) not null check (Уволен IN ('Уволен', 'Не уволен')),
[Дата увольнения] date check ([Дата увольнения] between '2012-01-01' and GETDATE()),
CONSTRAINT PK_Drivers primary key (ID))
GO

ALTER TABLE Drivers
ADD CONSTRAINT FK_Drivers_CallSign foreign key (ID) references CallSign(ID)
GO

ALTER TABLE Drivers
ADD CONSTRAINT FK_Drivers_WorkExperience foreign key (Стаж) references WorkExperience(ID)
GO

CREATE DEFAULT otpysk AS 'Не в отпуске' 
GO
EXEC sp_bindefault 'otpysk', 'Drivers.[В отпуске]'
GO

CREATE DEFAULT yvolen AS 'Не уволен' 
GO
EXEC sp_bindefault 'yvolen', 'Drivers.[Уволен]'
GO