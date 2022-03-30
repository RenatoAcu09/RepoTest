CREATE DATABASE DB_ApiClient
GO

USE DB_ApiClient 
GO

CREATE SCHEMA Adm
GO

CREATE TABLE Adm.Cliente(
codCliente varchar(10) PRIMARY KEY,
nombreCompleto VARCHAR(200) NOT NULL,
nombreCorto VARCHAR(40) NOT NULL,
abreviatura VARCHAR(40) NOT NULL,
RUC varchar(11) NOT NULL,
estado CHAR(1) NOT NULL,
grupoFacturacion varchar(100) NULL, 
inactivoDesde DATETIME NULL,
codigoSAP varchar(20) null 
)
GO



CREATE PROC Adm.sp_cliente_list
@codCliente varchar(10) = NULL
AS
BEGIN
	SELECT codCliente ,
           nombreCompleto ,
           nombreCorto ,
           Abreviatura ,
           RUC ,
           estado ,
           grupoFacturacion ,
           inactivoDesde ,
           codigoSAP FROM adm.Cliente WHERE codCliente=@codCliente OR @codCliente IS null
END
GO

CREATE PROC Adm.sp_cliente_insert
@codCliente varchar(10),
@nombreCompleto VARCHAR(200),
@nombreCorto VARCHAR(40),
@Abreviatura VARCHAR(40),
@RUC varchar(11),
@estado CHAR(1),
@grupoFacturacion varchar(100) = NULL, 
@inactivoDesde DATETIME = NULL,
@codigoSAP varchar(20) = NULL 
AS
BEGIN
	INSERT INTO adm.Cliente
	        ( codCliente ,
	          nombreCompleto ,
	          nombreCorto ,
	          Abreviatura ,
	          RUC ,
	          estado ,
	          grupoFacturacion ,
	          inactivoDesde ,
	          codigoSAP
	        )
	VALUES  ( @codCliente,
				@nombreCompleto,
				@nombreCorto,
				@Abreviatura,
				@RUC,
				@estado,
				@grupoFacturacion,
				@inactivoDesde,
				@codigoSAP
	        )	
END
GO


CREATE PROC Adm.sp_cliente_update
@codCliente varchar(10),
@nombreCompleto VARCHAR(200),
@nombreCorto VARCHAR(40),
@Abreviatura VARCHAR(40),
@RUC varchar(11),
@estado CHAR(1),
@grupoFacturacion varchar(100) = NULL, 
@inactivoDesde DATETIME = NULL,
@codigoSAP varchar(20) = NULL 
AS
BEGIN
	UPDATE adm.Cliente
	set nombreCompleto=@codCliente ,
	    nombreCorto=@nombreCorto ,
	    Abreviatura=@Abreviatura ,
	    RUC=@RUC ,
	    estado=@estado ,
	    grupoFacturacion=@grupoFacturacion ,
	    inactivoDesde=@inactivoDesde ,
	    codigoSAP=@codigoSAP
	WHERE codCliente = @codCliente
END
GO


CREATE PROC Adm.sp_cliente_delete
@codCliente varchar(10)
AS
BEGIN
	DELETE FROM adm.Cliente WHERE codCliente = @codCliente
END
GO




