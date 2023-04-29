create database lab1

use lab1

create table Harta (
Id int not null primary key,
Emri varchar (255) not null,
Vendndodhja decimal(10,8),
Kodi_Postal decimal(11,8)
);

create table Linjat (
Id int not null primary key,
Emri varchar (255) not null,
Rruga text,
Ndalesat text,
Kohezgjatja time,
);

create table Oraret (
Id int not null primary key,
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
Id int not null primary key,
Emri_i_rolit varchar (255)
);

create table Perdoruesi (
Id int not null primary key,
Emri varchar (255),
Mbiemri varchar(255),
Email varchar (255),
Fjalekalimi varchar(255),
Id_role int,
foreign key (Id_role) references Rolet_e_Perdoruesve(Id)
);

create table Pagesat (
Id int not null primary key,
Lloji_Pageses varchar(255),
Tarifa float
);

create table Menyra_Pageses (
Id int not null primary key,
Emri_menyres varchar (255),
Pershkkrimi varchar (255)
);

create table Promokodet (
Id int not null primary key,
Kodi_promocional varchar (255),
Zbritja float,
Data_skadimit date
);

create table Shitjet (
Id int not null primary key,
Lloji_pageses_Id int,
Menyra_pageses_Id int,
Promokodi_Id int,
Data date,
Sasia int,
foreign key (Lloji_pageses_Id) references Pagesat(Id),
foreign key (Menyra_pageses_Id) references Menyra_Pageses(Id),
foreign key (Promokodi_Id) references Promokodet(Id)
);

create table Feedback (
Id int primary key,
Emri_Perdoruesit varchar(255),
Komenti text,
Vleresimi int,
Krijuar_ne timestamp default current_timestamp,
Id_Linjat int not null,
foreign key (Id_Linjat) references Linjat(Id)
);

create table Njoftimet (
Id int not null primary key,
Titulli varchar (255) not null,
Pershkrimi text,
Data_Publikimit timestamp default current_timestamp,
Id_Linjat int not null,
foreign key (Id_Linjat) references Linjat(Id)
);

create table Infromacionet (
Id int not null primary key,
Titulli varchar (255),
Pershkrimi text,
Data_Publikimit date
);
