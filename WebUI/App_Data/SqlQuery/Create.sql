create database MessangerAndTaskDB
on
(	
	name = 'MessangerAndTaskDB',
	filename = 'D:\DataBase\MessangerAndTask\MessangerAndTaskDB.mdf',
	size = 5mb,
	maxsize = 10mb,
	filegrowth = 1mb
)
log on
(	
	name = 'LogMessangerAndTaskDB',
	filename = 'D:\DataBase\MessangerAndTask\MessangerAndTaskDB.ldf',
	size = 5mb,
	maxsize=10mb,
	filegrowth = 1mb
)