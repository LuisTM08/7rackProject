/* CREANDO DATA BASE PARA TIENDAS EL TAMBO */

CREATE DATABASE TAMBO
USE TAMBO
GO

CREATE TABLE USUARIO (
ID_USUARIO INT PRIMARY KEY IDENTITY (1,1),
ID_LOGIN NVARCHAR(128) NOT NULL,
NOMBRE VARCHAR(50) NULL,
APELLIDO VARCHAR(50) NULL,
SEXO CHAR(1) NULL,
DNI CHAR(8) NULL,
TELEFONO CHAR(9) NULL,
FECHA_NAC DATE NULL,
DIRECCION VARCHAR(50) NULL,
REFERENCIA VARCHAR(50) NULL,
ID_REGION INT NULL,
ID_PROVINCIA INT NULL,
ID_DISTRITO INT NULL,
AVATAR VARCHAR(100) NULL
)
GO
--- REGISTRANDO UN USUARIO NUEVO DESDE LA TABLA ASPNETUSERS A USUARIO ---

CREATE PROCEDURE USP_REGISTER_USER
@ID_LOGIN NVARCHAR(128)
AS
BEGIN
	INSERT INTO USUARIO VALUES(@ID_LOGIN, NULL, NULL,NULL,NULL,NULL,NULL,NULL,NULL,0,0,0,NULL)
END
GO

CREATE PROCEDURE USP_SEARCH_USER_IDLOGIN
@ID_LOGIN NVARCHAR(128)
AS
BEGIN
	SELECT 
	U.ID_USUARIO,
	U.ID_LOGIN,
	U.NOMBRE,
	U.APELLIDO,
	ASP.Email,
	U.SEXO,
	U.DNI,
	U.TELEFONO,
	U.FECHA_NAC,
	U.DIRECCION,
	U.REFERENCIA,
	U.ID_REGION,
	U.ID_PROVINCIA,
	U.ID_DISTRITO,
	U.AVATAR
	FROM USUARIO U INNER JOIN AspNetUsers ASP ON ASP.Id = U.ID_LOGIN
	WHERE U.ID_LOGIN = @ID_LOGIN
END
GO

CREATE PROCEDURE USP_SEARCH_USER_ENTIDAD_IDLOGIN
@ID_LOGIN NVARCHAR(128)
AS
BEGIN
	SELECT 
	U.ID_USUARIO,
	U.ID_LOGIN,
	U.NOMBRE,
	U.APELLIDO,
	ASP.Email,
	U.SEXO,
	U.DNI,
	U.TELEFONO,
	U.FECHA_NAC,
	U.DIRECCION,
	U.REFERENCIA,
	U.ID_REGION,
	R.REGION,
	U.ID_PROVINCIA,
	P.PROVINCIA,
	U.ID_DISTRITO,
	D.DISTRITO,
	U.AVATAR
	FROM USUARIO U INNER JOIN AspNetUsers ASP ON ASP.Id = U.ID_LOGIN
	INNER JOIN REGION R ON R.ID_REGION = U.ID_REGION
	INNER JOIN PROVINCIA P ON P.ID_PROVINCIA = U.ID_PROVINCIA
	INNER JOIN DISTRITO D ON D.ID_DISTRITO = U.ID_DISTRITO
	WHERE U.ID_LOGIN = @ID_LOGIN
END
GO

CREATE PROCEDURE USP_LIST_USERS
AS
BEGIN
	SELECT U.ID_USUARIO, U.ID_LOGIN, U.NOMBRE, U.APELLIDO, U.DNI, ASP.UserName,ASP.Email, U.TELEFONO 
	FROM USUARIO U INNER JOIN AspNetUsers ASP ON ASP.Id = U.ID_LOGIN
END
GO

CREATE PROCEDURE USP_BUSCAR_EMAIL_USER
@ID_LOGIN NVARCHAR(128)
AS
BEGIN
	SELECT U.Email FROM AspNetUsers U WHERE Id = @ID_LOGIN
END
GO

CREATE PROCEDURE USP_UPDATE_USER
@ID_USUARIO INT,
@ID_LOGIN NVARCHAR(128),
@NOMBRE VARCHAR(50),
@APELLIDO VARCHAR(50),
@SEXO CHAR(1),
@DNI CHAR(8),
@TELEFONO CHAR(9),
@FECHA_NAC DATE,
@DIRECCION VARCHAR(50),
@REFERENCIA VARCHAR(50),
@ID_REGION INT,
@ID_PROVINCIA INT,
@ID_DISTRITO INT
AS
BEGIN
	UPDATE USUARIO
	SET 
	NOMBRE = @NOMBRE,
	APELLIDO = @APELLIDO,
	SEXO = @SEXO,
	DNI = @DNI,
	TELEFONO = @TELEFONO,
	FECHA_NAC = @FECHA_NAC,
	DIRECCION = @DIRECCION,
	REFERENCIA = @REFERENCIA,
	ID_REGION = @ID_REGION,
	ID_PROVINCIA = @ID_PROVINCIA,
	ID_DISTRITO = @ID_DISTRITO
	WHERE ID_LOGIN = @ID_LOGIN
END
GO

CREATE PROCEDURE INSERT_IMAGE_USER
@ID_LOGIN NVARCHAR(128),
@NAMEIMAGEN VARCHAR(100)
AS
BEGIN
	UPDATE USUARIO
	SET
	AVATAR = @NAMEIMAGEN
	WHERE ID_LOGIN = @ID_LOGIN
END
GO

CREATE PROCEDURE USP_ELIMINAR_USUARIO
@IDLOGIN NVARCHAR(128)
AS
BEGIN
	DELETE FROM USUARIO WHERE ID_LOGIN = @IDLOGIN
	DELETE FROM AspNetUsers WHERE Id = @IDLOGIN
END
GO

---- LISTAR ROLES ----
CREATE PROCEDURE USP_LIST_ROL
AS
BEGIN
	SELECT Id, Name FROM AspNetRoles
