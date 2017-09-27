CREATE DATABASE DICE

USE DICE

--Drop Table Player
--Drop Table PlayerSession

--Drop Table Game
--Drop Table Dice
--Drop Table Step
--Drop Table PlayerCommon

CREATE TABLE Player(
Id int IDENTITY NOT NULL PRIMARY KEY,
UserName varchar(20) NOT NULL ,
FirstName varchar(20) NOT NULL,
LastName varchar(20),
PasswordHash varchar(150) NOT NULL,
IsActive int NOT NULL,
)

CREATE TABLE PlayerSession(
Id int IDENTITY NOT NULL PRIMARY KEY,
PlayerId int NOT NULL REFERENCES Player,
Token varchar(50),
StartTime date Not NULL,
EndTime date NOT NULL
)

CREATE TABLE PlayerCommon(
Id int IDENTITY NOT NULL PRIMARY KEY,
PlayerId int NOT NULL REFERENCES Player,
GamesCount int not Null,
WonsGames int Not NUll,
LostGames int Not NUll
)

CREATE TABLE Game(
Id int IDENTITY NOT NULL PRIMARY KEY,
FirstPlayerId int NOT NULL REFERENCES Player,
SecondPlayerId int REFERENCES Player,
CreateTime  date NOT NULL,
StartTime date,
EndTime date
)

CREATE TABLE Dice(
Id int NOT NULL PRIMARY KEY,
Face int NOT NULL UNIQUE
)


CREATE TABLE Round(
Id int IDENTITY NOT NULL PRIMARY KEY,
GameId int NOT NULL REFERENCES Game,
StartTime date NOT NULL,
EndTime date 

)


CREATE TABLE Step(
Id int IDENTITY NOT NULL PRIMARY KEY,
RoundId int NOT NULL REFERENCES Round,
FirstDice int NOT NULL REFERENCES Dice,
SecondDice int NOT NULL REFERENCES Dice
)







