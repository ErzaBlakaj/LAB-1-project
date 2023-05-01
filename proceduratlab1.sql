
 Create procedure Insert0raret
(
    @Id int,
    @Emri_i_linjes VARCHAR(255),
    @Numri_i_orarit INT,
    @Ora_e_nisjes TIME,
    @Ora_e_mberritjes TIME,
    @Statcioni_i_nisjes VARCHAR(255),
    @Statcioni_i_mberritjes VARCHAR(255),
    @Id_Linjat INT
)
AS
BEGIN
    
    INSERT INTO Oraret (Emri_i_linjes, Numri_i_orarit, Ora_e_nisjes, Ora_e_mberritjes, 
                        statcioni_i_nisjes, statcioni_i_mberritjes, Id_Linjat)
    VALUES (@Emri_i_linjes, @Numri_i_orarit, @Ora_e_nisjes, @Ora_e_mberritjes, 
            @Statcioni_i_nisjes, @Statcioni_i_mberritjes, @Id_Linjat)
END;
EXEC InsertOraret 
    @Emri_i_linjes = 'Linja 1',
    @Numri_i_orarit = 1,
    @Ora_e_nisjes = '08:00',
    @Ora_e_mberritjes = '09:30',
    @Statcioni_i_nisjes = 'Statcioni 1',
    @Statcioni_i_mberritjes = 'Statcioni 2',
    @Id_Linjat = 1;

	CREATE PROCEDURE UpdateOraret
(
    @Id INT,
    @Emri_i_linjes VARCHAR(255) = NULL,
    @Numri_i_orarit INT = NULL,
    @Ora_e_nisjes TIME = NULL,
    @Ora_e_mberritjes TIME = NULL,
    @Statcioni_i_nisjes VARCHAR(255) = NULL,
    @Statcioni_i_mberritjes VARCHAR(255) = NULL,
    @Id_Linjat INT = NULL
)
AS
BEGIN
    UPDATE Oraret
    SET Emri_i_linjes = COALESCE(@Emri_i_linjes, Emri_i_linjes),
        Numri_i_orarit = COALESCE(@Numri_i_orarit, Numri_i_orarit),
        Ora_e_nisjes = COALESCE(@Ora_e_nisjes, Ora_e_nisjes),
        Ora_e_mberritjes = COALESCE(@Ora_e_mberritjes, Ora_e_mberritjes),
        statcioni_i_nisjes = COALESCE(@Statcioni_i_nisjes, statcioni_i_nisjes),
        statcioni_i_mberritjes = COALESCE(@Statcioni_i_mberritjes, statcioni_i_mberritjes),
        Id_Linjat = COALESCE(@Id_Linjat, Id_Linjat)
    WHERE Id = @Id;
END;

CREATE PROCEDURE GetOraret
(
    @Id INT = NULL,
    @Emri_i_linjes VARCHAR(255) = NULL,
    @Numri_i_orarit INT = NULL,
    @Id_Linjat INT = NULL
)
AS
BEGIN
    SELECT *
    FROM Oraret
    WHERE (@Id IS NULL OR Id = @Id)
        AND (@Emri_i_linjes IS NULL OR Emri_i_linjes = @Emri_i_linjes)
        AND (@Numri_i_orarit IS NULL OR Numri_i_orarit = @Numri_i_orarit)
        AND (@Id_Linjat IS NULL OR Id_Linjat = @Id_Linjat)
END;


CREATE PROCEDURE DeleteOraret
(
    @Id INT = NULL,
    @Emri_i_linjes VARCHAR(255) = NULL,
    @Numri_i_orarit INT = NULL,
    @Id_Linjat INT = NULL
)
AS
BEGIN
    DELETE FROM Oraret
    WHERE (@Id IS NULL OR Id = @Id)
        AND (@Emri_i_linjes IS NULL OR Emri_i_linjes = @Emri_i_linjes)
        AND (@Numri_i_orarit IS NULL OR Numri_i_orarit = @Numri_i_orarit)
        AND (@Id_Linjat IS NULL OR Id_Linjat = @Id_Linjat)
END;