END
GO


CREATE PROCEDURE USP_ASIGNAR_ROL
@IDLOGIN NVARCHAR(128),
@IDROL NVARCHAR(128)
AS
BEGIN
	INSERT INTO AspNetUserRoles VALUES (@IDLOGIN, @IDROL)
END
GO
SELECT * FROM AspNetRoles
SELECT * FROM AspNetUsers
SELECT * FROM AspNetUserRoles
USP_ASIGNAR_ROL '29ba5e24-56d6-4169-a4ba-b30bde50b182','013e3686-ad69-4994-852e-58010969eae5'

---- TABLA DE REGIONES ----
CREATE TABLE REGION(
ID_REGION INT PRIMARY KEY,
REGION VARCHAR(50) NULL,
)
GO

INSERT INTO REGION (ID_REGION, REGION) VALUES
(1, 'AMAZONAS'),
(2, 'ANCASH'),
(3, 'APURIMAC'),
(4, 'AREQUIPA'),
(5, 'AYACUCHO'),
(6, 'CAJAMARCA'),
(7, 'CALLAO'),
(8, 'CUSCO'),
(9, 'HUANCAVELICA'),
(10, 'HUANUCO'),
(11, 'ICA'),
(12, 'JUNIN'),
(13, 'LA LIBERTAD'),
(14, 'LAMBAYEQUE'),
(15, 'LIMA'),
(16, 'LORETO'),
(17, 'MADRE DE DIOS'),
(18, 'MOQUEGUA'),
(19, 'PASCO'),
(20, 'PIURA'),
(21, 'PUNO'),
(22, 'SAN MARTIN'),
(23, 'TACNA'),
(24, 'TUMBES'),
(25, 'UCAYALI');
GO

CREATE PROCEDURE USP_LISTAR_REGION
AS
BEGIN
	SELECT R.ID_REGION, R.REGION FROM REGION R
END
GO

CREATE PROCEDURE USP_BUSCAR_REGION
@ID_REGION INT
AS
BEGIN
	SELECT R.ID_REGION, R.REGION FROM REGION R WHERE R.ID_REGION = @ID_REGION
END
GO
--- TABLA DE PROVINCIAS ---
CREATE TABLE PROVINCIA(
ID_PROVINCIA INT PRIMARY KEY,
PROVINCIA VARCHAR(50) NULL,
ID_REGION INT NOT NULL,
)
GO

