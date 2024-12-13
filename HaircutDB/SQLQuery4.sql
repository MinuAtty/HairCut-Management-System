CREATE TABLE services (
    productid INT IDENTITY (1,1),
    productname VARCHAR (20),
    productprice INT,
    duration INT,
    cost INT,
    PRIMARY KEY (productid)
);