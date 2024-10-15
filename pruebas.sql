CREATE TABLE Marca (
    IdMarcas INT PRIMARY KEY,
    Nombre VARCHAR(100),
    Descripcion VARCHAR(255)
);

CREATE TABLE Herramientas (
    CodigoHerramienta VARCHAR(20) PRIMARY KEY,
    Nombre VARCHAR(100),
    Medida VARCHAR(50),
    Descripcion VARCHAR(50),
    fkIdMarca INT,
    FOREIGN KEY (fkIdMarca) REFERENCES Marca(IdMarcas)
);

CREATE TABLE Refacciones (
	idRefaccion int primary key auto_increment,
    CodigoHerramientas VARCHAR(20),
    Nombre VARCHAR(100),
    Descripcion VARCHAR(50),
    fkIdMarca INT,
    PRIMARY KEY (CodigoHerramientas),
    FOREIGN KEY (fkIdMarca) REFERENCES Marca(IdMarcas)
);

CREATE TABLE Usuarios (
    idUsuario INT PRIMARY KEY,
    Nombre VARCHAR(100),
    ApellidoP VARCHAR(50),
    ApellidoM VARCHAR(50),
    FechaNacimiento DATE,
    RFC VARCHAR(20),
    Usuario VARCHAR(20),
    Tipo VARCHAR(50),
    Contraseña VARCHAR(255)
);

CREATE TABLE Formulario (
    idFormulario INT PRIMARY KEY,
    NombreFormulario VARCHAR(100)
);


CREATE TABLE Permisos (
    IdPermisos INT PRIMARY KEY,
    Lectura TINYINT,
    Escritura TINYINT,
    Eliminacion TINYINT,
    Actualizacion TINYINT,
    fkIdFormulario INT,
    fkIdUsuario INT,
    FOREIGN KEY (fkIdFormulario) REFERENCES Formulario(idFormulario),
    FOREIGN KEY (fkIdUsuario) REFERENCES Usuarios(idUsuario)
);

DELIMITER //
DROP PROCEDURE IF EXISTS validar;
CREATE PROCEDURE validar (
	IN _nic VARCHAR(50),
	IN _clave VARCHAR(255)
)
	BEGIN 
	DECLARE x INT; 
	SELECT COUNT(*) FROM usuarios WHERE nic=_nic AND clave=_clave INTO x;
	if x > 0 then
	SELECT 'C0rr3ct0' AS rs, (SELECT tipo FROM usuarios WHERE nic=_nic AND clave=_clave) AS tipo;
	else
	SELECT 'Error' AS rs, 0 AS tipo;
	END if;
END //
DELIMITER ;


INSERT INTO Marca (IdMarcas, Nombre, Descripcion)
VALUES 
(NULL, 'Bosch', 'Herramientas eléctricas'),
(NULL, 'Stanley', 'Herramientas manuales'),
(NULL, 'Makita', 'Herramientas de alta tecnología'),
(NULL, 'DeWalt', 'Herramientas de construcción'),
(NULL, 'Black+Decker', 'Electrodomésticos y herramientas de jardín');

INSERT INTO Herramientas (CodigoHerramienta, Nombre, Medida, Descripcion, fkIdMarca)
VALUES
('H001', 'Taladro Inalámbrico', '10.9', 'Taladro sin cable', 1),
('H002', 'Sierra Circular', '16.3', 'Corta madera', 3),
('H003', 'Destornillador', '20.3', 'Manual', 2),
('H004', 'Lijadora Orbital', '12.5', 'Lijado suave', 4),
('H005', 'Esmeriladora', '11.5', 'Esmerilado potente', 5);

INSERT INTO Refacciones (CodigoHerramientas, Nombre, Descripcion, fkIdMarca)
VALUES
('H001', 'Batería 18V', 'Recambio para taladro', 1),
('H002', 'Disco 165mm', 'Recambio para sierra', 3),
('H003', 'Punta Phillips', 'Recambio para destornillador', 2),
('H004', 'Papel de lija', 'Recambio para lijadora', 4),
('H005', 'Disco de corte', 'Recambio para esmeriladora', 5);


INSERT INTO Usuarios (idUsuario, Nombre, ApellidoP, ApellidoM, FechaNacimiento, RFC, Usuario, Tipo, Contraseña)
VALUES
(null, 'admin', 'Pérez', 'García', '1990-05-14', 'PEGA900514HMN', 'admin', 'Administrador', sha1('123456')),
(null, 'María', 'López', 'Martínez', '1985-08-21', 'LOMA850821HTC', 'mlopez', 'Usuario', sha1('123456'));
(null, 'Pedro', 'González', 'Sánchez', '1978-12-02', 'GOSA781202HBV', 'pgonzalez', 'Administrador', sha1('123456')),
(null, 'Ana', 'Ramírez', 'Cruz', '1995-03-30', 'RACA950330HGX', 'aramirez', 'Admin', 'Administrador', sha1('123456')),
(null, 'Luis', 'Fernández', 'Hernández', '1988-11-15', 'FEHE881115HTL', 'lfernandez', 'Usuario', sha1('123456'));