INSERT INTO PROVINCIA (ID_PROVINCIA, PROVINCIA, ID_REGION) VALUES
(1, 'CHACHAPOYAS ', 1),
(2, 'BAGUA', 1),
(3, 'BONGARA', 1),
(4, 'CONDORCANQUI', 1),
(5, 'LUYA', 1),
(6, 'RODRIGUEZ DE MENDOZA', 1),
(7, 'UTCUBAMBA', 1),
(8, 'HUARAZ', 2),
(9, 'AIJA', 2),
(10, 'ANTONIO RAYMONDI', 2),
(11, 'ASUNCION', 2),
(12, 'BOLOGNESI', 2),
(13, 'CARHUAZ', 2),
(14, 'CARLOS FERMIN FITZCARRALD', 2),
(15, 'CASMA', 2),
(16, 'CORONGO', 2),
(17, 'HUARI', 2),
(18, 'HUARMEY', 2),
(19, 'HUAYLAS', 2),
(20, 'MARISCAL LUZURIAGA', 2),
(21, 'OCROS', 2),
(22, 'PALLASCA', 2),
(23, 'POMABAMBA', 2),
(24, 'RECUAY', 2),
(25, 'SANTA', 2),
(26, 'SIHUAS', 2),
(27, 'YUNGAY', 2),
(28, 'ABANCAY', 3),
(29, 'ANDAHUAYLAS', 3),
(30, 'ANTABAMBA', 3),
(31, 'AYMARAES', 3),
(32, 'COTABAMBAS', 3),
(33, 'CHINCHEROS', 3),
(34, 'GRAU', 3),
(35, 'AREQUIPA', 4),
(36, 'CAMANA', 4),
(37, 'CARAVELI', 4),
(38, 'CASTILLA', 4),
(39, 'CAYLLOMA', 4),
(40, 'CONDESUYOS', 4),
(41, 'ISLAY', 4),
(42, 'LA UNION', 4),
(43, 'HUAMANGA', 5),
(44, 'CANGALLO', 5),
(45, 'HUANCA SANCOS', 5),
(46, 'HUANTA', 5),
(47, 'LA MAR', 5),
(48, 'LUCANAS', 5),
(49, 'PARINACOCHAS', 5),
(50, 'PAUCAR DEL SARA SARA', 5),
(51, 'SUCRE', 5),
(52, 'VICTOR FAJARDO', 5),
(53, 'VILCAS HUAMAN', 5),
(54, 'CAJAMARCA', 6),
(55, 'CAJABAMBA', 6),
(56, 'CELENDIN', 6),
(57, 'CHOTA ', 6),
(58, 'CONTUMAZA', 6),
(59, 'CUTERVO', 6),
(60, 'HUALGAYOC', 6),
(61, 'JAEN', 6),
(62, 'SAN IGNACIO', 6),
(63, 'SAN MARCOS', 6),
(64, 'SAN PABLO', 6),
(65, 'SANTA CRUZ', 6),
(66, 'CALLAO', 7),
(67, 'CUSCO', 8),
(68, 'ACOMAYO', 8),
(69, 'ANTA', 8),
(70, 'CALCA', 8),
(71, 'CANAS', 8),
(72, 'CANCHIS', 8),
(73, 'CHUMBIVILCAS', 8),
(74, 'ESPINAR', 8),
(75, 'LA CONVENCION', 8),
(76, 'PARURO', 8),
(77, 'PAUCARTAMBO', 8),
(78, 'QUISPICANCHI', 8),
(79, 'URUBAMBA', 8),
(80, 'HUANCAVELICA', 9),
(81, 'ACOBAMBA', 9),
(82, 'ANGARAES', 9),
(83, 'CASTROVIRREYNA', 9),
(84, 'CHURCAMPA', 9),
(85, 'HUAYTARA', 9),
(86, 'TAYACAJA', 9),
(87, 'HUANUCO', 10),
(88, 'AMBO', 10),
(89, 'DOS DE MAYO', 10),
(90, 'HUACAYBAMBA', 10),
(91, 'HUAMALIES', 10),
(92, 'LEONCIO PRADO', 10),
(93, 'MARA&Ntilde;ON', 10),
(94, 'PACHITEA', 10),
(95, 'PUERTO INCA', 10),
(96, 'LAURICOCHA', 10),
(97, 'YAROWILCA', 10),
(98, 'ICA', 11),
(99, 'CHINCHA', 11),
(100, 'NAZCA', 11),
(101, 'PALPA', 11),
(102, 'PISCO', 11),
(103, 'HUANCAYO', 12),
(104, 'CONCEPCION', 12),
(105, 'CHANCHAMAYO', 12),
(106, 'JAUJA', 12),
(107, 'JUNIN', 12),
(108, 'SATIPO', 12),
(109, 'TARMA', 12),
(110, 'YAULI', 12),
(111, 'CHUPACA', 12),
(112, 'TRUJILLO', 13),
(113, 'ASCOPE', 13),
(114, 'BOLIVAR', 13),
(115, 'CHEPEN', 13),
(116, 'JULCAN', 13),
(117, 'OTUZCO', 13),
(118, 'PACASMAYO', 13),
(119, 'PATAZ', 13),
(120, 'SANCHEZ CARRION', 13),
(121, 'SANTIAGO DE CHUCO', 13),
(122, 'GRAN CHIMU', 13),
(123, 'VIRU', 13),
(124, 'CHICLAYO', 14),
(125, 'FERRE&Ntilde;AFE', 14),
(126, 'LAMBAYEQUE', 14),
(127, 'LIMA', 15),
(128, 'BARRANCA', 15),
(129, 'CAJATAMBO', 15),
(130, 'CANTA', 15),
(131, 'CA&Ntilde;ETE', 15),
(132, 'HUARAL', 15),
(133, 'HUAROCHIRI', 15),
(134, 'HUAURA', 15),
(135, 'OYON', 15),
(136, 'YAUYOS', 15),
(137, 'MAYNAS', 16),
(138, 'ALTO AMAZONAS', 16),
(139, 'LORETO', 16),
(140, 'MARISCAL RAMON CASTILLA', 16),
(141, 'REQUENA', 16),
(142, 'UCAYALI', 16),
(143, 'TAMBOPATA', 17),
(144, 'MANU', 17),
(145, 'TAHUAMANU', 17),
(146, 'MARISCAL NIETO', 18),
(147, 'GENERAL SANCHEZ CERRO', 18),
(148, 'ILO', 18),
(149, 'PASCO', 19),
(150, 'DANIEL ALCIDES CARRION', 19),
(151, 'OXAPAMPA', 19),
(152, 'PIURA', 20),
(153, 'AYABACA', 20),
(154, 'HUANCABAMBA', 20),
(155, 'MORROPON', 20),
(156, 'PAITA', 20),
(157, 'SULLANA', 20),
(158, 'TALARA', 20),
(159, 'SECHURA', 20),
(160, 'PUNO', 21),
(161, 'AZANGARO', 21),
(162, 'CARABAYA', 21),
(163, 'CHUCUITO', 21),
(164, 'EL COLLAO', 21),
(165, 'HUANCANE', 21),
(166, 'LAMPA', 21),
(167, 'MELGAR', 21),
(168, 'MOHO', 21),
(169, 'SAN ANTONIO DE PUTINA', 21),
(170, 'SAN ROMAN', 21),
(171, 'SANDIA', 21),
(172, 'YUNGUYO', 21),
(173, 'MOYOBAMBA', 22),
(174, 'BELLAVISTA', 22),
(175, 'EL DORADO', 22),
(176, 'HUALLAGA', 22),
(177, 'LAMAS', 22),
(178, 'MARISCAL CACERES', 22),
(179, 'PICOTA', 22),
(180, 'RIOJA', 22),
(181, 'SAN MARTIN', 22),
(182, 'TOCACHE', 22),
(183, 'TACNA', 23),
(184, 'CANDARAVE', 23),
(185, 'JORGE BASADRE', 23),
(186, 'TARATA', 23),
(187, 'TUMBES', 24),
(188, 'CONTRALMIRANTE VILLAR', 24),
(189, 'ZARUMILLA', 24),
(190, 'CORONEL PORTILLO', 25),
(191, 'ATALAYA', 25),
(192, 'PADRE ABAD', 25),
(193, 'PURUS', 25);
GO

CREATE PROCEDURE USP_BUSCAR_PROVINCIA
@ID_REGION INT
AS
BEGIN
	SELECT P.ID_PROVINCIA, P.PROVINCIA FROM PROVINCIA P INNER JOIN REGION R  ON P.ID_REGION = R.ID_REGION WHERE R.ID_REGION = @ID_REGION
END
GO


CREATE TABLE DISTRITO(
ID_DISTRITO INT PRIMARY KEY,
DISTRITO VARCHAR(50) NULL,
ID_PROVINCIA INT NOT NULL,
)
GO

CREATE PROCEDURE USP_BUSCAR_DISTRITO
@ID_PROV INT
AS
BEGIN
	SELECT D.ID_DISTRITO, D.DISTRITO FROM PROVINCIA P INNER JOIN DISTRITO D  ON P.ID_PROVINCIA=D.ID_PROVINCIA WHERE P.ID_PROVINCIA = @ID_PROV
END
GO

------ INICIO DE MARCAS ---------

CREATE TABLE MARCAS(
ID_MARCA INT PRIMARY KEY IDENTITY(1,1),
NOMBRE_MARCA VARCHAR(50) NULL,
ESTADO INT NULL,
)

