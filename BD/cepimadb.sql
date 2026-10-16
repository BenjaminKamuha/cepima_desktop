-- phpMyAdmin SQL Dump
-- version 4.1.14
-- http://www.phpmyadmin.net
--
-- Client :  127.0.0.1
-- Généré le :  Sam 12 Décembre 2026 à 03:58
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
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Structure de la table `antecedents`
--

CREATE TABLE IF NOT EXISTS `antecedents` (
  `id_antecedent` int(11) NOT NULL AUTO_INCREMENT,
  `id_patient` int(11) NOT NULL,
  `id_consultation` int(11) DEFAULT NULL,
  `medical_hta` tinyint(1) NOT NULL DEFAULT '0',
  `medical_diabete` tinyint(1) NOT NULL DEFAULT '0',
  `medical_epilepsie` tinyint(1) NOT NULL DEFAULT '0',
  `medical_traumatisme_cranien` tinyint(1) NOT NULL DEFAULT '0',
  `medical_avc` tinyint(1) NOT NULL DEFAULT '0',
  `medical_vih` tinyint(1) NOT NULL DEFAULT '0',
  `medical_tuberculose` tinyint(1) NOT NULL DEFAULT '0',
  `medical_autre` text,
  `psy_depression` tinyint(1) NOT NULL DEFAULT '0',
  `psy_tentative_suicide` tinyint(1) NOT NULL DEFAULT '0',
  `psy_hospitalisation` tinyint(1) NOT NULL DEFAULT '0',
  `psy_trouble_bipolaire` tinyint(1) NOT NULL DEFAULT '0',
  `psy_schizophrenie` tinyint(1) NOT NULL DEFAULT '0',
  `psy_autre` text,
  `hereditaire_hta` tinyint(1) NOT NULL DEFAULT '0',
  `hereditaire_diabete` tinyint(1) NOT NULL DEFAULT '0',
  `hereditaire_epilepsie` tinyint(1) NOT NULL DEFAULT '0',
  `hereditaire_avc` tinyint(1) NOT NULL DEFAULT '0',
  `hereditaire_tuberculose` tinyint(1) NOT NULL DEFAULT '0',
  `hereditaire_vih` tinyint(1) NOT NULL DEFAULT '0',
  `hereditaire_autre` text,
  `familiaux` text,
  `collateraux` text,
  `chirurgicaux` text,
  `allergies` text,
  `habitudes_toxiques` text,
  `toxique_alcool` tinyint(1) NOT NULL DEFAULT '0',
  `toxique_tabac` tinyint(1) NOT NULL DEFAULT '0',
  `toxique_cannabis` tinyint(1) NOT NULL DEFAULT '0',
  `toxique_drogues` tinyint(1) NOT NULL DEFAULT '0',
  `toxique_autres` text,
  `date_enregistrement` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id_antecedent`),
  KEY `idx_antecedents_patient` (`id_patient`),
  KEY `idx_antecedents_consultation` (`id_consultation`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 AUTO_INCREMENT=1 ;

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
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Structure de la table `bon_sortie`
--

CREATE TABLE IF NOT EXISTS `bon_sortie` (
  `id_bon` int(11) NOT NULL AUTO_INCREMENT,
  `nom_resp` varchar(50) DEFAULT NULL,
  `signature_donneur` varchar(100) DEFAULT NULL,
  `montant` decimal(10,2) DEFAULT NULL,
  `date` datetime DEFAULT CURRENT_TIMESTAMP,
  `statut` enum('En attente','Validé','Annulé') DEFAULT 'En attente',
  PRIMARY KEY (`id_bon`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=2 ;

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
(1, 'CEPIMA/UKANDILAMA', 'Butembo,Av Talia', '+243 567 898 456', 'cepima@gmail.com', '2026-12-11', 1);

-- --------------------------------------------------------

--
-- Structure de la table `chambre`
--

CREATE TABLE IF NOT EXISTS `chambre` (
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
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

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
  `id_demande` int(11) DEFAULT NULL,
  `patient_id` int(11) NOT NULL,
  `type_consultation` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `motif` text COLLATE utf8mb4_unicode_ci,
  `historique_maladie` text COLLATE utf8mb4_unicode_ci,
  `diagnostic` text COLLATE utf8mb4_unicode_ci,
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
  KEY `idx_consultation_demande` (`id_demande`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci AUTO_INCREMENT=5 ;

--
-- Contenu de la table `consultation`
--

INSERT INTO `consultation` (`id`, `id_demande`, `patient_id`, `type_consultation`, `motif`, `historique_maladie`, `diagnostic`, `symptomes_depuis`, `symptome_insomnie`, `symptome_anxiete`, `symptome_agitation`, `symptome_tristesse`, `symptome_idees_delirantes`, `symptome_hallucinations`, `symptome_perte_memoire`, `symptome_autre`, `evolution_symptomes`, `facteurs_declenchants`, `risque_suicidaire`, `risque_agression`, `risque_fugue`, `autres_risques`, `diagnostic_id`, `prochaine_consultation`, `date_consultation`, `utilisateur_id`) VALUES
(4, 16, 21, '', '', NULL, NULL, '2026-10-02', 0, 0, 0, 0, 0, 0, 0, '', '', '', NULL, NULL, NULL, '', 28, '2026-10-02', '2026-10-02 15:47:49', 0);

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
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=18 ;

--
-- Contenu de la table `demande_service`
--

INSERT INTO `demande_service` (`id_demande`, `id_patient`, `id_service`, `id_prestation`, `id_personnel`, `date_demande`, `priorite`, `motif`, `statut`, `observation`) VALUES
(8, 21, 9, 15, NULL, '2026-10-02 13:05:19', 'Normale', 'ddjd', 'Terminée', 'ndndnd'),
(9, 21, 9, 15, NULL, '2026-10-02 13:20:47', 'Normale', 'pas de motif', 'Terminée', NULL),
(10, 21, 9, 15, NULL, '2026-10-02 13:59:11', 'Normale', 'n, b:;,', 'Terminée', NULL),
(11, 22, 9, 15, NULL, '2026-10-02 14:04:31', 'Normale', 'SAWA', 'Terminée', NULL),
(12, 21, 9, 15, NULL, '2026-10-02 14:18:20', 'Normale', '!lkn!:', 'Terminée', NULL),
(13, 21, 9, 15, NULL, '2026-10-02 14:20:41', 'Normale', ':kjbvlkjlkj', 'En cours', NULL),
(14, 22, 9, 15, NULL, '2026-10-02 14:41:35', 'Normale', 'hgfjhj', 'En cours', NULL),
(15, 23, 9, 15, NULL, '2026-10-02 14:48:45', 'Normale', 'JHGF', 'Terminée', NULL),
(16, 21, 10, 16, NULL, '2026-10-02 15:11:08', 'Normale', 'zsdf', 'Terminée', NULL),
(17, 23, 10, 16, NULL, '2026-10-02 16:01:57', 'Normale', '!m:;', 'Demandée', NULL);

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
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=17 ;

--
-- Contenu de la table `detail_facture`
--

INSERT INTO `detail_facture` (`id_detail_facture`, `id_facture`, `id_prestation`, `description`, `quantite`, `prix_unitaire`, `montant`) VALUES
(9, 5, 15, 'EEG', 1, '17.00', '17.00'),
(10, 6, 15, 'EEG', 1, '17.00', '17.00'),
(11, 7, 15, 'EEG', 1, '17.00', '17.00'),
(12, 8, 15, 'EEG', 1, '17.00', '17.00'),
(13, 9, 15, 'EEG', 1, '17.00', '17.00'),
(14, 10, 15, 'EEG', 1, '17.00', '17.00'),
(15, 11, 16, 'Consultation', 1, '5.00', '5.00'),
(16, 12, 16, 'Consultation', 1, '5.00', '5.00');

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
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

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
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=29 ;

--
-- Contenu de la table `diagnostic`
--

INSERT INTO `diagnostic` (`id`, `code`, `libelle`, `description`, `actif`) VALUES
(28, NULL, '', '', 1);

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
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=4 ;

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
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=2 ;

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
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=8 ;

--
-- Contenu de la table `examens_eeg`
--

INSERT INTO `examens_eeg` (`id_examens`, `id_demande`, `id_patient`, `id_consultation`, `date_examen`, `type_EEG`, `indication`, `etat_patient`, `privation_sommeil`, `duree_enregistrement`, `medicaments_avant_examen`, `prix_examen`, `resultat`, `statut`, `interpretation`, `observations`, `nom_fichier`, `chemin_fichier`, `extension_fichier`, `taille_fichier`) VALUES
(3, 8, 21, NULL, '2026-10-02', '18_cannaux', '', 'Éveil', 0, NULL, NULL, NULL, NULL, 'Terminé', NULL, NULL, NULL, NULL, NULL, NULL),
(4, 9, 21, NULL, '2026-10-02', '18_cannaux', '', 'Éveil', 0, NULL, NULL, NULL, NULL, 'Terminé', NULL, NULL, NULL, NULL, NULL, NULL),
(5, 15, 23, NULL, '2026-10-02', '18_cannaux', '', 'Éveil', 0, NULL, NULL, NULL, NULL, 'Terminé', NULL, NULL, NULL, NULL, NULL, NULL),
(6, 14, 22, NULL, '2026-10-02', '18_cannaux', '', 'Éveil', 0, NULL, NULL, NULL, NULL, 'En cours', NULL, NULL, NULL, NULL, NULL, NULL),
(7, 13, 21, NULL, '2026-10-02', '18_cannaux', '', 'Éveil', 0, NULL, NULL, NULL, NULL, 'En cours', NULL, NULL, NULL, NULL, NULL, NULL);

-- --------------------------------------------------------

--
-- Structure de la table `examen_neurologique`
--

CREATE TABLE IF NOT EXISTS `examen_neurologique` (
  `id_examen_neurologique` int(11) NOT NULL AUTO_INCREMENT,
  `id_patient` int(11) NOT NULL,
  `conscience` enum('Lucide','Obnubilée','Coma') DEFAULT NULL,
  `orientation_temporo_spatiale` enum('Oui','Non') DEFAULT NULL,
  `langage` enum('Cohérent','Non cohérent') DEFAULT NULL,
  `memoire` text,
  `nerfs_craniens` text,
  `force_musculaire` text,
  `tonus` text,
  `reflexes` text,
  `sensibilite` text,
  `coordination` text,
  `marche` text,
  `date_enregistrement` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id_examen_neurologique`),
  KEY `idx_examen_neuro_patient` (`id_patient`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Structure de la table `examen_psychiatrique`
--

CREATE TABLE IF NOT EXISTS `examen_psychiatrique` (
  `id_examen_psychiatrique` int(11) NOT NULL AUTO_INCREMENT,
  `id_patient` int(11) NOT NULL,
  `apparence_generale` enum('Bon','Mauvais') DEFAULT NULL,
  `contact` enum('Facile','Difficile') DEFAULT NULL,
  `humeur` enum('Normale','Dépressive','Euphorique') DEFAULT NULL,
  `discours` text,
  `pensee` text,
  `hallucination` text,
  `idees_suicidaires` enum('Oui','Non') DEFAULT NULL,
  `jugement` text,
  `date_enregistrement` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id_examen_psychiatrique`),
  KEY `idx_examen_psy_patient` (`id_patient`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 AUTO_INCREMENT=1 ;

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
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

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
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

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
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

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
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

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

--
-- Contenu de la table `livre_caisse`
--

INSERT INTO `livre_caisse` (`date`, `recette`, `depasse`, `solde`, `provenance`, `description`) VALUES
('2026-10-02 00:00:00', '17.00', '0.00', '17.00', '', 'Paiement d''examen EEG'),
('2026-10-02 00:00:00', '17.00', '0.00', '17.00', '', 'Paiement d''examen EEG'),
('2026-10-02 00:00:00', '17.00', '0.00', '17.00', '', 'Paiement d''examen EEG'),
('2026-10-02 00:00:00', '17.00', '0.00', '17.00', '', 'Paiement d''examen EEG'),
('2026-10-02 00:00:00', '17.00', '0.00', '17.00', '', 'Paiement d''examen EEG'),
('2026-10-02 00:00:00', '17.00', '0.00', '17.00', '', 'Paiement d''examen EEG'),
('2026-10-02 00:00:00', '17.00', '0.00', '17.00', '', 'Paiement d''examen EEG'),
('2026-10-02 00:00:00', '5.00', '0.00', '5.00', '', 'Paiement d''examen EEG'),
('2026-10-02 00:00:00', '5.00', '0.00', '5.00', '', 'Paiement d''examen EEG');

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
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

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
  `profession` varchar(150) DEFAULT NULL,
  `etat_civil` enum('Marié','Celibataire','Divorcé','Veuf','Veuve') DEFAULT NULL,
  `nom_pere` varchar(150) DEFAULT NULL,
  `nom_mere` varchar(150) DEFAULT NULL,
  `profession_pere` varchar(150) DEFAULT NULL,
  `profession_mere` varchar(150) DEFAULT NULL,
  `confession_religieuse` varchar(100) DEFAULT NULL,
  `niveau_etude` varchar(100) DEFAULT NULL,
  `personne_accompagnante` varchar(150) DEFAULT NULL,
  `telephone_accompagnant` varchar(20) DEFAULT NULL,
  `adresse_accompagnant` varchar(255) DEFAULT NULL,
  `autres_membres_famille` text,
  `engagement_tuteur` text,
  `date_creation` date DEFAULT NULL,
  `id_centre` int(11) NOT NULL,
  `photo` blob,
  `nom_garde` varchar(100) DEFAULT NULL,
  `telephone_garde` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`id_patient`),
  UNIQUE KEY `numero_fiche` (`numero_fiche`),
  KEY `id_centre` (`id_centre`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=2 ;

--
-- Contenu de la table `patients`
--

INSERT INTO `patients` (`id_patient`, `numero_fiche`, `nom`, `post_nom`, `prenom`, `sexe`, `date_naissance`, `telephone`, `adresse`, `profession`, `etat_civil`, `nom_pere`, `nom_mere`, `profession_pere`, `profession_mere`, `confession_religieuse`, `niveau_etude`, `personne_accompagnante`, `telephone_accompagnant`, `adresse_accompagnant`, `autres_membres_famille`, `engagement_tuteur`, `date_creation`, `id_centre`, `photo`, `nom_garde`, `telephone_garde`) VALUES
(1, 'CEP-001', 'Kasoki', 'Kavutya', 'Fazila', 'Feminin', '1999-07-14', '+243 987 546 789', 'Katwa/ Kavisa', 'Commerçante', 'Marié', 'Katembo mukulu', 'Kahambu Kanyere', 'Cultivateur', 'Cultivatrice', 'Catholique', 'Diplomé', 'Kambale sumuta', '+243 898 678 098', 'Vungi/ Quartie kisesi', 'pascal, tawite mwira', 'Je n''engage rien du tout', '2026-12-11', 0, NULL, 'Pas de com', 'Aucun contact');

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
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=6 ;

--
-- Contenu de la table `personnels`
--

INSERT INTO `personnels` (`id_personnel`, `id_centre`, `nom`, `post_nom`, `prenom`, `sexe`, `date_naissance`, `date_embauche`, `fonction`, `telephone`, `adresse`, `salaire_base`, `actif`, `situation_familliale`) VALUES
(1, NULL, 'KABASELE', 'MUKENDI', 'Jean', 'Masculin', '1988-05-12', '2022-01-10', 'Infirmier', '0810000001', 'Butembo', '450000.00', 'Actif', 'Marié'),
(2, NULL, 'MULAMBA', 'KALONJI', 'Marie', 'Féminin', '1992-08-20', '2023-03-15', 'Secrétaire', '0810000002', 'Butembo', '380000.00', 'Actif', 'Célibataire'),
(3, NULL, 'KASEREKA', 'PALUKU', 'Paul', 'Masculin', '1985-11-03', '2021-06-01', 'Médecin', '0810000003', 'Beni', '850000.00', 'Actif', 'Marié'),
(4, NULL, 'KAMBALE', 'VUNGI', 'Alice', 'Féminin', '1995-02-17', '2024-01-08', 'Infirmière', '0810000004', 'Butembo', '420000.00', 'Actif', 'Célibataire'),
(5, NULL, 'MUTIRI', 'KASAI', 'David', 'Masculin', '1990-09-25', '2022-09-12', 'Comptable', '0810000005', 'Butembo', '500000.00', 'Actif', 'Divorce');

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
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=15 ;

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
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=16 ;

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
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=6 ;

--
-- Contenu de la table `presences`
--

INSERT INTO `presences` (`id_presence`, `id_personnel`, `date_presence`, `heure_entree`, `heure_sortie`, `statut`) VALUES
(1, 1, '2026-10-01', '07:55:00', '16:05:00', 'Présent'),
(2, 2, '2026-10-01', '08:20:00', '16:10:00', 'Retard'),
(3, 3, '2026-10-01', '07:45:00', '16:00:00', 'Présent'),
(4, 4, '2026-10-01', '08:30:00', '16:20:00', 'Retard'),
(5, 5, '2026-10-01', NULL, NULL, 'Absent');

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
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=17 ;

--
-- Contenu de la table `prestation`
--

INSERT INTO `prestation` (`id_prestation`, `id_service`, `libelle`, `description`, `unite`, `actif`) VALUES
(15, 9, 'EEG', 'hdhdhdhd', '1', 1),
(16, 10, 'Consultation', 'Tarif consultation', '1', 1);

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
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

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
-- Structure de la table `role`
--

CREATE TABLE IF NOT EXISTS `role` (
  `id_role` int(11) NOT NULL AUTO_INCREMENT,
  `nom_role` varchar(50) DEFAULT NULL,
  `statut` enum('actif','inactif') DEFAULT 'actif',
  PRIMARY KEY (`id_role`),
  UNIQUE KEY `nom_role` (`nom_role`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

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
(1, 2, 'Décembre', '380000.00', '2026-12-11', '');

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
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=11 ;

--
-- Contenu de la table `service`
--

INSERT INTO `service` (`id_service`, `nom`, `description`, `actif`) VALUES
(9, 'EEG', 'Examens des nerfs', 1),
(10, 'Consultation', 'Consultation de malades', 1);

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
  `etat` enum('Bon','Moyen','Altéré') DEFAULT NULL,
  `date_prise` datetime DEFAULT NULL,
  `is_counsel` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id_signe`),
  KEY `id_patient` (`id_patient`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=11 ;

--
-- Contenu de la table `signes_vitaux`
--

INSERT INTO `signes_vitaux` (`id_signe`, `id_patient`, `temperature`, `tension`, `frequence_cardiaque`, `poids`, `taille`, `etat`, `date_prise`, `is_counsel`) VALUES
(8, 21, '34.00', '78', '120', '56.00', '1.00', NULL, '2026-10-02 00:00:00', 0),
(9, 22, '36.00', '45', '90', '45.00', '2.00', NULL, '2026-10-02 00:00:00', 0),
(10, 23, '23.00', '80', '120', '56.00', '7.00', NULL, '2026-10-02 00:00:00', 0);

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
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

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
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

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
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=21 ;

--
-- Contenu de la table `tarif_prestation`
--

INSERT INTO `tarif_prestation` (`id_tarif`, `id_prestation`, `prix`, `date_debut`, `date_fin`, `actif`) VALUES
(19, 15, '17.00', '2026-10-02', NULL, 1),
(20, 16, '5.00', '2026-10-02', NULL, 1);

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
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=4 ;

--
-- Contenu de la table `utilisateurs`
--

INSERT INTO `utilisateurs` (`id_utilisateurs`, `id_personnel`, `username`, `password_hash`, `role`, `date_creation`, `actif`) VALUES
(2, NULL, 'user', 'Uevmazz/YrsUd2j+MI+HYA==:9+XrEvkX7wJAD1pJV+EPOPsQpIexiqC+8Iiiv2doUaQ=', NULL, '2026-09-26', 1),
(3, NULL, 'richard', 'XaxtWhxyYGqp4SU1PG2eAg==:u7EYMLkY3Kr74fUWDuOk7RW2F1EDZFK2M5MeGBEzWu8=', NULL, '2026-10-02', 1);

-- --------------------------------------------------------

--
-- Structure de la table `utilisateur_role`
--

CREATE TABLE IF NOT EXISTS `utilisateur_role` (
  `id_utilisateur_role` int(11) NOT NULL AUTO_INCREMENT,
  `id_utilisateur` int(11) DEFAULT NULL,
  `id_role` int(11) DEFAULT NULL,
  PRIMARY KEY (`id_utilisateur_role`),
  KEY `fk_utilisateur_role` (`id_utilisateur`),
  KEY `fk_utilisateur_role_role` (`id_role`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

--
-- Contraintes pour les tables exportées
--

--
-- Contraintes pour la table `antecedents`
--
ALTER TABLE `antecedents`
  ADD CONSTRAINT `fk_antecedents_consultation` FOREIGN KEY (`id_consultation`) REFERENCES `consultation` (`id`) ON DELETE SET NULL ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_antecedents_patient` FOREIGN KEY (`id_patient`) REFERENCES `patients` (`id_patient`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Contraintes pour la table `consultation`
--
ALTER TABLE `consultation`
  ADD CONSTRAINT `fk_consultation_demande` FOREIGN KEY (`id_demande`) REFERENCES `demande_service` (`id_demande`) ON DELETE SET NULL ON UPDATE CASCADE,
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
-- Contraintes pour la table `examen_neurologique`
--
ALTER TABLE `examen_neurologique`
  ADD CONSTRAINT `fk_examen_neuro_patient` FOREIGN KEY (`id_patient`) REFERENCES `patients` (`id_patient`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Contraintes pour la table `examen_psychiatrique`
--
ALTER TABLE `examen_psychiatrique`
  ADD CONSTRAINT `fk_examen_psy_patient` FOREIGN KEY (`id_patient`) REFERENCES `patients` (`id_patient`) ON DELETE CASCADE ON UPDATE CASCADE;

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