CREATE PROCEDURE InsertPerdoruesi
(
    @Emri VARCHAR(255),
    @Mbiemri VARCHAR(255),
    @Email VARCHAR(255),
    @Fjalekalimi VARCHAR(255),
    @Id_role INT
)
AS
BEGIN
    INSERT INTO Perdoruesi (Emri, Mbiemri, Email, Fjalekalimi, Id_role)
    VALUES (@Emri, @Mbiemri, @Email, @Fjalekalimi, @Id_role)
END;
EXEC InsertPerdoruesi
    @Emri = 'John',
    @Mbiemri = 'Doe',
    @Email = 'johndoe@example.com',
    @Fjalekalimi = 'mypassword',
    @Id_role = 1;

	CREATE PROCEDURE UpdatePerdoruesi
    @Id INT,
    @Emri VARCHAR(255),
    @Mbiemri VARCHAR(255),
    @Email VARCHAR(255),
    @Fjalekalimi VARCHAR(255),
    @Id_role INT
AS
BEGIN
    UPDATE Perdoruesi
    SET Emri = @Emri,
        Mbiemri = @Mbiemri,
        Email = @Email,
        Fjalekalimi = @Fjalekalimi,
        Id_role = @Id_role
    WHERE Id = @Id;
END;


	CREATE PROCEDURE GetPerdoruesi
(
    @Id INT = NULL,
    @Emri VARCHAR(255) = NULL,
    @Mbiemri VARCHAR(255) = NULL,
    @Email VARCHAR(255) = NULL,
    @Id_role INT = NULL
)
AS
BEGIN
    SELECT *
    FROM Perdoruesi
    WHERE (@Id IS NULL OR Id = @Id)
        AND (@Emri IS NULL OR Emri = @Emri)
        AND (@Mbiemri IS NULL OR Mbiemri = @Mbiemri)
        AND (@Email IS NULL OR Email = @Email)
        AND (@Id_role IS NULL OR Id_role = @Id_role)
END;

CREATE PROCEDURE DeletePerdoruesi
(
    @Id INT = NULL,
    @Emri VARCHAR(255) = NULL,
    @Mbiemri VARCHAR(255) = NULL,
    @Email VARCHAR(255) = NULL,
    @Id_role INT = NULL
)
AS
BEGIN
    DELETE FROM Perdoruesi
    WHERE (@Id IS NULL OR Id = @Id)
        AND (@Emri IS NULL OR Emri = @Emri)
        AND (@Mbiemri IS NULL OR Mbiemri = @Mbiemri)
        AND (@Email IS NULL OR Email = @Email)
        AND (@Id_role IS NULL OR Id_role = @Id_role)
END;

CREATE PROCEDURE InsertPromokodet
    @Kodi_promocional VARCHAR(255),
    @Zbritja FLOAT,
    @Data_skadimit DATE,
    @DataERegjistrimit DATETIME
AS
BEGIN
    INSERT INTO Promokodet (Kodi_promocional, Zbritja, Data_skadimit, DataERegjistrimit)
    VALUES (@Kodi_promocional, @Zbritja, @Data_skadimit, @DataERegjistrimit);
END;
EXEC InsertPromokodet 'PROMO123', 0.25, '2023-06-30', '2023-04-24 14:30:00';


CREATE PROCEDURE GetPromokode
AS
BEGIN
    EXEC GetPromokode;
    SELECT *
    FROM Promokodet;
END;
CREATE PROCEDURE UpdatePromokodet
    @Kodi_promocional VARCHAR(255),
    @Zbritja FLOAT,
    @Data_skadimit DATE,
    @DataERegjistrimit DATETIME
AS
BEGIN
    UPDATE Promokodet
    SET Zbritja = @Zbritja,
        Data_skadimit = @Data_skadimit,
        DataERegjistrimit = @DataERegjistrimit
    WHERE Kodi_promocional = @Kodi_promocional;
END;
CREATE PROCEDURE DeletePromokodet
    @Kodi_promocional VARCHAR(255)
AS
BEGIN
    DELETE FROM Promokodet
    WHERE Kodi_promocional = @Kodi_promocional;
END;

	CREATE PROCEDURE InsertRolet
(
    @Emri_i_rolit VARCHAR(255)
)
AS
BEGIN
    INSERT INTO Rolet_e_Perdoruesve (Emri_i_rolit)
    VALUES (@Emri_i_rolit)
END;
EXEC InsertRolet
    @Emri_i_rolit = @Emri_i_rolit;

	CREATE PROCEDURE GetRolet
