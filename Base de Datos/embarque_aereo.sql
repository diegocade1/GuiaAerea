CREATE DATABASE  IF NOT EXISTS `embarque_aereo` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */;
USE `embarque_aereo`;
-- MySQL dump 10.13  Distrib 8.0.15, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: embarque_aereo
-- ------------------------------------------------------
-- Server version	8.0.15

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
-- Table structure for table `tbl_accounting_info`
--

DROP TABLE IF EXISTS `tbl_accounting_info`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tbl_accounting_info` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(50) NOT NULL,
  `address_1` varchar(50) NOT NULL,
  `address_2` varchar(50) NOT NULL,
  `email` varchar(100) NOT NULL,
  `telephone` varchar(15) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_accounting_info`
--

LOCK TABLES `tbl_accounting_info` WRITE;
/*!40000 ALTER TABLE `tbl_accounting_info` DISABLE KEYS */;
INSERT INTO `tbl_accounting_info` VALUES (1,'ALPHA BROKERS','2875 N.W. 82 AVENUE MIAMI','FLORIDA 33122 MIAMI - U.S.A.','fish@alphabrokers.com','305-594-9290');
/*!40000 ALTER TABLE `tbl_accounting_info` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_airline`
--

DROP TABLE IF EXISTS `tbl_airline`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tbl_airline` (
  `code` varchar(20) NOT NULL,
  `prefix_airline` varchar(5) NOT NULL,
  `name` varchar(50) NOT NULL,
  `rut` varchar(10) NOT NULL,
  `address` varchar(100) NOT NULL,
  `telephone` varchar(12) NOT NULL,
  `fax` varchar(12) NOT NULL,
  PRIMARY KEY (`code`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_airline`
--

LOCK TABLES `tbl_airline` WRITE;
/*!40000 ALTER TABLE `tbl_airline` DISABLE KEYS */;
INSERT INTO `tbl_airline` VALUES ('01','LATAM','LATAM Airlines','1-9','','',''),('02','AA','American Airlines','','','',''),('03','JBU','JetBlue Airways Corporation','','','',''),('04','ACA','Air Canada','','','','');
/*!40000 ALTER TABLE `tbl_airline` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_airport`
--

DROP TABLE IF EXISTS `tbl_airport`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tbl_airport` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(50) NOT NULL,
  `country` varchar(50) NOT NULL,
  `city` varchar(50) NOT NULL,
  `prefix` varchar(5) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_airport`
--

LOCK TABLES `tbl_airport` WRITE;
/*!40000 ALTER TABLE `tbl_airport` DISABLE KEYS */;
INSERT INTO `tbl_airport` VALUES (1,'Arturo Merino Benítez','CHILE','SANTIAGO','SCL'),(2,'Miami International Airport','USA','MIAMI','MIA'),(3,'Vancouver International Airport','CANADA','VANCOUVER','YVR');
/*!40000 ALTER TABLE `tbl_airport` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_carrier_agent`
--

DROP TABLE IF EXISTS `tbl_carrier_agent`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tbl_carrier_agent` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `account_number` varchar(12) NOT NULL,
  `rut` varchar(12) NOT NULL,
  `IATA_code` varchar(20) NOT NULL,
  `name` varchar(50) NOT NULL,
  `representante` varchar(50) NOT NULL,
  `firma_representante` varchar(50) NOT NULL,
  `address` varchar(100) NOT NULL,
  `comuna` varchar(50) NOT NULL,
  `telephone` varchar(12) NOT NULL,
  `email` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_carrier_agent`
--

LOCK TABLES `tbl_carrier_agent` WRITE;
/*!40000 ALTER TABLE `tbl_carrier_agent` DISABLE KEYS */;
INSERT INTO `tbl_carrier_agent` VALUES (1,'','76.558.820-0','75 - 1 - 0041/0011','CARGO NET CENTER S.A.','Sergio Cabrera','SCABRERA','AV. AMERICO VESPUCIO ORIENTE 1309 OF 202','PUDAHUEL - SANTIAGO - CHILE','','');
/*!40000 ALTER TABLE `tbl_carrier_agent` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_consignee`
--

DROP TABLE IF EXISTS `tbl_consignee`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tbl_consignee` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `account_number` varchar(12) NOT NULL,
  `name` varchar(50) NOT NULL,
  `address` varchar(100) NOT NULL,
  `telephone` varchar(15) NOT NULL,
  `email` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_consignee`
--

LOCK TABLES `tbl_consignee` WRITE;
/*!40000 ALTER TABLE `tbl_consignee` DISABLE KEYS */;
INSERT INTO `tbl_consignee` VALUES (1,'','CERMAQ US LLC','5835 BLUE LAGOON DRIVE, SUITE # 204 MIAMI FL 33126 U.S.A.','1 786 542 5544','Andre.Rojter@Cermaq.com');
/*!40000 ALTER TABLE `tbl_consignee` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_currency`
--

DROP TABLE IF EXISTS `tbl_currency`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tbl_currency` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(20) NOT NULL,
  `prefix` varchar(5) NOT NULL,
  `clp_value` decimal(10,2) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_currency`
--

LOCK TABLES `tbl_currency` WRITE;
/*!40000 ALTER TABLE `tbl_currency` DISABLE KEYS */;
INSERT INTO `tbl_currency` VALUES (1,'US Dolar','USD',695.80),(2,'Euro','EUR',790.25),(3,'Peso Argentino','ARS',15.93),(4,'Euro','EUR',790.25);
/*!40000 ALTER TABLE `tbl_currency` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_guide`
--

DROP TABLE IF EXISTS `tbl_guide`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tbl_guide` (
  `aerial_guide` varchar(15) NOT NULL,
  `id_guide_type` int(11) NOT NULL,
  `airline_code` varchar(20) NOT NULL,
  PRIMARY KEY (`aerial_guide`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_guide`
--

LOCK TABLES `tbl_guide` WRITE;
/*!40000 ALTER TABLE `tbl_guide` DISABLE KEYS */;
INSERT INTO `tbl_guide` VALUES ('1234',1,'01');
/*!40000 ALTER TABLE `tbl_guide` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_guide_type`
--

DROP TABLE IF EXISTS `tbl_guide_type`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tbl_guide_type` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `description` varchar(20) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_guide_type`
--

LOCK TABLES `tbl_guide_type` WRITE;
/*!40000 ALTER TABLE `tbl_guide_type` DISABLE KEYS */;
INSERT INTO `tbl_guide_type` VALUES (1,'GMADRE');
/*!40000 ALTER TABLE `tbl_guide_type` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_shipment_guide`
--

DROP TABLE IF EXISTS `tbl_shipment_guide`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tbl_shipment_guide` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `aerial_guide` varchar(15) NOT NULL,
  `id_shipper` int(11) NOT NULL,
  `id_consignee` int(11) NOT NULL,
  `id_carrier_agent` int(11) NOT NULL,
  `id_accounting_info` int(11) NOT NULL,
  `id_departure_airport` int(11) NOT NULL,
  `requested_routing` varchar(10) NOT NULL,
  `optional_shipping_number` varchar(20) NOT NULL,
  `optional_shipping_info` varchar(50) NOT NULL,
  `code_first_carrier` varchar(20) NOT NULL,
  `code_second_carrier` varchar(20) NOT NULL,
  `id_airport_destination_second_carrier` int(11) NOT NULL,
  `code_third_carrier` varchar(20) NOT NULL,
  `id_airport_destination_third_carrier` int(11) NOT NULL,
  `id_currency` int(11) NOT NULL,
  `payment_methods` enum('PP','CC') NOT NULL,
  `declared_value_carriage` varchar(10) NOT NULL,
  `declared_value_customs` varchar(10) NOT NULL,
  `id_destination_airport` int(11) NOT NULL,
  `requested_flight_num` varchar(10) NOT NULL,
  `requested_flight_date` date NOT NULL,
  `amount_insurance` varchar(10) NOT NULL,
  `handling_info` varchar(300) NOT NULL,
  `id_ULD` int(11) NOT NULL,
  `nature_quantity_goods` varchar(150) NOT NULL,
  `number_pieces` int(11) NOT NULL,
  `gross_weight` decimal(10,2) NOT NULL,
  `weight_charge` decimal(10,2) NOT NULL,
  `valuation_charge` decimal(10,2) NOT NULL,
  `tax` decimal(10,2) NOT NULL,
  `other_charges_due_agent` decimal(10,2) NOT NULL,
  `other_charges_due_carrier` decimal(10,2) NOT NULL,
  `total_prepaid` decimal(10,2) NOT NULL,
  `total_collect` decimal(10,2) NOT NULL,
  `currency_conversion_rate` decimal(10,2) NOT NULL,
  `collect_charges_dest_currency` decimal(10,2) NOT NULL,
  `charges_at_destination` decimal(10,2) NOT NULL,
  `total_collect_charges` decimal(10,2) NOT NULL,
  `signature_shipper` varchar(50) NOT NULL,
  `executed_date` date NOT NULL,
  `at_place` varchar(50) NOT NULL,
  `signature_issuing_carrier` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=30 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_shipment_guide`
--

LOCK TABLES `tbl_shipment_guide` WRITE;
/*!40000 ALTER TABLE `tbl_shipment_guide` DISABLE KEYS */;
INSERT INTO `tbl_shipment_guide` VALUES (1,'1234',1,1,1,1,1,'SCL - MIA','','','01','',0,'',0,1,'PP','NVD','NVC',2,'UC-1102','2019-05-06','NIL','PLEASE NOTIFY UPON ARRIVAL AT DESTINATION *** KEEP COOL *** THIS SHIPMENT DO NOT CONTAIN DANGEROUS G',1,'CARGO CONTAINS PERISHABLE FRESH ATLANTIC SALMON |INVOICE:31024685\r\n PO:|EXPORTATION\r\n PRODUCT OF CHILE',180,3272.00,3893.68,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,'CERMAQ Chile','2019-05-06','santiago de chile','SCABRERA'),(2,'1234',1,1,1,1,1,'SCL - MIA','','','01','',0,'',0,1,'PP','NVD','NVC',2,'UC-1102','2019-05-06','NIL','PLEASE NOTIFY UPON ARRIVAL AT DESTINATION *** KEEP COOL *** THIS SHIPMENT DO NOT CONTAIN DANGEROUS G',1,'CARGO CONTAINS PERISHABLE FRESH ATLANTIC SALMON |INVOICE:31024685\r\n PO:|EXPORTATION\r\n PRODUCT OF CHILE',180,3272.00,3893.68,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,'CERMAQ Chile','2019-05-06','santiago de chile','SCABRERA'),(3,'1234',1,1,1,1,1,'SCL - MIA','','','01','',0,'',0,1,'PP','NVD','NVC',2,'UC-1102','2019-05-06','NIL','PLEASE NOTIFY UPON ARRIVAL AT DESTINATION *** KEEP COOL *** THIS SHIPMENT DO NOT CONTAIN DANGEROUS G',1,'CARGO CONTAINS PERISHABLE FRESH ATLANTIC SALMON |INVOICE:31024685\r\n PO:|EXPORTATION\r\n PRODUCT OF CHILE',180,3272.00,3893.68,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,'CERMAQ Chile','2019-05-06','santiago de chile','SCABRERA'),(4,'1234',1,1,1,1,1,'SCL - MIA','','','01','',0,'',0,1,'PP','NVD','NVC',2,'UC-1102','2019-05-06','NIL','PLEASE NOTIFY UPON ARRIVAL AT DESTINATION *** KEEP COOL *** THIS SHIPMENT DO NOT CONTAIN DANGEROUS G',1,'CARGO CONTAINS PERISHABLE FRESH ATLANTIC SALMON |INVOICE:31024685\r\n PO:|EXPORTATION\r\n PRODUCT OF CHILE',180,3272.00,3893.68,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,'CERMAQ Chile','2019-05-06','santiago de chile','SCABRERA'),(5,'1234',1,1,1,1,1,'SCL - MIA','','','01','',0,'',0,1,'PP','NVD','NVC',2,'UC-1102','2019-05-06','NIL','PLEASE NOTIFY UPON ARRIVAL AT DESTINATION *** KEEP COOL *** THIS SHIPMENT DO NOT CONTAIN DANGEROUS G',1,'CARGO CONTAINS PERISHABLE FRESH ATLANTIC SALMON |INVOICE:31024685\r\n PO:|EXPORTATION\r\n PRODUCT OF CHILE',180,3272.00,3893.68,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,'CERMAQ Chile','2019-05-06','santiago de chile','SCABRERA'),(6,'1234',1,1,1,1,1,'SCL - MIA','','','01','',0,'',0,1,'PP','NVD','NVC',2,'UC-1102','2019-05-06','NIL','PLEASE NOTIFY UPON ARRIVAL AT DESTINATION *** KEEP COOL *** THIS SHIPMENT DO NOT CONTAIN DANGEROUS G',1,'CARGO CONTAINS PERISHABLE FRESH ATLANTIC SALMON |INVOICE:31024685\r\n PO:|EXPORTATION\r\n PRODUCT OF CHILE',180,3272.00,3893.68,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,'CERMAQ Chile','2019-05-06','santiago de chile','SCABRERA'),(7,'1234',1,1,1,1,1,'SCL - MIA','','','01','',0,'',0,1,'PP','NVD','NCV',2,'UC-1102','2019-05-05','NIL','PLEASE NOTIFY UPON ARRIVAL AT DESTINATION *** KEEP COOL *** THIS SHIPMENT DO NOT CONTAIN DANGEROUS G',1,'CARGO CONTAINS PERISHABLE FRESH ATLANTIC SALMON |INVOICE:31024685\r\n PO:|EXPORTATION\r\n PRODUCT OF CHILE',180,3272.00,3893.68,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,'CERMAQ Chile','2019-05-06','Santiago de Chile','SCABRERA'),(8,'1234',1,1,1,1,1,'SCL - MIA','','','01','',0,'',0,1,'PP','NVD','NCV',2,'UC-1102','2019-05-05','NIL','PLEASE NOTIFY UPON ARRIVAL AT DESTINATION *** KEEP COOL *** THIS SHIPMENT DO NOT CONTAIN DANGEROUS G',1,'CARGO CONTAINS PERISHABLE FRESH ATLANTIC SALMON |INVOICE:31024685\r\n PO:|EXPORTATION\r\n PRODUCT OF CHILE',180,3272.00,3893.68,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,'CERMAQ Chile','2019-05-06','Santiago de Chile','SCABRERA'),(9,'1234',1,1,1,1,1,'SCL - MIA','','','01','',0,'',0,1,'PP','NVD','NCV',2,'UC-1102','2019-05-05','NIL','PLEASE NOTIFY UPON ARRIVAL AT DESTINATION *** KEEP COOL *** THIS SHIPMENT DO NOT CONTAIN DANGEROUS G',1,'CARGO CONTAINS PERISHABLE FRESH ATLANTIC SALMON |INVOICE:31024685\r\n PO:|EXPORTATION\r\n PRODUCT OF CHILE',180,3272.00,3893.68,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,'CERMAQ Chile','2019-05-06','Santiago de Chile','SCABRERA'),(10,'1234',1,1,1,1,1,'SCL - MIA','','','01','',0,'',0,1,'PP','NVD','NCV',2,'UC-1102','2019-05-05','NIL','PLEASE NOTIFY UPON ARRIVAL AT DESTINATION *** KEEP COOL *** THIS SHIPMENT DO NOT CONTAIN DANGEROUS G',1,'CARGO CONTAINS PERISHABLE FRESH ATLANTIC SALMON |INVOICE:31024685\r\n PO:|EXPORTATION\r\n PRODUCT OF CHILE',180,3272.00,3893.68,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,'CERMAQ Chile','2019-05-06','Santiago de Chile','SCABRERA'),(11,'1234',1,1,1,1,1,'SCL - MIA','','','01','',0,'',0,1,'PP','NVD','NCV',2,'UC-1102','2019-05-05','NIL','PLEASE NOTIFY UPON ARRIVAL AT DESTINATION *** KEEP COOL *** THIS SHIPMENT DO NOT CONTAIN DANGEROUS G',1,'CARGO CONTAINS PERISHABLE FRESH ATLANTIC SALMON |INVOICE:31024685\r\n PO:|EXPORTATION\r\n PRODUCT OF CHILE',180,3272.00,3893.68,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,'CERMAQ Chile','2019-05-06','Santiago de Chile','SCABRERA'),(12,'1234',1,1,1,1,1,'SCL - MIA','','','01','',0,'',0,1,'PP','NVD','NCV',2,'UC-1102','2019-05-05','NIL','PLEASE NOTIFY UPON ARRIVAL AT DESTINATION *** KEEP COOL *** THIS SHIPMENT DO NOT CONTAIN DANGEROUS G',1,'CARGO CONTAINS PERISHABLE FRESH ATLANTIC SALMON..|INVOICE:31024685\r\n PO:|EXPORTATION\r\n PRODUCT OF CHILE',180,3272.00,3893.68,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,'CERMAQ Chile','2019-05-06','Santiago de Chile','SCABRERA'),(13,'1234',1,1,1,1,1,'SCL - MIA','','','01','',0,'',0,1,'PP','NVD','NCV',2,'UC-1102','2019-05-05','NIL','PLEASE NOTIFY UPON ARRIVAL AT DESTINATION *** KEEP COOL *** THIS SHIPMENT DO NOT CONTAIN DANGEROUS G',1,'CARGO CONTAINS PERISHABLE FRESH ATLANTIC SALMON...|INVOICE:31024685\r\n PO:|EXPORTATION\r\n PRODUCT OF CHILE',180,3272.00,3893.68,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,'CERMAQ Chile','2019-05-06','Santiago de Chile','SCABRERA'),(14,'1234',1,1,1,1,1,'SCL - MIA','','','01','',0,'',0,1,'PP','NVD','NCV',2,'UC-1102','2019-05-05','NIL','PLEASE NOTIFY UPON ARRIVAL AT DESTINATION *** KEEP COOL *** THIS SHIPMENT DO NOT CONTAIN DANGEROUS G',1,'CARGO CONTAINS PERISHABLE FRESH ATLANTIC SALMON....|INVOICE:31024685\r\n PO:|EXPORTATION\r\n PRODUCT OF CHILE',180,3272.00,3893.68,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,'CERMAQ Chile','2019-05-06','Santiago de Chile','SCABRERA'),(15,'1234',1,1,1,1,1,'SCL - MIA','','','01','',0,'',0,1,'PP','NVD','NCV',2,'UC-1102','2019-05-31','NIL','PLEASE NOTIFY UPON ARRIVAL AT DESTINATION *** KEEP COOL *** THIS SHIPMENT DO NOT CONTAIN DANGEROUS G',1,'CARGO CONTAINS PERISHABLE FRESH ATLANTIC SALMON |INVOICE:31024685|PO:|EXPORTATION\r\nPRODUCT OF CHILE',180,3272.00,3893.68,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,'CERMAQ Chile','2019-05-31','','SCABRERA'),(16,'1234',1,1,1,1,1,'SCL - MIA','','','01','',0,'',0,1,'PP','NVD','NCV',2,'UC-1102','2019-05-31','NIL','PLEASE NOTIFY UPON ARRIVAL AT DESTINATION *** KEEP COOL *** THIS SHIPMENT DO NOT CONTAIN DANGEROUS G',1,'CARGO CONTAINS PERISHABLE FRESH ATLANTIC SALMON |INVOICE:31024685|PO:|EXPORTATION\r\nPRODUCT OF CHILE',180,3272.00,3893.68,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,'CERMAQ Chile','2019-05-31','','SCABRERA'),(17,'1234',1,1,1,1,1,'SCL - MIA','','','01','',0,'',0,1,'PP','NVD','NCV',2,'UC-1102','2019-05-31','NIL','PLEASE NOTIFY UPON ARRIVAL AT DESTINATION *** KEEP COOL *** THIS SHIPMENT DO NOT CONTAIN DANGEROUS G',1,'CARGO CONTAINS PERISHABLE FRESH ATLANTIC SALMON |INVOICE:31024685|PO:|EXPORTATION\r\nPRODUCT OF CHILE',180,3272.00,3893.68,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,'CERMAQ Chile','2019-05-31','santiago de chile','SCABRERA'),(18,'1234',1,1,1,1,1,'SCL - MIA','','','01','',0,'',0,1,'PP','NVD','NCV',2,'UC-1102','2019-05-31','NIL','PLEASE NOTIFY UPON ARRIVAL AT DESTINATION *** KEEP COOL *** THIS SHIPMENT DO NOT CONTAIN DANGEROUS G',1,'CARGO CONTAINS PERISHABLE FRESH ATLANTIC SALMON |INVOICE:31024685|PO:|EXPORTATION\r\nPRODUCT OF CHILE',180,3272.00,3893.68,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,'CERMAQ Chile','2019-05-31','santiago de chile','SCABRERA'),(19,'1234',1,1,1,1,1,'SCL - MIA','','','01','',0,'',0,1,'PP','NVD','NCV',2,'UC-1102','2019-05-31','NIL','PLEASE NOTIFY UPON ARRIVAL AT DESTINATION *** KEEP COOL *** THIS SHIPMENT DO NOT CONTAIN DANGEROUS G',1,'CARGO CONTAINS PERISHABLE FRESH ATLANTIC SALMON |INVOICE:31024685|PO:|EXPORTATION\r\nPRODUCT OF CHILE',180,3272.00,3893.68,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,'CERMAQ Chile S.A.','2019-05-31','santiago de chile','SCABRERA'),(20,'1234',1,1,1,1,1,'SCL - MIA','','','01','',0,'',0,1,'PP','NVD','NCV',2,'UC-1102','2019-05-31','NIL','PLEASE NOTIFY UPON ARRIVAL AT DESTINATION *** KEEP COOL *** THIS SHIPMENT DO NOT CONTAIN DANGEROUS G',1,'CARGO CONTAINS PERISHABLE FRESH ATLANTIC SALMON |INVOICE:31024685|PO:|EXPORTATION\r\nPRODUCT OF CHILE',180,3272.00,3893.68,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,'CERMAQ Chile S.A.','2019-05-31','santiago de chile','SCABRERA'),(21,'1234',1,1,1,1,1,'SCL - MIA','','','01','',0,'',0,1,'CC','NVD','NCV',2,'UC-1102','2019-05-05','NIL','PLEASE NOTIFY UPON ARRIVAL AT DESTINATION *** KEEP COOL *** THIS SHIPMENT DO NOT CONTAIN DANGEROUS GOODS',1,'CARGO CONTAINS PERISHABLE FRESH ATLANTIC SALMON |INVOICE:31024685|PO:|EXPORTATION\r\nPRODUCT OF CHILE',180,3272.00,3893.68,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,'CERMAQ Chile S.A.','2019-05-06','Santiago de Chile','SCABRERA'),(22,'1234',1,1,1,1,1,'SCL - MIA','','','01','',0,'',0,1,'CC','NVD','NCV',2,'UC-1102','2019-05-05','NIL','PLEASE NOTIFY UPON ARRIVAL AT DESTINATION *** KEEP COOL *** THIS SHIPMENT DO NOT CONTAIN DANGEROUS GOODS',1,'CARGO CONTAINS PERISHABLE FRESH ATLANTIC SALMON |INVOICE:31024685|PO:|EXPORTATION\r\nPRODUCT OF CHILE',180,3272.00,3893.68,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,'CERMAQ Chile S.A.','2019-05-06','Santiago de Chile','SCABRERA'),(23,'1234',1,1,1,1,1,'SCL - MIA','','','01','04',3,'',0,1,'CC','NVD','NCV',2,'UC-1102','2019-05-05','NIL','PLEASE NOTIFY UPON ARRIVAL AT DESTINATION *** KEEP COOL *** THIS SHIPMENT DO NOT CONTAIN DANGEROUS GOODS',1,'CARGO CONTAINS PERISHABLE FRESH ATLANTIC SALMON |INVOICE:31024685|PO:|EXPORTATION\r\nPRODUCT OF CHILE',180,3272.00,3893.68,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,'CERMAQ Chile S.A.','2019-05-06','Santiago de Chile','SCABRERA'),(24,'1234',1,1,1,1,1,'SCL - MIA','','','01','04',3,'',0,1,'CC','NVD','NCV',2,'UC-1102','2019-05-05','NIL','PLEASE NOTIFY UPON ARRIVAL AT DESTINATION *** KEEP COOL *** THIS SHIPMENT DO NOT CONTAIN DANGEROUS GOODS',1,'CARGO CONTAINS PERISHABLE FRESH ATLANTIC SALMON |INVOICE:31024685|PO:|EXPORTATION\r\nPRODUCT OF CHILE',180,3272.00,3893.68,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,'CERMAQ Chile S.A.','2019-05-06','Santiago de Chile','SCABRERA'),(25,'1234',1,1,1,1,1,'SCL - MIA','','','01','04',3,'',0,1,'CC','NVD','NCV',2,'UC-1102','2019-05-05','NIL','PLEASE NOTIFY UPON ARRIVAL AT DESTINATION *** KEEP COOL *** THIS SHIPMENT DO NOT CONTAIN DANGEROUS GOODS',1,'CARGO CONTAINS PERISHABLE FRESH ATLANTIC SALMON |INVOICE:31024685|PO:|EXPORTATION\r\nPRODUCT OF CHILE',180,3272.00,3893.68,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,'CERMAQ Chile S.A.','2019-05-06','Santiago de Chile','SCABRERA'),(26,'1234',1,1,1,1,1,'SCL - MIA','','','01','04',3,'',0,1,'CC','NVD','NCV',2,'UC-1102','2019-05-05','NIL','PLEASE NOTIFY UPON ARRIVAL AT DESTINATION *** KEEP COOL *** THIS SHIPMENT DO NOT CONTAIN DANGEROUS GOODS',1,'CARGO CONTAINS PERISHABLE FRESH ATLANTIC SALMON |INVOICE:31024685|PO:|EXPORTATION\r\nPRODUCT OF CHILE',180,3272.00,3893.68,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,'CERMAQ Chile S.A.','2019-05-06','Santiago de Chile','SCABRERA'),(27,'1234',1,1,1,1,1,'SCL - MIA','','','01','04',3,'',0,1,'CC','NVD','NCV',2,'UC-1102','2019-05-05','NIL','PLEASE NOTIFY UPON ARRIVAL AT DESTINATION *** KEEP COOL *** THIS SHIPMENT DO NOT CONTAIN DANGEROUS GOODS',1,'CARGO CONTAINS PERISHABLE FRESH ATLANTIC SALMON |INVOICE:31024685|PO:|EXPORTATION\r\nPRODUCT OF CHILE',180,3272.00,3893.68,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,'CERMAQ Chile S.A.','2019-05-06','Santiago de Chile','SCABRERA'),(28,'1234',1,1,1,1,1,'SCL - MIA','','','01','',0,'',0,3,'PP','NVD','NCV',2,'UC-1102','2019-05-05','','PLEASE NOTIFY UPON ARRIVAL AT DESTINATION *** KEEP COOL *** THIS SHIPMENT DO NOT CONTAIN DANGEROUS GOODS',1,'CARGO CONTAINS PERISHABLE FRESH ATLANTIC SALMON |INVOICE:31024685|PO:|EXPORTATION\r\nPRODUCT OF CHILE',180,3272.00,3893.68,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,'CERMAQ Chile S.A.','2019-05-06','Santiago de Chile','SCABRERA'),(29,'1234',1,1,1,1,1,'SCL - MIA','','','01','04',3,'',0,1,'PP','NVD','NCV',2,'UC-1102','2019-05-06','NIL','PLEASE NOTIFY UPON ARRIVAL AT DESTINATION *** KEEP COOL *** THIS SHIPMENT DO NOT CONTAIN DANGEROUS GOODS',1,'CARGO CONTAINS PERISHABLE FRESH ATLANTIC SALMON |INVOICE:31024685|PO:|EXPORTATION\r\nPRODUCT OF CHILE',180,3272.00,3893.68,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,'CERMAQ Chile S.A.','2019-05-05','Santiago de Chile','SCABRERA');
/*!40000 ALTER TABLE `tbl_shipment_guide` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_shipper`
--

DROP TABLE IF EXISTS `tbl_shipper`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tbl_shipper` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `account_number` varchar(12) NOT NULL,
  `name` varchar(50) NOT NULL,
  `address` varchar(100) NOT NULL,
  `comuna` varchar(50) NOT NULL,
  `telephone` varchar(15) NOT NULL,
  `email` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_shipper`
--

LOCK TABLES `tbl_shipper` WRITE;
/*!40000 ALTER TABLE `tbl_shipper` DISABLE KEYS */;
INSERT INTO `tbl_shipper` VALUES (1,'79.784.980-4','CERMAQ Chile S.A.','AVDA. DIEGO PORTALES N° 2000 PISO 10','PUERTO MONTT - CHILE','56 65 2563200','');
/*!40000 ALTER TABLE `tbl_shipper` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_uld`
--

DROP TABLE IF EXISTS `tbl_uld`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tbl_uld` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `code` varchar(20) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_uld`
--

LOCK TABLES `tbl_uld` WRITE;
/*!40000 ALTER TABLE `tbl_uld` DISABLE KEYS */;
INSERT INTO `tbl_uld` VALUES (1,'PAG33475');
/*!40000 ALTER TABLE `tbl_uld` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'embarque_aereo'
--

--
-- Dumping routines for database 'embarque_aereo'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-05-31 16:58:25
