## Docker commands
``` console 
docker pull mariadb
```

``` console
docker run --name maria-database --network micro -v c:/docker/micro/mariadb:/var/lib/mysql -e MYSQL_ROOT_PASSWORD=Passw0rd -p 3310:3306 -p 33061:33060 -d mariadb
```

## Database scripts
``` sql
CREATE DATABASE db_notification;

USE db_notification;

CREATE TABLE SendMail(
  SendMailId INT AUTO_INCREMENT PRIMARY KEY,
  SendDate VARCHAR(10),
  Type VARCHAR(20),
  Message VARCHAR(250),
  Address VARCHAR(50),
  AccountId INT
);

SELECT * FROM SendMail;
```