INSERT INTO MARCAS VALUES ('Sin Marca',1)
INSERT INTO MARCAS VALUES ('Frito Lay',1)
INSERT INTO MARCAS VALUES ('Gloria',1)
INSERT INTO MARCAS VALUES ('Tabernero',1)
INSERT INTO MARCAS VALUES ('Pepsi',1)
INSERT INTO MARCAS VALUES ('Backus',1)
INSERT INTO MARCAS VALUES ('Vida',1)
INSERT INTO MARCAS VALUES ('Field',1)
INSERT INTO MARCAS VALUES ('A1',1)
INSERT INTO MARCAS VALUES ('Ajinomoto',1)
INSERT INTO MARCAS VALUES ('Donofrio',1)
INSERT INTO MARCAS VALUES ('Nestle',1)
INSERT INTO MARCAS VALUES ('Ambev',1)
INSERT INTO MARCAS VALUES ('Coca Cola',1)
INSERT INTO MARCAS VALUES ('Elite',1)
INSERT INTO MARCAS VALUES ('Bells',1)
GO

CREATE PROCEDURE USP_LISTA_MARCA
AS
BEGIN
	SELECT ID_MARCA, NOMBRE_MARCA, ESTADO FROM MARCAS
END
GO

CREATE PROCEDURE USP_CREATE_MARCA
@NOMBRE VARCHAR(50),
@ESTADO INT
AS
BEGIN
	INSERT INTO MARCAS VALUES (@NOMBRE,@ESTADO)
END
GO

CREATE PROCEDURE USP_UPDATE_MARCA
@ID_MAR INT,
@NOMBRE VARCHAR(50),
@ESTADO INT
AS
BEGIN
	UPDATE MARCAS SET
	NOMBRE_MARCA = @NOMBRE,
	ESTADO = @ESTADO
	WHERE ID_MARCA = @ID_MAR
END
GO

CREATE PROCEDURE USP_DELETE_MARCA
@ID_MAR INT
AS
BEGIN
	DELETE FROM MARCAS WHERE ID_MARCA = @ID_MAR
END
GO

CREATE PROCEDURE USP_SEARCH_MARCA
@ID_MAR INT
AS
BEGIN
	SELECT ID_MARCA, NOMBRE_MARCA, ESTADO FROM MARCAS WHERE ID_MARCA = @ID_MAR
END
GO
------ FIN DE MARCAS ------------------

----- INICIO DE CATEGORIAS --------------------

CREATE TABLE CATEGORIA(
ID_CATEGORIA INT PRIMARY KEY IDENTITY (1,1),
NOMBRE_CAT VARCHAR(50) NULL,
ESTADO INT NULL
)
GO

INSERT INTO CATEGORIA VALUES ('Sin Categoria',1)
INSERT INTO CATEGORIA VALUES ('Comidas',1)
INSERT INTO CATEGORIA VALUES ('Alcoholicas',1)
INSERT INTO CATEGORIA VALUES ('No Alcoholicas',1)
INSERT INTO CATEGORIA VALUES ('Golosinas',1)
INSERT INTO CATEGORIA VALUES ('Snaks',1)
INSERT INTO CATEGORIA VALUES ('Otros',1)

CREATE PROCEDURE USP_LISTA_CATERGORIA
AS
BEGIN
	SELECT ID_CATEGORIA, NOMBRE_CAT, ESTADO FROM CATEGORIA
END
GO

CREATE PROCEDURE USP_CREATE_CATEGORIA
@NOMBRE VARCHAR(50),
@ESTADO INT
AS
BEGIN
	INSERT INTO CATEGORIA VALUES (@NOMBRE,@ESTADO)
END

CREATE PROCEDURE USP_UPDATE_CATEGORIA
@ID_CAT INT,
@NOMBRE VARCHAR(50),
@ESTADO INT
AS
BEGIN
	UPDATE CATEGORIA SET
	NOMBRE_CAT = @NOMBRE,
	ESTADO = @ESTADO
	WHERE ID_CATEGORIA = @ID_CAT
END
GO

CREATE PROCEDURE USP_DELETE_CATEGORIA
@ID_CAT INT
AS
BEGIN
	DELETE FROM CATEGORIA WHERE ID_CATEGORIA = @ID_CAT
END
GO

CREATE PROCEDURE USP_SEARCH_CATEGORIA
@ID_CAT INT
AS
BEGIN
	SELECT ID_CATEGORIA, NOMBRE_CAT, ESTADO FROM CATEGORIA WHERE ID_CATEGORIA = @ID_CAT
END
GO

-------------- FIN DE CATEGORIA --------------

---- INICIO DE PRODUCTOS ---------

CREATE TABLE PRODUCTO(
ID_PRODUCTO INT PRIMARY KEY IDENTITY (1,1),
NOMBRE_PROD VARCHAR(120)NULL,
DESCRIPCION_PRO NVARCHAR(300)NULL,
PRECIOXUNIDAD DECIMAL(18,2) NULL,
STOCK INT NULL,
ID_CATEGORIA INT NULL,
ID_MARCA INT NULL,
ENPORTADA INT NULL,
IMAGEN VARCHAR(120) NULL,
ESTADO INT NULL,
)
GO

CREATE PROC USP_CREATE_PRODUCTO
@NOMBRE VARCHAR(120),
@DESCRIPCION NVARCHAR(300),
@PRECIO DECIMAL(18,2),
@STOCK INT,
@IDCATEGORIA INT,
@IDMARCA INT,
@ENPORTADA INT,
@IMAGEN VARCHAR(120),
@ESTADO INT
AS
BEGIN
	INSERT INTO PRODUCTO
	VALUES(@NOMBRE, @DESCRIPCION, @PRECIO, @STOCK, @IDCATEGORIA, @IDMARCA, @ENPORTADA,@IMAGEN, @ESTADO)
END
GO