AS
BEGIN
    SELECT *
    FROM Rolet_e_Perdoruesve;
END;

CREATE PROCEDURE UpdateRolet
    @Emri_i_rolit VARCHAR(255),
    @NewEmri_i_rolit VARCHAR(255)
AS
BEGIN
    UPDATE Rolet_e_Perdoruesve
    SET Emri_i_rolit = @NewEmri_i_rolit
    WHERE Emri_i_rolit = @Emri_i_rolit;
END;

CREATE PROCEDURE DeleteRolet
    @Emri_i_rolit VARCHAR(255)
AS
BEGIN
    DELETE FROM Rolet_e_Perdoruesve
    WHERE Emri_i_rolit = @Emri_i_rolit;
END;

CREATE PROCEDURE ShitjetInsertt
(
	@Menyra_pageses_Id int,
	@Promokodi_Id int,
	@Sasia int,
	@KlientId int = null
)
AS
BEGIN
	INSERT INTO Shitjet(Menyra_pageses_Id, Promokodi_Id, Data, Sasia, KlientId)
	VALUES (@Menyra_pageses_Id, @Promokodi_Id, getdate(), @Sasia, @KlientId)
END

CREATE PROCEDURE ShitjetUpdate
(
    @Id INT,
    @Menyra_pageses_Id INT,
    @Promokodi_Id INT,
    @Sasia INT,
    @KlientId INT = NULL
)
AS
BEGIN
    UPDATE Shitjet
    SET Menyra_pageses_Id = @Menyra_pageses_Id,
        Promokodi_Id = @Promokodi_Id,
        Sasia = @Sasia,
        KlientId = @KlientId
    WHERE Id = @Id;
END;

CREATE PROCEDURE ShitjetGet
(
    @Id INT
)
AS
BEGIN
    SELECT Id, Menyra_pageses_Id, Promokodi_Id, Data, Sasia, KlientId, DataERegjistrimit
    FROM Shitjet
    WHERE Id = @Id;
END;

CREATE PROCEDURE ShitjetDelete
(
    @Id INT
)
AS
BEGIN
    DELETE FROM Shitjet
    WHERE Id = @Id;
END;

CREATE PROCEDURE StacioniInsert
(
    @Emri VARCHAR(255),
    @Adresa VARCHAR(MAX),
    @Latitude FLOAT,
    @Longitude FLOAT,
    @Kodi_Postal DECIMAL(11, 8)
)
AS
BEGIN
    INSERT INTO Stacioni (Emri, Adresa, Latitude, Longitude, Kodi_Postal)
    VALUES (@Emri, @Adresa, @Latitude, @Longitude, @Kodi_Postal);
END;
EXEC StacioniInsert @Emri, @Adresa, @Latitude, @Longitude, @Kodi_Postal;

CREATE PROCEDURE StacioniGetAll
AS
BEGIN
    SELECT *
    FROM Stacioni;
END;

CREATE PROCEDURE StacioniUpdate
(
    @Id INT,
    @Emri VARCHAR(255),
    @Adresa VARCHAR(MAX),
    @Latitude FLOAT,
    @Longitude FLOAT,
    @Kodi_Postal DECIMAL(11, 8)
)
AS
BEGIN
    UPDATE Stacioni
    SET Emri = @Emri,
        Adresa = @Adresa,
        Latitude = @Latitude,
        Longitude = @Longitude,
        Kodi_Postal = @Kodi_Postal
    WHERE Id = @Id;
END;

CREATE PROCEDURE StacioniDelete
(
    @Id INT
)
AS
BEGIN
    DELETE FROM Stacioni
    WHERE Id = @Id;
END;

CREATE PROCEDURE StacioniLinjatInsert
(
    @StacioniId INT,
    @LinjatId INT
)
AS
BEGIN
    
    INSERT INTO Stacioni_Linjat (StacioniId, LinjatId)
    VALUES (@StacioniId, @LinjatId);
END;
DECLARE @StacioniId INT, @LinjatId INT;


SET @StacioniId = 1; 
SET @LinjatId = 2; 
EXEC StacioniLinjatInsert @StacioniId, @LinjatId;


CREATE PROCEDURE StacioniLinjatGetAll
AS
BEGIN
    SELECT *
    FROM Stacioni_Linjat;
