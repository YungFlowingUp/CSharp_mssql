CREATE DATABASE [Taxi]
ON
(NAME = 'Taxi',
FILENAME = 'C:\Kyrsovay\Taxi.mdf',
SIZE = 1,
MAXSIZE = 10,
FILEGROWTH = 1)
LOG ON
(NAME = 'Taxi_log',
FILENAME = 'C:\Kyrsovay\Taxi_log.ldf',
SIZE = 1,
MAXSIZE = 5,
FILEGROWTH = 1)
