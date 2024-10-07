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
    CodigoHerramientas VARCHAR(20),
    Nombre VARCHAR(100),
    Descripcion VARCHAR(50),
    fkIdMarca INT,
    PRIMARY KEY (CodigoHerramientas),
    FOREIGN KEY (fkIdMarca) REFERENCES Marca(IdMarcas)
);


CREATE TABLE Formulario (
    idFormulario INT PRIMARY KEY,
    NombreFormulario VARCHAR(100)
);

CREATE TABLE Usuarios (
    idUsuario INT PRIMARY KEY,
    Nombre VARCHAR(100),
    ApellidoP VARCHAR(50),
    ApellidoM VARCHAR(50),
    FechaNacimiento DATE,
    RFC VARCHAR(20),
    Usuario VARCHAR(20),
    Contraseña VARCHAR(255)
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