END;

CREATE PROCEDURE StacioniLinjatUpdate
(
    @Id INT,
    @StacioniId INT,
    @LinjatId INT
)
AS
BEGIN
    UPDATE Stacioni_Linjat
    SET StacioniId = @StacioniId,
        LinjatId = @LinjatId
    WHERE Id = @Id;
END;

CREATE PROCEDURE StacioniLinjatDelete
(
    @Id INT
)
AS
BEGIN
    DELETE FROM Stacioni_Linjat
    WHERE Id = @Id;
END;


CREATE PROCEDURE InsertFeedback
    @Emri_Perdoruesit varchar(255),
    @Komenti text,
    @Vleresimi int,
    @Id_Linjat int
AS
BEGIN
    INSERT INTO Feedback (Emri_Perdoruesit, Komenti, Vleresimi, Id_Linjat)
    VALUES (@Emri_Perdoruesit, @Komenti, @Vleresimi, @Id_Linjat)
END
EXEC InsertFeedback 'Adea', ' This is a great service!', 5, 1 



CREATE PROCEDURE UpdateFeedback
    @Id int,
    @Emri_Perdoruesit varchar(255),
    @Komenti text,
    @Vleresimi int,
    @Id_Linjat int
AS
BEGIN
    UPDATE Feedback
    SET Emri_Perdoruesit = @Emri_Perdoruesit,
        Komenti = @Komenti,
        Vleresimi = @Vleresimi,
        Id_Linjat = @Id_Linjat
    WHERE Id = @Id
END
EXEC UpdateFeedback 1, 'JaneDoe', 'This service needs improvement', 3, 2

CREATE PROCEDURE GetFeedback
    @Id int = NULL,
    @Emri_Perdoruesit varchar(255) = NULL,
    @Id_Linjat int = NULL
AS
BEGIN
    SELECT *
    FROM Feedback
    WHERE (@Id IS NULL OR Id = @Id)
        AND (@Emri_Perdoruesit IS NULL OR Emri_Perdoruesit = @Emri_Perdoruesit)
        AND (@Id_Linjat IS NULL OR Id_Linjat = @Id_Linjat)
END
EXEC GetFeedback @Id = 1
CREATE PROCEDURE DeleteFeedback
    @Id int = NULL,
    @Emri_Perdoruesit varchar(255) = NULL,
    @Id_Linjat int = NULL
AS
BEGIN
    DELETE FROM Feedback
    WHERE (@Id IS NULL OR Id = @Id)
        AND (@Emri_Perdoruesit IS NULL OR Emri_Perdoruesit = @Emri_Perdoruesit)
        AND (@Id_Linjat IS NULL OR Id_Linjat = @Id_Linjat)
END
EXEC DeleteFeedback @Id = 1


CREATE PROCEDURE InsertInfromacionet
    @Titulli varchar(255),
    @Pershkrimi text,
    @Data_Publikimit date
AS
BEGIN
    INSERT INTO Infromacionet (Titulli, Pershkrimi, Data_Publikimit)
    VALUES (@Titulli, @Pershkrimi, @Data_Publikimit)
END

EXEC InsertInfromacionet 'LirimPagese', 'Te gjithe studentet ne te gjitha linjat e urbanave do te jene te liruar nga pagesa ', '2023-04-24'

CREATE PROCEDURE UpdateInfromacionet
(
    @Id INT,
    @Titulli VARCHAR(255),
    @Pershkrimi TEXT,
    @Data_Publikimit DATE
)
AS
BEGIN
    UPDATE Infromacionet
    SET Titulli = @Titulli,
        Pershkrimi = @Pershkrimi,
        Data_Publikimit = @Data_Publikimit
    WHERE Id = @Id
END

CREATE PROCEDURE DeleteInfromacionet
(
    @Id INT
)
AS
BEGIN
    DELETE FROM Infromacionet
    WHERE Id = @Id
END

CREATE PROCEDURE GetInfromacionet
AS
BEGIN
    SELECT Id, Titulli, Pershkrimi, Data_Publikimit
    FROM Infromacionet
END

CREATE PROCEDURE InsertNjoftim
(
    @Titulli VARCHAR(255),
    @Pershkrimi TEXT,
    @Id_Linjat INT
)
AS
BEGIN
    INSERT INTO Njoftimet (Titulli, Pershkrimi, Id_Linjat)
    VALUES (@Titulli, @Pershkrimi, @Id_Linjat)
