# MicroserviceArchitecture
## Description
This repository contains a microservice architecture solution for a bank, built using `.NET 6`. The solution aims to provide a scalable, reliable and secure platform for managing financial transactions and customer information for a bank. </br>

![MicroserviceArchitecture Diagram](https://user-images.githubusercontent.com/30439829/216081783-31871fff-8fc3-4afc-96a8-6466c81abd40.png)

## Microservices
The solution consists of several microservices, each responsible for a specific aspect of the bank's operations. These microservices communicate with each other using APIs, ensuring loose coupling and easy maintenance. The microservices are:

- Security service: responsible for authentication.
- Account service: responsible for managing customer account information.
- Deposit service: responsible for processing deposit transactions.
- Withdrawal service: responsible for processing withdrawal transactions.
- History service: responsible for storing and retrieving transaction history for customers.
- Notification service: responsible for sending notifications to customers regarding their accounts and transactions.

## Features
- Scalable and modular architecture
- Secure and reliable communication between microservices
- Easy maintenance and upgrading of individual microservices
- Option to deploy microservices on-premises or in the cloud

### Docker commands
[Used commands](https://github.com/JoseAndresHV/MicroserviceArchitecture/blob/master/docker-commands.md)




