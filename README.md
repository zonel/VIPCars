# Project Documentation: VIPCars
![image](https://github.com/zoneel/VIPCars/assets/106118915/7aa53bef-65f9-45fc-8153-9478cea424ba)




## Project Description

VIPCars is a web application designed to facilitate the reservation of premium brand cars. This innovative platform offers users the convenience of booking high-end vehicles with ease.

## Technologies Used in the Project

- MVC
- Blazor
- Bootstrap
- Entity Framework
- MSSQL
- Clean Architecture
- MediatR
- CQRS
- Serilog
- Docker

## Project Architecture
Project is created, using CLEAN architecture. It means, that We have seprated our Application into 4 projects, also We are using Command and Query seperation pattern.

![image](https://github.com/zoneel/VIPCars/assets/106118915/57377937-b6f8-46e1-afa1-fbc08ae32135)


## Data Model
The data structure is a follows: 

![image](https://github.com/zoneel/VIPCars/assets/106118915/000b2e3c-45b9-4939-a0ab-ef6346771747)

The tables are constructed based on the following models:
- Cars
- Orders
- Users
- Addresses
- Roles

## Security

To ensure User security, We are storing hashed User's password in the Database.
We can achive this by using IPasswordhasher method

## Running Instructions

1. Clone the repository.

2. Create and run a container using docker-compose located in our project.

3. Access fully working website through your browser!

(default port is set to 5000 so you can access website by going to: localhost:5000) 

## Seeders!

To avoid access issues, it is recommended to log in with the pre-seeded user with the following data:

1. [Admin] email: admin@email.com // password: toortoor
2. [User] email: user@email.com // password: toortoor

## If you want to see how Admin panel works, i recommend You to log in as Admin :)
![image](https://github.com/zoneel/VIPCars/assets/106118915/7c5c422d-cd03-4602-9ef5-c387ca999491)
