-- phpMyAdmin SQL Dump
-- version 4.1.14
-- http://www.phpmyadmin.net
--
-- Client :  127.0.0.1
-- Généré le :  Lun 21 Septembre 2026 à 04:39
-- Version du serveur :  5.6.17
-- Version de PHP :  5.5.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Base de données :  `cepimadb`
--

-- --------------------------------------------------------

--
-- Structure de la table `affectation_chambre`
--

CREATE TABLE IF NOT EXISTS `affectation_chambre` (
  `id_affectation` int(11) NOT NULL AUTO_INCREMENT,
  `id_hospitalisation` int(11) DEFAULT NULL,
  `id_chambre` int(11) DEFAULT NULL,
  `date_debut` date DEFAULT NULL,
  `date_fin` date DEFAULT NULL,
  PRIMARY KEY (`id_affectation`),
  KEY `id_hospitalisation` (`id_hospitalisation`),
  KEY `id_chambre` (`id_chambre`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=5 ;

--
-- Contenu de la table `affectation_chambre`
--

INSERT INTO `affectation_chambre` (`id_affectation`, `id_hospitalisation`, `id_chambre`, `date_debut`, `date_fin`) VALUES
(1, 3, 32, '2026-07-09', NULL),
(2, 1, 30, '2026-07-09', '2026-07-09'),
(3, 1, 21, '2026-07-13', '2026-07-13'),
(4, 2, 32, '2026-07-13', NULL);

-- --------------------------------------------------------

--
-- Structure de la table `avances_salaire`
--

CREATE TABLE IF NOT EXISTS `avances_salaire` (
  `id_avance` int(11) NOT NULL AUTO_INCREMENT,
  `id_salaire` int(11) DEFAULT NULL,
  `date_avance` date DEFAULT NULL,
  `montant` decimal(12,2) DEFAULT NULL,
  `reste` decimal(12,2) DEFAULT NULL,
  PRIMARY KEY (`id_avance`),
  KEY `id_personnel` (`id_salaire`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=3 ;

--
-- Contenu de la table `avances_salaire`
--

INSERT INTO `avances_salaire` (`id_avance`, `id_salaire`, `date_avance`, `montant`, `reste`) VALUES
(1, 0, '2026-07-29', '150.00', '50.00'),
(2, 1, '2026-08-09', '56.00', '144.00');

-- --------------------------------------------------------

--
-- Structure de la table `bon_sortie`
--

CREATE TABLE IF NOT EXISTS `bon_sortie` (
  `id_bon` int(11) NOT NULL AUTO_INCREMENT,
  `nom_resp` varchar(50) DEFAULT NULL,
  `montant` decimal(10,2) DEFAULT NULL,
  `date` datetime DEFAULT CURRENT_TIMESTAMP,
  `statut` enum('en attente','validé','annulé') DEFAULT NULL,
  PRIMARY KEY (`id_bon`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Structure de la table `centres`
--

CREATE TABLE IF NOT EXISTS `centres` (
  `id_centre` int(11) NOT NULL AUTO_INCREMENT,
  `nom_centre` varchar(255) DEFAULT NULL,
  `adresse` varchar(255) DEFAULT NULL,
  `telephone` varchar(50) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  `date_creation` date DEFAULT NULL,
  `actif` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`id_centre`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=2 ;

--
-- Contenu de la table `centres`
--

INSERT INTO `centres` (`id_centre`, `nom_centre`, `adresse`, `telephone`, `email`, `date_creation`, `actif`) VALUES
(1, 'CEPIMA-Centre Ukandilama', 'Butembo/Avenue Talia', '+243 985 896 563', 'cepima@gmail.com', '2026-04-07', 1);

-- --------------------------------------------------------

--
-- Structure de la table `chambre`
--

CREATE TABLE IF NOT EXISTS `chambre` (
  `id_chambre` int(11) NOT NULL AUTO_INCREMENT,
  `id_centre` int(11) DEFAULT NULL,
  `id_service` int(11) NOT NULL,
  `numero_chambre` int(10) DEFAULT NULL,
  `nombre_lit` int(11) DEFAULT NULL,
  `type_chambre` enum('Individuelle','Double','Commune','Observation','Surveillance renforcée','Isolement thérapeutique','VIP') DEFAULT NULL,
  `tarif_journalier` decimal(12,2) DEFAULT NULL,
  `statut` enum('Disponible','Occupée','Reservée','Hos service','Maintenance') DEFAULT 'Disponible',
  PRIMARY KEY (`id_chambre`),
  KEY `id_centre` (`id_centre`),
  KEY `id_service` (`id_service`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=36 ;

--
-- Contenu de la table `chambre`
--

INSERT INTO `chambre` (`id_chambre`, `id_centre`, `id_service`, `numero_chambre`, `nombre_lit`, `type_chambre`, `tarif_journalier`, `statut`) VALUES
(1, 1, 1, 101, NULL, 'Individuelle', '10.86', 'Disponible'),
(2, 1, 1, 102, NULL, 'Double', '15.21', 'Disponible'),
(3, 1, 1, 103, NULL, 'Commune', '6.52', 'Disponible'),
(4, 1, 1, 104, NULL, 'Observation', '17.39', 'Disponible'),
(5, 1, 2, 201, NULL, 'Individuelle', '10.86', 'Disponible'),
(6, 1, 2, 202, NULL, 'Double', '15.25', 'Disponible'),
(7, 1, 2, 203, NULL, 'Commune', '6.52', 'Disponible'),
(8, 1, 2, 204, NULL, 'Observation', '17.30', 'Disponible'),
(9, 1, 3, 301, NULL, 'Observation', '21.73', 'Disponible'),
(10, 1, 3, 302, NULL, 'Double', '15.21', 'Disponible'),
(11, 1, 3, 303, NULL, 'Commune', '6.52', 'Disponible'),
(12, 1, 3, 304, NULL, 'Individuelle', '10.86', 'Disponible'),
(13, 1, 4, 401, NULL, 'Individuelle', '13.04', 'Disponible'),
(14, 1, 4, 402, NULL, 'Double', '17.39', 'Disponible'),
(15, 1, 4, 403, NULL, 'Commune', '7.80', 'Disponible'),
(16, 1, 4, 404, NULL, 'Observation', '10.56', 'Disponible'),
(17, 1, 5, 501, NULL, 'Individuelle', '13.04', 'Disponible'),
(18, 1, 5, 502, NULL, 'Double', '17.39', 'Disponible'),
(19, 1, 5, 503, NULL, 'Commune', '7.82', 'Disponible'),
(20, 1, 5, 504, NULL, 'Observation', '19.56', 'Disponible'),
(21, 1, 6, 50, NULL, 'Individuelle', '8.00', 'Disponible'),
(22, 1, 6, 602, NULL, 'Double', '13.00', 'Disponible'),
(23, 1, 6, 603, NULL, 'Commune', '5.20', 'Disponible'),
(24, 1, 6, 604, NULL, 'Observation', '15.20', 'Disponible'),
(25, 1, 7, 701, NULL, 'Individuelle', '10.86', 'Disponible'),
(26, 1, 7, 702, NULL, 'Double', '15.21', 'Disponible'),
(27, 1, 7, 703, NULL, 'Commune', '6.52', 'Disponible'),
(28, 1, 7, 704, NULL, 'Observation', '17.39', 'Disponible'),
(30, 1, 7, 706, NULL, 'Individuelle', '10.86', 'Disponible'),
(32, 1, 6, 90, NULL, 'Surveillance renforcée', '19.56', 'Occupée'),
(33, 1, 5, 91, NULL, 'Isolement thérapeutique', '2.17', 'Disponible'),
(34, 1, 6, 92, NULL, 'VIP', '4.34', 'Disponible'),
(35, 1, 6, 93, NULL, 'Isolement thérapeutique', '3.26', 'Disponible');

-- --------------------------------------------------------

--
-- Structure de la table `commande_achat`
--

CREATE TABLE IF NOT EXISTS `commande_achat` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `fournisseur_id` int(11) NOT NULL,
  `date_commande` date NOT NULL,
  `statut` varchar(30) NOT NULL DEFAULT 'EN_ATTENTE',
  `reference` varchar(50) DEFAULT NULL,
  `observation` text,
  PRIMARY KEY (`id`),
  UNIQUE KEY `reference` (`reference`),
  KEY `fournisseur_id` (`fournisseur_id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Structure de la table `commande_achat_ligne`
--

CREATE TABLE IF NOT EXISTS `commande_achat_ligne` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `commande_id` int(11) NOT NULL,
  `medicament_id` int(11) NOT NULL,
  `quantite` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `commande_id` (`commande_id`),
  KEY `medicament_id` (`medicament_id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Structure de la table `consultation`
--

CREATE TABLE IF NOT EXISTS `consultation` (
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
  KEY `idx_consultation_date` (`date_consultation`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Structure de la table `demande_service`
--

CREATE TABLE IF NOT EXISTS `demande_service` (
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
  KEY `idx_demande_prestation` (`id_prestation`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=4 ;

--
-- Contenu de la table `demande_service`
--

INSERT INTO `demande_service` (`id_demande`, `id_patient`, `id_service`, `id_prestation`, `id_personnel`, `date_demande`, `priorite`, `motif`, `statut`, `observation`) VALUES
(1, 20, 1, 1, NULL, '2026-09-19 04:55:19', 'Normale', 'srfaqer', 'Terminée', 'qsdf'),
(2, 20, 5, 10, NULL, '2026-09-19 04:56:40', 'Normale', 'sfsd', 'En attente', NULL),
(3, 20, 1, 1, NULL, '2026-09-19 10:00:37', 'Normale', 'sdfdqs', 'En attente', NULL);

-- --------------------------------------------------------

--
-- Structure de la table `depenses`
--

CREATE TABLE IF NOT EXISTS `depenses` (
  `id_depense` int(11) NOT NULL AUTO_INCREMENT,
  `id_centre` int(11) DEFAULT NULL,
  `date_depense` date DEFAULT NULL,
  `motif` varchar(50) DEFAULT NULL,
  `montant` decimal(12,2) DEFAULT NULL,
  `responsable` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id_depense`),
  KEY `id_centre` (`id_centre`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Structure de la table `details_soins`
--

CREATE TABLE IF NOT EXISTS `details_soins` (
  `id_detail_soin` int(11) NOT NULL AUTO_INCREMENT,
  `id_consultation` int(11) DEFAULT NULL,
  `id_soin` int(11) DEFAULT NULL,
  `quantite` int(10) DEFAULT NULL,
  `prix` decimal(12,2) DEFAULT NULL,
  PRIMARY KEY (`id_detail_soin`),
  KEY `id_consultation` (`id_consultation`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Structure de la table `detail_entree_stock`
--

CREATE TABLE IF NOT EXISTS `detail_entree_stock` (
  `id_detail` int(11) NOT NULL AUTO_INCREMENT,
  `id_entree` int(11) DEFAULT NULL,
  `id_medicament` int(11) DEFAULT NULL,
  `quantite` int(10) DEFAULT NULL,
  `prix_achat` decimal(12,2) DEFAULT NULL,
  PRIMARY KEY (`id_detail`),
  KEY `id_entree` (`id_entree`),
  KEY `id_medicament` (`id_medicament`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Structure de la table `detail_facture`
--

CREATE TABLE IF NOT EXISTS `detail_facture` (
  `id_detail_facture` int(11) NOT NULL AUTO_INCREMENT,
  `id_facture` int(11) DEFAULT NULL,
  `id_prestation` int(11) DEFAULT NULL,
  `description` varchar(100) DEFAULT NULL,
  `quantite` int(10) DEFAULT NULL,
  `prix_unitaire` decimal(12,2) DEFAULT NULL,
  `montant` decimal(12,2) DEFAULT NULL,
  PRIMARY KEY (`id_detail_facture`),
  KEY `id_facture` (`id_facture`),
  KEY `fk_detail_facture_prestation` (`id_prestation`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=3 ;

--
-- Contenu de la table `detail_facture`
--

INSERT INTO `detail_facture` (`id_detail_facture`, `id_facture`, `id_prestation`, `description`, `quantite`, `prix_unitaire`, `montant`) VALUES
(1, 1, 1, 'EEG 18 canaux', 1, '25.00', '25.00'),
(2, 1, 10, 'Consultation médicale', 1, '20.00', '20.00');

-- --------------------------------------------------------

--
-- Structure de la table `detail_sortie_ph_service`
--

CREATE TABLE IF NOT EXISTS `detail_sortie_ph_service` (
  `id_detail` int(11) NOT NULL AUTO_INCREMENT,
  `id_sortie` int(11) DEFAULT NULL,
  `id_medicament` int(11) DEFAULT NULL,
  `quantite` int(10) DEFAULT NULL,
  PRIMARY KEY (`id_detail`),
  KEY `id_medicament` (`id_medicament`),
  KEY `id_sortie` (`id_sortie`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Structure de la table `detail_sortie_stock`
--

CREATE TABLE IF NOT EXISTS `detail_sortie_stock` (
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
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=57 ;

--
-- Contenu de la table `detail_sortie_stock`
--

INSERT INTO `detail_sortie_stock` (`id_detail`, `id_sortie`, `id_medicament`, `quantite`, `prix_unitaire`, `montant`, `id_consultation`) VALUES
(12, 18, 4, 3, '0.50', NULL, NULL),
(13, 18, 4, 3, '0.50', NULL, NULL),
(14, 18, 4, 3, '0.50', NULL, NULL),
(15, 18, 4, 3, '0.50', NULL, NULL),
(16, 18, 4, 3, '0.50', NULL, NULL),
(17, 18, 4, 3, '0.50', NULL, NULL),
(18, 18, 4, 3, '0.50', NULL, NULL),
(19, 18, 4, 3, '0.50', NULL, NULL),
(20, 18, 4, 3, '0.50', NULL, NULL),
(21, 19, 6, 8, '1.20', NULL, NULL),
(22, 19, 9, 8, '1.60', NULL, NULL),
(23, 19, 12, 3, '0.70', NULL, NULL),
(24, 19, 6, 8, '1.20', NULL, NULL),
(25, 19, 9, 8, '1.60', NULL, NULL),
(26, 19, 12, 3, '0.70', NULL, NULL),
(27, 18, 4, 3, '0.50', NULL, NULL),
(28, 18, 4, 3, '0.50', NULL, NULL),
(29, 18, 4, 3, '0.50', NULL, NULL),
(30, 18, 4, 3, '0.50', NULL, NULL),
(31, 18, 4, 3, '0.50', NULL, NULL),
(32, 19, 6, 8, '1.20', NULL, NULL),
(33, 19, 9, 8, '1.60', NULL, NULL),
(34, 19, 12, 3, '0.70', NULL, NULL),
(35, 19, 6, 8, '1.20', NULL, NULL),
(36, 19, 9, 8, '1.60', NULL, NULL),
(37, 19, 12, 3, '0.70', NULL, NULL),
(38, 18, 4, 3, '0.50', NULL, NULL),
(39, 18, 4, 3, '0.50', NULL, NULL),
(40, 19, 6, 8, '1.20', NULL, NULL),
(41, 19, 9, 8, '1.60', NULL, NULL),
(42, 19, 12, 3, '0.70', NULL, NULL),
(43, 18, 4, 3, '0.50', NULL, NULL),
(44, 19, 6, 8, '1.20', NULL, NULL),
(45, 19, 9, 8, '1.60', NULL, NULL),
(46, 19, 12, 3, '0.70', NULL, NULL),
(47, 19, 6, 8, '1.20', NULL, NULL),
(48, 19, 9, 8, '1.60', NULL, NULL),
(49, 19, 12, 3, '0.70', NULL, NULL),
(50, 18, 4, 3, '0.50', NULL, NULL),
(51, 19, 6, 8, '1.20', NULL, NULL),
(52, 19, 9, 8, '1.60', NULL, NULL),
(53, 19, 12, 3, '0.70', NULL, NULL),
(54, 19, 6, 8, '1.20', NULL, NULL),
(55, 19, 9, 8, '1.60', NULL, NULL),
(56, 19, 12, 3, '0.70', NULL, NULL);

-- --------------------------------------------------------

--
-- Structure de la table `detail_sortie_s_pa`
--

CREATE TABLE IF NOT EXISTS `detail_sortie_s_pa` (
  `id_detail` int(11) NOT NULL AUTO_INCREMENT,
  `id_sortie` int(11) DEFAULT NULL,
  `id_medicament` int(11) DEFAULT NULL,
  `quantite` int(10) DEFAULT NULL,
  `prix_unitaire` decimal(12,2) DEFAULT NULL,
  PRIMARY KEY (`id_detail`),
  KEY `id_sortie` (`id_sortie`),
  KEY `id_medicament` (`id_medicament`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Structure de la table `diagnostic`
--

CREATE TABLE IF NOT EXISTS `diagnostic` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `code` varchar(20) DEFAULT NULL,
  `libelle` varchar(255) NOT NULL,
  `description` text,
  `actif` tinyint(1) NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`),
  KEY `idx_diagnostic_libelle` (`libelle`(100))
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=25 ;

--
-- Contenu de la table `diagnostic`
--

INSERT INTO `diagnostic` (`id`, `code`, `libelle`, `description`, `actif`) VALUES
(1, 'F00', 'Démence dans la maladie d?Alzheimer', NULL, 1),
(2, 'F01', 'Démence vasculaire', NULL, 1),
(3, 'F02', 'Démence dans d?autres maladies', NULL, 1),
(4, 'F05', 'Delirium, non induit par l?alcool ou d?autres substances', NULL, 1),
(5, 'F10', 'Troubles mentaux et du comportement liés à l?utilisation d?alcool', NULL, 1),
(6, 'F20', 'Schizophrénie', NULL, 1),
(7, 'F21', 'Trouble schizotypique', NULL, 1),
(8, 'F22', 'Trouble délirant persistant', NULL, 1),
(9, 'F23', 'Trouble psychotique aigu et transitoire', NULL, 1),
(10, 'F25', 'Trouble schizo-affectif', NULL, 1),
(11, 'F30', 'Épisode maniaque', NULL, 1),
(12, 'F31', 'Trouble affectif bipolaire', NULL, 1),
(13, 'F32', 'Épisode dépressif', NULL, 1),
(14, 'F33', 'Trouble dépressif récurrent', NULL, 1),
(15, 'F40', 'Troubles anxieux phobiques', NULL, 1),
(16, 'F41', 'Autres troubles anxieux', NULL, 1),
(17, 'F42', 'Trouble obsessionnel-compulsif', NULL, 1),
(18, 'F43', 'Réaction à un facteur de stress et troubles de l?adaptation', NULL, 1),
(19, 'F44', 'Troubles dissociatifs', NULL, 1),
(20, 'F45', 'Troubles somatoformes', NULL, 1),
(21, 'F51', 'Troubles non organiques du sommeil', NULL, 1),
(22, 'F60', 'Troubles spécifiques de la personnalité', NULL, 1),
(23, 'F70', 'Déficience intellectuelle légère', NULL, 1),
(24, 'F79', 'Déficience intellectuelle, sans précision', NULL, 1);

-- --------------------------------------------------------

--
-- Structure de la table `dispensation`
--

CREATE TABLE IF NOT EXISTS `dispensation` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `prescription_id` int(11) NOT NULL,
  `patient_id` int(11) NOT NULL,
  `type` varchar(30) NOT NULL,
  `date_dispensation` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `agent_id` int(11) DEFAULT NULL,
  `observation` text,
  PRIMARY KEY (`id`),
  KEY `prescription_id` (`prescription_id`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=7 ;

--
-- Contenu de la table `dispensation`
--

INSERT INTO `dispensation` (`id`, `prescription_id`, `patient_id`, `type`, `date_dispensation`, `agent_id`, `observation`) VALUES
(1, 7, 20, 'PHARMACIE', '2026-09-19 08:47:55', NULL, ''),
(2, 7, 20, 'PHARMACIE', '2026-09-19 08:48:07', NULL, ''),
(3, 7, 20, 'PHARMACIE', '2026-09-19 08:53:11', NULL, ''),
(4, 7, 20, 'PHARMACIE', '2026-09-19 08:53:56', NULL, ''),
(5, 7, 20, 'PHARMACIE', '2026-09-19 08:54:08', NULL, ''),
(6, 7, 20, 'PHARMACIE', '2026-09-19 08:55:33', NULL, '');

-- --------------------------------------------------------

--
-- Structure de la table `dispensation_ligne`
--

CREATE TABLE IF NOT EXISTS `dispensation_ligne` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `dispensation_id` int(11) NOT NULL,
  `medicament_id` int(11) NOT NULL,
  `lot_id` int(11) NOT NULL,
  `quantite` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `dispensation_id` (`dispensation_id`),
  KEY `medicament_id` (`medicament_id`),
  KEY `lot_id` (`lot_id`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=3 ;

--
-- Contenu de la table `dispensation_ligne`
--

INSERT INTO `dispensation_ligne` (`id`, `dispensation_id`, `medicament_id`, `lot_id`, `quantite`) VALUES
(1, 1, 1, 7, 10),
(2, 2, 1, 7, 10);

-- --------------------------------------------------------

--
-- Structure de la table `empreinte`
--

CREATE TABLE IF NOT EXISTS `empreinte` (
  `id_empreint` int(11) NOT NULL AUTO_INCREMENT,
  `id_personnel` int(11) DEFAULT NULL,
  `template_empreinte` varchar(50) DEFAULT NULL,
  `date_enregistrement` date DEFAULT NULL,
  PRIMARY KEY (`id_empreint`),
  KEY `id_personnel` (`id_personnel`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Structure de la table `entree_stock`
--

CREATE TABLE IF NOT EXISTS `entree_stock` (
  `id_entre` int(11) NOT NULL AUTO_INCREMENT,
  `id_centre` int(11) DEFAULT NULL,
  `date` date DEFAULT NULL,
  `fournisseur` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id_entre`),
  KEY `id_centre` (`id_centre`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Structure de la table `examens_eeg`
--

CREATE TABLE IF NOT EXISTS `examens_eeg` (
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
  KEY `idx_examens_eeg_demande` (`id_demande`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=2 ;

--
-- Contenu de la table `examens_eeg`
--

INSERT INTO `examens_eeg` (`id_examens`, `id_demande`, `id_patient`, `id_consultation`, `date_examen`, `type_EEG`, `indication`, `etat_patient`, `privation_sommeil`, `duree_enregistrement`, `medicaments_avant_examen`, `prix_examen`, `resultat`, `statut`, `interpretation`, `observations`, `nom_fichier`, `chemin_fichier`, `extension_fichier`, `taille_fichier`) VALUES
(1, 1, 20, NULL, '2026-09-19', '18_cannaux', '', 'Éveil', 0, NULL, NULL, NULL, NULL, 'Terminé', NULL, NULL, NULL, NULL, NULL, NULL);

-- --------------------------------------------------------

--
-- Structure de la table `facture`
--

CREATE TABLE IF NOT EXISTS `facture` (
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
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=2 ;

--
-- Contenu de la table `facture`
--

INSERT INTO `facture` (`id_facture`, `id_patient`, `id_consultation`, `id_centre`, `type_facture`, `date_facture`, `montant_total`, `montant_paye`, `reste`, `statut`) VALUES
(1, 20, NULL, 1, 'Ambulatoire', '2026-09-19', '45.00', '25.00', '20.00', 'Partiellement payé');

-- --------------------------------------------------------

--
-- Structure de la table `fournisseur`
--

CREATE TABLE IF NOT EXISTS `fournisseur` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nom` varchar(150) NOT NULL,
  `telephone` varchar(50) DEFAULT NULL,
  `adresse` varchar(255) DEFAULT NULL,
  `actif` tinyint(1) NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Structure de la table `historique_sejour`
--

CREATE TABLE IF NOT EXISTS `historique_sejour` (
  `id_historique` int(11) NOT NULL AUTO_INCREMENT,
  `id_hospitalisation` int(11) DEFAULT NULL,
  `evenement` text,
  `date_evenement` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id_historique`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=11 ;

--
-- Contenu de la table `historique_sejour`
--

INSERT INTO `historique_sejour` (`id_historique`, `id_hospitalisation`, `evenement`, `date_evenement`) VALUES
(1, 2, 'Patient : Kasereka Kuduma Joel hospitalisé', '2026-06-19 08:28:13'),
(2, 0, 'Prescription ajoutée par Dr : KABAMBA MWILU Jean : Carbamazepine, Amitriptyline', '2026-07-03 14:39:56'),
(3, 3, 'Patient : Bisimwa Lusenge Eric hospitalisé', '2026-07-09 07:48:48'),
(4, 3, 'Patient affecté à la chambre 90', '2026-07-09 07:49:30'),
(5, 1, 'Patient : Muhindo Kalungero John hospitalisé', '2026-07-09 08:40:20'),
(6, 1, 'Patient affecté à la chambre 706', '2026-07-09 08:41:07'),
(7, 1, 'Patient : Kambere Kamuha Kawaki hospitalisé', '2026-07-13 12:37:14'),
(8, 1, 'Patient affecté à la chambre 706', '2026-07-13 12:37:52'),
(9, 2, 'Patient : Kambere Kamuha Kawaki hospitalisé', '2026-07-13 13:08:16'),
(10, 2, 'Patient affecté à la chambre 90', '2026-07-13 15:10:07');

-- --------------------------------------------------------

--
-- Structure de la table `horaire`
--

CREATE TABLE IF NOT EXISTS `horaire` (
  `id_horaire` int(11) NOT NULL AUTO_INCREMENT,
  `heure_entree_normal` time DEFAULT NULL,
  `heure_sortie_normal` time DEFAULT NULL,
  `jour_travail` varchar(50) DEFAULT NULL,
  `id_personnel` int(11) NOT NULL,
  PRIMARY KEY (`id_horaire`),
  UNIQUE KEY `unique_personnel_jour` (`id_personnel`,`jour_travail`),
  KEY `id_personnel` (`id_personnel`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=2 ;

--
-- Contenu de la table `horaire`
--

INSERT INTO `horaire` (`id_horaire`, `heure_entree_normal`, `heure_sortie_normal`, `jour_travail`, `id_personnel`) VALUES
(1, '16:21:45', '16:21:45', 'Samedi', 8);

-- --------------------------------------------------------

--
-- Structure de la table `hospitalisation`
--

CREATE TABLE IF NOT EXISTS `hospitalisation` (
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
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=2 ;

--
-- Contenu de la table `hospitalisation`
--

INSERT INTO `hospitalisation` (`id_hospitalisation`, `id_patient`, `id_centre`, `id_service`, `id_consultation`, `date_entree`, `date_sortie`, `motif`, `etat`) VALUES
(1, 20, 1, 1, 1, '2026-09-19', NULL, 'Hospitalisation de test', 'Hospitalisé');

-- --------------------------------------------------------

--
-- Structure de la table `inventaire`
--

CREATE TABLE IF NOT EXISTS `inventaire` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `date_debut` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `date_fin` datetime DEFAULT NULL,
  `responsable_id` int(11) NOT NULL,
  `type` varchar(30) NOT NULL DEFAULT 'COMPLET',
  `statut` varchar(30) NOT NULL DEFAULT 'EN_COURS',
  `observation` text,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=6 ;

--
-- Contenu de la table `inventaire`
--

INSERT INTO `inventaire` (`id`, `date_debut`, `date_fin`, `responsable_id`, `type`, `statut`, `observation`) VALUES
(1, '2026-09-02 13:00:05', '2026-09-02 17:05:20', 1, 'COMPLET', 'TERMINE', ''),
(2, '2026-09-02 15:05:16', NULL, 1, 'COMPLET', 'EN_COURS', ''),
(3, '2026-09-02 15:06:43', NULL, 1, 'COMPLET', 'EN_COURS', 'Trop d''écart'),
(4, '2026-09-02 17:16:50', '2026-09-02 17:18:30', 1, 'COMPLET', 'TERMINE', ''),
(5, '2026-09-02 17:22:51', '2026-09-02 17:23:01', 1, 'COMPLET', 'TERMINE', '');

-- --------------------------------------------------------

--
-- Structure de la table `inventaire_ligne`
--

CREATE TABLE IF NOT EXISTS `inventaire_ligne` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `inventaire_id` int(11) NOT NULL,
  `lot_id` int(11) NOT NULL,
  `quantite_systeme` int(11) NOT NULL,
  `quantite_comptee` int(11) NOT NULL,
  `ecart` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `inventaire_id` (`inventaire_id`),
  KEY `lot_id` (`lot_id`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=31 ;

--
-- Contenu de la table `inventaire_ligne`
--

INSERT INTO `inventaire_ligne` (`id`, `inventaire_id`, `lot_id`, `quantite_systeme`, `quantite_comptee`, `ecart`) VALUES
(1, 1, 7, 54, 50, -4),
(2, 1, 2, 23, 25, 2),
(3, 1, 3, 3, 3, 0),
(4, 1, 6, 3, 3, 0),
(5, 1, 5, 5, 5, 0),
(6, 1, 4, 8, 8, 0),
(7, 2, 7, 54, 44, -10),
(8, 2, 2, 23, 65, 42),
(9, 2, 3, 3, 23, 20),
(10, 2, 6, 3, 2, -1),
(11, 2, 5, 5, 34, 29),
(12, 2, 4, 8, 5, -3),
(13, 3, 7, 54, 44, -10),
(14, 3, 2, 23, 65, 42),
(15, 3, 3, 3, 23, 20),
(16, 3, 6, 3, 2, -1),
(17, 3, 5, 5, 34, 29),
(18, 3, 4, 8, 5, -3),
(19, 4, 7, 50, 60, 10),
(20, 4, 2, 25, 32, 7),
(21, 4, 3, 3, 21, 18),
(22, 4, 6, 3, 2, -1),
(23, 4, 5, 5, 5, 0),
(24, 4, 4, 8, 9, 1),
(25, 5, 7, 60, 70, 10),
(26, 5, 2, 32, 12, -20),
(27, 5, 3, 21, 24, 3),
(28, 5, 6, 2, 20, 18),
(29, 5, 5, 5, 7, 2),
(30, 5, 4, 9, 8, -1);

-- --------------------------------------------------------

--
-- Structure de la table `livre_caisse`
--

CREATE TABLE IF NOT EXISTS `livre_caisse` (
  `date` datetime DEFAULT CURRENT_TIMESTAMP,
  `recette` decimal(10,2) DEFAULT NULL,
  `depasse` decimal(10,2) DEFAULT NULL,
  `solde` decimal(10,2) DEFAULT '0.00',
  `provenance` enum('EEG','GENERALE') DEFAULT NULL,
  `description` varchar(200) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Structure de la table `logs`
--

CREATE TABLE IF NOT EXISTS `logs` (
  `id_logs` int(11) NOT NULL AUTO_INCREMENT,
  `id_utilisateur` int(11) DEFAULT NULL,
  `action` varchar(255) DEFAULT NULL,
  `date_action` date DEFAULT NULL,
  `description` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id_logs`),
  KEY `id_utilisateur` (`id_utilisateur`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Structure de la table `lot_medicament`
--

CREATE TABLE IF NOT EXISTS `lot_medicament` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `medicament_id` int(11) NOT NULL,
  `numero_lot` varchar(100) NOT NULL,
  `date_expiration` date NOT NULL,
  `quantite` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  UNIQUE KEY `medicament_id` (`medicament_id`,`numero_lot`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=8 ;

--
-- Contenu de la table `lot_medicament`
--

INSERT INTO `lot_medicament` (`id`, `medicament_id`, `numero_lot`, `date_expiration`, `quantite`) VALUES
(1, 36, 'REC2342', '2027-09-01', 12),
(2, 24, 'LOT-23SDF', '2027-09-01', 12),
(3, 24, '98SDF', '2027-09-01', 24),
(4, 46, '34FDSF', '2027-09-01', 8),
(5, 4, '32DFD', '2027-09-01', 7),
(6, 4, '334dfd', '2027-09-01', 20),
(7, 1, '23EE', '2027-09-01', 50);

-- --------------------------------------------------------

--
-- Structure de la table `medicament`
--

CREATE TABLE IF NOT EXISTS `medicament` (
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
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=55 ;

--
-- Contenu de la table `medicament`
--

INSERT INTO `medicament` (`id`, `nom`, `dosage`, `FORME`, `seuil_minimum`, `actif`, `categorie_id`, `prix_achat`, `prix_vente`, `unite_gestion_id`, `unite_gestion`) VALUES
(1, 'Antiramide', NULL, NULL, 0, 1, 2, '0.00', '0.00', 2, NULL),
(2, 'Ant', NULL, NULL, 0, 1, 2, '0.00', '0.00', 2, NULL),
(3, 'Diazepan', NULL, NULL, 0, 0, 22, '0.00', '0.00', 22, NULL),
(4, 'Autre', NULL, NULL, 4, 1, 8, '2.00', '2.00', 8, NULL),
(5, 'Aspirine', NULL, NULL, 20, 1, 4, '0.00', '0.00', 4, NULL),
(6, 'Décaris', NULL, NULL, 85, 1, 3, '20.00', '20.00', 3, NULL),
(7, 'zerzerzer', NULL, NULL, 85, 0, 2, '0.00', '0.00', 2, NULL),
(8, 'ZARA', NULL, NULL, 8, 1, 2, '0.00', '0.00', 2, NULL),
(9, 'Kibabe', NULL, NULL, 0, 0, 23, '0.00', '0.00', 23, NULL),
(10, 'Paracetamol', '500 mg', 'Comprimé', 0, 1, 1, NULL, NULL, 1, NULL),
(11, 'Ibuprofène', '400 mg', 'Comprimé', 0, 1, 2, NULL, NULL, 1, NULL),
(12, 'Amoxicilline', '500 mg', 'Gélule', 0, 1, 3, NULL, NULL, 1, NULL),
(13, 'Metronidazole', '500 mg', 'Comprimé', 0, 1, 3, NULL, NULL, 1, NULL),
(14, 'Oméprazole', '20 mg', 'Gélule', 0, 1, 4, NULL, NULL, 1, NULL),
(15, 'Diclofénac', '50 mg', 'Comprimé', 0, 1, 2, NULL, NULL, 1, NULL),
(16, 'Ceftriaxone', '1 g', 'Injection', 0, 1, 3, NULL, NULL, 2, NULL),
(17, 'Sirop Paracetamol', '120 mg/5 ml', 'Sirop', 0, 1, 1, NULL, NULL, 3, NULL),
(18, 'Vitamine C', '500 mg', 'Comprimé', 0, 1, 5, NULL, NULL, 1, NULL),
(19, 'Loratadine', '10 mg', 'Comprimé', 0, 1, 6, NULL, NULL, 1, NULL),
(20, 'Salbutamol', '100 µg/dose', 'Inhalateur', 0, 1, 7, NULL, NULL, 4, NULL),
(21, 'Hydrocortisone', '100 mg', 'Injection', 0, 1, 8, NULL, NULL, 2, NULL),
(22, 'Fer', '200 mg', 'Comprimé', 0, 1, 5, NULL, NULL, 1, NULL),
(23, 'Azithromycine', '500 mg', 'Comprimé', 0, 1, 3, NULL, NULL, 1, NULL),
(24, 'Aspirine', '100 mg', 'Comprimé', 0, 1, 2, NULL, NULL, 1, NULL),
(25, 'Amoxicilline + Acide clavulanique', '1 g', 'Comprimé', 0, 1, 3, NULL, NULL, 1, NULL),
(26, 'Ciprofloxacine', '500 mg', 'Comprimé', 0, 1, 3, NULL, NULL, 1, NULL),
(27, 'Doxycycline', '100 mg', 'Gélule', 0, 1, 3, NULL, NULL, 1, NULL),
(28, 'Clindamycine', '300 mg', 'Gélule', 0, 1, 3, NULL, NULL, 1, NULL),
(29, 'Gentamicine', '80 mg/2 ml', 'Injection', 0, 1, 3, NULL, NULL, 2, NULL),
(30, 'Paracetamol', '1 g', 'Comprimé', 0, 1, 1, NULL, NULL, 1, NULL),
(31, 'Paracetamol', '100 mg/ml', 'Solution buvable', 0, 1, 1, NULL, NULL, 3, NULL),
(32, 'Naproxène', '500 mg', 'Comprimé', 0, 1, 2, NULL, NULL, 1, NULL),
(33, 'Kétoprofène', '100 mg', 'Gélule', 0, 1, 2, NULL, NULL, 1, NULL),
(34, 'Tramadol', '50 mg', 'Gélule', 0, 1, 9, NULL, NULL, 1, NULL),
(35, 'Morphine', '10 mg/ml', 'Injection', 0, 1, 9, NULL, NULL, 2, NULL),
(36, 'Amlodipine', '5 mg', 'Comprimé', 0, 0, 10, NULL, NULL, 1, NULL),
(37, 'Losartan', '50 mg', 'Comprimé', 0, 1, 10, NULL, NULL, 1, NULL),
(38, 'Captopril', '25 mg', 'Comprimé', 0, 1, 10, NULL, NULL, 1, NULL),
(39, 'Furosémide', '40 mg', 'Comprimé', 0, 1, 10, NULL, NULL, 1, NULL),
(40, 'Metformine', '500 mg', 'Comprimé', 0, 1, 11, NULL, NULL, 1, NULL),
(41, 'Glibenclamide', '5 mg', 'Comprimé', 0, 1, 11, NULL, NULL, 1, NULL),
(42, 'Insuline humaine', '100 UI/ml', 'Injection', 0, 1, 11, NULL, NULL, 2, NULL),
(43, 'Salbutamol', '2 mg/5 ml', 'Sirop', 8, 1, 7, '0.00', '0.00', 7, NULL),
(44, 'Budesonide', '200 µg/dose', 'Inhalateur', 0, 1, 7, NULL, NULL, 4, NULL),
(45, 'Cetirizine', '10 mg', 'Comprimé', 0, 1, 5, '16.00', '16.00', 5, NULL),
(46, 'Chlorphenamine', '4 mg', 'Comprimé', 0, 1, 6, NULL, NULL, 1, NULL),
(47, 'Prednisolone', '20 mg', 'Comprimé', 0, 1, 8, NULL, NULL, 1, NULL),
(48, 'Dexamethasone e', '4 mg/ml', 'Injection', 0, 0, 8, '0.00', '0.00', 8, NULL),
(49, 'Oméprazole', '40 mg', 'Gélule', 0, 1, 4, NULL, NULL, 1, NULL),
(50, 'Pantoprazole', '40 mg', 'Comprimé', 0, 1, 4, NULL, NULL, 1, NULL),
(51, 'Aluminium hydroxide', '500 mg', 'Comprimé', 0, 0, 4, NULL, NULL, 1, NULL),
(52, 'Fer + Acide folique', '200 mg + 400 µg', 'Comprimé', 0, 1, 5, NULL, NULL, 1, NULL),
(53, 'Acide folique', '5 mg', 'Comprimé', 0, 0, 5, NULL, NULL, 1, NULL),
(54, 'Vitamine B12', '1000 µg', 'Comprimé', 0, 1, 5, NULL, NULL, 1, NULL);

-- --------------------------------------------------------

--
-- Structure de la table `medicament_categorie`
--

CREATE TABLE IF NOT EXISTS `medicament_categorie` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nom` varchar(100) NOT NULL,
  `couleur` varchar(20) NOT NULL,
  `actif` tinyint(1) DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=24 ;

--
-- Contenu de la table `medicament_categorie`
--

INSERT INTO `medicament_categorie` (`id`, `nom`, `couleur`, `actif`) VALUES
(1, 'Antipsychotique', '#9B59B6', 1),
(2, 'Antidépresseur', '#3498DB', 1),
(3, 'Anxiolytique', '#2ECC71', 1),
(4, 'Anticonvulsivant', '#E67E22', 1),
(5, 'Hypnotique', '#1ABC9C', 1),
(6, 'Thymorégulateur', '#E74C3C', 1),
(7, 'Correcteur', '#F1C40F', 1),
(8, 'Antalgique', '#95A5A6', 1),
(9, 'Antibiotique', '#16A085', 1),
(10, 'Autre', '#7F8C8D', 1),
(11, 'Bichubichu', '#20FD31', 1),
(12, 'xyz', '#1E90FF', 1),
(13, 'xyz', '#1E90FF', 1),
(14, 'rfhdfdgh', '#C744D9', 1),
(15, 'zersf', '#1E90FF', 1),
(16, 'sdfzaerdsf', '#1E90FF', 1),
(17, 'sdfsgsdf', '#BBFF1E', 1),
(18, 'rrrrrrrrrrrrrrrrrrrrrrrrr', '#1E90FF', 1),
(19, 'fdcfh', '#1E90FF', 1),
(20, 'zzzzzzzzzzzzzzzzzzzz', '#7B7EA2', 1),
(21, '&&&&&&', '#1E90FF', 1),
(22, 'oooooooooooooooo', '#E13C7A', 1),
(23, 'MyCategory', '#FF8811', 1);

-- --------------------------------------------------------

--
-- Structure de la table `mouvement_stock`
--

CREATE TABLE IF NOT EXISTS `mouvement_stock` (
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
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=21 ;

--
-- Contenu de la table `mouvement_stock`
--

INSERT INTO `mouvement_stock` (`id`, `lot_id`, `type`, `quantite`, `date_mouvement`, `reference`, `utilisateur_id`, `observation`) VALUES
(1, 1, 'ENTREE', 12, '2026-09-01 21:03:19', 'REC2342', NULL, 'Réception de stock'),
(2, 2, 'ENTREE', 23, '2026-09-01 21:05:29', 'LOT-23SDF', NULL, 'Réception de stock'),
(3, 3, 'ENTREE', 3, '2026-09-01 21:24:41', '98SDF', NULL, 'Réception de stock'),
(4, 4, 'ENTREE', 8, '2026-09-01 21:37:13', '34FDSF', NULL, 'Réception de stock'),
(5, 5, 'ENTREE', 5, '2026-09-01 21:42:38', '32DFD', NULL, 'Réception de stock'),
(6, 6, 'ENTREE', 3, '2026-09-01 21:43:03', '334dfd', NULL, 'Réception de stock'),
(7, 7, 'ENTREE', 54, '2026-09-01 21:47:04', '23EE', NULL, 'Réception de stock'),
(8, 7, 'AJUSTEMENT', -4, '2026-09-02 17:05:19', 'INVENTAIRE-1', NULL, 'Ajustement suite à l''inventaire #1'),
(9, 2, 'AJUSTEMENT', 2, '2026-09-02 17:05:20', 'INVENTAIRE-1', NULL, 'Ajustement suite à l''inventaire #1'),
(10, 7, 'AJUSTEMENT', 10, '2026-09-02 17:18:30', 'INVENTAIRE-4', NULL, 'Ajustement suite à l''inventaire #4'),
(11, 2, 'AJUSTEMENT', 7, '2026-09-02 17:18:30', 'INVENTAIRE-4', NULL, 'Ajustement suite à l''inventaire #4'),
(12, 3, 'AJUSTEMENT', 18, '2026-09-02 17:18:30', 'INVENTAIRE-4', NULL, 'Ajustement suite à l''inventaire #4'),
(13, 6, 'AJUSTEMENT', -1, '2026-09-02 17:18:30', 'INVENTAIRE-4', NULL, 'Ajustement suite à l''inventaire #4'),
(14, 4, 'AJUSTEMENT', 1, '2026-09-02 17:18:30', 'INVENTAIRE-4', NULL, 'Ajustement suite à l''inventaire #4'),
(15, 7, 'AJUSTEMENT', 10, '2026-09-02 17:23:01', 'INVENTAIRE-5', NULL, 'Ajustement suite à l''inventaire #5'),
(16, 2, 'AJUSTEMENT', -20, '2026-09-02 17:23:01', 'INVENTAIRE-5', NULL, 'Ajustement suite à l''inventaire #5'),
(17, 3, 'AJUSTEMENT', 3, '2026-09-02 17:23:01', 'INVENTAIRE-5', NULL, 'Ajustement suite à l''inventaire #5'),
(18, 6, 'AJUSTEMENT', 18, '2026-09-02 17:23:01', 'INVENTAIRE-5', NULL, 'Ajustement suite à l''inventaire #5'),
(19, 5, 'AJUSTEMENT', 2, '2026-09-02 17:23:01', 'INVENTAIRE-5', NULL, 'Ajustement suite à l''inventaire #5'),
(20, 4, 'AJUSTEMENT', -1, '2026-09-02 17:23:01', 'INVENTAIRE-5', NULL, 'Ajustement suite à l''inventaire #5');

-- --------------------------------------------------------

--
-- Structure de la table `paiement`
--

CREATE TABLE IF NOT EXISTS `paiement` (
  `id_paiement` int(11) NOT NULL AUTO_INCREMENT,
  `id_facture` int(11) DEFAULT NULL,
  `id_detail_facture` int(11) DEFAULT NULL,
  `date_paiement` date DEFAULT NULL,
  `montant` decimal(12,2) DEFAULT NULL,
  `reste` decimal(10,2) NOT NULL,
  `type_paiement` enum('Partiel','Complet') NOT NULL,
  PRIMARY KEY (`id_paiement`),
  KEY `id_facture` (`id_facture`),
  KEY `idx_paiement_detail` (`id_detail_facture`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=2 ;

--
-- Contenu de la table `paiement`
--

INSERT INTO `paiement` (`id_paiement`, `id_facture`, `id_detail_facture`, `date_paiement`, `montant`, `reste`, `type_paiement`) VALUES
(1, 1, 1, '2026-09-19', '25.00', '0.00', 'Complet');

-- --------------------------------------------------------

--
-- Structure de la table `paiement_eeg`
--

CREATE TABLE IF NOT EXISTS `paiement_eeg` (
  `id_paiement_eeg` int(11) NOT NULL AUTO_INCREMENT,
  `id_examen` int(11) DEFAULT NULL,
  `montant_eeg` decimal(12,2) DEFAULT NULL,
  `date_paiement` date DEFAULT NULL,
  `mode_paiement` enum('Cash','Paiement mobile') DEFAULT NULL,
  PRIMARY KEY (`id_paiement_eeg`),
  KEY `id_examen` (`id_examen`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Structure de la table `patients`
--

CREATE TABLE IF NOT EXISTS `patients` (
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
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=21 ;

--
-- Contenu de la table `patients`
--

INSERT INTO `patients` (`id_patient`, `numero_fiche`, `nom`, `post_nom`, `prenom`, `sexe`, `date_naissance`, `telephone`, `adresse`, `date_creation`, `id_centre`, `photo`, `nom_garde`, `telephone_garde`) VALUES
(2, 'CEP-001', 'Kasereka', 'Mulamo', 'Mafungula', 'Homme', '1994-06-09', '+243 245 985 633', 'Kyambuli', '2026-04-09', 1, NULL, NULL, NULL),
(3, 'CEP-003', 'Kasereka', 'Mukandala', 'Jean', 'Homme', '1999-06-25', '0947856321', 'Butembo', '2026-04-09', 1, NULL, NULL, NULL),
(4, 'CEP-004', 'kakule', 'Mughanda', 'Jean-louis', 'Homme', '1995-07-13', '+243 254 789 545 ', 'Avenue du centre', '2026-04-22', 1, NULL, NULL, NULL),
(5, 'CEP-005', 'kasereka', 'mafungula', 'joel', 'Homme', '1994-06-15', '+243 895 745 526', 'Vukula', '2026-05-20', 1, NULL, NULL, NULL),
(6, 'CEP-006', 'Mukeba', 'Kalume', 'Jean', 'Masculin', '1998-05-14', '099112233', 'Goma Katindo', '2026-05-28', 1, NULL, NULL, NULL),
(7, 'CEP-007', 'Kasereka', 'Bahati', 'Aline', 'Feminin', '2001-03-20', '097445566', 'Goma Himbi', '2026-05-28', 1, NULL, NULL, NULL),
(8, 'CEP-008', 'Mateso', 'Kambale', 'Patrick', 'Masculin', '1995-11-08', '081223344', 'Goma Majengo', '2026-05-28', 1, NULL, NULL, NULL),
(9, 'CEP-009', 'Safari', 'Mukwege', 'Grâce', 'Feminin', '2003-07-17', '082334455', 'Goma Ndosho', '2026-05-28', 1, NULL, NULL, NULL),
(10, 'CEP-0010', 'Bisimwa', 'Lusenge', 'Eric', 'Masculin', '1990-01-25', '099556677', 'Goma Keshero', '2026-05-28', 1, NULL, NULL, NULL),
(11, 'CEP-0011', 'Uwimana', 'Nadine', 'Chantal', 'Feminin', '1999-09-12', '081998877', 'Goma Katoyi', '2026-05-28', 1, NULL, NULL, NULL),
(12, 'CEP-0012', 'Kavira', 'Mumbere', 'Daniel', 'Masculin', '1997-12-30', '082887766', 'Goma Virunga', '2026-05-28', 1, NULL, NULL, NULL),
(13, 'CEP-0013', 'Niyonsaba', 'Claude', 'Sandrine', 'Feminin', '2002-04-11', '097776655', 'Goma Lac Vert', '2026-05-28', 1, NULL, NULL, NULL),
(14, 'CEP-0014', 'Mambene', 'Masika', 'Joël', 'Masculin', '1994-08-09', '099665544', 'Goma Mugunga', '2026-05-28', 1, NULL, NULL, NULL),
(15, 'CEP-0015', 'Kamala', 'Bahwere', 'Esther', 'Feminin', '2000-06-21', '081554433', 'Goma Kyeshero', '2026-05-28', 1, NULL, NULL, NULL),
(16, 'CEP-016', 'Kasereka', 'Kuduma', 'Joel', 'Homme', '1999-06-08', '09845345434', 'Vichai', '2026-06-19', 1, NULL, NULL, NULL),
(17, 'CEP-017', 'Mumbere', 'Kamuha', 'Patrick', 'Homme', '1994-06-25', '093464345', 'Vulamba', '2026-06-24', 1, NULL, NULL, NULL),
(18, 'CEP-018', 'Muhindo', 'Kalungero', 'John', 'Homme', '2000-02-15', '0987634234', 'Kitulu/ mukuna', '2026-06-24', 1, NULL, NULL, NULL),
(19, 'CEP-019', 'Kambere', 'Kamuha', 'Kawaki', 'Homme', '1994-06-25', '098768734', 'Vungi', '2026-07-06', 1, NULL, NULL, NULL),
(20, 'CEP-020', 'Masika', 'Musema trop', 'Musema', 'Femme', '1995-07-14', '+243 789 562 365', 'Ngolwe', '2026-08-28', 1, NULL, 'Maman Jeanne', ' +243 785 365 214');

-- --------------------------------------------------------

--
-- Structure de la table `personnels`
--

CREATE TABLE IF NOT EXISTS `personnels` (
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
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=10 ;

--
-- Contenu de la table `personnels`
--

INSERT INTO `personnels` (`id_personnel`, `id_centre`, `nom`, `post_nom`, `prenom`, `sexe`, `date_naissance`, `date_embauche`, `fonction`, `telephone`, `adresse`, `salaire_base`, `actif`, `situation_familliale`) VALUES
(1, 1, 'KABAMBA', 'MWILU', 'Jean', 'M', '1985-03-12', '2020-01-15', 'Psychiatre', '+243 989 567 434', 'Goma', '1200.00', NULL, NULL),
(2, 1, 'MUKENDI', 'LUBOYA', 'Aline', 'F', '1990-07-22', '2021-05-10', 'Psychologue', '0991000002', 'Goma', '900.00', NULL, NULL),
(3, 1, 'KALONJI', 'MUKUNA', 'David', 'M', '1988-11-05', '2019-09-01', 'Psychiatre', '0991000003', 'Goma', '600.00', NULL, NULL),
(4, 1, 'NSIMBA', 'KABUYA', 'Sarah', 'Féminin', '1992-02-18', '2022-03-20', 'Ass. Sociale', '0991000004', 'Goma', '700.00', NULL, NULL),
(5, 1, 'MBUYI', 'TSHIBANGU', 'Patrick', 'Masculin', '1980-06-30', '2018-07-12', 'Généraliste', '0991000005', 'Goma', '1100.00', NULL, NULL),
(6, 1, 'KASONGO', 'MULUMBA', 'Grace', 'F', '1995-09-14', '2023-01-05', 'Psychologue', '0991000006', 'Goma', '850.00', NULL, NULL),
(7, 1, 'ILUNGA', 'KABEYA', 'Michel', 'M', '1983-12-01', '2017-11-23', 'Laboratoire', '0991000007', 'Goma', '650.00', NULL, NULL),
(8, 1, 'KABONGO', 'MWANA', 'Chantal', 'F', '1991-04-09', '2020-06-18', 'Infirmière', '0991000008', 'Goma', '580.00', NULL, NULL),
(9, 1, 'MULANGA', 'KATUMBA', 'Eric', 'M', '1987-08-25', '2019-02-14', 'Psychologue', '0991000009', 'Goma', '500.00', NULL, NULL);

-- --------------------------------------------------------

--
-- Structure de la table `prescription`
--

CREATE TABLE IF NOT EXISTS `prescription` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `patient_id` int(11) NOT NULL,
  `medecin_id` int(11) NOT NULL,
  `date_prescription` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `statut` varchar(30) NOT NULL DEFAULT 'ACTIVE',
  `observation` text,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=8 ;

--
-- Contenu de la table `prescription`
--

INSERT INTO `prescription` (`id`, `patient_id`, `medecin_id`, `date_prescription`, `statut`, `observation`) VALUES
(1, 20, 1, '2026-09-19 10:55:12', 'ACTIVE', 'Prescription de test - médicaments ambulatoires'),
(2, 20, 1, '2026-09-19 10:55:18', 'ACTIVE', 'Prescription de test numéro 2'),
(3, 20, 1, '2026-09-19 10:55:26', 'DELIVREE', 'Prescription déjà délivrée - test'),
(4, 20, 1, '2026-09-19 10:55:31', 'ACTIVE', 'Test prescription patient 20'),
(5, 21, 1, '2026-09-19 10:55:31', 'ACTIVE', 'Test prescription patient 21'),
(6, 22, 1, '2026-09-19 10:55:31', 'ACTIVE', 'Test prescription patient 22'),
(7, 20, 1, '2026-09-19 12:40:29', 'ACTIVE', 'Prescription de test pour la pharmacie');

-- --------------------------------------------------------

--
-- Structure de la table `prescriptions`
--

CREATE TABLE IF NOT EXISTS `prescriptions` (
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
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Structure de la table `prescription_ligne`
--

CREATE TABLE IF NOT EXISTS `prescription_ligne` (
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
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=7 ;

--
-- Contenu de la table `prescription_ligne`
--

INSERT INTO `prescription_ligne` (`id`, `prescription_id`, `medicament_id`, `dose`, `frequence`, `duree`, `quantite_prescrite`) VALUES
(1, 7, 1, '500 mg', '2 fois par jour', '5 jours', 10),
(2, 7, 2, '500 mg', '3 fois par jour', '5 jours', 15),
(3, 7, 3, '1 comprimé', '2 fois par jour', '7 jours', 14),
(4, 7, 1, '500 mg', '2 fois par jour', '5 jours', 10),
(5, 7, 2, '500 mg', '3 fois par jour', '5 jours', 15),
(6, 7, 3, '1 comprimé', '2 fois par jour', '7 jours', 14);

-- --------------------------------------------------------

--
-- Structure de la table `presences`
--

CREATE TABLE IF NOT EXISTS `presences` (
  `id_presence` int(11) NOT NULL AUTO_INCREMENT,
  `id_personnel` int(11) DEFAULT NULL,
  `date_presence` date DEFAULT NULL,
  `heure_entree` time DEFAULT NULL,
  `heure_sortie` time DEFAULT NULL,
  `statut` enum('Présent','Absent','Retard') DEFAULT NULL,
  PRIMARY KEY (`id_presence`),
  KEY `id_personnel` (`id_personnel`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=2 ;

--
-- Contenu de la table `presences`
--

INSERT INTO `presences` (`id_presence`, `id_personnel`, `date_presence`, `heure_entree`, `heure_sortie`, `statut`) VALUES
(1, 1, '2026-04-15', '13:10:23', '13:10:23', 'Présent');

-- --------------------------------------------------------

--
-- Structure de la table `prestation`
--

CREATE TABLE IF NOT EXISTS `prestation` (
  `id_prestation` int(11) NOT NULL AUTO_INCREMENT,
  `id_service` int(11) NOT NULL,
  `libelle` varchar(150) NOT NULL,
  `description` varchar(255) DEFAULT NULL,
  `unite` varchar(50) DEFAULT NULL,
  `actif` tinyint(1) NOT NULL DEFAULT '1',
  PRIMARY KEY (`id_prestation`),
  KEY `idx_prestation_service` (`id_service`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=13 ;

--
-- Contenu de la table `prestation`
--

INSERT INTO `prestation` (`id_prestation`, `id_service`, `libelle`, `description`, `unite`, `actif`) VALUES
(1, 1, 'EEG 18 canaux', 'Électroencéphalogramme 18 canaux', 'Examen', 1),
(2, 1, 'EEG 32 canaux', 'Électroencéphalogramme 32 canaux', 'Examen', 1),
(3, 2, 'Glycémie', 'Dosage de la glycémie', 'Examen', 1),
(4, 2, 'NFS', 'Numération formule sanguine', 'Examen', 1),
(5, 2, 'Test VIH', 'Dépistage du VIH', 'Examen', 1),
(6, 3, 'Consultation psychologique', 'Consultation avec un psychologue', 'Séance', 1),
(7, 3, 'Suivi psychologique', 'Séance de suivi psychologique', 'Séance', 1),
(8, 4, 'Radiographie', 'Examen radiographique', 'Examen', 1),
(9, 4, 'Échographie', 'Examen échographique', 'Examen', 1),
(10, 5, 'Consultation médicale', 'Consultation médicale générale', 'Acte', 1),
(11, 6, 'Imprimé', 'Impression d''un document', 'Unité', 1),
(12, 6, 'Certificat médical', 'Établissement d''un certificat médical', 'Unité', 1);

-- --------------------------------------------------------

--
-- Structure de la table `prime`
--

CREATE TABLE IF NOT EXISTS `prime` (
  `id_prime` int(11) NOT NULL AUTO_INCREMENT,
  `id_salaire` int(11) DEFAULT NULL,
  `date_prime` date DEFAULT NULL,
  `motif` varchar(100) DEFAULT NULL,
  `montant` decimal(12,2) DEFAULT NULL,
  PRIMARY KEY (`id_prime`),
  KEY `id_personnel` (`id_salaire`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=2 ;

--
-- Contenu de la table `prime`
--

INSERT INTO `prime` (`id_prime`, `id_salaire`, `date_prime`, `motif`, `montant`) VALUES
(1, 1, '2026-08-07', 'Personnel vaillant', '30.00');

-- --------------------------------------------------------

--
-- Structure de la table `reception_achat`
--

CREATE TABLE IF NOT EXISTS `reception_achat` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `commande_id` int(11) DEFAULT NULL,
  `fournisseur_id` int(11) NOT NULL,
  `date_reception` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `reference` varchar(100) DEFAULT NULL,
  `observation` text,
  PRIMARY KEY (`id`),
  KEY `commande_id` (`commande_id`),
  KEY `fournisseur_id` (`fournisseur_id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Structure de la table `reception_achat_ligne`
--

CREATE TABLE IF NOT EXISTS `reception_achat_ligne` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `reception_id` int(11) NOT NULL,
  `medicament_id` int(11) NOT NULL,
  `lot_id` int(11) NOT NULL,
  `quantite` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `reception_id` (`reception_id`),
  KEY `medicament_id` (`medicament_id`),
  KEY `lot_id` (`lot_id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Structure de la table `retenue`
--

CREATE TABLE IF NOT EXISTS `retenue` (
  `id_retenue` int(11) NOT NULL AUTO_INCREMENT,
  `id_salaire` int(11) DEFAULT NULL,
  `date_retenue` date DEFAULT NULL,
  `motif` varchar(50) DEFAULT NULL,
  `montant` decimal(12,2) DEFAULT NULL,
  PRIMARY KEY (`id_retenue`),
  KEY `id_personnel` (`id_salaire`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Structure de la table `salaires`
--

CREATE TABLE IF NOT EXISTS `salaires` (
  `id_salaire` int(11) NOT NULL AUTO_INCREMENT,
  `id_personnel` int(11) DEFAULT NULL,
  `mois` varchar(50) NOT NULL,
  `salaire_base` decimal(12,2) NOT NULL,
  `date_paiement` date NOT NULL,
  `statut` enum('Payé','Nom payé','En attente') NOT NULL,
  PRIMARY KEY (`id_salaire`),
  KEY `id_personnel` (`id_personnel`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=2 ;

--
-- Contenu de la table `salaires`
--

INSERT INTO `salaires` (`id_salaire`, `id_personnel`, `mois`, `salaire_base`, `date_paiement`, `statut`) VALUES
(1, 1, 'Janvier', '200.00', '2026-04-18', 'Payé');

-- --------------------------------------------------------

--
-- Structure de la table `service`
--

CREATE TABLE IF NOT EXISTS `service` (
  `id_service` int(11) NOT NULL AUTO_INCREMENT,
  `nom` varchar(150) NOT NULL,
  `description` varchar(255) DEFAULT NULL,
  `actif` tinyint(1) NOT NULL DEFAULT '1',
  PRIMARY KEY (`id_service`),
  UNIQUE KEY `uk_service_nom` (`nom`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=8 ;

--
-- Contenu de la table `service`
--

INSERT INTO `service` (`id_service`, `nom`, `description`, `actif`) VALUES
(1, 'EEG', 'Électroencéphalogramme', 1),
(2, 'Laboratoire', 'Examens de laboratoire', 1),
(3, 'Psychologie', 'Consultation et suivi psychologique', 1),
(4, 'Imagerie', 'Examens d''imagerie médicale', 1),
(5, 'Consultation', 'Service de consultation', 1),
(6, 'Autre', 'Autre services', 1),
(7, 'Service', 'La description du service', 1);

-- --------------------------------------------------------

--
-- Structure de la table `signes_vitaux`
--

CREATE TABLE IF NOT EXISTS `signes_vitaux` (
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
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=8 ;

--
-- Contenu de la table `signes_vitaux`
--

INSERT INTO `signes_vitaux` (`id_signe`, `id_patient`, `temperature`, `tension`, `frequence_cardiaque`, `poids`, `taille`, `date_prise`, `is_counsel`) VALUES
(1, 19, '35.00', '120Hmmg', '70Bpm', '55.00', '1.00', '2026-08-20 00:00:00', 1),
(2, 18, '45.00', '45', '12', '45.00', '1.00', '2026-08-21 00:00:00', 0),
(3, 19, '32.00', '120/80Hmmg', '70Bpm', '52.00', '1.00', '2026-08-28 00:00:00', 0),
(4, 20, '45.00', '522', '41', '52.00', '1.00', '2026-08-28 00:00:00', 0),
(5, 20, '23.00', '10', '34', '56.00', '1.80', '2026-09-04 00:00:00', 0),
(6, 20, '45.00', '12', '6', '23.00', '53.00', '2026-09-04 00:00:00', 0),
(7, 20, '23.00', '12', '23', '54.00', '33.00', '2026-09-04 00:00:00', 0);

-- --------------------------------------------------------

--
-- Structure de la table `soins`
--

CREATE TABLE IF NOT EXISTS `soins` (
  `id_soin` int(11) NOT NULL AUTO_INCREMENT,
  `nom_soin` varchar(25) DEFAULT NULL,
  `prix` decimal(12,2) DEFAULT NULL,
  `actif` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`id_soin`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Structure de la table `sorties_stock`
--

CREATE TABLE IF NOT EXISTS `sorties_stock` (
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
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=46 ;

--
-- Contenu de la table `sorties_stock`
--

INSERT INTO `sorties_stock` (`id_sortie`, `id_centre`, `type_sortie`, `id_patient`, `id_service`, `date_sortie`, `statut`) VALUES
(18, 1, NULL, 5, NULL, NULL, 'en attente'),
(19, 1, NULL, 15, NULL, NULL, 'en attente'),
(20, 1, '', 10, NULL, '2026-07-09', 'en attente'),
(21, 1, '', 18, NULL, '2026-07-09', 'en attente'),
(22, 1, '', 18, NULL, '2026-07-10', 'en attente'),
(23, 1, '', 19, NULL, '2026-07-10', 'en attente'),
(24, 1, '', 19, NULL, '2026-07-10', 'en attente'),
(25, 1, '', 18, NULL, '2026-07-10', 'en attente'),
(26, 1, 'ambulatoire', 19, NULL, '2026-07-10', 'en attente'),
(27, 1, 'ambulatoire', 18, NULL, '2026-07-10', 'en attente'),
(28, 1, 'ambulatoire', 18, NULL, '2026-07-10', 'en attente'),
(29, 1, 'ambulatoire', 3, NULL, '2026-07-10', 'en attente'),
(30, 1, 'ambulatoire', 19, NULL, '2026-07-10', 'en attente'),
(31, 1, 'ambulatoire', 18, NULL, '2026-07-10', 'en attente'),
(32, 1, 'ambulatoire', 19, NULL, '2026-07-10', 'en attente'),
(33, 1, 'ambulatoire', 19, NULL, '2026-07-11', 'en attente'),
(34, 1, '', 19, NULL, '2026-07-13', 'en attente'),
(35, 1, '', 19, NULL, '2026-07-13', 'en attente'),
(36, 1, '', 19, NULL, '2026-07-13', 'en attente'),
(37, 1, '', 17, NULL, '2026-07-14', 'en attente'),
(38, 1, 'ambulatoire', 17, NULL, '2026-07-14', 'en attente'),
(39, 1, 'ambulatoire', 19, NULL, '2026-07-14', 'en attente'),
(40, 1, 'ambulatoire', 19, NULL, '2026-07-18', 'en attente'),
(41, 1, 'ambulatoire', 19, NULL, '2026-07-21', 'en attente'),
(42, 1, 'ambulatoire', 19, NULL, '2026-07-31', 'en attente'),
(43, 1, 'ambulatoire', 19, NULL, '2026-08-12', 'en attente'),
(44, 1, 'ambulatoire', 19, NULL, '2026-08-20', 'en attente'),
(45, 1, 'ambulatoire', 18, NULL, '2026-08-21', 'en attente');

-- --------------------------------------------------------

--
-- Structure de la table `sortie_ph_service`
--

CREATE TABLE IF NOT EXISTS `sortie_ph_service` (
  `id_sortie` int(11) NOT NULL AUTO_INCREMENT,
  `id_centre` int(11) DEFAULT NULL,
  `id_service` int(11) DEFAULT NULL,
  `date_sortie` date DEFAULT NULL,
  PRIMARY KEY (`id_sortie`),
  KEY `id_centre` (`id_centre`),
  KEY `id_service` (`id_service`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Structure de la table `sortie_s_pa`
--

CREATE TABLE IF NOT EXISTS `sortie_s_pa` (
  `id_sortie` int(11) NOT NULL AUTO_INCREMENT,
  `id_hospitalisation` int(11) DEFAULT NULL,
  `id_service` int(11) DEFAULT NULL,
  `date_sortie` date DEFAULT NULL,
  PRIMARY KEY (`id_sortie`),
  KEY `id_hospitalisation` (`id_hospitalisation`),
  KEY `id_service` (`id_service`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Structure de la table `stock_pharmacie`
--

CREATE TABLE IF NOT EXISTS `stock_pharmacie` (
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
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=26 ;

--
-- Contenu de la table `stock_pharmacie`
--

INSERT INTO `stock_pharmacie` (`id_stock`, `id_centre`, `id_medicament`, `quantite`, `unite`, `stock_minimum`) VALUES
(1, 1, 1, 2, NULL, 0),
(2, 1, 2, 22, NULL, 0),
(3, 1, 3, 22, NULL, 0),
(4, 1, 4, 25, NULL, 0),
(8, 1, 5, 15, NULL, 0),
(9, 1, 6, 22, NULL, 0),
(10, 1, 7, 22, NULL, 0),
(11, 1, 8, 22, NULL, 0),
(12, 1, 9, 22, NULL, 0),
(13, 1, 10, 18, NULL, 0),
(14, 1, 11, 14, NULL, 0),
(15, 1, 12, 18, NULL, 0),
(16, 1, 13, 22, NULL, 0),
(17, 1, 14, 22, NULL, 0),
(18, 1, 15, 18, NULL, 0),
(19, 1, 16, 22, NULL, 0),
(21, 1, 17, 22, NULL, 0),
(22, 1, 18, 22, NULL, 0),
(23, 1, 19, 22, NULL, 0),
(24, 1, 20, 22, NULL, 0),
(25, 1, 22, 6, 'Carton', 0);

-- --------------------------------------------------------

--
-- Structure de la table `stock_service`
--

CREATE TABLE IF NOT EXISTS `stock_service` (
  `id_stock_service` int(11) NOT NULL AUTO_INCREMENT,
  `id_service` int(11) DEFAULT NULL,
  `id_medicament` int(11) DEFAULT NULL,
  `quantite` int(10) DEFAULT NULL,
  `stock_minimum` int(10) DEFAULT NULL,
  PRIMARY KEY (`id_stock_service`),
  KEY `id_service` (`id_service`),
  KEY `id_medicament` (`id_medicament`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Structure de la table `suivi_hospitalisation`
--

CREATE TABLE IF NOT EXISTS `suivi_hospitalisation` (
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
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Structure de la table `tarif_prestation`
--

CREATE TABLE IF NOT EXISTS `tarif_prestation` (
  `id_tarif` int(11) NOT NULL AUTO_INCREMENT,
  `id_prestation` int(11) NOT NULL,
  `prix` decimal(12,2) NOT NULL,
  `date_debut` date NOT NULL,
  `date_fin` date DEFAULT NULL,
  `actif` tinyint(1) NOT NULL DEFAULT '1',
  PRIMARY KEY (`id_tarif`),
  KEY `idx_tarif_prestation` (`id_prestation`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=17 ;

--
-- Contenu de la table `tarif_prestation`
--

INSERT INTO `tarif_prestation` (`id_tarif`, `id_prestation`, `prix`, `date_debut`, `date_fin`, `actif`) VALUES
(1, 1, '50.00', '2026-09-18', '2026-09-17', 0),
(2, 2, '70.00', '2026-09-18', '2026-09-17', 0),
(3, 3, '5.00', '2026-09-18', NULL, 1),
(4, 4, '10.00', '2026-09-18', NULL, 1),
(5, 5, '8.00', '2026-09-18', NULL, 1),
(6, 6, '15.00', '2026-09-18', NULL, 1),
(7, 7, '12.00', '2026-09-18', NULL, 1),
(8, 8, '20.00', '2026-09-18', NULL, 1),
(9, 9, '25.00', '2026-09-18', NULL, 1),
(10, 10, '20.00', '2026-09-18', NULL, 1),
(11, 11, '1.00', '2026-09-18', NULL, 1),
(12, 12, '5.00', '2026-09-18', '2026-09-17', 0),
(13, 1, '46.00', '2026-09-18', '2026-09-17', 0),
(14, 12, '34.00', '2026-09-18', NULL, 1),
(15, 1, '25.00', '2026-09-18', NULL, 1),
(16, 2, '30.00', '2026-09-18', NULL, 1);

-- --------------------------------------------------------

--
-- Structure de la table `tarif_service`
--

CREATE TABLE IF NOT EXISTS `tarif_service` (
  `id_tarif` int(11) NOT NULL AUTO_INCREMENT,
  `id_service` int(11) NOT NULL,
  `prix` decimal(12,2) NOT NULL,
  `actif` tinyint(1) NOT NULL DEFAULT '1',
  `date_debut` date NOT NULL,
  `date_fin` date DEFAULT NULL,
  PRIMARY KEY (`id_tarif`),
  KEY `idx_tarif_service` (`id_service`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Structure de la table `unite_gestion`
--

CREATE TABLE IF NOT EXISTS `unite_gestion` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nom` varchar(100) NOT NULL,
  `abreviation` varchar(20) DEFAULT NULL,
  `description` varchar(255) DEFAULT NULL,
  `actif` tinyint(1) NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`),
  UNIQUE KEY `nom` (`nom`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=25 ;

--
-- Contenu de la table `unite_gestion`
--

INSERT INTO `unite_gestion` (`id`, `nom`, `abreviation`, `description`, `actif`) VALUES
(1, 'Comprimé', 'cp', 'Médicament sous forme de comprimé', 1),
(2, 'Gélule', 'gél', 'Médicament sous forme de gélule', 1),
(3, 'Capsule', 'caps', 'Médicament sous forme de capsule', 1),
(4, 'Flacon', 'fl', 'Médicament conditionné dans un flacon', 1),
(5, 'Ampoule', 'amp', 'Médicament conditionné dans une ampoule', 1),
(6, 'Tube', 'tube', 'Médicament conditionné dans un tube', 1),
(7, 'Boîte', 'bte', 'Médicament conditionné dans une boîte', 1),
(8, 'Sachet', 'sach', 'Médicament conditionné dans un sachet', 1),
(9, 'Poche', 'poche', 'Médicament conditionné dans une poche', 1),
(10, 'Suppositoire', 'supp', 'Médicament sous forme de suppositoire', 1),
(11, 'Dose', 'dose', 'Médicament distribué par dose', 1),
(12, 'Unité', 'unité', 'Unité générale de gestion', 1),
(13, 'popcorn', 'ppc', 'Unité du popcorn', 1),
(14, 'Autrement', 'atr', 'Autre unité', 1),
(15, 'zero', 'zr', 'zero description', 1),
(16, 'ppp', 'p', 'Only p', 1),
(17, 'dfgsfgsdf', 'sdgsdfer', 'ssdfzr', 1),
(18, 'd', 'dtgsdftg', 'sdsdf', 1),
(19, 'sfsdf', 'sdfs', 'fsdfsdfsdf', 1),
(20, 'xxxxxxxxxxxxxxxxxxx', 'aa', 'srzsr', 1),
(21, 'qqqqqqqqqqqqqqqqqq', 'qqqqqqqqq', 'rrrrr', 1),
(22, 'wwwwwwwwwwwwwwww', NULL, NULL, 1),
(23, 'sd', 'fsdsdf', 'sdsdfsdf', 1),
(24, '&&&&&&', '&&&&&&', '&&', 1);

-- --------------------------------------------------------

--
-- Structure de la table `utilisateurs`
--

CREATE TABLE IF NOT EXISTS `utilisateurs` (
  `id_utilisateurs` int(11) NOT NULL AUTO_INCREMENT,
  `id_personnel` int(11) DEFAULT NULL,
  `username` varchar(100) DEFAULT NULL,
  `password_hash` varchar(100) DEFAULT NULL,
  `role` varchar(50) DEFAULT NULL,
  `date_creation` date DEFAULT NULL,
  `actif` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`id_utilisateurs`),
  KEY `id_personnel` (`id_personnel`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=2 ;

--
-- Contenu de la table `utilisateurs`
--

INSERT INTO `utilisateurs` (`id_utilisateurs`, `id_personnel`, `username`, `password_hash`, `role`, `date_creation`, `actif`) VALUES
(1, 1, 'user', '0000', 'Secretaire', '2026-04-21', NULL);

--
-- Contraintes pour les tables exportées
--

--
-- Contraintes pour la table `consultation`
--
ALTER TABLE `consultation`
  ADD CONSTRAINT `fk_consultation_diagnostic` FOREIGN KEY (`diagnostic_id`) REFERENCES `diagnostic` (`id`) ON DELETE SET NULL ON UPDATE CASCADE;

--
-- Contraintes pour la table `demande_service`
--
ALTER TABLE `demande_service`
  ADD CONSTRAINT `fk_demande_patient` FOREIGN KEY (`id_patient`) REFERENCES `patients` (`id_patient`) ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_demande_prestation` FOREIGN KEY (`id_prestation`) REFERENCES `prestation` (`id_prestation`),
  ADD CONSTRAINT `fk_demande_service` FOREIGN KEY (`id_service`) REFERENCES `service` (`id_service`) ON UPDATE CASCADE;

--
-- Contraintes pour la table `detail_facture`
--
ALTER TABLE `detail_facture`
  ADD CONSTRAINT `fk_detail_facture_prestation` FOREIGN KEY (`id_prestation`) REFERENCES `prestation` (`id_prestation`);

--
-- Contraintes pour la table `examens_eeg`
--
ALTER TABLE `examens_eeg`
  ADD CONSTRAINT `fk_examens_eeg_demande` FOREIGN KEY (`id_demande`) REFERENCES `demande_service` (`id_demande`) ON DELETE SET NULL ON UPDATE CASCADE;

--
-- Contraintes pour la table `paiement`
--
ALTER TABLE `paiement`
  ADD CONSTRAINT `fk_paiement_detail` FOREIGN KEY (`id_detail_facture`) REFERENCES `detail_facture` (`id_detail_facture`) ON DELETE SET NULL ON UPDATE CASCADE;

--
-- Contraintes pour la table `presences`
--
ALTER TABLE `presences`
  ADD CONSTRAINT `fk_presence_personnel` FOREIGN KEY (`id_personnel`) REFERENCES `personnels` (`id_personnel`);

--
-- Contraintes pour la table `tarif_service`
--
ALTER TABLE `tarif_service`
  ADD CONSTRAINT `fk_tarif_service` FOREIGN KEY (`id_service`) REFERENCES `service` (`id_service`) ON UPDATE CASCADE;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