USP_SEARCH_PRODUCTO_CATEGORIA 7

CREATE PROC USP_SEARCH_PRODUCTO_CATEGORIA
@idCategoria int
AS
BEGIN
SELECT
   P.ID_PRODUCTO,
   P.NOMBRE_PROD,
   P.DESCRIPCION_PRO,
   P.PRECIOXUNIDAD,
   P.STOCK,
   P.ID_CATEGORIA,
   C.NOMBRE_CAT,
   P.ID_MARCA,
   M.NOMBRE_MARCA,
   P.ENPORTADA,
   P.IMAGEN,
   P.ESTADO
   FROM PRODUCTO P INNER JOIN CATEGORIA C ON P.ID_CATEGORIA = C.ID_CATEGORIA
   INNER JOIN MARCAS M ON P.ID_MARCA = M.ID_MARCA
   WHERE C.ID_CATEGORIA = @idCategoria
END
GO


CREATE PROC USP_UPDATE_PRODUCTO
@IDPRODUCTO INT,
@NOMBRE VARCHAR(120),
@DESCRIPCION NVARCHAR(300),
@PRECIO DECIMAL(18,2),
@STOCK INT,
@IDCATEGORIA INT,
@IDMARCA INT,
@ENPORTADA INT,
@IMAGEN VARCHAR(120),
@ESTADO INT
AS
BEGIN
   UPDATE PRODUCTO SET
   NOMBRE_PROD=@NOMBRE,
   DESCRIPCION_PRO=@DESCRIPCION,
   PRECIOXUNIDAD=@PRECIO,
   STOCK=@STOCK,
   ID_CATEGORIA=@IDCATEGORIA,
   ID_MARCA = @IDMARCA,
   ENPORTADA = @ENPORTADA,
   IMAGEN = @IMAGEN,
   ESTADO = @ESTADO
   WHERE ID_PRODUCTO=@IDPRODUCTO
END
GO

CREATE PROC USP_SEARCH_PRODUCTO_ID
@IDPRODUCTO INT
AS
BEGIN
   SELECT
   P.ID_PRODUCTO,
   P.NOMBRE_PROD,
   P.DESCRIPCION_PRO,
   P.PRECIOXUNIDAD,
   P.STOCK,
   P.ID_CATEGORIA,
   C.NOMBRE_CAT,
   P.ID_MARCA,
   M.NOMBRE_MARCA,
   P.ENPORTADA,
   P.IMAGEN,
   P.ESTADO
   FROM PRODUCTO P INNER JOIN CATEGORIA C ON P.ID_CATEGORIA = C.ID_CATEGORIA
   INNER JOIN MARCAS M ON P.ID_MARCA = M.ID_MARCA
   WHERE ID_PRODUCTO=@IDPRODUCTO
END
GO

CREATE PROC USP_LIST_PRODUCTO
AS
BEGIN
  SELECT
   P.ID_PRODUCTO,
   P.NOMBRE_PROD,
   P.DESCRIPCION_PRO,
   P.PRECIOXUNIDAD,
   P.STOCK,
   P.ID_CATEGORIA,
   C.NOMBRE_CAT,
   P.ID_MARCA,
   M.NOMBRE_MARCA,
   P.ENPORTADA,
   P.IMAGEN,
   P.ESTADO
   FROM PRODUCTO P INNER JOIN CATEGORIA C ON P.ID_CATEGORIA = C.ID_CATEGORIA
   INNER JOIN MARCAS M ON P.ID_MARCA = M.ID_MARCA
END
GO

CREATE PROC USP_CURRENT_PRODUCTO
AS
BEGIN
  SELECT TOP 6
   P.ID_PRODUCTO,
   P.NOMBRE_PROD,
   P.DESCRIPCION_PRO,
   P.PRECIOXUNIDAD,
   P.STOCK,
   P.ID_CATEGORIA,
   C.NOMBRE_CAT,
   P.ID_MARCA,
   M.NOMBRE_MARCA,
   P.ENPORTADA,
   P.IMAGEN,
   P.ESTADO
   FROM PRODUCTO P INNER JOIN CATEGORIA C ON P.ID_CATEGORIA = C.ID_CATEGORIA
   INNER JOIN MARCAS M ON P.ID_MARCA = M.ID_MARCA
   ORDER BY ID_PRODUCTO DESC
END
GO

CREATE PROC USP_PORTADA_PRODUCTO
AS
BEGIN
  SELECT TOP 3
   P.ID_PRODUCTO,
   P.NOMBRE_PROD,
   P.DESCRIPCION_PRO,
   P.PRECIOXUNIDAD,
   P.STOCK,
   P.ID_CATEGORIA,
   C.NOMBRE_CAT,
   P.ID_MARCA,
   M.NOMBRE_MARCA,
   P.ENPORTADA,
   P.IMAGEN,
   P.ESTADO
   FROM PRODUCTO P INNER JOIN CATEGORIA C ON P.ID_CATEGORIA = C.ID_CATEGORIA
   INNER JOIN MARCAS M ON P.ID_MARCA = M.ID_MARCA WHERE P.ENPORTADA = 2
   ORDER BY ID_PRODUCTO DESC
END
GO


CREATE PROC USP_RECOMENDADO_PRODUCTO
AS
BEGIN
  SELECT TOP 6
   P.ID_PRODUCTO,
   P.NOMBRE_PROD,
   P.DESCRIPCION_PRO,
   P.PRECIOXUNIDAD,
   P.STOCK,
   P.ID_CATEGORIA,
   C.NOMBRE_CAT,
   P.ID_MARCA,
   M.NOMBRE_MARCA,
   P.ENPORTADA,
   P.IMAGEN,
   P.ESTADO
   FROM PRODUCTO P INNER JOIN CATEGORIA C ON P.ID_CATEGORIA = C.ID_CATEGORIA
   INNER JOIN MARCAS M ON P.ID_MARCA = M.ID_MARCA WHERE P.ENPORTADA = 3
   ORDER BY ID_PRODUCTO DESC
