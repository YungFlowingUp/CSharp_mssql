CREATE VIEW V1 AS
SELECT Orders.ID AS [Код заказа], CallSign.Позывной AS [Позывной водителя], Фамилия, 
	   Имя, Отчество, Статус, [Дата получения], 
	   [Время полученя], [Город отправления], 
	   [Улица отправления], [Дом отправления], [Город назначения], 
	   [Улица назначения], [Дом назначения], [Комментарии к заказу]
FROM Orders JOIN Clients ON Orders.Клиент = Clients.ID JOIN
	 CallSign ON Orders.Позывной = CallSign.ID
GO

CREATE VIEW V2 AS
SELECT Waybill.ID AS [Код путевого листа], CallSign.Позывной, [Дата открытия], 
	   [Время открытия], [Дата закрытия], [Время закрытия], [Количество выполненных заказов],
	   [Оплата работы]
FROM Waybill JOIN CallSign ON Waybill.Позывной = CallSign.ID
GO