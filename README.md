$$
University Book Shop
$$

[![GitHub Actions Status](https://github.com/MrLait/UniversityBookShop/actions/workflows/CiReactAppAndDotNetApp.yml/badge.svg)](https://github.com/MrLait/UniversityBookShop/actions)

[![GitHub Actions Status](https://github.com/MrLait/UniversityBookShop/actions/workflows/DockerBuild.yml/badge.svg)](https://github.com/MrLait/UniversityBookShop/actions)

# Description
This project is developed using technologies such as Docker, .NET 6, MySQL Server, React, Nginx, and MongoDB. You have two ways to run this project:

1. Run the application using Docker Compose.
2. Run all technologies one by one.

## Installation
### Run with Docker
1. [Install Docker Desktop on Windows](https://docs.docker.com/desktop/install/windows-install/) 
   
### Run without Docker
1. Download [.NET 6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
2. Download [MySQL 8.0.36](https://dev.mysql.com/downloads/installer/)
3. Download React:
   - Install [Node.js with npm](https://nodejs.org/en/download) and then restart your PC.
4. MongoDB links:
   - Download [Community Server](https://www.mongodb.com/try/download/community)
   - Download [MongoDB Shell](https://www.mongodb.com/try/download/shell)
     - MongoDB Shell install instructions:
       1. Download the archive and extract it to the MongoDB directory.
       2. Edit the system environment variables and add the path to the bin directory.

## Project folders:
1. Backend folder: UniversityBookShop\src\dotnet-app\UniversityBookShop.Api\
2. Client folder: UniversityBookShop\src\react-app\university-book-shop\
## ApplicationUrl:
1. Backend.Api url: https://localhost:7265,http://localhost:5108 
2. Client url: http://localhost:3000

# **How to Run the Application**
## **Using Docker Compose**
1. [Ensure that Docker Desktop is installed on Windows.](https://docs.docker.com/desktop/install/windows-install/)
2. Navigate to the root directory of the UniversityBookShop project.
3. Open a terminal or command prompt in the root directory and run the following command:
   ```bash
   docker-compose up -d
   ```
4. Wait for the build and container startup process to complete.
5. After a successful launch, your application will be available at the following URLs:
   1. nginx: http://localhost
      1. Docker ports: "80:80"
   2. Client application: http://localhost:5001/ but you have to use http://localhost
      1. Docker ports: "5001:3000⁠"
   3. Backend API: http://localhost:7265
      1. Docker ports: "7265:80⁠"
   4. MySql docker ports:: "30062:3060"

## **Without Using Docker**
1. Follow the instructions below to install each component individually:
   1. Install .NET 6, MySQL 8.0.36, Node.js with npm,
2. Navigate to the project directories:
   1. Backend: src\dotnet-app\UniversityBookShop.Api\
   2. Client: src\react-app\university-book-shop\
3. Run each part of the project separately following the instructions in their respective directories.
   1. Using scripts
      1. Go to folder scripts and run 
         ```
         RunUniversityBookShop.bat
         ```
   1. Or use command:
      1. Go to backend folder and use command: 
         ```
         dotnet run
         ```
      2. Go to frontend folder and use command: 
         ```
         npm start
         ```
4. After a successful launch, application will be available at the following URLs:
   1. Backend API: https://localhost:7265, http://localhost:5108
   2. Client application: http://localhost:3000