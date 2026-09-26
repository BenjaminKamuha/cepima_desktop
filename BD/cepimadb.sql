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
  `signature_donneur` varchar(100) DEFAULT NULL,
  `montant` decimal(10,2) DEFAULT NULL,
  `date` datetime DEFAULT CURRENT_TIMESTAMP,
  `statut` enum('En attente','Validé','Annulé') DEFAULT 'En attente',
  PRIMARY KEY (`id_bon`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;
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
  `nombre_lit` int(11) DEFAULT NULL,
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
  `id_demande` int(11) DEFAULT NULL,
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
  KEY `idx_consultation_demande` (`id_demande`),
  CONSTRAINT `fk_consultation_demande` FOREIGN KEY (`id_demande`) REFERENCES `demande_service` (`id_demande`) ON DELETE SET NULL ON UPDATE CASCADE,
  CONSTRAINT `fk_consultation_diagnostic` FOREIGN KEY (`diagnostic_id`) REFERENCES `diagnostic` (`id`) ON DELETE SET NULL ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
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
  `id_prestation` int(11) DEFAULT NULL,
  `id_personnel` int(11) DEFAULT NULL,
  `date_demande` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `priorite` enum('Normale','Urgente') NOT NULL DEFAULT 'Normale',
  `motif` text,
  `statut` enum('Demandée','Acceptée','En cours','Terminée','Annulée','En attente') DEFAULT NULL,
  `observation` text,
  PRIMARY KEY (`id_demande`),
  KEY `idx_demande_patient` (`id_patient`),
  KEY `idx_demande_service` (`id_service`),
  KEY `idx_demande_personnel` (`id_personnel`),
  KEY `idx_demande_date` (`date_demande`),
  KEY `idx_demande_statut` (`statut`),
  KEY `idx_demande_prestation` (`id_prestation`),
  CONSTRAINT `fk_demande_patient` FOREIGN KEY (`id_patient`) REFERENCES `patients` (`id_patient`) ON UPDATE CASCADE,
  CONSTRAINT `fk_demande_prestation` FOREIGN KEY (`id_prestation`) REFERENCES `prestation` (`id_prestation`),
  CONSTRAINT `fk_demande_service` FOREIGN KEY (`id_service`) REFERENCES `service` (`id_service`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `demande_service`
--

LOCK TABLES `demande_service` WRITE;
/*!40000 ALTER TABLE `demande_service` DISABLE KEYS */;
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
  `id_prestation` int(11) DEFAULT NULL,
  `description` varchar(100) DEFAULT NULL,
  `quantite` int(10) DEFAULT NULL,
  `prix_unitaire` decimal(12,2) DEFAULT NULL,
  `montant` decimal(12,2) DEFAULT NULL,
  PRIMARY KEY (`id_detail_facture`),
  KEY `id_facture` (`id_facture`),
  KEY `fk_detail_facture_prestation` (`id_prestation`),
  CONSTRAINT `fk_detail_facture_prestation` FOREIGN KEY (`id_prestation`) REFERENCES `prestation` (`id_prestation`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=latin1;
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
) ENGINE=InnoDB AUTO_INCREMENT=28 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `diagnostic`
--

LOCK TABLES `diagnostic` WRITE;
/*!40000 ALTER TABLE `diagnostic` DISABLE KEYS */;
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
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;
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
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;
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
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `examens_eeg`
--

LOCK TABLES `examens_eeg` WRITE;
/*!40000 ALTER TABLE `examens_eeg` DISABLE KEYS */;
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
  `id_consultation` int(11) DEFAULT NULL,
  `id_centre` int(11) DEFAULT NULL,
  `type_facture` enum('Ambulatoire','Hospitalisé') NOT NULL,
  `date_facture` date DEFAULT NULL,
  `montant_total` decimal(12,2) DEFAULT NULL,
  `montant_paye` decimal(12,2) NOT NULL DEFAULT '0.00',
  `reste` decimal(12,2) NOT NULL DEFAULT '0.00',
  `statut` enum('Non payé','Partiellement payé','Payé','Clôturée') DEFAULT 'Non payé',
  PRIMARY KEY (`id_facture`),
  KEY `id_patient` (`id_patient`),
  KEY `id_centre` (`id_centre`),
  KEY `id_consultation` (`id_consultation`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;
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
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;
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
  `id_detail_facture` int(11) DEFAULT NULL,
  `date_paiement` date DEFAULT NULL,
  `montant` decimal(12,2) DEFAULT NULL,
  `reste` decimal(10,2) NOT NULL,
  `type_paiement` enum('Partiel','Complet') NOT NULL,
  PRIMARY KEY (`id_paiement`),
  KEY `id_facture` (`id_facture`),
  KEY `idx_paiement_detail` (`id_detail_facture`),
  CONSTRAINT `fk_paiement_detail` FOREIGN KEY (`id_detail_facture`) REFERENCES `detail_facture` (`id_detail_facture`) ON DELETE SET NULL ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;
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
  `actif` enum('Actif','Non actif') DEFAULT NULL,
  `situation_familliale` enum('Marié','Célibataire','Divorce') DEFAULT NULL,
  PRIMARY KEY (`id_personnel`),
  KEY `id_centre` (`id_centre`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `personnels`
--

LOCK TABLES `personnels` WRITE;
/*!40000 ALTER TABLE `personnels` DISABLE KEYS */;
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
  `date_prescription` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `statut` varchar(30) NOT NULL DEFAULT 'ACTIVE',
  `observation` text,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=15 DEFAULT CHARSET=latin1;
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
) ENGINE=MyISAM AUTO_INCREMENT=16 DEFAULT CHARSET=latin1;
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
/*!40000 ALTER TABLE `presences` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `prestation`
--

DROP TABLE IF EXISTS `prestation`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `prestation` (
  `id_prestation` int(11) NOT NULL AUTO_INCREMENT,
  `id_service` int(11) NOT NULL,
  `libelle` varchar(150) NOT NULL,
  `description` varchar(255) DEFAULT NULL,
  `unite` varchar(50) DEFAULT NULL,
  `actif` tinyint(1) NOT NULL DEFAULT '1',
  PRIMARY KEY (`id_prestation`),
  KEY `idx_prestation_service` (`id_service`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `prestation`
--

LOCK TABLES `prestation` WRITE;
/*!40000 ALTER TABLE `prestation` DISABLE KEYS */;
/*!40000 ALTER TABLE `prestation` ENABLE KEYS */;
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
-- Table structure for table `role`
--

DROP TABLE IF EXISTS `role`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `role` (
  `id_role` int(11) NOT NULL AUTO_INCREMENT,
  `nom_role` varchar(50) DEFAULT NULL,
  `statut` enum('actif','inactif') DEFAULT 'actif',
  PRIMARY KEY (`id_role`),
  UNIQUE KEY `nom_role` (`nom_role`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `role`
--

LOCK TABLES `role` WRITE;
/*!40000 ALTER TABLE `role` DISABLE KEYS */;
/*!40000 ALTER TABLE `role` ENABLE KEYS */;
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
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `service`
--

LOCK TABLES `service` WRITE;
/*!40000 ALTER TABLE `service` DISABLE KEYS */;
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
-- Table structure for table `tarif_prestation`
--

DROP TABLE IF EXISTS `tarif_prestation`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tarif_prestation` (
  `id_tarif` int(11) NOT NULL AUTO_INCREMENT,
  `id_prestation` int(11) NOT NULL,
  `prix` decimal(12,2) NOT NULL,
  `date_debut` date NOT NULL,
  `date_fin` date DEFAULT NULL,
  `actif` tinyint(1) NOT NULL DEFAULT '1',
  PRIMARY KEY (`id_tarif`),
  KEY `idx_tarif_prestation` (`id_prestation`)
) ENGINE=MyISAM AUTO_INCREMENT=19 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tarif_prestation`
--

LOCK TABLES `tarif_prestation` WRITE;
/*!40000 ALTER TABLE `tarif_prestation` DISABLE KEYS */;
/*!40000 ALTER TABLE `tarif_prestation` ENABLE KEYS */;
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
  `prix` decimal(12,2) NOT NULL,
  `actif` tinyint(1) NOT NULL DEFAULT '1',
  `date_debut` date NOT NULL,
  `date_fin` date DEFAULT NULL,
  PRIMARY KEY (`id_tarif`),
  KEY `idx_tarif_service` (`id_service`),
  CONSTRAINT `fk_tarif_service` FOREIGN KEY (`id_service`) REFERENCES `service` (`id_service`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tarif_service`
--

LOCK TABLES `tarif_service` WRITE;
/*!40000 ALTER TABLE `tarif_service` DISABLE KEYS */;
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
/*!40000 ALTER TABLE `unite_gestion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `utilisateur_role`
--

DROP TABLE IF EXISTS `utilisateur_role`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `utilisateur_role` (
  `id_utilisateur_role` int(11) NOT NULL AUTO_INCREMENT,
  `id_utilisateur` int(11) DEFAULT NULL,
  `id_role` int(11) DEFAULT NULL,
  PRIMARY KEY (`id_utilisateur_role`),
  KEY `fk_utilisateur_role` (`id_utilisateur`),
  KEY `fk_utilisateur_role_role` (`id_role`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `utilisateur_role`
--

LOCK TABLES `utilisateur_role` WRITE;
/*!40000 ALTER TABLE `utilisateur_role` DISABLE KEYS */;
/*!40000 ALTER TABLE `utilisateur_role` ENABLE KEYS */;
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
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `utilisateurs`
--

LOCK TABLES `utilisateurs` WRITE;
/*!40000 ALTER TABLE `utilisateurs` DISABLE KEYS */;
INSERT INTO `utilisateurs` VALUES (2,NULL,'user','Uevmazz/YrsUd2j+MI+HYA==:9+XrEvkX7wJAD1pJV+EPOPsQpIexiqC+8Iiiv2doUaQ=',NULL,'2026-09-26',1);
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

-- Dump completed on 2026-09-26 11:28:52
