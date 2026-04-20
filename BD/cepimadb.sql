-- phpMyAdmin SQL Dump
-- version 4.0.4
-- http://www.phpmyadmin.net
--
-- Client: localhost
-- Généré le: Lun 20 Avril 2026 à 12:28
-- Version du serveur: 5.6.12-log
-- Version de PHP: 5.4.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Base de données: `cepimadb`
--
CREATE DATABASE IF NOT EXISTS `cepimadb` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `cepimadb`;

-- --------------------------------------------------------

--
-- Structure de la table `affectaton_chambre`
--

CREATE TABLE IF NOT EXISTS `affectaton_chambre` (
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
  `numero_chambre` int(10) DEFAULT NULL,
  `type_chambre` varchar(50) DEFAULT NULL,
  `tarif_journalier` decimal(12,2) DEFAULT NULL,
  `statut` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`id_chambre`),
  KEY `id_centre` (`id_centre`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Structure de la table `consultation`
--

CREATE TABLE IF NOT EXISTS `consultation` (
  `id_consultation` int(11) NOT NULL AUTO_INCREMENT,
  `id_patient` int(11) DEFAULT NULL,
  `id_centre` int(11) DEFAULT NULL,
  `id_personnel` int(11) DEFAULT NULL,
  `date_consultation` date DEFAULT NULL,
  `motif` varchar(255) DEFAULT NULL,
  `diagnostic` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id_consultation`),
  KEY `id_patient` (`id_patient`),
  KEY `id_centre` (`id_centre`),
  KEY `id_personnel` (`id_personnel`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

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
  `description` varchar(100) DEFAULT NULL,
  `quantite` int(10) DEFAULT NULL,
  `prix_unitaire` decimal(12,2) DEFAULT NULL,
  `montant` decimal(12,2) DEFAULT NULL,
  PRIMARY KEY (`id_detail_facture`),
  KEY `id_facture` (`id_facture`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

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
-- Structure de la table `detai_sortie_stock`
--

CREATE TABLE IF NOT EXISTS `detai_sortie_stock` (
  `id_detail` int(11) NOT NULL AUTO_INCREMENT,
  `id_sortie` int(11) DEFAULT NULL,
  `id_medicament` int(11) DEFAULT NULL,
  `quantite` int(10) DEFAULT NULL,
  `prix_unitaire` decimal(12,2) DEFAULT NULL,
  `montant` decimal(12,2) DEFAULT NULL,
  PRIMARY KEY (`id_detail`),
  KEY `id_sortie` (`id_sortie`),
  KEY `id_medicament` (`id_medicament`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

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
  `id_patient` int(11) DEFAULT NULL,
  `id_consultation` int(11) DEFAULT NULL,
  `date_examen` date DEFAULT NULL,
  `type_EEG` enum('18','32') DEFAULT NULL,
  `resultat` varchar(255) DEFAULT NULL,
  `interpretation` varchar(255) DEFAULT NULL,
  `utilisateur` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id_examens`),
  KEY `id_patient` (`id_patient`),
  KEY `id_consultation` (`id_consultation`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Structure de la table `facture`
--

CREATE TABLE IF NOT EXISTS `facture` (
  `id_facture` int(11) NOT NULL AUTO_INCREMENT,
  `id_patient` int(11) DEFAULT NULL,
  `id_centre` int(11) DEFAULT NULL,
  `date_facture` date DEFAULT NULL,
  `montant_total` decimal(12,2) DEFAULT NULL,
  `statut` enum('Imprimé','En attente') DEFAULT NULL,
  PRIMARY KEY (`id_facture`),
  KEY `id_patient` (`id_patient`),
  KEY `id_centre` (`id_centre`)
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
  `date_entree` date DEFAULT NULL,
  `date_sortie` date DEFAULT NULL,
  `motif` varchar(255) DEFAULT NULL,
  `etat` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id_hospitalisation`),
  KEY `id_patient` (`id_patient`),
  KEY `id_centre` (`id_centre`),
  KEY `id_service` (`id_service`),
  KEY `id_service_2` (`id_service`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

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
-- Structure de la table `medicament`
--

CREATE TABLE IF NOT EXISTS `medicament` (
  `id_medicament` int(11) NOT NULL AUTO_INCREMENT,
  `nom_medicament` varchar(50) DEFAULT NULL,
  `categorie` varchar(20) DEFAULT NULL,
  `unite` varchar(50) DEFAULT NULL,
  `prix_achat` decimal(12,2) DEFAULT NULL,
  `prix_vente` decimal(12,2) DEFAULT NULL,
  PRIMARY KEY (`id_medicament`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Structure de la table `paiement`
--

CREATE TABLE IF NOT EXISTS `paiement` (
  `id_paiement` int(11) NOT NULL AUTO_INCREMENT,
  `id_facture` int(11) DEFAULT NULL,
  `numero_recu` int(11) DEFAULT NULL,
  `date_paiement` date DEFAULT NULL,
  `montant` decimal(12,2) DEFAULT NULL,
  `mode_paiement` varchar(20) DEFAULT NULL,
  `type_paiement` varchar(20) DEFAULT NULL,
  `reference` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id_paiement`),
  UNIQUE KEY `numero_recu` (`numero_recu`),
  KEY `id_facture` (`id_facture`)
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
  PRIMARY KEY (`id_patient`),
  UNIQUE KEY `numero_fiche` (`numero_fiche`),
  KEY `id_centre` (`id_centre`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=4 ;

--
-- Contenu de la table `patients`
--

INSERT INTO `patients` (`id_patient`, `numero_fiche`, `nom`, `post_nom`, `prenom`, `sexe`, `date_naissance`, `telephone`, `adresse`, `date_creation`, `id_centre`) VALUES
(2, 'CEP-001', 'Kambale', 'Mukama', 'Mafungula', 'Homme', '1994-06-09', '+243 245 985 633', 'Butembo/Katwa/kyambuli', '2026-04-09', 1),
(3, 'CEP-003', 'bvcbn', 'ghjkl', 'jhgh', 'Homme', '2026-04-09', 'jhgfhj', 'lkjjghjklm', '2026-04-09', 1);

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
  `actif` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`id_personnel`),
  KEY `id_centre` (`id_centre`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=11 ;

--
-- Contenu de la table `personnels`
--

INSERT INTO `personnels` (`id_personnel`, `id_centre`, `nom`, `post_nom`, `prenom`, `sexe`, `date_naissance`, `date_embauche`, `fonction`, `telephone`, `adresse`, `salaire_base`, `actif`) VALUES
(1, 1, 'KABAMBA', 'MWILU', 'Jean', 'M', '1985-03-12', '2020-01-15', 'Psychiatre', '0991000001', 'Goma', '1200.00', NULL),
(2, 1, 'MUKENDI', 'LUBOYA', 'Aline', 'F', '1990-07-22', '2021-05-10', 'Psychologue', '0991000002', 'Goma', '900.00', NULL),
(3, 1, 'KALONJI', 'MUKUNA', 'David', 'M', '1988-11-05', '2019-09-01', 'Infirmier psychiatrique', '0991000003', 'Goma', '600.00', NULL),
(4, 1, 'NSIMBA', 'KABUYA', 'Sarah', 'F', '1992-02-18', '2022-03-20', 'Assistante sociale', '0991000004', 'Goma', '700.00', NULL),
(5, 1, 'MBUYI', 'TSHIBANGU', 'Patrick', 'M', '1980-06-30', '2018-07-12', 'Médecin généraliste', '0991000005', 'Goma', '1100.00', NULL),
(6, 1, 'KASONGO', 'MULUMBA', 'Grace', 'F', '1995-09-14', '2023-01-05', 'Psychologue', '0991000006', 'Goma', '850.00', NULL),
(7, 1, 'ILUNGA', 'KABEYA', 'Michel', 'M', '1983-12-01', '2017-11-23', 'Technicien de laboratoire', '0991000007', 'Goma', '650.00', NULL),
(8, 1, 'KABONGO', 'MWANA', 'Chantal', 'F', '1991-04-09', '2020-06-18', 'Infirmière', '0991000008', 'Goma', '580.00', NULL),
(9, 1, 'MULANGA', 'KATUMBA', 'Eric', 'M', '1987-08-25', '2019-02-14', 'Agent administratif', '0991000009', 'Goma', '500.00', NULL),
(10, 1, 'SHABANI', 'NGOYI', 'Lucie', 'F', '1993-10-11', '2021-12-01', 'Secrétaire médicale', '0991000010', 'Goma', '550.00', NULL);

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
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=2 ;

--
-- Contenu de la table `retenue`
--

INSERT INTO `retenue` (`id_retenue`, `id_salaire`, `date_retenue`, `motif`, `montant`) VALUES
(1, 1, '2026-04-18', 'retard', '30.00');

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
-- Structure de la table `services`
--

CREATE TABLE IF NOT EXISTS `services` (
  `id_service` int(11) NOT NULL AUTO_INCREMENT,
  `id_centre` int(11) DEFAULT NULL,
  `nom_service` varchar(50) DEFAULT NULL,
  `description` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id_service`),
  KEY `id_centre` (`id_centre`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Structure de la table `signes_vitaux`
--

CREATE TABLE IF NOT EXISTS `signes_vitaux` (
  `id_signe` int(11) NOT NULL AUTO_INCREMENT,
  `id_patient` int(11) DEFAULT NULL,
  `temperature` decimal(4,2) DEFAULT NULL,
  `tension` varchar(10) DEFAULT NULL,
  `frequence_cardiaque` int(11) DEFAULT NULL,
  `poids` decimal(5,2) DEFAULT NULL,
  `taille` decimal(5,2) DEFAULT NULL,
  `date_prise` datetime DEFAULT NULL,
  PRIMARY KEY (`id_signe`),
  KEY `id_patient` (`id_patient`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

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
  `type_sortie` varchar(20) DEFAULT NULL,
  `id_patient` int(11) DEFAULT NULL,
  `id_service` int(11) DEFAULT NULL,
  `date_sortie` date DEFAULT NULL,
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
  `id_medicament` int(11) DEFAULT NULL,
  `quantite` int(10) DEFAULT NULL,
  `stock_minimun` int(10) DEFAULT NULL,
  PRIMARY KEY (`id_stock`),
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
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

--
-- Contraintes pour les tables exportées
--

--
-- Contraintes pour la table `affectaton_chambre`
--
ALTER TABLE `affectaton_chambre`
  ADD CONSTRAINT `fk_hospitalisation_chambre` FOREIGN KEY (`id_chambre`) REFERENCES `chambre` (`id_chambre`) ON DELETE CASCADE,
  ADD CONSTRAINT `fk_hospitalisation_id` FOREIGN KEY (`id_hospitalisation`) REFERENCES `hospitalisation` (`id_hospitalisation`) ON DELETE CASCADE;

--
-- Contraintes pour la table `avances_salaire`
--
ALTER TABLE `avances_salaire`
  ADD CONSTRAINT `fk_avance_salaire` FOREIGN KEY (`id_salaire`) REFERENCES `salaires` (`id_salaire`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Contraintes pour la table `chambre`
--
ALTER TABLE `chambre`
  ADD CONSTRAINT `fk_chambre_idCentre` FOREIGN KEY (`id_centre`) REFERENCES `centres` (`id_centre`) ON DELETE CASCADE;

--
-- Contraintes pour la table `consultation`
--
ALTER TABLE `consultation`
  ADD CONSTRAINT `fk_consultation _personnel` FOREIGN KEY (`id_personnel`) REFERENCES `personnels` (`id_personnel`) ON DELETE CASCADE,
  ADD CONSTRAINT `fk_consultation_centre` FOREIGN KEY (`id_centre`) REFERENCES `centres` (`id_centre`) ON DELETE CASCADE,
  ADD CONSTRAINT `fk_consultation_patient` FOREIGN KEY (`id_patient`) REFERENCES `patients` (`id_patient`) ON DELETE CASCADE;

--
-- Contraintes pour la table `depenses`
--
ALTER TABLE `depenses`
  ADD CONSTRAINT `fk_centre_depense` FOREIGN KEY (`id_centre`) REFERENCES `centres` (`id_centre`) ON DELETE CASCADE;

--
-- Contraintes pour la table `details_soins`
--
ALTER TABLE `details_soins`
  ADD CONSTRAINT `fk_detail_soin_` FOREIGN KEY (`id_consultation`) REFERENCES `consultation` (`id_consultation`) ON DELETE CASCADE;

--
-- Contraintes pour la table `detail_entree_stock`
--
ALTER TABLE `detail_entree_stock`
  ADD CONSTRAINT `fk_entree_stock` FOREIGN KEY (`id_entree`) REFERENCES `entree_stock` (`id_entre`) ON DELETE CASCADE,
  ADD CONSTRAINT `fk_medoc_id` FOREIGN KEY (`id_medicament`) REFERENCES `medicament` (`id_medicament`) ON DELETE CASCADE;

--
-- Contraintes pour la table `detail_facture`
--
ALTER TABLE `detail_facture`
  ADD CONSTRAINT `fk_facture` FOREIGN KEY (`id_facture`) REFERENCES `facture` (`id_facture`) ON DELETE CASCADE;

--
-- Contraintes pour la table `detail_sortie_ph_service`
--
ALTER TABLE `detail_sortie_ph_service`
  ADD CONSTRAINT `fk_medoc_detail` FOREIGN KEY (`id_medicament`) REFERENCES `medicament` (`id_medicament`) ON DELETE CASCADE,
  ADD CONSTRAINT `fk_s_ph` FOREIGN KEY (`id_sortie`) REFERENCES `sortie_ph_service` (`id_sortie`) ON DELETE CASCADE;

--
-- Contraintes pour la table `detail_sortie_s_pa`
--
ALTER TABLE `detail_sortie_s_pa`
  ADD CONSTRAINT `fk_medicament_detail` FOREIGN KEY (`id_medicament`) REFERENCES `medicament` (`id_medicament`) ON DELETE CASCADE,
  ADD CONSTRAINT `fk_sortie_detail` FOREIGN KEY (`id_sortie`) REFERENCES `sorties_stock` (`id_sortie`) ON DELETE CASCADE;

--
-- Contraintes pour la table `detai_sortie_stock`
--
ALTER TABLE `detai_sortie_stock`
  ADD CONSTRAINT `fk_medicament_sortie_detail` FOREIGN KEY (`id_medicament`) REFERENCES `medicament` (`id_medicament`) ON DELETE CASCADE,
  ADD CONSTRAINT `fk_sortie_idStock` FOREIGN KEY (`id_sortie`) REFERENCES `sorties_stock` (`id_sortie`) ON DELETE CASCADE;

--
-- Contraintes pour la table `empreinte`
--
ALTER TABLE `empreinte`
  ADD CONSTRAINT `fk_personnel_empreinte` FOREIGN KEY (`id_personnel`) REFERENCES `personnels` (`id_personnel`) ON DELETE CASCADE;

--
-- Contraintes pour la table `entree_stock`
--
ALTER TABLE `entree_stock`
  ADD CONSTRAINT `centre_fk_stock` FOREIGN KEY (`id_centre`) REFERENCES `centres` (`id_centre`) ON DELETE CASCADE;

--
-- Contraintes pour la table `examens_eeg`
--
ALTER TABLE `examens_eeg`
  ADD CONSTRAINT `fk_consultation` FOREIGN KEY (`id_consultation`) REFERENCES `consultation` (`id_consultation`) ON DELETE CASCADE,
  ADD CONSTRAINT `fk_patient_examen` FOREIGN KEY (`id_patient`) REFERENCES `patients` (`id_patient`) ON DELETE CASCADE;

--
-- Contraintes pour la table `facture`
--
ALTER TABLE `facture`
  ADD CONSTRAINT `centre_fk_facture` FOREIGN KEY (`id_centre`) REFERENCES `centres` (`id_centre`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `patient_fk_facture` FOREIGN KEY (`id_patient`) REFERENCES `patients` (`id_patient`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Contraintes pour la table `horaire`
--
ALTER TABLE `horaire`
  ADD CONSTRAINT `fk_personnel_horaire` FOREIGN KEY (`id_personnel`) REFERENCES `personnels` (`id_personnel`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Contraintes pour la table `hospitalisation`
--
ALTER TABLE `hospitalisation`
  ADD CONSTRAINT `fk_centre_hospitalisation` FOREIGN KEY (`id_centre`) REFERENCES `centres` (`id_centre`) ON DELETE CASCADE,
  ADD CONSTRAINT `fk_patient_hospitalisation` FOREIGN KEY (`id_patient`) REFERENCES `patients` (`id_patient`) ON DELETE CASCADE,
  ADD CONSTRAINT `fk_service` FOREIGN KEY (`id_service`) REFERENCES `services` (`id_service`) ON DELETE CASCADE;

--
-- Contraintes pour la table `logs`
--
ALTER TABLE `logs`
  ADD CONSTRAINT `user_fk_logs` FOREIGN KEY (`id_utilisateur`) REFERENCES `utilisateurs` (`id_utilisateurs`) ON DELETE CASCADE;

--
-- Contraintes pour la table `paiement`
--
ALTER TABLE `paiement`
  ADD CONSTRAINT `facture_fk` FOREIGN KEY (`id_facture`) REFERENCES `facture` (`id_facture`) ON DELETE CASCADE;

--
-- Contraintes pour la table `patients`
--
ALTER TABLE `patients`
  ADD CONSTRAINT `patients_ibfk_1` FOREIGN KEY (`id_centre`) REFERENCES `centres` (`id_centre`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Contraintes pour la table `personnels`
--
ALTER TABLE `personnels`
  ADD CONSTRAINT `fk_personnel_centre` FOREIGN KEY (`id_centre`) REFERENCES `centres` (`id_centre`) ON DELETE CASCADE;

--
-- Contraintes pour la table `presences`
--
ALTER TABLE `presences`
  ADD CONSTRAINT `personnel_fk_` FOREIGN KEY (`id_personnel`) REFERENCES `personnels` (`id_personnel`) ON DELETE CASCADE;

--
-- Contraintes pour la table `prime`
--
ALTER TABLE `prime`
  ADD CONSTRAINT `fk_prime_salaire` FOREIGN KEY (`id_salaire`) REFERENCES `salaires` (`id_salaire`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Contraintes pour la table `retenue`
--
ALTER TABLE `retenue`
  ADD CONSTRAINT `fk_retenue_salaire` FOREIGN KEY (`id_salaire`) REFERENCES `salaires` (`id_salaire`) ON DELETE CASCADE;

--
-- Contraintes pour la table `salaires`
--
ALTER TABLE `salaires`
  ADD CONSTRAINT `fk_salaire_personnel` FOREIGN KEY (`id_personnel`) REFERENCES `personnels` (`id_personnel`) ON DELETE CASCADE;

--
-- Contraintes pour la table `services`
--
ALTER TABLE `services`
  ADD CONSTRAINT `fk_service_centre` FOREIGN KEY (`id_centre`) REFERENCES `centres` (`id_centre`) ON DELETE CASCADE;

--
-- Contraintes pour la table `signes_vitaux`
--
ALTER TABLE `signes_vitaux`
  ADD CONSTRAINT `signes_vitaux_ibfk_1` FOREIGN KEY (`id_patient`) REFERENCES `patients` (`id_patient`);

--
-- Contraintes pour la table `sorties_stock`
--
ALTER TABLE `sorties_stock`
  ADD CONSTRAINT `fk_centre_stock` FOREIGN KEY (`id_centre`) REFERENCES `centres` (`id_centre`) ON DELETE CASCADE,
  ADD CONSTRAINT `fk_patient_stock` FOREIGN KEY (`id_patient`) REFERENCES `patients` (`id_patient`) ON DELETE CASCADE,
  ADD CONSTRAINT `fk_service_stock` FOREIGN KEY (`id_service`) REFERENCES `services` (`id_service`) ON DELETE CASCADE;

--
-- Contraintes pour la table `sortie_ph_service`
--
ALTER TABLE `sortie_ph_service`
  ADD CONSTRAINT `fk_sortie_service` FOREIGN KEY (`id_centre`) REFERENCES `centres` (`id_centre`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `service_fk_sortie` FOREIGN KEY (`id_service`) REFERENCES `services` (`id_service`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Contraintes pour la table `sortie_s_pa`
--
ALTER TABLE `sortie_s_pa`
  ADD CONSTRAINT `fk_hospitalisation_sortie` FOREIGN KEY (`id_hospitalisation`) REFERENCES `hospitalisation` (`id_hospitalisation`) ON DELETE CASCADE,
  ADD CONSTRAINT `fk_sortie_patient` FOREIGN KEY (`id_service`) REFERENCES `services` (`id_service`) ON DELETE CASCADE;

--
-- Contraintes pour la table `stock_pharmacie`
--
ALTER TABLE `stock_pharmacie`
  ADD CONSTRAINT `fk_medoc_pharmacie` FOREIGN KEY (`id_medicament`) REFERENCES `medicament` (`id_medicament`) ON DELETE CASCADE,
  ADD CONSTRAINT `stock_fk_pharmacie` FOREIGN KEY (`id_centre`) REFERENCES `centres` (`id_centre`) ON DELETE CASCADE;

--
-- Contraintes pour la table `stock_service`
--
ALTER TABLE `stock_service`
  ADD CONSTRAINT `fk_medicament_stock_service` FOREIGN KEY (`id_medicament`) REFERENCES `medicament` (`id_medicament`) ON DELETE CASCADE,
  ADD CONSTRAINT `fk_service__service_` FOREIGN KEY (`id_service`) REFERENCES `services` (`id_service`) ON DELETE CASCADE;

--
-- Contraintes pour la table `utilisateurs`
--
ALTER TABLE `utilisateurs`
  ADD CONSTRAINT `fk_personnel_user` FOREIGN KEY (`id_personnel`) REFERENCES `personnels` (`id_personnel`) ON DELETE CASCADE;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