END
GO

CREATE PROC USP_SEARCH_ALL_PRODUCTOS
@FILTER VARCHAR(120)
AS
BEGIN
SELECT
   P.ID_PRODUCTO,
   P.NOMBRE_PROD,
   P.DESCRIPCION_PRO,
   P.PRECIOXUNIDAD,
   P.STOCK,
   P.ID_CATEGORIA,
   C.NOMBRE_CAT,
   P.ID_MARCA,
   M.NOMBRE_MARCA,
   P.ENPORTADA,
   P.IMAGEN,
   P.ESTADO
   FROM PRODUCTO P INNER JOIN CATEGORIA C ON P.ID_CATEGORIA = C.ID_CATEGORIA
   INNER JOIN MARCAS M ON P.ID_MARCA = M.ID_MARCA
   WHERE P.NOMBRE_PROD LIKE '%'+@FILTER+'%' 
   OR P.DESCRIPCION_PRO LIKE '%'+@FILTER+'%' 
   OR M.NOMBRE_MARCA LIKE '%'+@FILTER+'%' 
   ORDER BY ID_PRODUCTO DESC
END
GO



--- FIN DE USP PRODUCTO ----
---- TABLA TEMPORAL DEL CARRITO DE COMPRAS ---

CREATE TABLE CARRITO(
ID_LOGIN NVARCHAR(128) NULL,
ID_PRODUCTO INT NULL,
NOMBRE_PRO VARCHAR(120),
CANTIDAD INT NULL,
PRECIOXUNIDAD DECIMAL(18,2)NULL,
SUBTOTAL DECIMAL(18,2) NULL,
IMAGEN VARCHAR(120),
DESCRIP NVARCHAR(300)
)
GO

CREATE PROCEDURE USP_DELETE_CARRITO
@ID_LOGIN NVARCHAR(128)
AS
BEGIN
	DELETE FROM CARRITO WHERE ID_LOGIN = @ID_LOGIN
END
GO

CREATE PROCEDURE USP_ADD_CARRITO
@ID_LOGIN NVARCHAR(128),
@ID_PRODUCTO INT,
@NOMBRE_PRO VARCHAR(120),
@CANTIDAD INT,
@PRECIOXUNIDAD DECIMAL(18,2),
@SUBTOTAL DECIMAL(18,2),
@IMAGEN VARCHAR(120),
@DESCRIP NVARCHAR(300)
AS
BEGIN
	IF(SELECT COUNT(*) FROM CARRITO WHERE ID_PRODUCTO = @ID_PRODUCTO AND ID_LOGIN = @ID_LOGIN)>0
		UPDATE CARRITO SET CANTIDAD =  CANTIDAD + @CANTIDAD, SUBTOTAL = SUBTOTAL + @SUBTOTAL WHERE ID_PRODUCTO = @ID_PRODUCTO
	ELSE
		INSERT CARRITO VALUES(@ID_LOGIN,@ID_PRODUCTO,@NOMBRE_PRO,@CANTIDAD,@PRECIOXUNIDAD,@SUBTOTAL, @IMAGEN, @DESCRIP)
END
GO

CREATE PROCEDURE USP_AUMENTAR_ITEM
@ID_LOGIN NVARCHAR(128),
@ID_PRODUCTO INT,
@CANTIDAD INT,
@SUBTOTAL DECIMAL(18,2)
AS
BEGIN
	UPDATE CARRITO SET CANTIDAD =  @CANTIDAD, SUBTOTAL = @SUBTOTAL WHERE ID_PRODUCTO = @ID_PRODUCTO AND ID_LOGIN = @ID_LOGIN
END
GO

CREATE PROCEDURE USP_LISTAR_CARRITO_IDUSER
@ID_LOGIN NVARCHAR(128)
AS
BEGIN
	SELECT ID_LOGIN, ID_PRODUCTO, NOMBRE_PRO, CANTIDAD, PRECIOXUNIDAD, SUBTOTAL, IMAGEN, DESCRIP FROM CARRITO WHERE ID_LOGIN = @ID_LOGIN
END
GO

CREATE PROCEDURE USP_TOTAL_ITEMS_CARRITO
@ID_LOGIN NVARCHAR(128)
AS
BEGIN
	SELECT SUM(CANTIDAD) FROM CARRITO WHERE ID_LOGIN = @ID_LOGIN
END
GO

CREATE PROCEDURE USP_QUITAR_ITEM_CARRITO
@ID_LOGIN NVARCHAR(128),
@ID_PRODUCTO INT
AS
BEGIN
	DELETE FROM CARRITO WHERE ID_PRODUCTO = @ID_PRODUCTO AND ID_LOGIN = @ID_LOGIN
END
GO

----- INICIO DE TABLA CUPON -----

CREATE TABLE CUPON(
ID_CUPON INT PRIMARY KEY IDENTITY (1,1),
NOMBRE_CUPON VARCHAR(120)NULL,
CODIGO_CUPON CHAR(8),
PORCENTAJE INT NULL,
VISIBILIDAD INT NULL,
ESTADO INT NULL
)
GO

CREATE PROCEDURE USP_CREATE_CUPON
@NOMBRECUPON VARCHAR(120),
@CODIGO_CUPON CHAR(8),
@PORCENTAJE INT,
@VISIBILIDAD INT,
@ESTADO INT
AS
BEGIN
	INSERT CUPON VALUES(@NOMBRECUPON,@CODIGO_CUPON,@PORCENTAJE,@VISIBILIDAD,@ESTADO)
END
GO

CREATE PROCEDURE USP_UPDATE_CUPON
@IDCUPON INT,
@NOMBRECUPON VARCHAR(120),
@CODIGO_CUPON CHAR(8),
@PORCENTAJE INT,
@VISIBILIDAD INT,
@ESTADO INT
AS
BEGIN
	UPDATE CUPON SET
	NOMBRE_CUPON = @NOMBRECUPON,
	CODIGO_CUPON = @CODIGO_CUPON,
	PORCENTAJE = @PORCENTAJE,
	VISIBILIDAD = @VISIBILIDAD,
	ESTADO = @ESTADO
	WHERE ID_CUPON = @IDCUPON
