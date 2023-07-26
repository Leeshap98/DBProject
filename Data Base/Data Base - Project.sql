-- MySQL dump 10.13  Distrib 8.0.33, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: dbgame
-- ------------------------------------------------------
-- Server version	8.0.33

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `playercontrol`
--

DROP TABLE IF EXISTS `playercontrol`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `playercontrol` (
  `PlayerID` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) DEFAULT NULL,
  `InGame` tinyint DEFAULT NULL,
  `Score` int DEFAULT NULL,
  `Finished` tinyint DEFAULT NULL,
  UNIQUE KEY `PlayerID_UNIQUE` (`PlayerID`),
  UNIQUE KEY `Name_UNIQUE` (`Name`)
) ENGINE=InnoDB AUTO_INCREMENT=106 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `playercontrol`
--

LOCK TABLES `playercontrol` WRITE;
/*!40000 ALTER TABLE `playercontrol` DISABLE KEYS */;
/*!40000 ALTER TABLE `playercontrol` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `q_and_a`
--

DROP TABLE IF EXISTS `q_and_a`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `q_and_a` (
  `QID` int NOT NULL AUTO_INCREMENT,
  `Question` varchar(100) NOT NULL,
  `Ans1` varchar(100) NOT NULL,
  `Ans2` varchar(100) NOT NULL,
  `Ans3` varchar(100) NOT NULL,
  `Ans4` varchar(100) NOT NULL,
  `CorrectID` int NOT NULL,
  PRIMARY KEY (`QID`),
  UNIQUE KEY `QID_UNIQUE` (`QID`),
  UNIQUE KEY `Ans4_UNIQUE` (`Ans4`),
  UNIQUE KEY `Ans3_UNIQUE` (`Ans3`),
  UNIQUE KEY `Ans2_UNIQUE` (`Ans2`),
  UNIQUE KEY `Ans1_UNIQUE` (`Ans1`),
  UNIQUE KEY `Question_UNIQUE` (`Question`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `q_and_a`
--

LOCK TABLES `q_and_a` WRITE;
/*!40000 ALTER TABLE `q_and_a` DISABLE KEYS */;
INSERT INTO `q_and_a` VALUES (1,'what animal gifts each other when they decide to start a family?','Penguines','Snakes','Hyenas','Eagles',1),(2,'what animal tends to have a best friend for life?','Cows','Foxes','Pengiunes','Whales',1),(3,'which type of animal can block their ears on command?','Frogs','Parrots','Squirles','Octopuses',1),(4,'which of the following animals plays catch using a smaller animal?','Dolphins','Monkeys','Koalas','Lions',1),(5,'what animal has fingerprints that are indistinguishable from humans?','Koalas','Kangaroos','Guinea Pigs','Seals',1);
/*!40000 ALTER TABLE `q_and_a` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `questions`
--

DROP TABLE IF EXISTS `questions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `questions` (
  `idquestions` int DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `questions`
--

LOCK TABLES `questions` WRITE;
/*!40000 ALTER TABLE `questions` DISABLE KEYS */;
/*!40000 ALTER TABLE `questions` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-07-26 23:42:11
