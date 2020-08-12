if (object_id('[dbo].[Cliente]') is not null)
	return 

create table dbo.Cliente
(
	IdCliente int identity (1,1) not null,
	Nome varchar (150) not null,
	Tipo tinyint not null,
	CPFCNPJ varchar (14) not null,
	DDD varchar(2) not null,
	Fone varchar(9) not null,
	DataCriacao datetime not null,
	Excluido bit not null,
	Constraint [PK_Cliente] primary key clustered ([IdCliente])
)

--Drop table dbo.cliente

Select * from dbo.Cliente

Insert into dbo.Cliente (Nome,Tipo,CPFCNPJ,DDD,Fone,DataCriacao,Excluido)
Values('Kauy',0,'75742655002','11','958588585',getdate(),0)

delete dbo.Cliente where IdCliente = 2

Insert into dbo.Cliente (Nome,Tipo,CPFCNPJ,DDD,Fone,DataCriacao,Excluido)
Values('5dimensao',1,'79929579000121','11','945455454',getdate(),0)

Update dbo.Cliente set Nome = '5°dimensao LTDA', DDD = '21' where IdCliente = 3