END
GO

CREATE PROCEDURE USP_SEARCH_CUPON_ID
@IDCUPON INT
AS
BEGIN
	SELECT ID_CUPON, NOMBRE_CUPON, CODIGO_CUPON, PORCENTAJE, VISIBILIDAD, ESTADO FROM CUPON WHERE ID_CUPON = @IDCUPON
END
GO

CREATE PROCEDURE USP_LISTAR_CUPON
AS
BEGIN
	SELECT ID_CUPON, NOMBRE_CUPON, CODIGO_CUPON, PORCENTAJE, VISIBILIDAD, ESTADO FROM CUPON
END
GO


CREATE PROCEDURE USP_SEARCH_CUPON_CODE
@CODIGO_CUPON CHAR(8)
AS
BEGIN
	SELECT ID_CUPON, NOMBRE_CUPON, CODIGO_CUPON, PORCENTAJE, VISIBILIDAD, ESTADO FROM CUPON WHERE CODIGO_CUPON = @CODIGO_CUPON
END
GO

CREATE PROCEDURE USP_DELETE_CUPON
@IDCUPON INT
AS
BEGIN
	DELETE CUPON WHERE ID_CUPON = @IDCUPON
END
GO

----- USUARIO CUPON ---------
SELECT * FROM CUPON_USER
CREATE TABLE CUPON_USER(
ID_LOGIN NVARCHAR(128) NULL,
CODIGO_CUPON CHAR(8) NULL,
VALOR INT NULL,
ESTADO INT NULL,
FECHA DATETIME NOT NULL
)
GO

CREATE PROCEDURE USP_CREATE_CUPON_USER
@ID_LOGIN NVARCHAR(128),
@CODIGO_CUPON CHAR(8),
@VALOR INT
AS
BEGIN
	INSERT CUPON_USER VALUES(@ID_LOGIN,@CODIGO_CUPON,@VALOR,1,GETDATE())
END
GO

CREATE PROCEDURE USP_SEARCH_CUPON_USER
@ID_LOGIN NVARCHAR(128),
@CODIGO_CUPON CHAR(8)
AS
BEGIN
	SELECT VALOR FROM CUPON_USER WHERE ID_LOGIN = @ID_LOGIN ORDER BY FECHA DESC LIMIT 1
END
GO
select * from CARRITO
SELECT * FROM PEDIDO
SELECT * FROM DETALLE_PEDIDO

------- TABLA DE PEDIDO ---------------
DELETE FROM PEDIDO
DELETE FROM CARRITO
DELETE FROM DETALLE_PEDIDO

CREATE TABLE PEDIDO(
ID_PEDIDO INT PRIMARY KEY IDENTITY(1,1),
ID_LOGIN NVARCHAR(128) NOT NULL,
FECHA_PEDIDO DATETIME NOT NULL,
FECHA_ENTREGA DATETIME NULL,
FECHA_ENVIO DATETIME NULL,
SUBTOTAL DECIMAL(18,2) NULL,
ENVIO DECIMAL(18,2) NULL,
DESCUENTO DECIMAL(18,2),
TOTAL DECIMAL(18,2) NULL,
DIRECCION VARCHAR(50)NULL,
REFERENCIA VARCHAR(50)NULL,
DISTRITO VARCHAR(50)NULL,
PROVINCIA VARCHAR(50)NULL,
REGION VARCHAR(50)NULL,
PAGO INT NULL,
ESTADO INT
)
GO

CREATE TABLE DETALLE_PEDIDO(
ID_PEDIDO INT NOT NULL,
ID_PRODUCTO INT NOT NULL,
CANTIDAD INT NOT NULL,
PRECIOUNITARIO DECIMAL(18,2) NOT NULL,
SUBTOTAL DECIMAL(18,2) NOT NULL,
)
GO

CREATE PROCEDURE USP_CREAR_PEDIDO
@ID_LOGIN NVARCHAR(128),
@SUBTOTAL  DECIMAL(18,2),
@ENVIO  DECIMAL(18,2),
@DESCUENTO  DECIMAL(18,2),
@TOTAL  DECIMAL(18,2),
@DIRECCION VARCHAR(50),
@REFERENCIA VARCHAR(50),
@DISTRITO VARCHAR(50),
@PROVINCIA VARCHAR(50),
@REGION VARCHAR(50)
AS
BEGIN
	DECLARE @ULTIMO INT
	INSERT PEDIDO VALUES(@ID_LOGIN,GETDATE(),NULL,NULL,@SUBTOTAL,@ENVIO,@DESCUENTO,@TOTAL,@DIRECCION,@REFERENCIA,@DISTRITO,@PROVINCIA,@REGION,1,1)
	SET @ULTIMO = SCOPE_IDENTITY()
	SELECT @ULTIMO
END
GO

USP_CREAR_PEDIDO 'XXXXX',20.2,5,0,30.2,'XXXXXXX','XXXX','XXXX','XXXXX','XXXXX'

CREATE PROCEDURE USP_DETALLE_PEDIDO
@IDPEDIDO INT,
@IDPRODUCTO INT,
@CANTIDAD INT,
@PRECIOUNITARIO DECIMAL(18,2),
@SUBTOTAL DECIMAL(18,2)
AS
BEGIN
	INSERT DETALLE_PEDIDO VALUES(@IDPEDIDO,@IDPRODUCTO,@CANTIDAD,@PRECIOUNITARIO,@SUBTOTAL)
END
GO

CREATE PROCEDURE USP_PROCESAR_PAGO_PEDIDO
@IDPEDIDO INT,
@PAGO INT
AS
BEGIN
	UPDATE PEDIDO SET
	PAGO = @PAGO
	WHERE ID_PEDIDO = @IDPEDIDO
