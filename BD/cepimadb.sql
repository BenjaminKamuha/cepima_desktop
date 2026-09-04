-- MySQL dump 10.13  Distrib 8.0.33, for Win64 (x86_64)
--
-- Host: localhost    Database: cepimadb
-- ------------------------------------------------------
-- Server version	5.7.36

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `affectation_chambre`
--

DROP TABLE IF EXISTS `affectation_chambre`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `affectation_chambre` (
  `id_affectation` int(11) NOT NULL AUTO_INCREMENT,
  `id_hospitalisation` int(11) DEFAULT NULL,
  `id_chambre` int(11) DEFAULT NULL,
  `date_debut` date DEFAULT NULL,
  `date_fin` date DEFAULT NULL,
  PRIMARY KEY (`id_affectation`),
  KEY `id_hospitalisation` (`id_hospitalisation`),
  KEY `id_chambre` (`id_chambre`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `affectation_chambre`
--

LOCK TABLES `affectation_chambre` WRITE;
/*!40000 ALTER TABLE `affectation_chambre` DISABLE KEYS */;
INSERT INTO `affectation_chambre` VALUES (1,3,32,'2026-07-09',NULL),(2,1,30,'2026-07-09','2026-07-09'),(3,1,21,'2026-07-13','2026-07-13'),(4,2,32,'2026-07-13',NULL);
/*!40000 ALTER TABLE `affectation_chambre` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `avances_salaire`
--

DROP TABLE IF EXISTS `avances_salaire`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `avances_salaire` (
  `id_avance` int(11) NOT NULL AUTO_INCREMENT,
  `id_salaire` int(11) DEFAULT NULL,
  `date_avance` date DEFAULT NULL,
  `montant` decimal(12,2) DEFAULT NULL,
  `reste` decimal(12,2) DEFAULT NULL,
  PRIMARY KEY (`id_avance`),
  KEY `id_personnel` (`id_salaire`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `avances_salaire`
--

LOCK TABLES `avances_salaire` WRITE;
/*!40000 ALTER TABLE `avances_salaire` DISABLE KEYS */;
INSERT INTO `avances_salaire` VALUES (1,0,'2026-07-29',150.00,50.00),(2,1,'2026-08-09',56.00,144.00);
/*!40000 ALTER TABLE `avances_salaire` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `bon_sortie`
--

DROP TABLE IF EXISTS `bon_sortie`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `bon_sortie` (
  `id_bon` int(11) NOT NULL AUTO_INCREMENT,
  `nom_resp` varchar(50) DEFAULT NULL,
  `montant` decimal(10,2) DEFAULT NULL,
  `date` datetime DEFAULT CURRENT_TIMESTAMP,
  `statut` enum('en attente','validé','annulé') DEFAULT NULL,
  PRIMARY KEY (`id_bon`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `bon_sortie`
--

LOCK TABLES `bon_sortie` WRITE;
/*!40000 ALTER TABLE `bon_sortie` DISABLE KEYS */;
/*!40000 ALTER TABLE `bon_sortie` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `centres`
--

DROP TABLE IF EXISTS `centres`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `centres` (
  `id_centre` int(11) NOT NULL AUTO_INCREMENT,
  `nom_centre` varchar(255) DEFAULT NULL,
  `adresse` varchar(255) DEFAULT NULL,
  `telephone` varchar(50) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  `date_creation` date DEFAULT NULL,
  `actif` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`id_centre`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `centres`
--

LOCK TABLES `centres` WRITE;
/*!40000 ALTER TABLE `centres` DISABLE KEYS */;
INSERT INTO `centres` VALUES (1,'CEPIMA-Centre Ukandilama','Butembo/Avenue Talia','+243 985 896 563','cepima@gmail.com','2026-04-07',1);
/*!40000 ALTER TABLE `centres` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `chambre`
--

DROP TABLE IF EXISTS `chambre`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `chambre` (
  `id_chambre` int(11) NOT NULL AUTO_INCREMENT,
  `id_centre` int(11) DEFAULT NULL,
  `id_service` int(11) NOT NULL,
  `numero_chambre` int(10) DEFAULT NULL,
  `type_chambre` enum('Individuelle','Double','Commune','Observation','Surveillance renforcée','Isolement thérapeutique','VIP') DEFAULT NULL,
  `tarif_journalier` decimal(12,2) DEFAULT NULL,
  `statut` enum('Disponible','Occupée','Reservée','Hos service','Maintenance') DEFAULT 'Disponible',
  PRIMARY KEY (`id_chambre`),
  KEY `id_centre` (`id_centre`),
  KEY `id_service` (`id_service`)
) ENGINE=InnoDB AUTO_INCREMENT=36 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `chambre`
--

LOCK TABLES `chambre` WRITE;
/*!40000 ALTER TABLE `chambre` DISABLE KEYS */;
INSERT INTO `chambre` VALUES (1,1,1,101,'Individuelle',10.86,'Disponible'),(2,1,1,102,'Double',15.21,'Disponible'),(3,1,1,103,'Commune',6.52,'Disponible'),(4,1,1,104,'Observation',17.39,'Disponible'),(5,1,2,201,'Individuelle',10.86,'Disponible'),(6,1,2,202,'Double',15.25,'Disponible'),(7,1,2,203,'Commune',6.52,'Disponible'),(8,1,2,204,'Observation',17.30,'Disponible'),(9,1,3,301,'Observation',21.73,'Disponible'),(10,1,3,302,'Double',15.21,'Disponible'),(11,1,3,303,'Commune',6.52,'Disponible'),(12,1,3,304,'Individuelle',10.86,'Disponible'),(13,1,4,401,'Individuelle',13.04,'Disponible'),(14,1,4,402,'Double',17.39,'Disponible'),(15,1,4,403,'Commune',7.80,'Disponible'),(16,1,4,404,'Observation',10.56,'Disponible'),(17,1,5,501,'Individuelle',13.04,'Disponible'),(18,1,5,502,'Double',17.39,'Disponible'),(19,1,5,503,'Commune',7.82,'Disponible'),(20,1,5,504,'Observation',19.56,'Disponible'),(21,1,6,50,'Individuelle',8.00,'Disponible'),(22,1,6,602,'Double',13.00,'Disponible'),(23,1,6,603,'Commune',5.20,'Disponible'),(24,1,6,604,'Observation',15.20,'Disponible'),(25,1,7,701,'Individuelle',10.86,'Disponible'),(26,1,7,702,'Double',15.21,'Disponible'),(27,1,7,703,'Commune',6.52,'Disponible'),(28,1,7,704,'Observation',17.39,'Disponible'),(30,1,7,706,'Individuelle',10.86,'Disponible'),(32,1,6,90,'Surveillance renforcée',19.56,'Occupée'),(33,1,5,91,'Isolement thérapeutique',2.17,'Disponible'),(34,1,6,92,'VIP',4.34,'Disponible'),(35,1,6,93,'Isolement thérapeutique',3.26,'Disponible');
/*!40000 ALTER TABLE `chambre` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `commande_achat`
--

DROP TABLE IF EXISTS `commande_achat`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `commande_achat` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `fournisseur_id` int(11) NOT NULL,
  `date_commande` date NOT NULL,
  `statut` varchar(30) NOT NULL DEFAULT 'EN_ATTENTE',
  `reference` varchar(50) DEFAULT NULL,
  `observation` text,
  PRIMARY KEY (`id`),
  UNIQUE KEY `reference` (`reference`),
  KEY `fournisseur_id` (`fournisseur_id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `commande_achat`
--

LOCK TABLES `commande_achat` WRITE;
/*!40000 ALTER TABLE `commande_achat` DISABLE KEYS */;
/*!40000 ALTER TABLE `commande_achat` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `commande_achat_ligne`
--

DROP TABLE IF EXISTS `commande_achat_ligne`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `commande_achat_ligne` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `commande_id` int(11) NOT NULL,
  `medicament_id` int(11) NOT NULL,
  `quantite` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `commande_id` (`commande_id`),
  KEY `medicament_id` (`medicament_id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `commande_achat_ligne`
--

LOCK TABLES `commande_achat_ligne` WRITE;
/*!40000 ALTER TABLE `commande_achat_ligne` DISABLE KEYS */;
/*!40000 ALTER TABLE `commande_achat_ligne` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `consultation`
--

DROP TABLE IF EXISTS `consultation`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `consultation` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `patient_id` int(11) NOT NULL,
  `type_consultation` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `motif` text COLLATE utf8mb4_unicode_ci,
  `symptomes_depuis` date DEFAULT NULL,
  `symptome_insomnie` tinyint(1) NOT NULL DEFAULT '0',
  `symptome_anxiete` tinyint(1) NOT NULL DEFAULT '0',
  `symptome_agitation` tinyint(1) NOT NULL DEFAULT '0',
  `symptome_tristesse` tinyint(1) NOT NULL DEFAULT '0',
  `symptome_idees_delirantes` tinyint(1) NOT NULL DEFAULT '0',
  `symptome_hallucinations` tinyint(1) NOT NULL DEFAULT '0',
  `symptome_perte_memoire` tinyint(1) NOT NULL DEFAULT '0',
  `symptome_autre` varchar(255) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `evolution_symptomes` text COLLATE utf8mb4_unicode_ci,
  `facteurs_declenchants` text COLLATE utf8mb4_unicode_ci,
  `risque_suicidaire` varchar(20) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `risque_agression` varchar(20) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `risque_fugue` varchar(20) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `autres_risques` text COLLATE utf8mb4_unicode_ci,
  `diagnostic_id` int(11) DEFAULT NULL,
  `prochaine_consultation` date DEFAULT NULL,
  `date_consultation` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `utilisateur_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `idx_consultation_patient` (`patient_id`),
  KEY `idx_consultation_diagnostic` (`diagnostic_id`),
  KEY `idx_consultation_date` (`date_consultation`),
  CONSTRAINT `fk_consultation_diagnostic` FOREIGN KEY (`diagnostic_id`) REFERENCES `diagnostic` (`id`) ON DELETE SET NULL ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `consultation`
--

LOCK TABLES `consultation` WRITE;
/*!40000 ALTER TABLE `consultation` DISABLE KEYS */;
/*!40000 ALTER TABLE `consultation` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `demande_service`
--

DROP TABLE IF EXISTS `demande_service`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `demande_service` (
  `id_demande` int(11) NOT NULL AUTO_INCREMENT,
  `id_patient` int(11) NOT NULL,
  `id_service` int(11) NOT NULL,
  `id_consultation` int(11) DEFAULT NULL,
  `id_personnel` int(11) DEFAULT NULL,
  `date_demande` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `priorite` enum('Normale','Urgente') NOT NULL DEFAULT 'Normale',
  `motif` text,
  `statut` enum('Demandée','Acceptée','En cours','Terminée','Annulée') NOT NULL DEFAULT 'Demandée',
  `observation` text,
  PRIMARY KEY (`id_demande`),
  KEY `idx_demande_patient` (`id_patient`),
  KEY `idx_demande_service` (`id_service`),
  KEY `idx_demande_consultation` (`id_consultation`),
  KEY `idx_demande_personnel` (`id_personnel`),
  KEY `idx_demande_date` (`date_demande`),
  KEY `idx_demande_statut` (`statut`),
  CONSTRAINT `fk_demande_consultation` FOREIGN KEY (`id_consultation`) REFERENCES `consultation` (`id`) ON DELETE SET NULL ON UPDATE CASCADE,
  CONSTRAINT `fk_demande_patient` FOREIGN KEY (`id_patient`) REFERENCES `patients` (`id_patient`) ON UPDATE CASCADE,
  CONSTRAINT `fk_demande_service` FOREIGN KEY (`id_service`) REFERENCES `service` (`id_service`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `demande_service`
--

LOCK TABLES `demande_service` WRITE;
/*!40000 ALTER TABLE `demande_service` DISABLE KEYS */;
INSERT INTO `demande_service` VALUES (1,2,1,NULL,NULL,'2026-09-03 20:45:53','Urgente','Crises convulsives répétées','Demandée','Le patient soufre beaucoup'),(2,20,2,NULL,NULL,'2026-09-04 06:32:35','Urgente','Troube psycopatique','Annulée',NULL),(3,20,4,NULL,NULL,'2026-09-04 06:36:47','Normale','sdfsdf','Annulée','zer'),(4,20,1,NULL,NULL,'2026-09-04 08:53:00','Urgente','Parler trop sans arrêt','Annulée','Le patient parle beaucoup. On dirais il est bracher sur une source 240 v kkkk'),(5,20,1,NULL,NULL,'2026-09-04 09:05:15','Normale','fsf','Terminée','zerfsdf');
/*!40000 ALTER TABLE `demande_service` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `depenses`
--

DROP TABLE IF EXISTS `depenses`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `depenses` (
  `id_depense` int(11) NOT NULL AUTO_INCREMENT,
  `id_centre` int(11) DEFAULT NULL,
  `date_depense` date DEFAULT NULL,
  `motif` varchar(50) DEFAULT NULL,
  `montant` decimal(12,2) DEFAULT NULL,
  `responsable` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id_depense`),
  KEY `id_centre` (`id_centre`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `depenses`
--

LOCK TABLES `depenses` WRITE;
/*!40000 ALTER TABLE `depenses` DISABLE KEYS */;
/*!40000 ALTER TABLE `depenses` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `detail_entree_stock`
--

DROP TABLE IF EXISTS `detail_entree_stock`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `detail_entree_stock` (
  `id_detail` int(11) NOT NULL AUTO_INCREMENT,
  `id_entree` int(11) DEFAULT NULL,
  `id_medicament` int(11) DEFAULT NULL,
  `quantite` int(10) DEFAULT NULL,
  `prix_achat` decimal(12,2) DEFAULT NULL,
  PRIMARY KEY (`id_detail`),
  KEY `id_entree` (`id_entree`),
  KEY `id_medicament` (`id_medicament`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `detail_entree_stock`
--

LOCK TABLES `detail_entree_stock` WRITE;
/*!40000 ALTER TABLE `detail_entree_stock` DISABLE KEYS */;
/*!40000 ALTER TABLE `detail_entree_stock` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `detail_facture`
--

DROP TABLE IF EXISTS `detail_facture`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `detail_facture` (
  `id_detail_facture` int(11) NOT NULL AUTO_INCREMENT,
  `id_facture` int(11) DEFAULT NULL,
  `description` varchar(100) DEFAULT NULL,
  `quantite` int(10) DEFAULT NULL,
  `prix_unitaire` decimal(12,2) DEFAULT NULL,
  `montant` decimal(12,2) DEFAULT NULL,
  PRIMARY KEY (`id_detail_facture`),
  KEY `id_facture` (`id_facture`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `detail_facture`
--

LOCK TABLES `detail_facture` WRITE;
/*!40000 ALTER TABLE `detail_facture` DISABLE KEYS */;
/*!40000 ALTER TABLE `detail_facture` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `detail_sortie_ph_service`
--

DROP TABLE IF EXISTS `detail_sortie_ph_service`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `detail_sortie_ph_service` (
  `id_detail` int(11) NOT NULL AUTO_INCREMENT,
  `id_sortie` int(11) DEFAULT NULL,
  `id_medicament` int(11) DEFAULT NULL,
  `quantite` int(10) DEFAULT NULL,
  PRIMARY KEY (`id_detail`),
  KEY `id_medicament` (`id_medicament`),
  KEY `id_sortie` (`id_sortie`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `detail_sortie_ph_service`
--

LOCK TABLES `detail_sortie_ph_service` WRITE;
/*!40000 ALTER TABLE `detail_sortie_ph_service` DISABLE KEYS */;
/*!40000 ALTER TABLE `detail_sortie_ph_service` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `detail_sortie_s_pa`
--

DROP TABLE IF EXISTS `detail_sortie_s_pa`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `detail_sortie_s_pa` (
  `id_detail` int(11) NOT NULL AUTO_INCREMENT,
  `id_sortie` int(11) DEFAULT NULL,
  `id_medicament` int(11) DEFAULT NULL,
  `quantite` int(10) DEFAULT NULL,
  `prix_unitaire` decimal(12,2) DEFAULT NULL,
  PRIMARY KEY (`id_detail`),
  KEY `id_sortie` (`id_sortie`),
  KEY `id_medicament` (`id_medicament`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `detail_sortie_s_pa`
--

LOCK TABLES `detail_sortie_s_pa` WRITE;
/*!40000 ALTER TABLE `detail_sortie_s_pa` DISABLE KEYS */;
/*!40000 ALTER TABLE `detail_sortie_s_pa` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `detail_sortie_stock`
--

DROP TABLE IF EXISTS `detail_sortie_stock`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `detail_sortie_stock` (
  `id_detail` int(11) NOT NULL AUTO_INCREMENT,
  `id_sortie` int(11) DEFAULT NULL,
  `id_medicament` int(11) DEFAULT NULL,
  `quantite` int(10) DEFAULT NULL,
  `prix_unitaire` decimal(12,2) DEFAULT NULL,
  `montant` decimal(12,2) DEFAULT NULL,
  `id_consultation` int(11) DEFAULT NULL,
  PRIMARY KEY (`id_detail`),
  KEY `id_sortie` (`id_sortie`),
  KEY `id_medicament` (`id_medicament`),
  KEY `fk_detail_sortie_stock_consultation` (`id_consultation`)
) ENGINE=InnoDB AUTO_INCREMENT=57 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `detail_sortie_stock`
--

LOCK TABLES `detail_sortie_stock` WRITE;
/*!40000 ALTER TABLE `detail_sortie_stock` DISABLE KEYS */;
INSERT INTO `detail_sortie_stock` VALUES (12,18,4,3,0.50,NULL,NULL),(13,18,4,3,0.50,NULL,NULL),(14,18,4,3,0.50,NULL,NULL),(15,18,4,3,0.50,NULL,NULL),(16,18,4,3,0.50,NULL,NULL),(17,18,4,3,0.50,NULL,NULL),(18,18,4,3,0.50,NULL,NULL),(19,18,4,3,0.50,NULL,NULL),(20,18,4,3,0.50,NULL,NULL),(21,19,6,8,1.20,NULL,NULL),(22,19,9,8,1.60,NULL,NULL),(23,19,12,3,0.70,NULL,NULL),(24,19,6,8,1.20,NULL,NULL),(25,19,9,8,1.60,NULL,NULL),(26,19,12,3,0.70,NULL,NULL),(27,18,4,3,0.50,NULL,NULL),(28,18,4,3,0.50,NULL,NULL),(29,18,4,3,0.50,NULL,NULL),(30,18,4,3,0.50,NULL,NULL),(31,18,4,3,0.50,NULL,NULL),(32,19,6,8,1.20,NULL,NULL),(33,19,9,8,1.60,NULL,NULL),(34,19,12,3,0.70,NULL,NULL),(35,19,6,8,1.20,NULL,NULL),(36,19,9,8,1.60,NULL,NULL),(37,19,12,3,0.70,NULL,NULL),(38,18,4,3,0.50,NULL,NULL),(39,18,4,3,0.50,NULL,NULL),(40,19,6,8,1.20,NULL,NULL),(41,19,9,8,1.60,NULL,NULL),(42,19,12,3,0.70,NULL,NULL),(43,18,4,3,0.50,NULL,NULL),(44,19,6,8,1.20,NULL,NULL),(45,19,9,8,1.60,NULL,NULL),(46,19,12,3,0.70,NULL,NULL),(47,19,6,8,1.20,NULL,NULL),(48,19,9,8,1.60,NULL,NULL),(49,19,12,3,0.70,NULL,NULL),(50,18,4,3,0.50,NULL,NULL),(51,19,6,8,1.20,NULL,NULL),(52,19,9,8,1.60,NULL,NULL),(53,19,12,3,0.70,NULL,NULL),(54,19,6,8,1.20,NULL,NULL),(55,19,9,8,1.60,NULL,NULL),(56,19,12,3,0.70,NULL,NULL);
/*!40000 ALTER TABLE `detail_sortie_stock` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `details_soins`
--

DROP TABLE IF EXISTS `details_soins`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `details_soins` (
  `id_detail_soin` int(11) NOT NULL AUTO_INCREMENT,
  `id_consultation` int(11) DEFAULT NULL,
  `id_soin` int(11) DEFAULT NULL,
  `quantite` int(10) DEFAULT NULL,
  `prix` decimal(12,2) DEFAULT NULL,
  PRIMARY KEY (`id_detail_soin`),
  KEY `id_consultation` (`id_consultation`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `details_soins`
--

LOCK TABLES `details_soins` WRITE;
/*!40000 ALTER TABLE `details_soins` DISABLE KEYS */;
/*!40000 ALTER TABLE `details_soins` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `diagnostic`
--

DROP TABLE IF EXISTS `diagnostic`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `diagnostic` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `code` varchar(20) DEFAULT NULL,
  `libelle` varchar(255) NOT NULL,
  `description` text,
  `actif` tinyint(1) NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`),
  KEY `idx_diagnostic_libelle` (`libelle`(100))
) ENGINE=InnoDB AUTO_INCREMENT=25 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `diagnostic`
--

LOCK TABLES `diagnostic` WRITE;
/*!40000 ALTER TABLE `diagnostic` DISABLE KEYS */;
INSERT INTO `diagnostic` VALUES (1,'F00','Démence dans la maladie d?Alzheimer',NULL,1),(2,'F01','Démence vasculaire',NULL,1),(3,'F02','Démence dans d?autres maladies',NULL,1),(4,'F05','Delirium, non induit par l?alcool ou d?autres substances',NULL,1),(5,'F10','Troubles mentaux et du comportement liés à l?utilisation d?alcool',NULL,1),(6,'F20','Schizophrénie',NULL,1),(7,'F21','Trouble schizotypique',NULL,1),(8,'F22','Trouble délirant persistant',NULL,1),(9,'F23','Trouble psychotique aigu et transitoire',NULL,1),(10,'F25','Trouble schizo-affectif',NULL,1),(11,'F30','Épisode maniaque',NULL,1),(12,'F31','Trouble affectif bipolaire',NULL,1),(13,'F32','Épisode dépressif',NULL,1),(14,'F33','Trouble dépressif récurrent',NULL,1),(15,'F40','Troubles anxieux phobiques',NULL,1),(16,'F41','Autres troubles anxieux',NULL,1),(17,'F42','Trouble obsessionnel-compulsif',NULL,1),(18,'F43','Réaction à un facteur de stress et troubles de l?adaptation',NULL,1),(19,'F44','Troubles dissociatifs',NULL,1),(20,'F45','Troubles somatoformes',NULL,1),(21,'F51','Troubles non organiques du sommeil',NULL,1),(22,'F60','Troubles spécifiques de la personnalité',NULL,1),(23,'F70','Déficience intellectuelle légère',NULL,1),(24,'F79','Déficience intellectuelle, sans précision',NULL,1);
/*!40000 ALTER TABLE `diagnostic` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `dispensation`
--

DROP TABLE IF EXISTS `dispensation`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `dispensation` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `prescription_id` int(11) NOT NULL,
  `patient_id` int(11) NOT NULL,
  `type` varchar(30) NOT NULL,
  `date_dispensation` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `agent_id` int(11) DEFAULT NULL,
  `observation` text,
  PRIMARY KEY (`id`),
  KEY `prescription_id` (`prescription_id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dispensation`
--

LOCK TABLES `dispensation` WRITE;
/*!40000 ALTER TABLE `dispensation` DISABLE KEYS */;
/*!40000 ALTER TABLE `dispensation` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `dispensation_ligne`
--

DROP TABLE IF EXISTS `dispensation_ligne`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `dispensation_ligne` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `dispensation_id` int(11) NOT NULL,
  `medicament_id` int(11) NOT NULL,
  `lot_id` int(11) NOT NULL,
  `quantite` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `dispensation_id` (`dispensation_id`),
  KEY `medicament_id` (`medicament_id`),
  KEY `lot_id` (`lot_id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dispensation_ligne`
--

LOCK TABLES `dispensation_ligne` WRITE;
/*!40000 ALTER TABLE `dispensation_ligne` DISABLE KEYS */;
/*!40000 ALTER TABLE `dispensation_ligne` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `empreinte`
--

DROP TABLE IF EXISTS `empreinte`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `empreinte` (
  `id_empreint` int(11) NOT NULL AUTO_INCREMENT,
  `id_personnel` int(11) DEFAULT NULL,
  `template_empreinte` varchar(50) DEFAULT NULL,
  `date_enregistrement` date DEFAULT NULL,
  PRIMARY KEY (`id_empreint`),
  KEY `id_personnel` (`id_personnel`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `empreinte`
--

LOCK TABLES `empreinte` WRITE;
/*!40000 ALTER TABLE `empreinte` DISABLE KEYS */;
/*!40000 ALTER TABLE `empreinte` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `entree_stock`
--

DROP TABLE IF EXISTS `entree_stock`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `entree_stock` (
  `id_entre` int(11) NOT NULL AUTO_INCREMENT,
  `id_centre` int(11) DEFAULT NULL,
  `date` date DEFAULT NULL,
  `fournisseur` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id_entre`),
  KEY `id_centre` (`id_centre`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `entree_stock`
--

LOCK TABLES `entree_stock` WRITE;
/*!40000 ALTER TABLE `entree_stock` DISABLE KEYS */;
/*!40000 ALTER TABLE `entree_stock` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `examens_eeg`
--

DROP TABLE IF EXISTS `examens_eeg`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `examens_eeg` (
  `id_examens` int(11) NOT NULL AUTO_INCREMENT,
  `id_demande` int(11) DEFAULT NULL,
  `id_patient` int(11) DEFAULT NULL,
  `id_consultation` int(11) DEFAULT NULL,
  `date_examen` date DEFAULT NULL,
  `type_EEG` enum('18_cannaux','32_cannaux') DEFAULT NULL,
  `indication` text,
  `etat_patient` enum('Éveil','Somnolence','Sommeil') DEFAULT NULL,
  `privation_sommeil` tinyint(1) NOT NULL DEFAULT '0',
  `duree_enregistrement` int(11) DEFAULT NULL,
  `medicaments_avant_examen` text,
  `prix_examen` decimal(12,2) DEFAULT NULL,
  `resultat` text,
  `statut` enum('Demande','En cours','Terminé') DEFAULT 'Demande',
  `interpretation` text,
  `observations` text,
  `nom_fichier` varchar(255) DEFAULT NULL,
  `chemin_fichier` varchar(500) DEFAULT NULL,
  `extension_fichier` varchar(20) DEFAULT NULL,
  `taille_fichier` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`id_examens`),
  KEY `id_patient` (`id_patient`),
  KEY `id_consultation` (`id_consultation`),
  KEY `idx_examens_eeg_demande` (`id_demande`),
  CONSTRAINT `fk_examens_eeg_demande` FOREIGN KEY (`id_demande`) REFERENCES `demande_service` (`id_demande`) ON DELETE SET NULL ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `examens_eeg`
--

LOCK TABLES `examens_eeg` WRITE;
/*!40000 ALTER TABLE `examens_eeg` DISABLE KEYS */;
INSERT INTO `examens_eeg` VALUES (1,5,20,NULL,'2026-09-04','18_cannaux','Autre','Éveil',0,NULL,NULL,NULL,NULL,'Terminé',NULL,'Autre','fiche test enregistrement eeg.edf','D:\\2026\\CEPIMA\\cepima_desktop\\AFW\\Cepima\\Cepima\\bin\\Release\\FichiersEEG\\20_20260904100149_fiche test enregistrement eeg.edf','.edf',NULL);
/*!40000 ALTER TABLE `examens_eeg` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `facture`
--

DROP TABLE IF EXISTS `facture`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `facture` (
  `id_facture` int(11) NOT NULL AUTO_INCREMENT,
  `id_patient` int(11) DEFAULT NULL,
  `id_consultation` int(11) NOT NULL,
  `id_centre` int(11) DEFAULT NULL,
  `type_facture` enum('Ambulatoire','Hospitalisé') NOT NULL,
  `date_facture` date DEFAULT NULL,
  `montant_total` decimal(12,2) DEFAULT NULL,
  `statut` enum('Non payé','Payé','Partiellement payé') DEFAULT 'Non payé',
  PRIMARY KEY (`id_facture`),
  KEY `id_patient` (`id_patient`),
  KEY `id_centre` (`id_centre`),
  KEY `id_consultation` (`id_consultation`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `facture`
--

LOCK TABLES `facture` WRITE;
/*!40000 ALTER TABLE `facture` DISABLE KEYS */;
/*!40000 ALTER TABLE `facture` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `fournisseur`
--

DROP TABLE IF EXISTS `fournisseur`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `fournisseur` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nom` varchar(150) NOT NULL,
  `telephone` varchar(50) DEFAULT NULL,
  `adresse` varchar(255) DEFAULT NULL,
  `actif` tinyint(1) NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `fournisseur`
--

LOCK TABLES `fournisseur` WRITE;
/*!40000 ALTER TABLE `fournisseur` DISABLE KEYS */;
/*!40000 ALTER TABLE `fournisseur` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `historique_sejour`
--

DROP TABLE IF EXISTS `historique_sejour`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `historique_sejour` (
  `id_historique` int(11) NOT NULL AUTO_INCREMENT,
  `id_hospitalisation` int(11) DEFAULT NULL,
  `evenement` text,
  `date_evenement` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id_historique`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `historique_sejour`
--

LOCK TABLES `historique_sejour` WRITE;
/*!40000 ALTER TABLE `historique_sejour` DISABLE KEYS */;
INSERT INTO `historique_sejour` VALUES (1,2,'Patient : Kasereka Kuduma Joel hospitalisé','2026-06-19 08:28:13'),(2,0,'Prescription ajoutée par Dr : KABAMBA MWILU Jean : Carbamazepine, Amitriptyline','2026-07-03 14:39:56'),(3,3,'Patient : Bisimwa Lusenge Eric hospitalisé','2026-07-09 07:48:48'),(4,3,'Patient affecté à la chambre 90','2026-07-09 07:49:30'),(5,1,'Patient : Muhindo Kalungero John hospitalisé','2026-07-09 08:40:20'),(6,1,'Patient affecté à la chambre 706','2026-07-09 08:41:07'),(7,1,'Patient : Kambere Kamuha Kawaki hospitalisé','2026-07-13 12:37:14'),(8,1,'Patient affecté à la chambre 706','2026-07-13 12:37:52'),(9,2,'Patient : Kambere Kamuha Kawaki hospitalisé','2026-07-13 13:08:16'),(10,2,'Patient affecté à la chambre 90','2026-07-13 15:10:07');
/*!40000 ALTER TABLE `historique_sejour` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `horaire`
--

DROP TABLE IF EXISTS `horaire`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `horaire` (
  `id_horaire` int(11) NOT NULL AUTO_INCREMENT,
  `heure_entree_normal` time DEFAULT NULL,
  `heure_sortie_normal` time DEFAULT NULL,
  `jour_travail` varchar(50) DEFAULT NULL,
  `id_personnel` int(11) NOT NULL,
  PRIMARY KEY (`id_horaire`),
  UNIQUE KEY `unique_personnel_jour` (`id_personnel`,`jour_travail`),
  KEY `id_personnel` (`id_personnel`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `horaire`
--

LOCK TABLES `horaire` WRITE;
/*!40000 ALTER TABLE `horaire` DISABLE KEYS */;
INSERT INTO `horaire` VALUES (1,'16:21:45','16:21:45','Samedi',8);
/*!40000 ALTER TABLE `horaire` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `hospitalisation`
--

DROP TABLE IF EXISTS `hospitalisation`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `hospitalisation` (
  `id_hospitalisation` int(11) NOT NULL AUTO_INCREMENT,
  `id_patient` int(11) DEFAULT NULL,
  `id_centre` int(11) DEFAULT NULL,
  `id_service` int(11) DEFAULT NULL,
  `id_consultation` int(11) NOT NULL,
  `date_entree` date DEFAULT NULL,
  `date_sortie` date DEFAULT NULL,
  `motif` varchar(255) DEFAULT NULL,
  `etat` enum('Hospitalisé','En observation','Stable','Sorti') DEFAULT NULL,
  PRIMARY KEY (`id_hospitalisation`),
  KEY `id_patient` (`id_patient`),
  KEY `id_centre` (`id_centre`),
  KEY `id_service` (`id_service`),
  KEY `id_service_2` (`id_service`),
  KEY `id_consultation` (`id_consultation`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `hospitalisation`
--

LOCK TABLES `hospitalisation` WRITE;
/*!40000 ALTER TABLE `hospitalisation` DISABLE KEYS */;
/*!40000 ALTER TABLE `hospitalisation` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `inventaire`
--

DROP TABLE IF EXISTS `inventaire`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `inventaire` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `date_debut` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `date_fin` datetime DEFAULT NULL,
  `responsable_id` int(11) NOT NULL,
  `type` varchar(30) NOT NULL DEFAULT 'COMPLET',
  `statut` varchar(30) NOT NULL DEFAULT 'EN_COURS',
  `observation` text,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `inventaire`
--

LOCK TABLES `inventaire` WRITE;
/*!40000 ALTER TABLE `inventaire` DISABLE KEYS */;
INSERT INTO `inventaire` VALUES (1,'2026-09-02 13:00:05','2026-09-02 17:05:20',1,'COMPLET','TERMINE',''),(2,'2026-09-02 15:05:16',NULL,1,'COMPLET','EN_COURS',''),(3,'2026-09-02 15:06:43',NULL,1,'COMPLET','EN_COURS','Trop d\'écart'),(4,'2026-09-02 17:16:50','2026-09-02 17:18:30',1,'COMPLET','TERMINE',''),(5,'2026-09-02 17:22:51','2026-09-02 17:23:01',1,'COMPLET','TERMINE','');
/*!40000 ALTER TABLE `inventaire` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `inventaire_ligne`
--

DROP TABLE IF EXISTS `inventaire_ligne`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `inventaire_ligne` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `inventaire_id` int(11) NOT NULL,
  `lot_id` int(11) NOT NULL,
  `quantite_systeme` int(11) NOT NULL,
  `quantite_comptee` int(11) NOT NULL,
  `ecart` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `inventaire_id` (`inventaire_id`),
  KEY `lot_id` (`lot_id`)
) ENGINE=MyISAM AUTO_INCREMENT=31 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `inventaire_ligne`
--

LOCK TABLES `inventaire_ligne` WRITE;
/*!40000 ALTER TABLE `inventaire_ligne` DISABLE KEYS */;
INSERT INTO `inventaire_ligne` VALUES (1,1,7,54,50,-4),(2,1,2,23,25,2),(3,1,3,3,3,0),(4,1,6,3,3,0),(5,1,5,5,5,0),(6,1,4,8,8,0),(7,2,7,54,44,-10),(8,2,2,23,65,42),(9,2,3,3,23,20),(10,2,6,3,2,-1),(11,2,5,5,34,29),(12,2,4,8,5,-3),(13,3,7,54,44,-10),(14,3,2,23,65,42),(15,3,3,3,23,20),(16,3,6,3,2,-1),(17,3,5,5,34,29),(18,3,4,8,5,-3),(19,4,7,50,60,10),(20,4,2,25,32,7),(21,4,3,3,21,18),(22,4,6,3,2,-1),(23,4,5,5,5,0),(24,4,4,8,9,1),(25,5,7,60,70,10),(26,5,2,32,12,-20),(27,5,3,21,24,3),(28,5,6,2,20,18),(29,5,5,5,7,2),(30,5,4,9,8,-1);
/*!40000 ALTER TABLE `inventaire_ligne` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `livre_caisse`
--

DROP TABLE IF EXISTS `livre_caisse`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `livre_caisse` (
  `date` datetime DEFAULT CURRENT_TIMESTAMP,
  `recette` decimal(10,2) DEFAULT NULL,
  `depasse` decimal(10,2) DEFAULT NULL,
  `solde` decimal(10,2) DEFAULT '0.00',
  `provenance` enum('EEG','GENERALE') DEFAULT NULL,
  `description` varchar(200) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `livre_caisse`
--

LOCK TABLES `livre_caisse` WRITE;
/*!40000 ALTER TABLE `livre_caisse` DISABLE KEYS */;
/*!40000 ALTER TABLE `livre_caisse` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `logs`
--

DROP TABLE IF EXISTS `logs`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `logs` (
  `id_logs` int(11) NOT NULL AUTO_INCREMENT,
  `id_utilisateur` int(11) DEFAULT NULL,
  `action` varchar(255) DEFAULT NULL,
  `date_action` date DEFAULT NULL,
  `description` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id_logs`),
  KEY `id_utilisateur` (`id_utilisateur`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `logs`
--

LOCK TABLES `logs` WRITE;
/*!40000 ALTER TABLE `logs` DISABLE KEYS */;
/*!40000 ALTER TABLE `logs` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `lot_medicament`
--

DROP TABLE IF EXISTS `lot_medicament`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `lot_medicament` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `medicament_id` int(11) NOT NULL,
  `numero_lot` varchar(100) NOT NULL,
  `date_expiration` date NOT NULL,
  `quantite` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  UNIQUE KEY `medicament_id` (`medicament_id`,`numero_lot`)
) ENGINE=MyISAM AUTO_INCREMENT=8 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `lot_medicament`
--

LOCK TABLES `lot_medicament` WRITE;
/*!40000 ALTER TABLE `lot_medicament` DISABLE KEYS */;
INSERT INTO `lot_medicament` VALUES (1,36,'REC2342','2027-09-01',12),(2,24,'LOT-23SDF','2027-09-01',12),(3,24,'98SDF','2027-09-01',24),(4,46,'34FDSF','2027-09-01',8),(5,4,'32DFD','2027-09-01',7),(6,4,'334dfd','2027-09-01',20),(7,1,'23EE','2027-09-01',70);
/*!40000 ALTER TABLE `lot_medicament` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `medicament`
--

DROP TABLE IF EXISTS `medicament`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `medicament` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nom` varchar(150) NOT NULL,
  `dosage` varchar(100) DEFAULT NULL,
  `FORME` varchar(100) DEFAULT NULL,
  `seuil_minimum` int(11) NOT NULL DEFAULT '0',
  `actif` tinyint(1) NOT NULL DEFAULT '1',
  `categorie_id` int(11) DEFAULT NULL,
  `prix_achat` decimal(12,2) DEFAULT NULL,
  `prix_vente` decimal(12,2) DEFAULT NULL,
  `unite_gestion_id` int(11) DEFAULT NULL,
  `unite_gestion` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `nom` (`nom`,`dosage`,`FORME`),
  KEY `fk_medicament_categorie` (`categorie_id`),
  KEY `fk_medicament_unite_gestion` (`unite_gestion_id`)
) ENGINE=MyISAM AUTO_INCREMENT=55 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `medicament`
--

LOCK TABLES `medicament` WRITE;
/*!40000 ALTER TABLE `medicament` DISABLE KEYS */;
INSERT INTO `medicament` VALUES (1,'Antiramide',NULL,NULL,0,1,2,0.00,0.00,2,NULL),(2,'Ant',NULL,NULL,0,1,2,0.00,0.00,2,NULL),(3,'Diazepan',NULL,NULL,0,0,22,0.00,0.00,22,NULL),(4,'Autre',NULL,NULL,4,1,8,2.00,2.00,8,NULL),(5,'Aspirine',NULL,NULL,20,1,4,0.00,0.00,4,NULL),(6,'Décaris',NULL,NULL,85,1,3,20.00,20.00,3,NULL),(7,'zerzerzer',NULL,NULL,85,0,2,0.00,0.00,2,NULL),(8,'ZARA',NULL,NULL,8,1,2,0.00,0.00,2,NULL),(9,'Kibabe',NULL,NULL,0,0,23,0.00,0.00,23,NULL),(10,'Paracetamol','500 mg','Comprimé',0,1,1,NULL,NULL,1,NULL),(11,'Ibuprofène','400 mg','Comprimé',0,1,2,NULL,NULL,1,NULL),(12,'Amoxicilline','500 mg','Gélule',0,1,3,NULL,NULL,1,NULL),(13,'Metronidazole','500 mg','Comprimé',0,1,3,NULL,NULL,1,NULL),(14,'Oméprazole','20 mg','Gélule',0,1,4,NULL,NULL,1,NULL),(15,'Diclofénac','50 mg','Comprimé',0,1,2,NULL,NULL,1,NULL),(16,'Ceftriaxone','1 g','Injection',0,1,3,NULL,NULL,2,NULL),(17,'Sirop Paracetamol','120 mg/5 ml','Sirop',0,1,1,NULL,NULL,3,NULL),(18,'Vitamine C','500 mg','Comprimé',0,1,5,NULL,NULL,1,NULL),(19,'Loratadine','10 mg','Comprimé',0,1,6,NULL,NULL,1,NULL),(20,'Salbutamol','100 µg/dose','Inhalateur',0,1,7,NULL,NULL,4,NULL),(21,'Hydrocortisone','100 mg','Injection',0,1,8,NULL,NULL,2,NULL),(22,'Fer','200 mg','Comprimé',0,1,5,NULL,NULL,1,NULL),(23,'Azithromycine','500 mg','Comprimé',0,1,3,NULL,NULL,1,NULL),(24,'Aspirine','100 mg','Comprimé',0,1,2,NULL,NULL,1,NULL),(25,'Amoxicilline + Acide clavulanique','1 g','Comprimé',0,1,3,NULL,NULL,1,NULL),(26,'Ciprofloxacine','500 mg','Comprimé',0,1,3,NULL,NULL,1,NULL),(27,'Doxycycline','100 mg','Gélule',0,1,3,NULL,NULL,1,NULL),(28,'Clindamycine','300 mg','Gélule',0,1,3,NULL,NULL,1,NULL),(29,'Gentamicine','80 mg/2 ml','Injection',0,1,3,NULL,NULL,2,NULL),(30,'Paracetamol','1 g','Comprimé',0,1,1,NULL,NULL,1,NULL),(31,'Paracetamol','100 mg/ml','Solution buvable',0,1,1,NULL,NULL,3,NULL),(32,'Naproxène','500 mg','Comprimé',0,1,2,NULL,NULL,1,NULL),(33,'Kétoprofène','100 mg','Gélule',0,1,2,NULL,NULL,1,NULL),(34,'Tramadol','50 mg','Gélule',0,1,9,NULL,NULL,1,NULL),(35,'Morphine','10 mg/ml','Injection',0,1,9,NULL,NULL,2,NULL),(36,'Amlodipine','5 mg','Comprimé',0,0,10,NULL,NULL,1,NULL),(37,'Losartan','50 mg','Comprimé',0,1,10,NULL,NULL,1,NULL),(38,'Captopril','25 mg','Comprimé',0,1,10,NULL,NULL,1,NULL),(39,'Furosémide','40 mg','Comprimé',0,1,10,NULL,NULL,1,NULL),(40,'Metformine','500 mg','Comprimé',0,1,11,NULL,NULL,1,NULL),(41,'Glibenclamide','5 mg','Comprimé',0,1,11,NULL,NULL,1,NULL),(42,'Insuline humaine','100 UI/ml','Injection',0,1,11,NULL,NULL,2,NULL),(43,'Salbutamol','2 mg/5 ml','Sirop',0,1,7,NULL,NULL,3,NULL),(44,'Budesonide','200 µg/dose','Inhalateur',0,1,7,NULL,NULL,4,NULL),(45,'Cetirizine','10 mg','Comprimé',0,1,5,16.00,16.00,5,NULL),(46,'Chlorphenamine','4 mg','Comprimé',0,1,6,NULL,NULL,1,NULL),(47,'Prednisolone','20 mg','Comprimé',0,1,8,NULL,NULL,1,NULL),(48,'Dexamethasone e','4 mg/ml','Injection',0,0,8,0.00,0.00,8,NULL),(49,'Oméprazole','40 mg','Gélule',0,1,4,NULL,NULL,1,NULL),(50,'Pantoprazole','40 mg','Comprimé',0,1,4,NULL,NULL,1,NULL),(51,'Aluminium hydroxide','500 mg','Comprimé',0,0,4,NULL,NULL,1,NULL),(52,'Fer + Acide folique','200 mg + 400 µg','Comprimé',0,1,5,NULL,NULL,1,NULL),(53,'Acide folique','5 mg','Comprimé',0,0,5,NULL,NULL,1,NULL),(54,'Vitamine B12','1000 µg','Comprimé',0,1,5,NULL,NULL,1,NULL);
/*!40000 ALTER TABLE `medicament` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `medicament_categorie`
--

DROP TABLE IF EXISTS `medicament_categorie`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `medicament_categorie` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nom` varchar(100) NOT NULL,
  `couleur` varchar(20) NOT NULL,
  `actif` tinyint(1) DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=24 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `medicament_categorie`
--

LOCK TABLES `medicament_categorie` WRITE;
/*!40000 ALTER TABLE `medicament_categorie` DISABLE KEYS */;
INSERT INTO `medicament_categorie` VALUES (1,'Antipsychotique','#9B59B6',1),(2,'Antidépresseur','#3498DB',1),(3,'Anxiolytique','#2ECC71',1),(4,'Anticonvulsivant','#E67E22',1),(5,'Hypnotique','#1ABC9C',1),(6,'Thymorégulateur','#E74C3C',1),(7,'Correcteur','#F1C40F',1),(8,'Antalgique','#95A5A6',1),(9,'Antibiotique','#16A085',1),(10,'Autre','#7F8C8D',1),(11,'Bichubichu','#20FD31',1),(12,'xyz','#1E90FF',1),(13,'xyz','#1E90FF',1),(14,'rfhdfdgh','#C744D9',1),(15,'zersf','#1E90FF',1),(16,'sdfzaerdsf','#1E90FF',1),(17,'sdfsgsdf','#BBFF1E',1),(18,'rrrrrrrrrrrrrrrrrrrrrrrrr','#1E90FF',1),(19,'fdcfh','#1E90FF',1),(20,'zzzzzzzzzzzzzzzzzzzz','#7B7EA2',1),(21,'&&&&&&','#1E90FF',1),(22,'oooooooooooooooo','#E13C7A',1),(23,'MyCategory','#FF8811',1);
/*!40000 ALTER TABLE `medicament_categorie` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `mouvement_stock`
--

DROP TABLE IF EXISTS `mouvement_stock`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `mouvement_stock` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `lot_id` int(11) NOT NULL,
  `type` varchar(30) NOT NULL,
  `quantite` int(11) NOT NULL,
  `date_mouvement` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `reference` varchar(100) DEFAULT NULL,
  `utilisateur_id` int(11) DEFAULT NULL,
  `observation` text,
  PRIMARY KEY (`id`),
  KEY `lot_id` (`lot_id`)
) ENGINE=MyISAM AUTO_INCREMENT=21 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `mouvement_stock`
--

LOCK TABLES `mouvement_stock` WRITE;
/*!40000 ALTER TABLE `mouvement_stock` DISABLE KEYS */;
INSERT INTO `mouvement_stock` VALUES (1,1,'ENTREE',12,'2026-09-01 21:03:19','REC2342',NULL,'Réception de stock'),(2,2,'ENTREE',23,'2026-09-01 21:05:29','LOT-23SDF',NULL,'Réception de stock'),(3,3,'ENTREE',3,'2026-09-01 21:24:41','98SDF',NULL,'Réception de stock'),(4,4,'ENTREE',8,'2026-09-01 21:37:13','34FDSF',NULL,'Réception de stock'),(5,5,'ENTREE',5,'2026-09-01 21:42:38','32DFD',NULL,'Réception de stock'),(6,6,'ENTREE',3,'2026-09-01 21:43:03','334dfd',NULL,'Réception de stock'),(7,7,'ENTREE',54,'2026-09-01 21:47:04','23EE',NULL,'Réception de stock'),(8,7,'AJUSTEMENT',-4,'2026-09-02 17:05:19','INVENTAIRE-1',NULL,'Ajustement suite à l\'inventaire #1'),(9,2,'AJUSTEMENT',2,'2026-09-02 17:05:20','INVENTAIRE-1',NULL,'Ajustement suite à l\'inventaire #1'),(10,7,'AJUSTEMENT',10,'2026-09-02 17:18:30','INVENTAIRE-4',NULL,'Ajustement suite à l\'inventaire #4'),(11,2,'AJUSTEMENT',7,'2026-09-02 17:18:30','INVENTAIRE-4',NULL,'Ajustement suite à l\'inventaire #4'),(12,3,'AJUSTEMENT',18,'2026-09-02 17:18:30','INVENTAIRE-4',NULL,'Ajustement suite à l\'inventaire #4'),(13,6,'AJUSTEMENT',-1,'2026-09-02 17:18:30','INVENTAIRE-4',NULL,'Ajustement suite à l\'inventaire #4'),(14,4,'AJUSTEMENT',1,'2026-09-02 17:18:30','INVENTAIRE-4',NULL,'Ajustement suite à l\'inventaire #4'),(15,7,'AJUSTEMENT',10,'2026-09-02 17:23:01','INVENTAIRE-5',NULL,'Ajustement suite à l\'inventaire #5'),(16,2,'AJUSTEMENT',-20,'2026-09-02 17:23:01','INVENTAIRE-5',NULL,'Ajustement suite à l\'inventaire #5'),(17,3,'AJUSTEMENT',3,'2026-09-02 17:23:01','INVENTAIRE-5',NULL,'Ajustement suite à l\'inventaire #5'),(18,6,'AJUSTEMENT',18,'2026-09-02 17:23:01','INVENTAIRE-5',NULL,'Ajustement suite à l\'inventaire #5'),(19,5,'AJUSTEMENT',2,'2026-09-02 17:23:01','INVENTAIRE-5',NULL,'Ajustement suite à l\'inventaire #5'),(20,4,'AJUSTEMENT',-1,'2026-09-02 17:23:01','INVENTAIRE-5',NULL,'Ajustement suite à l\'inventaire #5');
/*!40000 ALTER TABLE `mouvement_stock` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `paiement`
--

DROP TABLE IF EXISTS `paiement`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `paiement` (
  `id_paiement` int(11) NOT NULL AUTO_INCREMENT,
  `id_facture` int(11) DEFAULT NULL,
  `numero_recu` int(11) DEFAULT NULL,
  `date_paiement` date DEFAULT NULL,
  `montant` decimal(12,2) DEFAULT NULL,
  `reste` decimal(10,2) NOT NULL,
  `mode_paiement` varchar(20) DEFAULT NULL,
  `type_paiement` enum('Partiel','Complet') NOT NULL,
  PRIMARY KEY (`id_paiement`),
  UNIQUE KEY `numero_recu` (`numero_recu`),
  KEY `id_facture` (`id_facture`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `paiement`
--

LOCK TABLES `paiement` WRITE;
/*!40000 ALTER TABLE `paiement` DISABLE KEYS */;
/*!40000 ALTER TABLE `paiement` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `paiement_eeg`
--

DROP TABLE IF EXISTS `paiement_eeg`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `paiement_eeg` (
  `id_paiement_eeg` int(11) NOT NULL AUTO_INCREMENT,
  `id_examen` int(11) DEFAULT NULL,
  `montant_eeg` decimal(12,2) DEFAULT NULL,
  `date_paiement` date DEFAULT NULL,
  `mode_paiement` enum('Cash','Paiement mobile') DEFAULT NULL,
  PRIMARY KEY (`id_paiement_eeg`),
  KEY `id_examen` (`id_examen`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `paiement_eeg`
--

LOCK TABLES `paiement_eeg` WRITE;
/*!40000 ALTER TABLE `paiement_eeg` DISABLE KEYS */;
/*!40000 ALTER TABLE `paiement_eeg` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `patients`
--

DROP TABLE IF EXISTS `patients`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `patients` (
  `id_patient` int(11) NOT NULL AUTO_INCREMENT,
  `numero_fiche` varchar(20) DEFAULT NULL,
  `nom` varchar(100) DEFAULT NULL,
  `post_nom` varchar(100) DEFAULT NULL,
  `prenom` varchar(100) DEFAULT NULL,
  `sexe` varchar(20) DEFAULT NULL,
  `date_naissance` date DEFAULT NULL,
  `telephone` varchar(20) DEFAULT NULL,
  `adresse` varchar(100) DEFAULT NULL,
  `date_creation` date DEFAULT NULL,
  `id_centre` int(11) NOT NULL,
  `photo` blob,
  `nom_garde` varchar(100) DEFAULT NULL,
  `telephone_garde` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`id_patient`),
  UNIQUE KEY `numero_fiche` (`numero_fiche`),
  KEY `id_centre` (`id_centre`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `patients`
--

LOCK TABLES `patients` WRITE;
/*!40000 ALTER TABLE `patients` DISABLE KEYS */;
INSERT INTO `patients` VALUES (2,'CEP-001','Kasereka','Mulamo','Mafungula','Homme','1994-06-09','+243 245 985 633','Kyambuli','2026-04-09',1,NULL,NULL,NULL),(3,'CEP-003','Kasereka','Mukandala','Jean','Homme','1999-06-25','0947856321','Butembo','2026-04-09',1,NULL,NULL,NULL),(4,'CEP-004','kakule','Mughanda','Jean-louis','Homme','1995-07-13','+243 254 789 545 ','Avenue du centre','2026-04-22',1,NULL,NULL,NULL),(5,'CEP-005','kasereka','mafungula','joel','Homme','1994-06-15','+243 895 745 526','Vukula','2026-05-20',1,NULL,NULL,NULL),(6,'CEP-006','Mukeba','Kalume','Jean','Masculin','1998-05-14','099112233','Goma Katindo','2026-05-28',1,NULL,NULL,NULL),(7,'CEP-007','Kasereka','Bahati','Aline','Feminin','2001-03-20','097445566','Goma Himbi','2026-05-28',1,NULL,NULL,NULL),(8,'CEP-008','Mateso','Kambale','Patrick','Masculin','1995-11-08','081223344','Goma Majengo','2026-05-28',1,NULL,NULL,NULL),(9,'CEP-009','Safari','Mukwege','Grâce','Feminin','2003-07-17','082334455','Goma Ndosho','2026-05-28',1,NULL,NULL,NULL),(10,'CEP-0010','Bisimwa','Lusenge','Eric','Masculin','1990-01-25','099556677','Goma Keshero','2026-05-28',1,NULL,NULL,NULL),(11,'CEP-0011','Uwimana','Nadine','Chantal','Feminin','1999-09-12','081998877','Goma Katoyi','2026-05-28',1,NULL,NULL,NULL),(12,'CEP-0012','Kavira','Mumbere','Daniel','Masculin','1997-12-30','082887766','Goma Virunga','2026-05-28',1,NULL,NULL,NULL),(13,'CEP-0013','Niyonsaba','Claude','Sandrine','Feminin','2002-04-11','097776655','Goma Lac Vert','2026-05-28',1,NULL,NULL,NULL),(14,'CEP-0014','Mambene','Masika','Joël','Masculin','1994-08-09','099665544','Goma Mugunga','2026-05-28',1,NULL,NULL,NULL),(15,'CEP-0015','Kamala','Bahwere','Esther','Feminin','2000-06-21','081554433','Goma Kyeshero','2026-05-28',1,NULL,NULL,NULL),(16,'CEP-016','Kasereka','Kuduma','Joel','Homme','1999-06-08','09845345434','Vichai','2026-06-19',1,NULL,NULL,NULL),(17,'CEP-017','Mumbere','Kamuha','Patrick','Homme','1994-06-25','093464345','Vulamba','2026-06-24',1,NULL,NULL,NULL),(18,'CEP-018','Muhindo','Kalungero','John','Homme','2000-02-15','0987634234','Kitulu/ mukuna','2026-06-24',1,NULL,NULL,NULL),(19,'CEP-019','Kambere','Kamuha','Kawaki','Homme','1994-06-25','098768734','Vungi','2026-07-06',1,NULL,NULL,NULL),(20,'CEP-020','Masika','Musema trop','Musema','Femme','1995-07-14','+243 789 562 365','Ngolwe','2026-08-28',1,NULL,'Maman Jeanne',' +243 785 365 214');
/*!40000 ALTER TABLE `patients` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `personnels`
--

DROP TABLE IF EXISTS `personnels`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `personnels` (
  `id_personnel` int(11) NOT NULL AUTO_INCREMENT,
  `id_centre` int(11) DEFAULT NULL,
  `nom` varchar(50) DEFAULT NULL,
  `post_nom` varchar(50) DEFAULT NULL,
  `prenom` varchar(50) DEFAULT NULL,
  `sexe` varchar(20) DEFAULT NULL,
  `date_naissance` date DEFAULT NULL,
  `date_embauche` date DEFAULT NULL,
  `fonction` varchar(50) DEFAULT NULL,
  `telephone` varchar(20) DEFAULT NULL,
  `adresse` varchar(50) DEFAULT NULL,
  `salaire_base` decimal(12,2) DEFAULT NULL,
  `actif` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`id_personnel`),
  KEY `id_centre` (`id_centre`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `personnels`
--

LOCK TABLES `personnels` WRITE;
/*!40000 ALTER TABLE `personnels` DISABLE KEYS */;
INSERT INTO `personnels` VALUES (1,1,'KABAMBA','MWILU','Jean','M','1985-03-12','2020-01-15','Psychiatre','+243 989 567 434','Goma',1200.00,NULL),(2,1,'MUKENDI','LUBOYA','Aline','F','1990-07-22','2021-05-10','Psychologue','0991000002','Goma',900.00,NULL),(3,1,'KALONJI','MUKUNA','David','M','1988-11-05','2019-09-01','Psychiatre','0991000003','Goma',600.00,NULL),(4,1,'NSIMBA','KABUYA','Sarah','Féminin','1992-02-18','2022-03-20','Ass. Sociale','0991000004','Goma',700.00,NULL),(5,1,'MBUYI','TSHIBANGU','Patrick','Masculin','1980-06-30','2018-07-12','Généraliste','0991000005','Goma',1100.00,NULL),(6,1,'KASONGO','MULUMBA','Grace','F','1995-09-14','2023-01-05','Psychologue','0991000006','Goma',850.00,NULL),(7,1,'ILUNGA','KABEYA','Michel','M','1983-12-01','2017-11-23','Laboratoire','0991000007','Goma',650.00,NULL),(8,1,'KABONGO','MWANA','Chantal','F','1991-04-09','2020-06-18','Infirmière','0991000008','Goma',580.00,NULL),(9,1,'MULANGA','KATUMBA','Eric','M','1987-08-25','2019-02-14','Psychologue','0991000009','Goma',500.00,NULL);
/*!40000 ALTER TABLE `personnels` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `prescription`
--

DROP TABLE IF EXISTS `prescription`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `prescription` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `patient_id` int(11) NOT NULL,
  `medecin_id` int(11) NOT NULL,
  `consultation_id` int(11) DEFAULT NULL,
  `date_prescription` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `statut` varchar(30) NOT NULL DEFAULT 'ACTIVE',
  `observation` text,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `prescription`
--

LOCK TABLES `prescription` WRITE;
/*!40000 ALTER TABLE `prescription` DISABLE KEYS */;
/*!40000 ALTER TABLE `prescription` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `prescription_ligne`
--

DROP TABLE IF EXISTS `prescription_ligne`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `prescription_ligne` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `prescription_id` int(11) NOT NULL,
  `medicament_id` int(11) NOT NULL,
  `dose` varchar(50) NOT NULL,
  `frequence` varchar(100) NOT NULL,
  `duree` varchar(50) DEFAULT NULL,
  `quantite_prescrite` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `prescription_id` (`prescription_id`),
  KEY `medicament_id` (`medicament_id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `prescription_ligne`
--

LOCK TABLES `prescription_ligne` WRITE;
/*!40000 ALTER TABLE `prescription_ligne` DISABLE KEYS */;
/*!40000 ALTER TABLE `prescription_ligne` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `prescriptions`
--

DROP TABLE IF EXISTS `prescriptions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `prescriptions` (
  `id_prescription` int(11) NOT NULL AUTO_INCREMENT,
  `id_sortie` int(11) DEFAULT NULL,
  `id_patient` int(11) NOT NULL,
  `id_medicament` int(11) NOT NULL,
  `id_consultation` int(11) NOT NULL,
  `quantite` int(11) DEFAULT NULL,
  `unite` varchar(50) NOT NULL,
  `statut` enum('Livrée','Non livrée') NOT NULL,
  `date_prescription` date DEFAULT NULL,
  PRIMARY KEY (`id_prescription`),
  KEY `id_patient` (`id_patient`),
  KEY `id_medicament` (`id_medicament`),
  KEY `fk_sortie_pharmacie` (`id_sortie`),
  KEY `id_consultation` (`id_consultation`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `prescriptions`
--

LOCK TABLES `prescriptions` WRITE;
/*!40000 ALTER TABLE `prescriptions` DISABLE KEYS */;
/*!40000 ALTER TABLE `prescriptions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `presences`
--

DROP TABLE IF EXISTS `presences`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `presences` (
  `id_presence` int(11) NOT NULL AUTO_INCREMENT,
  `id_personnel` int(11) DEFAULT NULL,
  `date_presence` date DEFAULT NULL,
  `heure_entree` time DEFAULT NULL,
  `heure_sortie` time DEFAULT NULL,
  `statut` enum('Présent','Absent','Retard') DEFAULT NULL,
  PRIMARY KEY (`id_presence`),
  KEY `id_personnel` (`id_personnel`),
  CONSTRAINT `fk_presence_personnel` FOREIGN KEY (`id_personnel`) REFERENCES `personnels` (`id_personnel`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `presences`
--

LOCK TABLES `presences` WRITE;
/*!40000 ALTER TABLE `presences` DISABLE KEYS */;
INSERT INTO `presences` VALUES (1,1,'2026-04-15','13:10:23','13:10:23','Présent');
/*!40000 ALTER TABLE `presences` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `prime`
--

DROP TABLE IF EXISTS `prime`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `prime` (
  `id_prime` int(11) NOT NULL AUTO_INCREMENT,
  `id_salaire` int(11) DEFAULT NULL,
  `date_prime` date DEFAULT NULL,
  `motif` varchar(100) DEFAULT NULL,
  `montant` decimal(12,2) DEFAULT NULL,
  PRIMARY KEY (`id_prime`),
  KEY `id_personnel` (`id_salaire`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `prime`
--

LOCK TABLES `prime` WRITE;
/*!40000 ALTER TABLE `prime` DISABLE KEYS */;
INSERT INTO `prime` VALUES (1,1,'2026-08-07','Personnel vaillant',30.00);
/*!40000 ALTER TABLE `prime` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `reception_achat`
--

DROP TABLE IF EXISTS `reception_achat`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `reception_achat` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `commande_id` int(11) DEFAULT NULL,
  `fournisseur_id` int(11) NOT NULL,
  `date_reception` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `reference` varchar(100) DEFAULT NULL,
  `observation` text,
  PRIMARY KEY (`id`),
  KEY `commande_id` (`commande_id`),
  KEY `fournisseur_id` (`fournisseur_id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `reception_achat`
--

LOCK TABLES `reception_achat` WRITE;
/*!40000 ALTER TABLE `reception_achat` DISABLE KEYS */;
/*!40000 ALTER TABLE `reception_achat` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `reception_achat_ligne`
--

DROP TABLE IF EXISTS `reception_achat_ligne`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `reception_achat_ligne` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `reception_id` int(11) NOT NULL,
  `medicament_id` int(11) NOT NULL,
  `lot_id` int(11) NOT NULL,
  `quantite` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `reception_id` (`reception_id`),
  KEY `medicament_id` (`medicament_id`),
  KEY `lot_id` (`lot_id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `reception_achat_ligne`
--

LOCK TABLES `reception_achat_ligne` WRITE;
/*!40000 ALTER TABLE `reception_achat_ligne` DISABLE KEYS */;
/*!40000 ALTER TABLE `reception_achat_ligne` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `retenue`
--

DROP TABLE IF EXISTS `retenue`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `retenue` (
  `id_retenue` int(11) NOT NULL AUTO_INCREMENT,
  `id_salaire` int(11) DEFAULT NULL,
  `date_retenue` date DEFAULT NULL,
  `motif` varchar(50) DEFAULT NULL,
  `montant` decimal(12,2) DEFAULT NULL,
  PRIMARY KEY (`id_retenue`),
  KEY `id_personnel` (`id_salaire`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `retenue`
--

LOCK TABLES `retenue` WRITE;
/*!40000 ALTER TABLE `retenue` DISABLE KEYS */;
/*!40000 ALTER TABLE `retenue` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `salaires`
--

DROP TABLE IF EXISTS `salaires`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `salaires` (
  `id_salaire` int(11) NOT NULL AUTO_INCREMENT,
  `id_personnel` int(11) DEFAULT NULL,
  `mois` varchar(50) NOT NULL,
  `salaire_base` decimal(12,2) NOT NULL,
  `date_paiement` date NOT NULL,
  `statut` enum('Payé','Nom payé','En attente') NOT NULL,
  PRIMARY KEY (`id_salaire`),
  KEY `id_personnel` (`id_personnel`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `salaires`
--

LOCK TABLES `salaires` WRITE;
/*!40000 ALTER TABLE `salaires` DISABLE KEYS */;
INSERT INTO `salaires` VALUES (1,1,'Janvier',200.00,'2026-04-18','Payé');
/*!40000 ALTER TABLE `salaires` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `service`
--

DROP TABLE IF EXISTS `service`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `service` (
  `id_service` int(11) NOT NULL AUTO_INCREMENT,
  `nom` varchar(150) NOT NULL,
  `description` varchar(255) DEFAULT NULL,
  `actif` tinyint(1) NOT NULL DEFAULT '1',
  PRIMARY KEY (`id_service`),
  UNIQUE KEY `uk_service_nom` (`nom`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `service`
--

LOCK TABLES `service` WRITE;
/*!40000 ALTER TABLE `service` DISABLE KEYS */;
INSERT INTO `service` VALUES (1,'EEG','Électroencéphalogramme',1),(2,'Laboratoire','Examens de laboratoire',1),(3,'Psychologie','Consultation et suivi psychologique',1),(4,'Imagerie','Examens d?imagerie médicale',1);
/*!40000 ALTER TABLE `service` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `signes_vitaux`
--

DROP TABLE IF EXISTS `signes_vitaux`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `signes_vitaux` (
  `id_signe` int(11) NOT NULL AUTO_INCREMENT,
  `id_patient` int(11) DEFAULT NULL,
  `temperature` decimal(4,2) DEFAULT NULL,
  `tension` varchar(10) DEFAULT NULL,
  `frequence_cardiaque` varchar(50) DEFAULT NULL,
  `poids` decimal(5,2) DEFAULT NULL,
  `taille` decimal(5,2) DEFAULT NULL,
  `date_prise` datetime DEFAULT NULL,
  `is_counsel` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id_signe`),
  KEY `id_patient` (`id_patient`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `signes_vitaux`
--

LOCK TABLES `signes_vitaux` WRITE;
/*!40000 ALTER TABLE `signes_vitaux` DISABLE KEYS */;
INSERT INTO `signes_vitaux` VALUES (1,19,35.00,'120Hmmg','70Bpm',55.00,1.00,'2026-08-20 00:00:00',1),(2,18,45.00,'45','12',45.00,1.00,'2026-08-21 00:00:00',0),(3,19,32.00,'120/80Hmmg','70Bpm',52.00,1.00,'2026-08-28 00:00:00',0),(4,20,45.00,'522','41',52.00,1.00,'2026-08-28 00:00:00',0),(5,20,23.00,'10','34',56.00,1.80,'2026-09-04 00:00:00',0),(6,20,45.00,'12','6',23.00,53.00,'2026-09-04 00:00:00',0),(7,20,23.00,'12','23',54.00,33.00,'2026-09-04 00:00:00',0);
/*!40000 ALTER TABLE `signes_vitaux` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `soins`
--

DROP TABLE IF EXISTS `soins`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `soins` (
  `id_soin` int(11) NOT NULL AUTO_INCREMENT,
  `nom_soin` varchar(25) DEFAULT NULL,
  `prix` decimal(12,2) DEFAULT NULL,
  `actif` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`id_soin`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `soins`
--

LOCK TABLES `soins` WRITE;
/*!40000 ALTER TABLE `soins` DISABLE KEYS */;
/*!40000 ALTER TABLE `soins` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sortie_ph_service`
--

DROP TABLE IF EXISTS `sortie_ph_service`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sortie_ph_service` (
  `id_sortie` int(11) NOT NULL AUTO_INCREMENT,
  `id_centre` int(11) DEFAULT NULL,
  `id_service` int(11) DEFAULT NULL,
  `date_sortie` date DEFAULT NULL,
  PRIMARY KEY (`id_sortie`),
  KEY `id_centre` (`id_centre`),
  KEY `id_service` (`id_service`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sortie_ph_service`
--

LOCK TABLES `sortie_ph_service` WRITE;
/*!40000 ALTER TABLE `sortie_ph_service` DISABLE KEYS */;
/*!40000 ALTER TABLE `sortie_ph_service` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sortie_s_pa`
--

DROP TABLE IF EXISTS `sortie_s_pa`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sortie_s_pa` (
  `id_sortie` int(11) NOT NULL AUTO_INCREMENT,
  `id_hospitalisation` int(11) DEFAULT NULL,
  `id_service` int(11) DEFAULT NULL,
  `date_sortie` date DEFAULT NULL,
  PRIMARY KEY (`id_sortie`),
  KEY `id_hospitalisation` (`id_hospitalisation`),
  KEY `id_service` (`id_service`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sortie_s_pa`
--

LOCK TABLES `sortie_s_pa` WRITE;
/*!40000 ALTER TABLE `sortie_s_pa` DISABLE KEYS */;
/*!40000 ALTER TABLE `sortie_s_pa` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sorties_stock`
--

DROP TABLE IF EXISTS `sorties_stock`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sorties_stock` (
  `id_sortie` int(11) NOT NULL AUTO_INCREMENT,
  `id_centre` int(11) DEFAULT NULL,
  `type_sortie` enum('ambulatoire','hospitalisation') DEFAULT 'ambulatoire',
  `id_patient` int(11) DEFAULT NULL,
  `id_service` int(11) DEFAULT NULL,
  `date_sortie` date DEFAULT NULL,
  `statut` enum('validée','en attente','annulée') DEFAULT 'en attente',
  PRIMARY KEY (`id_sortie`),
  KEY `id_centre` (`id_centre`),
  KEY `id_service` (`id_service`),
  KEY `id_patient` (`id_patient`)
) ENGINE=InnoDB AUTO_INCREMENT=46 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sorties_stock`
--

LOCK TABLES `sorties_stock` WRITE;
/*!40000 ALTER TABLE `sorties_stock` DISABLE KEYS */;
INSERT INTO `sorties_stock` VALUES (18,1,NULL,5,NULL,NULL,'en attente'),(19,1,NULL,15,NULL,NULL,'en attente'),(20,1,'',10,NULL,'2026-07-09','en attente'),(21,1,'',18,NULL,'2026-07-09','en attente'),(22,1,'',18,NULL,'2026-07-10','en attente'),(23,1,'',19,NULL,'2026-07-10','en attente'),(24,1,'',19,NULL,'2026-07-10','en attente'),(25,1,'',18,NULL,'2026-07-10','en attente'),(26,1,'ambulatoire',19,NULL,'2026-07-10','en attente'),(27,1,'ambulatoire',18,NULL,'2026-07-10','en attente'),(28,1,'ambulatoire',18,NULL,'2026-07-10','en attente'),(29,1,'ambulatoire',3,NULL,'2026-07-10','en attente'),(30,1,'ambulatoire',19,NULL,'2026-07-10','en attente'),(31,1,'ambulatoire',18,NULL,'2026-07-10','en attente'),(32,1,'ambulatoire',19,NULL,'2026-07-10','en attente'),(33,1,'ambulatoire',19,NULL,'2026-07-11','en attente'),(34,1,'',19,NULL,'2026-07-13','en attente'),(35,1,'',19,NULL,'2026-07-13','en attente'),(36,1,'',19,NULL,'2026-07-13','en attente'),(37,1,'',17,NULL,'2026-07-14','en attente'),(38,1,'ambulatoire',17,NULL,'2026-07-14','en attente'),(39,1,'ambulatoire',19,NULL,'2026-07-14','en attente'),(40,1,'ambulatoire',19,NULL,'2026-07-18','en attente'),(41,1,'ambulatoire',19,NULL,'2026-07-21','en attente'),(42,1,'ambulatoire',19,NULL,'2026-07-31','en attente'),(43,1,'ambulatoire',19,NULL,'2026-08-12','en attente'),(44,1,'ambulatoire',19,NULL,'2026-08-20','en attente'),(45,1,'ambulatoire',18,NULL,'2026-08-21','en attente');
/*!40000 ALTER TABLE `sorties_stock` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `stock_pharmacie`
--

DROP TABLE IF EXISTS `stock_pharmacie`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `stock_pharmacie` (
  `id_stock` int(11) NOT NULL AUTO_INCREMENT,
  `id_centre` int(11) DEFAULT NULL,
  `id_medicament` int(11) NOT NULL,
  `quantite` int(10) DEFAULT NULL,
  `unite` varchar(100) DEFAULT NULL,
  `stock_minimum` int(11) DEFAULT '0',
  PRIMARY KEY (`id_stock`),
  UNIQUE KEY `id_medicament_2` (`id_medicament`),
  KEY `id_centre` (`id_centre`),
  KEY `id_medicament` (`id_medicament`)
) ENGINE=InnoDB AUTO_INCREMENT=26 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `stock_pharmacie`
--

LOCK TABLES `stock_pharmacie` WRITE;
/*!40000 ALTER TABLE `stock_pharmacie` DISABLE KEYS */;
INSERT INTO `stock_pharmacie` VALUES (1,1,1,22,NULL,0),(2,1,2,22,NULL,0),(3,1,3,22,NULL,0),(4,1,4,25,NULL,0),(8,1,5,15,NULL,0),(9,1,6,22,NULL,0),(10,1,7,22,NULL,0),(11,1,8,22,NULL,0),(12,1,9,22,NULL,0),(13,1,10,18,NULL,0),(14,1,11,14,NULL,0),(15,1,12,18,NULL,0),(16,1,13,22,NULL,0),(17,1,14,22,NULL,0),(18,1,15,18,NULL,0),(19,1,16,22,NULL,0),(21,1,17,22,NULL,0),(22,1,18,22,NULL,0),(23,1,19,22,NULL,0),(24,1,20,22,NULL,0),(25,1,22,6,'Carton',0);
/*!40000 ALTER TABLE `stock_pharmacie` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `stock_service`
--

DROP TABLE IF EXISTS `stock_service`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `stock_service` (
  `id_stock_service` int(11) NOT NULL AUTO_INCREMENT,
  `id_service` int(11) DEFAULT NULL,
  `id_medicament` int(11) DEFAULT NULL,
  `quantite` int(10) DEFAULT NULL,
  `stock_minimum` int(10) DEFAULT NULL,
  PRIMARY KEY (`id_stock_service`),
  KEY `id_service` (`id_service`),
  KEY `id_medicament` (`id_medicament`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `stock_service`
--

LOCK TABLES `stock_service` WRITE;
/*!40000 ALTER TABLE `stock_service` DISABLE KEYS */;
/*!40000 ALTER TABLE `stock_service` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `suivi_hospitalisation`
--

DROP TABLE IF EXISTS `suivi_hospitalisation`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `suivi_hospitalisation` (
  `id_suivi` int(11) NOT NULL AUTO_INCREMENT,
  `id_hospitalisation` int(11) NOT NULL,
  `temperature` decimal(4,1) NOT NULL,
  `tension` varchar(20) NOT NULL,
  `rythme_cardiaque` varchar(50) DEFAULT NULL,
  `observation` text NOT NULL,
  `date_suivi` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `etat_mental` enum('Stable','Anxieux','Agressif','Dépressif','Euphorique') NOT NULL,
  PRIMARY KEY (`id_suivi`),
  KEY `id_hospitalisation` (`id_hospitalisation`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `suivi_hospitalisation`
--

LOCK TABLES `suivi_hospitalisation` WRITE;
/*!40000 ALTER TABLE `suivi_hospitalisation` DISABLE KEYS */;
/*!40000 ALTER TABLE `suivi_hospitalisation` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tarif_service`
--

DROP TABLE IF EXISTS `tarif_service`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tarif_service` (
  `id_tarif` int(11) NOT NULL AUTO_INCREMENT,
  `id_service` int(11) NOT NULL,
  `libelle` varchar(150) NOT NULL,
  `montant` decimal(12,2) NOT NULL DEFAULT '0.00',
  `devise` varchar(10) NOT NULL DEFAULT 'USD',
  `actif` tinyint(1) NOT NULL DEFAULT '1',
  `date_debut` date NOT NULL,
  `date_fin` date DEFAULT NULL,
  PRIMARY KEY (`id_tarif`),
  KEY `idx_tarif_service` (`id_service`),
  CONSTRAINT `fk_tarif_service` FOREIGN KEY (`id_service`) REFERENCES `services` (`id_service`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tarif_service`
--

LOCK TABLES `tarif_service` WRITE;
/*!40000 ALTER TABLE `tarif_service` DISABLE KEYS */;
INSERT INTO `tarif_service` VALUES (1,1,'Consultation psychiatrique',10.00,'USD',1,'2026-01-01',NULL),(2,1,'Consultation de suivi',8.00,'USD',1,'2026-01-01',NULL),(3,2,'Hospitalisation par jour',20.00,'USD',1,'2026-01-01',NULL),(4,3,'Analyse laboratoire',5.00,'USD',1,'2026-01-01',NULL),(5,4,'EEG',25.00,'USD',1,'2026-01-01',NULL),(6,5,'Séance de psychologie',10.00,'USD',1,'2026-01-01',NULL);
/*!40000 ALTER TABLE `tarif_service` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `unite_gestion`
--

DROP TABLE IF EXISTS `unite_gestion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `unite_gestion` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nom` varchar(100) NOT NULL,
  `abreviation` varchar(20) DEFAULT NULL,
  `description` varchar(255) DEFAULT NULL,
  `actif` tinyint(1) NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`),
  UNIQUE KEY `nom` (`nom`)
) ENGINE=MyISAM AUTO_INCREMENT=25 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `unite_gestion`
--

LOCK TABLES `unite_gestion` WRITE;
/*!40000 ALTER TABLE `unite_gestion` DISABLE KEYS */;
INSERT INTO `unite_gestion` VALUES (1,'Comprimé','cp','Médicament sous forme de comprimé',1),(2,'Gélule','gél','Médicament sous forme de gélule',1),(3,'Capsule','caps','Médicament sous forme de capsule',1),(4,'Flacon','fl','Médicament conditionné dans un flacon',1),(5,'Ampoule','amp','Médicament conditionné dans une ampoule',1),(6,'Tube','tube','Médicament conditionné dans un tube',1),(7,'Boîte','bte','Médicament conditionné dans une boîte',1),(8,'Sachet','sach','Médicament conditionné dans un sachet',1),(9,'Poche','poche','Médicament conditionné dans une poche',1),(10,'Suppositoire','supp','Médicament sous forme de suppositoire',1),(11,'Dose','dose','Médicament distribué par dose',1),(12,'Unité','unité','Unité générale de gestion',1),(13,'popcorn','ppc','Unité du popcorn',1),(14,'Autrement','atr','Autre unité',1),(15,'zero','zr','zero description',1),(16,'ppp','p','Only p',1),(17,'dfgsfgsdf','sdgsdfer','ssdfzr',1),(18,'d','dtgsdftg','sdsdf',1),(19,'sfsdf','sdfs','fsdfsdfsdf',1),(20,'xxxxxxxxxxxxxxxxxxx','aa','srzsr',1),(21,'qqqqqqqqqqqqqqqqqq','qqqqqqqqq','rrrrr',1),(22,'wwwwwwwwwwwwwwww',NULL,NULL,1),(23,'sd','fsdsdf','sdsdfsdf',1),(24,'&&&&&&','&&&&&&','&&',1);
/*!40000 ALTER TABLE `unite_gestion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `utilisateurs`
--

DROP TABLE IF EXISTS `utilisateurs`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `utilisateurs` (
  `id_utilisateurs` int(11) NOT NULL AUTO_INCREMENT,
  `id_personnel` int(11) DEFAULT NULL,
  `username` varchar(100) DEFAULT NULL,
  `password_hash` varchar(100) DEFAULT NULL,
  `role` varchar(50) DEFAULT NULL,
  `date_creation` date DEFAULT NULL,
  `actif` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`id_utilisateurs`),
  KEY `id_personnel` (`id_personnel`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `utilisateurs`
--

LOCK TABLES `utilisateurs` WRITE;
/*!40000 ALTER TABLE `utilisateurs` DISABLE KEYS */;
INSERT INTO `utilisateurs` VALUES (1,1,'user','0000','Secretaire','2026-04-21',NULL);
/*!40000 ALTER TABLE `utilisateurs` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-09-04 11:47:13
