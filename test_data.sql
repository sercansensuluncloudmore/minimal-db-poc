use tempdb; 

CREATE TABLE Persons (PersonID int,Username varchar(255)); 

INSERT INTO Persons (PersonID, Username) VALUES (1, 'Test_Username_1'); 
INSERT INTO Persons (PersonID, Username) VALUES (2, 'Test_Username_2'); 

SELECT * FROM Persons;