* .NET Core 2.2 will need to be installed, it can be found here https://dotnet.microsoft.com/download/dotnet-core/2.2
* For Mac users, download MySQL here: https://dev.mysql.com/downloads/file/?id=484914
* For Windows users, download MySQL here: https://dev.mysql.com/downloads/file/?id=484919
* Install MySQL and set the system path, more information on how to do that can be found here: https://www.learnhowtoprogram.com/c-and-net/getting-started-with-c/installing-and-configuring-mysql
* Run MySQL by entering `mysql -uroot -pepicodus` in the terminal
* Enter the following commands to create the necessary database and tables:
```
CREATE DATABASE `best_restaurants`;
USE DATABASE `best_restaurants`;
CREATE TABLE `cuisines` (
  `CuisineId` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`CuisineId`)
);
CREATE TABLE `restaurants` (
  `RestaurantId` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(255) DEFAULT NULL,
  `Description` varchar(255) DEFAULT NULL,
  `Address` varchar(255) DEFAULT NULL,
  `CuisineId` int NOT NULL DEFAULT '0',
  PRIMARY KEY (`RestaurantId`)
);
CREATE TABLE `reviews` (
  `ReviewId` int NOT NULL AUTO_INCREMENT,
  `ReviewerName` varchar(255) DEFAULT NULL,
  `ReviewText` varchar(255) DEFAULT NULL,
  `Rating` int NOT NULL DEFAULT '0',
  `RestaurantId` int NOT NULL DEFAULT '0',
  PRIMARY KEY (`ReviewId`)
);
```
* Clone the GitHub repository by running `git clone https://github.com/pagrimm/BestRestaurants.Solution.git` in the terminal
* Navigate to the newly created `BestRestaurants.Solution` folder
* Navigate to the `BestRestaurants` subfolder and run `dotnet restore`
* Run `dotnet build` to build the app and `dotnet run` to run it
* The web app will now be available on `http://localhost:5000/` in your browser