END
EXEC InsertNjoftim
    @Titulli = 'My Notification Title',
    @Pershkrimi = 'This is my notification description',
    @Id_Linjat = 1;

CREATE PROCEDURE UpdateNjoftim
(
    @Id INT,
    @Titulli VARCHAR(255),
    @Pershkrimi TEXT,
    @Id_Linjat INT
)
AS
BEGIN
    UPDATE Njoftimet
    SET Titulli = @Titulli,
        Pershkrimi = @Pershkrimi,
        Id_Linjat = @Id_Linjat
    WHERE Id = @Id
END

CREATE PROCEDURE GetNjoftimet
AS
BEGIN
    SELECT Njoftimet.Id, Njoftimet.Titulli, Njoftimet.Pershkrimi, Njoftimet.Data_Publikimit, Linjat.Emri
    FROM Njoftimet
    INNER JOIN Linjat ON Njoftimet.Id_Linjat = Linjat.Id
END

CREATE PROCEDURE DeleteNjoftim
(
    @Id INT
)
AS
BEGIN
    DELETE FROM Njoftimet
    WHERE Id = @Id
END

CREATE PROCEDURE InsertLinjat
    @Emri varchar(255),
    @Rruga text,
    @Ndalesat text,
    @Kohezgjatja time
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Linjat (Emri, Rruga, Ndalesat, Kohezgjatja)
    VALUES (@Emri, @Rruga, @Ndalesat, @Kohezgjatja);
END

EXEC InsertLinjat 'Linja 1', 'Rruga e Pejes', 'Nuk ka', '14:30:00';
select * FROM Linjat


CREATE PROCEDURE UpdateLinjat
    @Id int,
    @Emri varchar(255),
    @Rruga text,
    @Ndalesat text,
    @Kohezgjatja time
AS
BEGIN
    UPDATE Linjat
    SET Emri = @Emri, Rruga = @Rruga, Ndalesat = @Ndalesat, Kohezgjatja = @Kohezgjatja
    WHERE Id = @Id;
END

EXEC UpdateLinjat 1, 'Linja 1 updated', 'Rruga e Pejes updated', 'Ndalja tek shkolla updated', '00:45:00';

CREATE PROCEDURE GetLinjatById
    @Id int
AS
BEGIN
    SELECT Id, Emri, Rruga, Ndalesat, Kohezgjatja
    FROM Linjat
    WHERE Id = @Id;
END

CREATE PROCEDURE DeleteLinjatById
    @Id int
AS
BEGIN
    DELETE FROM Linjat
    WHERE Id = @Id;
END
EXEC DeleteLinjatById 1;

CREATE PROCEDURE InsertAutobusat
    @Pershkrimi varchar(255),
    @Targat varchar(50),
    @DataERegjistrimit datetime,
    @DataESkadimitTeRegjistrimit datetime,
    @NrShasise varchar(100)
AS
BEGIN
    INSERT INTO Autobusat (Pershkrimi, Targat, DataERegjistrimit, DataESkadimitTeRegjistrimit, NrShasise)
    VALUES (@Pershkrimi, @Targat, @DataERegjistrimit, @DataESkadimitTeRegjistrimit, @NrShasise);
END
delete from Autobusat
select * from Autobusat

EXEC InsertAutobusat 'Autobusi 1', 'ABC123', '2023-04-24', '2024-04-24', '1234-56789-01234';

CREATE PROCEDURE UpdateAutobusat
    @Id int,
    @Pershkrimi varchar(255),
    @Targat varchar(50),
    @DataERegjistrimit datetime,
    @DataESkadimitTeRegjistrimit datetime,
    @NrShasise varchar(100)
AS
BEGIN
    UPDATE Autobusat
    SET Pershkrimi = @Pershkrimi, Targat = @Targat, DataERegjistrimit = @DataERegjistrimit, DataESkadimitTeRegjistrimit = @DataESkadimitTeRegjistrimit, NrShasise = @NrShasise
    WHERE Id = @Id;
END

EXEC UpdateAutobusat 1, 'Autobusi 1 updated', 'XYZ789', '2023-04-25', '2024-04-25', '5678-90123-45678';

