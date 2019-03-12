-- MySQL dump 10.13  Distrib 8.0.13, for Win64 (x86_64)
--
-- Host: localhost    Database: tasks
-- ------------------------------------------------------
-- Server version	8.0.13

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
 SET NAMES utf8 ;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `access`
--

DROP TABLE IF EXISTS `access`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `access` (
  `access_id` int(11) NOT NULL AUTO_INCREMENT,
  `access_name` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY (`access_id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `access`
--

LOCK TABLES `access` WRITE;
/*!40000 ALTER TABLE `access` DISABLE KEYS */;
INSERT INTO `access` VALUES (1,'looking'),(2,'update'),(3,'retrohours'),(4,'reports');
/*!40000 ALTER TABLE `access` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `actual_hours`
--

DROP TABLE IF EXISTS `actual_hours`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `actual_hours` (
  `actual_hours_id` int(11) NOT NULL AUTO_INCREMENT,
  `user_id` int(11) NOT NULL,
  `project_id` int(11) NOT NULL,
  `count_houers` double NOT NULL,
  `date` date NOT NULL,
  PRIMARY KEY (`actual_hours_id`)
) ENGINE=InnoDB AUTO_INCREMENT=27 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `actual_hours`
--

LOCK TABLES `actual_hours` WRITE;
/*!40000 ALTER TABLE `actual_hours` DISABLE KEYS */;
INSERT INTO `actual_hours` VALUES (10,39,11,4,'2018-12-28'),(11,52,17,5,'2018-12-13'),(12,53,17,3,'2018-12-13'),(13,54,17,4,'2018-12-13'),(14,55,17,3,'2018-12-13'),(15,56,17,2,'2018-12-13'),(16,57,17,5,'2018-12-13'),(17,58,17,4,'2018-12-13'),(19,60,17,4,'2018-12-13'),(20,52,17,0.116666666666667,'2018-12-13'),(22,50,17,40,'2018-12-13'),(23,50,19,19,'2018-12-13'),(24,50,17,1.1,'2019-03-05'),(25,50,17,2.1,'2019-03-05'),(26,62,19,34,'2019-03-05');
/*!40000 ALTER TABLE `actual_hours` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `projects`
--

DROP TABLE IF EXISTS `projects`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `projects` (
  `project_id` int(11) NOT NULL AUTO_INCREMENT,
  `project_name` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `client_name` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `team_leader_id` int(11) NOT NULL,
  `develope_hours` int(11) NOT NULL,
  `qa_hours` int(11) NOT NULL,
  `ui/ux_hours` int(11) NOT NULL,
  `start_date` date NOT NULL,
  `finish_date` date NOT NULL,
  `is_active` tinyint(4) DEFAULT '1',
  PRIMARY KEY (`project_id`),
  KEY `team_idx` (`team_leader_id`),
  CONSTRAINT `team` FOREIGN KEY (`team_leader_id`) REFERENCES `users` (`user_id`)
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `projects`
--

LOCK TABLES `projects` WRITE;
/*!40000 ALTER TABLE `projects` DISABLE KEYS */;
INSERT INTO `projects` VALUES (11,'xxxx','xxx',38,1,1,10,'2018-12-26','2018-12-28',1),(12,'zzz','xxx',38,5,4,3,'2018-12-26','2018-12-28',0),(13,'cccc','xxx',38,1,1,1,'2018-12-19','2018-12-28',1),(14,'ccc','ccc',48,2,3,4,'2018-12-28','2019-01-25',1),(15,'ddd','aaaaa',48,1,1,1,'2018-12-29','2019-01-26',1),(16,'seldat','aaaaa',48,1,1,1,'2018-12-29','2019-01-26',1),(17,'buildonise','all',47,200,180,150,'2018-12-29','2018-12-13',1),(18,'teleric','all',47,250,130,50,'2018-12-29','2018-12-13',1),(19,'hellooow','fff',38,3,3,3,'2019-03-22','2019-05-02',1),(20,'asddd','aaaa',74,10,10,10,'2019-03-23','2019-04-27',1),(21,'cocaKola','coca',38,12,12,32,'2019-03-14','2019-03-30',1);
/*!40000 ALTER TABLE `projects` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user_kinds`
--

DROP TABLE IF EXISTS `user_kinds`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `user_kinds` (
  `user_kinds_id` int(11) NOT NULL AUTO_INCREMENT,
  `user_kinds_name` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY (`user_kinds_id`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user_kinds`
--

LOCK TABLES `user_kinds` WRITE;
/*!40000 ALTER TABLE `user_kinds` DISABLE KEYS */;
INSERT INTO `user_kinds` VALUES (1,'manager'),(2,'teamLeader'),(3,'developer'),(4,'QA'),(5,'ui/ux');
/*!40000 ALTER TABLE `user_kinds` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `userkind_to_access`
--

DROP TABLE IF EXISTS `userkind_to_access`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `userkind_to_access` (
  `userkind_to_access_id` int(11) NOT NULL AUTO_INCREMENT,
  `user_kind_id` int(11) NOT NULL,
  `access_id` int(11) NOT NULL,
  PRIMARY KEY (`userkind_to_access_id`)
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `userkind_to_access`
--

LOCK TABLES `userkind_to_access` WRITE;
/*!40000 ALTER TABLE `userkind_to_access` DISABLE KEYS */;
INSERT INTO `userkind_to_access` VALUES (15,1,1),(16,1,2),(17,1,3),(18,1,4),(19,2,1),(20,2,3),(21,3,1),(22,4,1),(23,5,1);
/*!40000 ALTER TABLE `userkind_to_access` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `users` (
  `user_id` int(11) NOT NULL AUTO_INCREMENT,
  `user_name` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `user_email` varchar(200) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `password` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `team_leader_id` int(11) DEFAULT NULL,
  `user_kind_id` int(11) NOT NULL,
  `user_ip` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '0',
  `verify_password` varchar(45) DEFAULT '0',
  PRIMARY KEY (`user_id`)
) ENGINE=InnoDB AUTO_INCREMENT=77 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (37,'manager','zvia.edl@gmail.com','8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92',0,1,'0','IUnhie'),(38,'team','zvia.edl@gmail.com','8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92',0,2,'0',''),(39,'tamar','zvia.edl@gmail.com','8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92',39,3,'0','0'),(42,'chana','zvia.edl@gmail.com','8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92',38,4,'0','R9FAQm'),(46,'Zivi','zvia.edl@gmail.com','8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92',44,4,'0','0'),(47,'team2','zvia.edl@gmail.com','8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92',38,2,'0',''),(48,'gggg','zvia.edl@gmail.com','7476f98f717fe5dd535964f23d76319c2ce277f13514ae40f5c9048c6e571893',0,2,'0','0'),(49,'Yehudit','zvia.edl@gmail.com','8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92',47,3,'0','0'),(50,'zvia','zvia.edl@gmail.com','8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92',47,3,'0','0'),(51,'chani','chani@gg.hh','8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92',47,3,'0','0'),(52,'efrat','efrat@gmail.com','8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92',47,3,'0','0'),(53,'tammar','tammar@gmail.com','8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92',47,3,'0','0'),(54,'racheli','racheli@gmail.com','8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92',47,5,'0','0'),(55,'sari','racheli@gmail.com','8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92',47,5,'0','0'),(56,'tovi','zvia.edl@gmail.com','8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92',47,5,'0','0'),(57,'rivka','zvia.edl@gmail.com','8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92',47,5,'0','0'),(58,'Shoshi','zvia.edl@gmail.com','8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92',47,5,'0','0'),(60,'chaym','chaym@gmail.com','8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92',47,4,'0','0'),(61,'davia','a@gmail.com','8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92',47,4,'0','0'),(62,'ssssss','a@sss.xx','8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92',38,3,'0','0'),(63,'aaaa','a@ss.cc','8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92',48,4,'0','0'),(65,'sssss','a@ss.cc','8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92',48,4,'0','0'),(66,'chavi','a@ss.cc','8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92',48,4,'0','0'),(67,'wwww','a@ss.xx','8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92',47,3,'0','0'),(68,'cccc','a@ss.xx','8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92',47,3,'0','0'),(70,'cccccc','a@ss.cc','8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92',38,3,'0','0'),(71,'aaa','a@gmail.com','8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92',0,2,'0','0'),(74,'newteam','a@gmail.com','8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92',0,2,'0','0');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `worker_to_project`
--

DROP TABLE IF EXISTS `worker_to_project`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `worker_to_project` (
  `worker_to_project_id` int(11) NOT NULL AUTO_INCREMENT,
  `user_id` int(11) NOT NULL,
  `project_id` int(11) NOT NULL,
  `hours` int(11) DEFAULT '0',
  PRIMARY KEY (`worker_to_project_id`)
) ENGINE=InnoDB AUTO_INCREMENT=74 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `worker_to_project`
--

LOCK TABLES `worker_to_project` WRITE;
/*!40000 ALTER TABLE `worker_to_project` DISABLE KEYS */;
INSERT INTO `worker_to_project` VALUES (15,39,11,0),(22,39,13,0),(23,42,13,10),(24,51,14,10),(25,37,0,0),(26,38,0,0),(27,48,0,0),(28,37,0,0),(29,38,0,0),(30,48,0,0),(31,56,16,0),(32,37,0,0),(33,38,0,0),(34,48,0,0),(35,49,17,0),(36,50,17,20),(37,51,17,10),(38,52,17,10),(39,53,17,0),(40,54,17,0),(41,55,17,10),(42,56,17,0),(43,57,17,0),(44,58,17,20),(46,60,17,0),(47,37,0,0),(48,38,0,0),(49,48,0,0),(50,49,18,0),(51,50,18,20),(52,51,18,0),(53,52,18,0),(54,53,18,0),(55,54,18,0),(56,55,18,0),(57,56,18,0),(58,57,18,0),(59,58,18,0),(61,60,18,0),(62,42,19,6),(63,47,19,120),(64,62,19,57),(65,70,19,100),(66,49,19,0),(67,50,19,10),(68,42,21,0),(69,47,21,0),(70,62,21,0),(71,70,21,0),(72,50,21,0),(73,49,21,0);
/*!40000 ALTER TABLE `worker_to_project` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-03-12  8:18:20
