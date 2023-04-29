create table Stacioni (
Id int primary key identity(1,1),
Emri varchar (255) not null,
Adresa varchar(max) not null,
Latitude FLOAT,
Longitude FLOAT,
Kodi_Postal decimal(11,8)
);

CREATE TABLE Stacioni_Linjat(
Id int primary key identity(1,1),
StacioniId int not null,
LinjatId int not null,
foreign key (StacioniId) references Stacioni(Id),
foreign key (LinjatId) references Linjat(Id)
)


create table Linjat (
Id int primary key identity(1,1),
Emri varchar (255) not null,
Rruga text,
Ndalesat text,
Kohezgjatja time,
);

create table Autobusat(
	Id int primary key identity(1,1),
	Pershkrimi varchar(255) not null,
	Targat varchar(50) null,
	DataERegjistrimit datetime null,
	DataESkadimitTeRegjistrimit datetime null,
	NrShasise varchar(100) null
)

CREATE TABLE Autobusat_Linjat(
Id int primary key identity(1,1),
AutobusiId int not null,
LinjatId int not null,
foreign key (AutobusiId) references Autobusat(Id),
foreign key (LinjatId) references Linjat(Id)
)

create table Oraret (
Id int primary key identity(1,1),
Emri_i_linjes varchar (255),
Numri_i_orarit int,
Ora_e_nisjes time,
Ora_e_mberritjes time,
statcioni_i_nisjes varchar (255),
statcioni_i_mberritjes varchar (255),
Id_Linjat int not null,
foreign key (Id_Linjat) references Linjat(Id)
);

create table Rolet_e_Perdoruesve (
Id int primary key identity(1,1),
Emri_i_rolit varchar (255)
);

create table Perdoruesi (
Id int primary key identity(1,1),
Emri varchar (255),
Mbiemri varchar(255),
Email varchar (255),
Fjalekalimi varchar(255),
Id_role int,
foreign key (Id_role) references Rolet_e_Perdoruesve(Id)
);


create table MenyratEPageses(
Id int primary key identity(1,1),
Pershkrimi varchar (255)
);


create table Promokodet (
Id int primary key identity(1,1),
Kodi_promocional varchar (255),
Zbritja float,
Data_skadimit date,
DataERegjistrimit datetime
);

create table Shitjet (
Id int primary key identity(1,1),
Menyra_pageses_Id int,
Promokodi_Id int,
Data date,
Sasia int,
KlientId int null,
DataERegjistrimit datetime default(getdate()),
foreign key (Menyra_pageses_Id) references MenyratEPageses(Id),
foreign key (Promokodi_Id) references Promokodet(Id),
foreign key (KlientId) references Perdoruesi(Id)
);

create table Feedback (
Id int primary key identity(1,1),
Emri_Perdoruesit varchar(255),
Komenti text,
Vleresimi int,
Krijuar_ne datetime default(getdate()),
Id_Linjat int not null,
foreign key (Id_Linjat) references Linjat(Id)
);

create table Njoftimet (
Id int primary key identity(1,1),
Titulli varchar (255) not null,
Pershkrimi text,
Data_Publikimit datetime default(getdate()),
Id_Linjat int not null,
foreign key (Id_Linjat) references Linjat(Id)
);

create table Infromacionet (
Id int primary key identity(1,1),
Titulli varchar (255),
Pershkrimi text,
Data_Publikimit date
);


