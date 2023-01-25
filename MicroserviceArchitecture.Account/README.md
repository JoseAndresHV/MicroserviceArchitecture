## Docker commands
``` console 
docker pull mcr.microsoft.com/mssql/server:2019-latest
```

``` console
docker run -e "ACCEPT_EULA=Y" --network micro -v c:/docker/micro/sqlserver/data:/var/opt/mssql/data -v c:/docker/micro/sqlserver/log:/var/opt/mssql/log -v c:/docker/micro/sqlserver/secrets:/var/opt/mssql/secrets -e "SA_PASSWORD=Passw0rd" -p 1434:1433 --name sql-database -d mcr.microsoft.com/mssql/server:2019-latest
```

## Database scripts
``` sql
CREATE DATABASE db_account;
GO
 
USE db_account;
 
CREATE TABLE Customer(
  IdCustomer INT PRIMARY KEY,
  FullName VARCHAR(150),
  Email VARCHAR(50)
);
 
select * from Customer;
 
INSERT INTO Customer VALUES(1,'Jose Andres Hurtado','joseandreshurtadov@gmail.com');
INSERT INTO Customer VALUES(2,'Leonel Messi','lmessi@gmail.com');
INSERT INTO Customer VALUES(3,'Paolo Guerrero','pguerrero@gmail.com');
INSERT INTO Customer VALUES(4,'Andrea Pirlo','apirlo@gmail.com');
INSERT INTO Customer VALUES(5,'Renato Tapia','rtapia@gmail.com');
         
CREATE TABLE Account(
  IdAccount INT PRIMARY KEY,
  TotalAmount NUMERIC(18,2),
  IdCustomer INT
);

ALTER TABLE Account
ADD FOREIGN KEY (IdCustomer) REFERENCES Customer(IdCustomer);
 
INSERT INTO Account VALUES(1,1000,1);
INSERT INTO Account VALUES(2,5000,1);
INSERT INTO Account VALUES(3,300,2);
INSERT INTO Account VALUES(4,600,1);
INSERT INTO Account VALUES(5,400,2);
INSERT INTO Account VALUES(6,100,1);
INSERT INTO Account VALUES(7,1000,3);
INSERT INTO Account VALUES(8,2000,4);
INSERT INTO Account VALUES(9,5000,5);
INSERT INTO Account VALUES(10,1000,2);
 
SELECT * FROM Account;
```