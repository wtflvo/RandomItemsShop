CREATE TABLE ShopTable(
   id          INTEGER  NOT NULL PRIMARY KEY 
  ,title       VARCHAR(97) NOT NULL
  ,price       NUMERIC(6,2) NOT NULL
  ,description VARCHAR(772) NOT NULL
  ,category    VARCHAR(16) NOT NULL
  ,image       VARCHAR(71) NOT NULL
  ,count INTEGER  NOT NULL
);