END
GO

CREATE PROCEDURE USP_USER_PEDIDO
@ID_LOGIN NVARCHAR(120)
AS
BEGIN
	SELECT TOP 1 ID_PEDIDO, FECHA_PEDIDO, SUBTOTAL, ENVIO, DESCUENTO, TOTAL, PAGO, ESTADO, DIRECCION, REFERENCIA, DISTRITO, PROVINCIA, REGION FROM PEDIDO WHERE ID_LOGIN = @ID_LOGIN ORDER BY FECHA_PEDIDO DESC
END
GO

CREATE PROCEDURE USP_LISTA_DETALLE_PEDIDO
@ID_PEDIDO INT
AS
BEGIN
	SELECT D.ID_PEDIDO, D.ID_PRODUCTO, P.NOMBRE_PROD, D.PRECIOUNITARIO, D.CANTIDAD, D.SUBTOTAL, P.IMAGEN, P.DESCRIPCION_PRO
	FROM DETALLE_PEDIDO D INNER JOIN PRODUCTO P ON P.ID_PRODUCTO = D.ID_PRODUCTO WHERE ID_PEDIDO = @ID_PEDIDO
END
GO

CREATE PROCEDURE USP_LISTAR_PEDIDO
AS
BEGIN
	SELECT P.ID_PEDIDO, P.FECHA_PEDIDO, P.FECHA_ENTREGA, P.FECHA_ENVIO, P.SUBTOTAL, P.ENVIO, P.DESCUENTO, P.TOTAL, P.DIRECCION, P.REFERENCIA, P.DISTRITO, P.PROVINCIA, P.REGION, P.PAGO, P.ESTADO,  (U.APELLIDO + ', ' + U.NOMBRE) AS NOMBRE  FROM PEDIDO P INNER JOIN USUARIO U ON U.ID_LOGIN = P.ID_LOGIN
END
GO

CREATE PROCEDURE USP_DELETE_PEDIDO
@ID_PEDIDO INT
AS
BEGIN
	DELETE FROM PEDIDO WHERE ID_PEDIDO = @ID_PEDIDO
	DELETE FROM DETALLE_PEDIDO WHERE ID_PEDIDO = @ID_PEDIDO
END
GO

CREATE PROCEDURE USP_BUSCAR_PEDIDO
@ID_PEDIDO INT
AS
BEGIN
	SELECT P.ID_PEDIDO, P.FECHA_PEDIDO, P.FECHA_ENTREGA, P.FECHA_ENVIO, P.SUBTOTAL, P.ENVIO, P.DESCUENTO, P.TOTAL, P.DIRECCION, P.REFERENCIA, P.DISTRITO, P.PROVINCIA, P.REGION, P.PAGO, P.ESTADO,  (U.APELLIDO + ', ' + U.NOMBRE) AS NOMBRE 
	FROM PEDIDO P INNER JOIN USUARIO U ON U.ID_LOGIN = P.ID_LOGIN WHERE P.ID_PEDIDO = @ID_PEDIDO
END
GO

CREATE PROCEDURE USP_ACTUALIZAR_ESTADO_PEDIDO
@IDPEDIDO INT,
@ESTADO INT
AS
BEGIN
	IF @ESTADO = 2
		BEGIN
			UPDATE PEDIDO SET
			FECHA_ENVIO =  GETDATE(),
			ESTADO = @ESTADO
			WHERE ID_PEDIDO =  @IDPEDIDO
		END
	ELSE IF @ESTADO = 3
		BEGIN
			UPDATE PEDIDO SET
			FECHA_ENTREGA =  GETDATE(),
			ESTADO = @ESTADO
			WHERE ID_PEDIDO =  @IDPEDIDO
		END
	ELSE
		BEGIN
			UPDATE PEDIDO SET
			FECHA_PEDIDO =  GETDATE(),
			ESTADO = @ESTADO
			WHERE ID_PEDIDO =  @IDPEDIDO
		END
END
GO


---- SIMULADOR DE PAGOS -----

CREATE TABLE TARJETA(
ID_PEDIDO INT PRIMARY KEY IDENTITY(1,1),
TITULAR NVARCHAR(128),
NTARJETA VARCHAR(16),
TIPO INT NULL,
CVC CHAR(3) NULL,
MES INT NULL,
ANIO INT NULL,
CREDITO DECIMAL(18,2) NULL
)
GO

CREATE PROCEDURE USP_INSERTAR_TARJETA
@TITULAR NVARCHAR(128),
@NTARJETA VARCHAR(16),
@TIPO INT,
@CVC CHAR(3),
@MES INT,
@ANIO INT,
@CREDITO DECIMAL(18,2)
AS
BEGIN
	INSERT INTO TARJETA VALUES(@TITULAR,@NTARJETA,@TIPO,@CVC,@MES,@ANIO,@CREDITO)
END
GO

SELECT * FROM TARJETA
GO
--USP_INSERTAR_TARJETA 'ALEX RUBEN ARAGON CALIXTO', '4474110016142388',1,'571',11,2020,1500
--USP_INSERTAR_TARJETA 'ALEX RUBEN ARAGON CALIXTO', '5300721114178228',2,'857',9,2018,30


CREATE PROCEDURE USP_LISTACOMPRAS
@ID_LOGIN NVARCHAR(128)
AS
BEGIN
SELECT p.ID_LOGIN, pro.ID_PRODUCTO, pro.NOMBRE_PROD,pro.DESCRIPCION_PRO,P.FECHA_PEDIDO, dp.CANTIDAD , p.TOTAL
FROM DETALLE_PEDIDO dp JOIN Pedido p
ON dp.ID_PEDIDO  = p.ID_PEDIDO
JOIN PRODUCTO pro
ON dp.ID_PRODUCTO = pro.ID_PRODUCTO
WHERE ID_LOGIN = @ID_LOGIN
END
GO

select * from AspNetRoles
select * from AspNetUsers