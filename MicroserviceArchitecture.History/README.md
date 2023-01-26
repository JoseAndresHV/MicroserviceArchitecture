## Docker commands
``` console 
docker pull mongo
```

``` console
docker run -p 27018:27017 --network micro -v c:/docker/micro/mongo:/etc/mongo -e MONGO_INITDB_ROOT_USERNAME=joseandreshv -e MONGO_INITDB_ROOT_PASSWORD=Passw0rd --name mongo-database -d mongo
```