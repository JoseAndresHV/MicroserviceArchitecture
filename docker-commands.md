# Docker commands
Docker commands used to set up the project:

``` console 
docker network create micro
```

### Microservices
- [Security](https://github.com/JoseAndresHV/MicroserviceArchitecture/blob/master/MicroserviceArchitecture.Security/README.md)
- [Account](https://github.com/JoseAndresHV/MicroserviceArchitecture/blob/master/MicroserviceArchitecture.Account/README.md)
- [Deposit](https://github.com/JoseAndresHV/MicroserviceArchitecture/blob/master/MicroserviceArchitecture.Deposit/README.md)
- [Withdrawal](https://github.com/JoseAndresHV/MicroserviceArchitecture/blob/master/MicroserviceArchitecture.Withdrawal/README.md)
- [History](https://github.com/JoseAndresHV/MicroserviceArchitecture/blob/master/MicroserviceArchitecture.History/README.md)
- [Notification](https://github.com/JoseAndresHV/MicroserviceArchitecture/blob/master/MicroserviceArchitecture.Notification/README.md)

### Registry and discovery
``` console 
docker pull consul
```
``` console 
docker run --name consul-service -p 8500:8500 -d --network micro consul 
```

### Load Balancing
``` console 
docker pull fabiolb/fabio
```
``` console 
docker run --name fabio-service -e FABIO_REGISTRY_CONSUL_ADDR=consul-service:8500 -p 9998:9998 -p 9999:9999 -d --network micro fabiolb/fabio
```

### Config Server
``` console 
docker pull hyness/spring-cloud-config-server
```
``` console 
docker run -d --name config-service -p 8888:8888 -e SPRING_CLOUD_CONFIG_SERVER_GIT_URI=https://github.com/JoseAndresHV/MicroserviceArchitecture hyness/spring-cloud-config-server
```

### In-memory Database
``` console 
docker pull redis
```
``` console 
docker run -d -p 6379:6379 --network micro -v c:/docker/micro/redis:/data -e REDIS_PASSWORD=Passw0rd --name redis-database redis --requirepass Passw0rd
```

### Distributed Tracing

``` console 
docker pull jaegertracing/all-in-one
```
``` console 
docker run -d --name jaeger-service -e COLLECTOR_ZIPKIN_HTTP_PORT=9411 -p 5775:5775/udp -p 6831:6831/udp -p 6832:6832/udp -p 5778:5778 -p 16686:16686 -p 14268:14268 -p 9411:9411 --network micro jaegertracing/all-in-one
```

### Metrics
``` console 
docker pull prom/prometheus
```
``` console 
docker run -p 9090:9090 --name prometheus-service --network micro -v c:/docker/micro/prometheus/prometheus.yml:/etc/prometheus/prometheus.yml -d prom/prometheus
```

### Analytics
``` console 
docker pull grafana/grafana
```
``` console 
docker run -p 3000:3000 --name grafana-service --network micro -d grafana/grafana
```

### Logs
``` console 
docker pull datalust/seq
```
``` console 
docker run -e ACCEPT_EULA=Y --name log-service -p 5341:80 -d datalust/seq
```