CREATE PROCEDURE GetAutobusatById
    @Id int
AS
BEGIN
    SELECT Id, Pershkrimi, Targat, DataERegjistrimit, DataESkadimitTeRegjistrimit, NrShasise
    FROM Autobusat
    WHERE Id = @Id;
END

EXEC GetAutobusatById 1;

CREATE PROCEDURE DeleteAutobusatById
    @Id int
AS
BEGIN
    DELETE FROM Autobusat
    WHERE Id = @Id;
END

EXEC DeleteAutobusatById 1;

CREATE PROCEDURE InsertAutobusat_Linjat
    @AutobusiId int,
    @LinjatId int
AS
BEGIN
    INSERT INTO Autobusat_Linjat (AutobusiId, LinjatId)
    VALUES (@AutobusiId, @LinjatId);
END
EXEC InsertAutobusat_Linjat 1, 2;

CREATE PROCEDURE UpdateAutobusat_Linjat
    @Id int,
    @AutobusiId int,
    @LinjatId int
AS
BEGIN
    UPDATE Autobusat_Linjat
    SET AutobusiId = @AutobusiId, LinjatId = @LinjatId
    WHERE Id = @Id;
END
EXEC UpdateAutobusat_Linjat 1, 3, 4;

CREATE PROCEDURE GetAutobusat_LinjatById
    @Id int
AS
BEGIN
    SELECT Id, AutobusiId, LinjatId
    FROM Autobusat_Linjat
    WHERE Id = @Id;
END

EXEC GetAutobusat_LinjatById 1;

CREATE PROCEDURE DeleteAutobusat_LinjatById
    @Id int
AS
BEGIN
    DELETE FROM Autobusat_Linjat
    WHERE Id = @Id;
END
EXEC DeleteAutobusat_LinjatById 1;

CREATE PROCEDURE InsertMultipleMenyratEPageses
    @Pershkrimi1 varchar(255),
    @Pershkrimi2 varchar(255),
    @Pershkrimi3 varchar(255)
AS
BEGIN
    INSERT INTO MenyratEPageses (Pershkrimi)
    VALUES (@Pershkrimi1), (@Pershkrimi2), (@Pershkrimi3);
END
EXEC InsertMultipleMenyratEPageses 'Karta Kreditore', 'Banka Online', 'Kesh';

CREATE PROCEDURE UpdateMenyratEPageses
    @Id int,
    @Pershkrimi varchar(255)
AS
BEGIN
    UPDATE MenyratEPageses
    SET Pershkrimi = @Pershkrimi
    WHERE Id = @Id;
END
EXEC UpdateMenyratEPageses 1, 'Karta Debitore';


CREATE PROCEDURE GetMenyratEPagesesById
    @Id int
AS
BEGIN
    SELECT Id, Pershkrimi
    FROM MenyratEPageses
    WHERE Id = @Id;
END

EXEC GetMenyratEPagesesById 1;


CREATE PROCEDURE DeleteMenyratEPagesesById
    @Id int
AS
BEGIN
    DELETE FROM MenyratEPageses
    WHERE Id = @Id;
END


EXEC DeleteMenyratEPagesesById 1;



CREATE PROCEDURE InsertSubscription
  @duration VARCHAR(20),
  @price DECIMAL(10,2),
  @Start_date DATE,
  @End_date DATE
AS
BEGIN
  INSERT INTO subscription (duration, price, Start_data, End_date)
  VALUES (@duration, @price, @Start_date, @End_date);
END;
EXEC InsertSubscription 'monthly', 19.99, '2023-05-01', '2023-06-01';

CREATE PROCEDURE UpdateSubscription
  @id INT,
  @duration VARCHAR(20),
  @price DECIMAL(10,2),
  @Start_date DATE,
  @End_date DATE
AS
BEGIN
  UPDATE subscription
  SET duration = @duration,
      price = @price,
      Start_data = @Start_date,
      End_date = @End_date
  WHERE id = @id;
END;
EXEC UpdateSubscription 1, 'yearly', 99.99, '2023-01-01', '2024-01-01';

CREATE PROCEDURE DeleteSubscription
  @id INT
AS
BEGIN
  DELETE FROM subscription
  WHERE id = @id;
END;
EXEC DeleteSubscription 1;
