
CREATE TABLE Contacto(
ID_CONTACTO INT PRIMARY KEY IDENTITY(1,1),
NOMBRE VARCHAR(50)NULL,
EMAIL VARCHAR(50)NULL,
ASUNTO VARCHAR(50)NULL,
MENSAJE VARCHAR(150)NULL,
)

go

CREATE PROC USP_REGISTER_CONTACT
@NOMBRE VARCHAR(50),
@EMAIL VARCHAR(50),
@ASUNTO VARCHAR(50),
@MENSAJE VARCHAR(150)
AS
BEGIN
INSERT INTO CONTACTO
	VALUES(@NOMBRE, @EMAIL, @ASUNTO, @MENSAJE)
END
GO


--MIS COMPRAS PAGE

CREATE TABLE COMPRAS(
ID_COMPRAS INT PRIMARY KEY IDENTITY(1,1),
NOMBRE_PRO VARCHAR(120),
FECHA DATETIME,
CANTIDAD INT NULL,
TOTAL DECIMAL(18,2) NULL,
)
go

CREATE PROC USPREGISTER_COMPRA
@NOMBRE_PRO VARCHAR(120),
@FECHA DATETIME,
@CANTIDAD INT,
@TOTAL DECIMAL(18,2)
AS
BEGIN
INSERT INTO COMPRAS
	VALUES(@NOMBRE_PRO, @FECHA, @CANTIDAD, @TOTAL)

END
GO



CREATE PROC USP_LISTAR_COMPRA
AS
BEGIN
SELECT
  NOMBRE_PRO, FECHA, CANTIDAD, TOTAL
   FROM COMPRAS
END
GO




