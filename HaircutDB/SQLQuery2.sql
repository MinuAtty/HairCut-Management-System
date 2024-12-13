CREATE TABLE client (
    clientid INT IDENTITY (1,1),
    clientname VARCHAR (20),
    clientsurname VARCHAR (20),
    clientphone INT,
    clientemail VARCHAR (20),
    PRIMARY KEY (clientid)
);