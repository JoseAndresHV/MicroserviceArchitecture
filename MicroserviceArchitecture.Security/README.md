## Docker commands
``` console 
docker pull mysql
```

``` console
docker run --name mysql-database --network micro -v c:/docker/micro/mysql:/var/lib/mysql -e MYSQL_ROOT_PASSWORD=Passw0rd -p 3307:3306 -p 33062:33060 -d mysql
```

## Database scripts
``` sql
CREATE DATABASE db_security;

USE db_security;

CREATE TABLE IF NOT EXISTS Access(
  UserId INT AUTO_INCREMENT PRIMARY KEY,
  FullName VARCHAR(255) NOT NULL,
  Username VARCHAR(50) NOT NULL,
  Password VARCHAR(50) NOT NULL
);

INSERT INTO Access(Fullname, Username, Password)
VALUES('Jose Andres Hurtado', 'joseandreshv','Passw0rd');
```