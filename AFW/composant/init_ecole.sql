CREATE DATABASE gestionecole;

USE gestionecole;

--#Table élève
 CREATE TABLE `eleve` (
  `IdEleve` int(11) NOT NULL AUTO_INCREMENT,
  `nom` varchar(100) DEFAULT NULL,
  `postnom` varchar(100) DEFAULT NULL,
  `prenom` varchar(100) DEFAULT NULL,
  `genre` varchar(10) DEFAULT NULL,
  `date` date DEFAULT NULL,
  `adresse` varchar(100) NOT NULL,
  `nomTuteur` varchar(100) DEFAULT NULL,
  `numeroTuteur` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`IdEleve`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1

SET FOREIGN_KEY_CHECKS = 0;
TRUNCATE TABLE eleve;
SET FOREIGN_KEY_CHECKS = 1;

--#Table professeur
 CREATE TABLE `professeur` (
  `idProfesseur` int(11) NOT NULL AUTO_INCREMENT,
  `matricule` varchar(100) DEFAULT NULL,
  `nom` varchar(100) DEFAULT NULL,
  `postnom` varchar(100) DEFAULT NULL,
  `prenom` varchar(100) DEFAULT NULL,
  `genre` varchar(10) NOT NULL,
  `dateNaissance` date DEFAULT NULL,
  `adresse` varchar(100) DEFAULT NULL,
  `telephone` varchar(100) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  `grade` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`idProfesseur`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1

SET FOREIGN_KEY_CHECKS = 0;
TRUNCATE TABLE professeur;
SET FOREIGN_KEY_CHECKS = 1;

--#Table cours
CREATE TABLE `cours` (
  `idCours` int(11) NOT NULL AUTO_INCREMENT,
  `nomCours` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`idCours`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=latin1

SET FOREIGN_KEY_CHECKS = 0;
TRUNCATE TABLE cours;
SET FOREIGN_KEY_CHECKS = 1

--#Table classe
 CREATE TABLE `classe` (
  `idClasse` int(11) NOT NULL AUTO_INCREMENT,
  `niveau` varchar(100) NOT NULL,
  `option_` varchar(100) NOT NULL,
  `effectif` int(11) DEFAULT NULL,
  PRIMARY KEY (`idClasse`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1


SET FOREIGN_KEY_CHECKS = 0;
TRUNCATE TABLE classe;
SET FOREIGN_KEY_CHECKS = 1

--#table AnneeScolaire
 CREATE TABLE `anneescolaire` (
  `idAnnee` int(11) NOT NULL AUTO_INCREMENT,
  `anneeDebut` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`idAnnee`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1

SET FOREIGN_KEY_CHECKS = 0;
TRUNCATE TABLE anneescolaire;
SET FOREIGN_KEY_CHECKS = 1

--#table cours_classe
 CREATE TABLE `cours_classe` (
  `idcr` int(11) NOT NULL AUTO_INCREMENT,
  `idClasse` int(11) DEFAULT NULL,
  `idCours` int(11) DEFAULT NULL,
  `idAnnee` int(11) DEFAULT NULL,
  PRIMARY KEY (`idcr`),
  KEY `fk_classe_cours_classe` (`idClasse`),
  KEY `fk_cours_cours_classe` (`idCours`),
  KEY `fk_anneeScolaire_cours_classe` (`idAnnee`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1

SET FOREIGN_KEY_CHECKS = 0;
TRUNCATE TABLE cours_classe;
SET FOREIGN_KEY_CHECKS = 1

--#table cours_professeur
 CREATE TABLE `cours_professeur` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `idProfesseur` int(11) DEFAULT NULL,
  `idClasse` int(11) DEFAULT NULL,
  `idCours` int(11) DEFAULT NULL,
  `idAnnee` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_classe_cours_professeur` (`idClasse`),
  KEY `fk_cours_cours_professeur` (`idCours`),
  KEY `fk_annee_cours_professeur` (`idAnnee`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1

SET FOREIGN_KEY_CHECKS = 0;
TRUNCATE TABLE cours_professeur;
SET FOREIGN_KEY_CHECKS = 1

--#table fraisclasse
 CREATE TABLE `fraisclasse` (
  `idFrais` int(11) NOT NULL AUTO_INCREMENT,
  `idAnnee` int(11) NOT NULL,
  `idClasse` int(11) DEFAULT NULL,
  `frais` decimal(10,2) NOT NULL,
  PRIMARY KEY (`idFrais`),
  UNIQUE KEY `idClasse` (`idClasse`),
  KEY `idAnnee` (`idAnnee`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1

SET FOREIGN_KEY_CHECKS = 0;
TRUNCATE TABLE fraisclasse;
SET FOREIGN_KEY_CHECKS = 1

--#table fraistrimestre
CREATE TABLE `fraistrimestre` (
  `idTrimestre` int(11) NOT NULL AUTO_INCREMENT,
  `idFrais` int(11) NOT NULL,
  `trimestre` varchar(20) DEFAULT NULL,
  `seuil` decimal(10,2) DEFAULT NULL,
  PRIMARY KEY (`idTrimestre`),
  KEY `fk_trimestre_frais` (`idFrais`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1

SET FOREIGN_KEY_CHECKS = 0;
TRUNCATE TABLE fraistrimestre;
SET FOREIGN_KEY_CHECKS = 1

--#table parcours_eleve
 CREATE TABLE `parcours_eleve` (
  `idParcours` int(11) NOT NULL AUTO_INCREMENT,
  `idEleve` int(11) DEFAULT NULL,
  `idClasse` int(11) DEFAULT NULL,
  `idAnnee` int(11) DEFAULT NULL,
  PRIMARY KEY (`idParcours`),
  KEY `fk_eleve_parcours` (`idEleve`),
  KEY `fk_classe_parcours` (`idClasse`),
  KEY `fk_anneScolaire_parcours` (`idAnnee`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1

SET FOREIGN_KEY_CHECKS = 0;
TRUNCATE TABLE parcours_eleve;
SET FOREIGN_KEY_CHECKS = 1

--#table paiement
 CREATE TABLE `paiement` (
  `idPaiement` int(11) NOT NULL AUTO_INCREMENT,
  `montantPayer` decimal(10,5) DEFAULT NULL,
  `datePaiement` date NOT NULL,
  `idAnnee` int(11) DEFAULT NULL,
  `idTrimestre` int(11) NOT NULL,
  `idParcours` int(11) DEFAULT NULL,
  PRIMARY KEY (`idPaiement`),
  KEY `fk_anneeScolaire_paiement` (`idAnnee`),
  KEY `fk_trimestre_paiement` (`idTrimestre`),
  KEY `fk_parcours_paiement_classe` (`idParcours`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1

SET FOREIGN_KEY_CHECKS = 0;
TRUNCATE TABLE paiement;
SET FOREIGN_KEY_CHECKS = 1

--#table ecole
 CREATE TABLE `ecole` (
  `idEcole` int(11) NOT NULL AUTO_INCREMENT,
  `nom` varchar(255) NOT NULL,
  `slogan` varchar(255) DEFAULT NULL,
  `adresse` varchar(255) DEFAULT NULL,
  `telephone` varchar(18) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  `logo` longblob,
  PRIMARY KEY (`idEcole`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1


SET FOREIGN_KEY_CHECKS = 0;
TRUNCATE TABLE ecole;
SET FOREIGN_KEY_CHECKS = 1

--#table utilisateur
 CREATE TABLE `utilisateur` (
  `idUtilisateur` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(20) NOT NULL,
  `password` varchar(20) NOT NULL,
  `role` varchar(50) NOT NULL,
  `is_root` tinyint(1) NOT NULL,
  PRIMARY KEY (`idUtilisateur`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1

SET FOREIGN_KEY_CHECKS = 0;
TRUNCATE TABLE utilisateur;
SET FOREIGN_KEY_CHECKS = 1


INSERT INTO utilisateur(`username`,`password`,`role`,`is_root`)VALUES("root","","Administrateur",1);

--#table notification
 CREATE TABLE `notification` (
  `idNotification` int(11) NOT NULL AUTO_INCREMENT,
  `idPaiement` int(11) DEFAULT NULL,
  `title` varchar(100) NOT NULL,
  `description` text,
  `dateCreation` date DEFAULT NULL,
  `isRead` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`idNotification`),
  UNIQUE KEY `unique_paiement` (`idPaiement`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1

SET FOREIGN_KEY_CHECKS = 0;
TRUNCATE TABLE notification;
SET FOREIGN_KEY_CHECKS = 1



