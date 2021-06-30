/* CREACION DE LA BASE DE DATOS */

create database DBTutorias   
on
  (name = DBTutorias,           -- Primary data file
   filename = 'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Files\Tutorias.mdf',
  
  SIZE = 5MB,
  MAXSIZE = 20MB,
  FILEGROWTH = 5MB
  )  
  log on
  (name = DBTutorias_Log,       -- Log file
   filename = 'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Files\Tutorias.ldf',
   SIZE = 5MB,
   MAXSIZE = 20MB,
   FILEGROWTH = 2MB
  )
go
	
/* CREACION DE TIPOS */

use DBTutorias

/* CREACION DE TABLAS */

create table EscuelaProfesional
( -- lista de atributos
  CodEP varchar(8) NOT NULL,
  Nombre varchar(45) NOT NULL,
  -- definición de claves
  primary key (CodEP),
)
go

create table Alumno
( -- lista de atributos
  CodAlumno varchar(8) NOT NULL,
  Nombres varchar(45) NOT NULL,
  Apellidos varchar(45) NOT NULL,
  CodEP varchar(8), 
  -- definición de claves
  primary key (CodAlumno),
  foreign key (CodEP) REFERENCES EscuelaProfesional(CodEP)
)
go

create table DocenteTutor
( -- lista de atributos
  CodTutor varchar(8) NOT NULL,
  Nombres varchar(45) NOT NULL,
  Apellidos varchar(45) NOT NULL,
  CodEP varchar(8), 
  -- definición de claves
  primary key (CodTutor),
  foreign key (CodEP) REFERENCES EscuelaProfesional(CodEP)
)
go

use DBTutorias

/* INSERTAR DATOS */

insert into EscuelaProfesional values('IN','INGENIERIA INFORMATICA Y DE SISTEMAS')
insert into EscuelaProfesional values('ME','MATEMATICAS')
insert into EscuelaProfesional values('CO','CONTABILIDAD')
insert into EscuelaProfesional values('IL','INGENIERIA ELECTRONICA')

insert into Alumno values('980115','ANA','PAZ GUERRA','IN')
insert into Alumno values('990225','ANGEL ANTONIO','ARCE ANDIA','IN')
insert into Alumno values('991347','BENITO','BUENO BUENDIA','IN')
insert into Alumno values('000231','CARLOTA','CUSI COSIO','IN')
insert into Alumno values('001121','DAVID','DUEÑAS DAVILA','IN')
insert into Alumno values('980335','ERNESTO','ESCOBAR ESTRADA','ME')
insert into Alumno values('980255','FABIOLA','FARFAN FLORES','ME')
insert into Alumno values('991371','GABRIELA','GARCIA GUDIEL','ME')
insert into Alumno values('000219','HUMBERTO','HURTADO HUILLCA','ME')
insert into Alumno values('001227','INES','IBARRA IBAÑEZ','ME')
insert into Alumno values('980116','JULIO','JIMENEZ JARAMILLO','CO')
insert into Alumno values('980277','KEVIN','KAWAMURA KAWAMURA','CO')
insert into Alumno values('991197','LILIANA','LOZA LUZA','CO')
insert into Alumno values('000919','MARISOL','MEZA MAR','CO')
insert into Alumno values('001447','NOHEMI','NUÑEZ NAVIA','CO')
insert into Alumno values('980366','OMAR','ORTEGA OCAMPO','IL')
insert into Alumno values('990788','PABLO','PRADO PERALTA','IL')
insert into Alumno values('991779','ROSA','RAMOS ROBLES','IL')
insert into Alumno values('000998','SOFIA','SALAZAR SALAS','IL')
insert into Alumno values('001876','TOMAS','TORRES TARRAGA','IL')

insert into DocenteTutor values ('123400','ALEJANDRO','GARCIA OLIVERA','IN')
insert into DocenteTutor values ('153418','MARIA','MENDOZA QUISPE','IN')
insert into DocenteTutor values ('162700','JOSE LUIS','PEÑA AYALA','IN')
insert into DocenteTutor values ('188021','CARLOS','ATAYUPANQUI SALAS','IN')
insert into DocenteTutor values ('183456','JUAN','CANAL TORRES','ME')
insert into DocenteTutor values ('176543','ZOILA','ACUÑA UMERES','ME')
insert into DocenteTutor values ('193023','ESTHER','PAREDES OLIVERA','CO')
insert into DocenteTutor values ('172453','ERNESTO','CARPIO PUELLES','CO')
insert into DocenteTutor values ('193405','GIOVANNA','TARRAGA PEZO','IL')
insert into DocenteTutor values ('189022','EVA','ARCE CRESPO','IL')

select * from Alumno