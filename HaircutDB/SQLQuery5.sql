CREATE TABLE billing (
    id INT IDENTITY (1,1),
    cusname VARCHAR (20),
    servicename VARCHAR (20),
    cost INT,
    PRIMARY KEY (id)
);