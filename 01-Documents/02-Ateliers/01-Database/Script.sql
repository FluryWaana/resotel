-- --------------------------------------------------------
-- Hôte :                        localhost
-- Version du serveur:           5.7.24 - MySQL Community Server (GPL)
-- SE du serveur:                Win64
-- HeidiSQL Version:             9.5.0.5332
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


-- Listage de la structure de la base pour resotel
DROP DATABASE IF EXISTS `resotel`;
CREATE DATABASE IF NOT EXISTS `resotel` /*!40100 DEFAULT CHARACTER SET utf8 COLLATE utf8_unicode_ci */;
USE `resotel`;

-- Listage de la structure de la table resotel. bedroom
DROP TABLE IF EXISTS `bedroom`;
CREATE TABLE IF NOT EXISTS `bedroom` (
  `bedroom_id` int(11) NOT NULL AUTO_INCREMENT,
  `bedroom_floor` int(11) NOT NULL,
  `bedroom_number` int(11) NOT NULL,
  `bedroom_price` float NOT NULL,
  `bedroom_status` varchar(150) COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`bedroom_id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- Listage des données de la table resotel.bedroom : ~10 rows (environ)
/*!40000 ALTER TABLE `bedroom` DISABLE KEYS */;
INSERT INTO `bedroom` (`bedroom_id`, `bedroom_floor`, `bedroom_number`, `bedroom_price`, `bedroom_status`) VALUES
	(1, 0, 1, 69, 'libre'),
	(2, 0, 2, 69, 'occupée'),
	(3, 0, 3, 79, 'libre'),
	(4, 0, 4, 89, 'à nettoyer'),
	(5, 0, 5, 129, 'libre'),
	(6, 0, 6, 89, 'libre'),
	(7, 0, 7, 69, 'occupée'),
	(8, 0, 8, 79, 'occupée'),
	(9, 1, 9, 129, 'occupée'),
	(10, 1, 10, 129, 'libre');
/*!40000 ALTER TABLE `bedroom` ENABLE KEYS */;

-- Listage de la structure de la table resotel. booking
DROP TABLE IF EXISTS `booking`;
CREATE TABLE IF NOT EXISTS `booking` (
  `booking_id` int(11) NOT NULL AUTO_INCREMENT,
  `booking_start` date NOT NULL,
  `booking_end` date NOT NULL,
  `bedroom_id` int(11) NOT NULL,
  `invoice_reference` int(11) NOT NULL,
  PRIMARY KEY (`booking_id`),
  KEY `booking_bedroom_FK` (`bedroom_id`),
  KEY `booking_invoice0_FK` (`invoice_reference`),
  CONSTRAINT `booking_bedroom_FK` FOREIGN KEY (`bedroom_id`) REFERENCES `bedroom` (`bedroom_id`),
  CONSTRAINT `booking_invoice0_FK` FOREIGN KEY (`invoice_reference`) REFERENCES `invoice` (`invoice_reference`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- Listage des données de la table resotel.booking : ~0 rows (environ)
/*!40000 ALTER TABLE `booking` DISABLE KEYS */;
/*!40000 ALTER TABLE `booking` ENABLE KEYS */;

-- Listage de la structure de la table resotel. client
DROP TABLE IF EXISTS `client`;
CREATE TABLE IF NOT EXISTS `client` (
  `client_id` int(11) NOT NULL AUTO_INCREMENT,
  `client_lastname` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `client_firstname` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `client_address` varchar(200) COLLATE utf8_unicode_ci NOT NULL,
  `client_city` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `client_postalCode` varchar(5) COLLATE utf8_unicode_ci NOT NULL,
  `client_email` varchar(128) COLLATE utf8_unicode_ci NOT NULL,
  `client_phone` varchar(15) COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`client_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- Listage des données de la table resotel.client : ~0 rows (environ)
/*!40000 ALTER TABLE `client` DISABLE KEYS */;
	INSERT INTO `client` (`client_id`, `client_lastname`, `client_firstname`, `client_address`, `client_city`, `client_postalCode`, `client_email`, `client_phone`) VALUES
	(1, 'blais', 'laetitia', '32, Avenue des Pr\'es', 'MONTIGNY-LE-BRETONNEUX', '78180', 'laetitiablais@teleworm.us', '0192237548'),
	(2, 'tétrault', 'cloridan', '45, rue du Château', 'SAINT-ÉTIENNE-DU-ROUVRAY', '76800', 'cloridantetrault@dayrep.com', '0203685754'),
	(3, 'saucier', 'robert', '82, rue Adolphe Wurtz', 'LE PUY-EN-VELAY', '43000', 'robertsaucier@rhyta.com', '0460177355'),
	(4, '', '', '', '', '', '', ''),
	(5, '', '', '', '', '', '', ''),
	(6, '', '', '', '', '', '', ''),
	(7, '', '', '', '', '', '', ''),
	(8, '', '', '', '', '', '', ''),
	(9, '', '', '', '', '', '', ''),
	(10, '', '', '', '', '', '', ''),
	(11, '', '', '', '', '', '', ''),
	(12, '', '', '', '', '', '', ''),
	(13, '', '', '', '', '', '', ''),
	(14, '', '', '', '', '', '', ''),
	(15, '', '', '', '', '', '', ''),
	(16, '', '', '', '', '', '', ''),
	(17, '', '', '', '', '', '', ''),
	(18, '', '', '', '', '', '', ''),
	(19, '', '', '', '', '', '', '')
	(20, '', '', '', '', '', '', '');
/*!40000 ALTER TABLE `client` ENABLE KEYS */;

-- Listage de la structure de la table resotel. concerner
DROP TABLE IF EXISTS `concerner`;
CREATE TABLE IF NOT EXISTS `concerner` (
  `feature_id` int(11) NOT NULL,
  `booking_id` int(11) NOT NULL,
  `fearture_date_start` date DEFAULT NULL,
  `fearture_date_end` date DEFAULT NULL,
  PRIMARY KEY (`feature_id`,`booking_id`),
  KEY `Concerner_booking0_FK` (`booking_id`),
  CONSTRAINT `Concerner_booking0_FK` FOREIGN KEY (`booking_id`) REFERENCES `booking` (`booking_id`),
  CONSTRAINT `Concerner_feature_FK` FOREIGN KEY (`feature_id`) REFERENCES `feature` (`feature_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- Listage des données de la table resotel.concerner : ~0 rows (environ)
/*!40000 ALTER TABLE `concerner` DISABLE KEYS */;
/*!40000 ALTER TABLE `concerner` ENABLE KEYS */;

-- Listage de la structure de la table resotel. effectuer
DROP TABLE IF EXISTS `effectuer`;
CREATE TABLE IF NOT EXISTS `effectuer` (
  `booking_id` int(11) NOT NULL,
  `client_id` int(11) NOT NULL,
  PRIMARY KEY (`booking_id`,`client_id`),
  KEY `Effectuer_client0_FK` (`client_id`),
  CONSTRAINT `Effectuer_booking_FK` FOREIGN KEY (`booking_id`) REFERENCES `booking` (`booking_id`),
  CONSTRAINT `Effectuer_client0_FK` FOREIGN KEY (`client_id`) REFERENCES `client` (`client_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- Listage des données de la table resotel.effectuer : ~0 rows (environ)
/*!40000 ALTER TABLE `effectuer` DISABLE KEYS */;
/*!40000 ALTER TABLE `effectuer` ENABLE KEYS */;

-- Listage de la structure de la table resotel. feature
DROP TABLE IF EXISTS `feature`;
CREATE TABLE IF NOT EXISTS `feature` (
  `feature_id` int(11) NOT NULL AUTO_INCREMENT,
  `feature_default` tinyint(1) NOT NULL,
  `feature_name` varchar(100) COLLATE utf8_unicode_ci NOT NULL,
  `feature_price` float DEFAULT NULL,
  PRIMARY KEY (`feature_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- Listage des données de la table resotel.feature : ~0 rows (environ)
/*!40000 ALTER TABLE `feature` DISABLE KEYS */;
/*!40000 ALTER TABLE `feature` ENABLE KEYS */;

-- Listage de la structure de la table resotel. invoice
DROP TABLE IF EXISTS `invoice`;
CREATE TABLE IF NOT EXISTS `invoice` (
  `invoice_reference` int(11) NOT NULL AUTO_INCREMENT,
  `invoice_date` date NOT NULL,
  `invoice_tva` float NOT NULL,
  `client_id` int(11) NOT NULL,
  PRIMARY KEY (`invoice_reference`),
  KEY `invoice_client_FK` (`client_id`),
  CONSTRAINT `invoice_client_FK` FOREIGN KEY (`client_id`) REFERENCES `client` (`client_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- Listage des données de la table resotel.invoice : ~0 rows (environ)
/*!40000 ALTER TABLE `invoice` DISABLE KEYS */;
/*!40000 ALTER TABLE `invoice` ENABLE KEYS */;

-- Listage de la structure de la table resotel. posseder
DROP TABLE IF EXISTS `posseder`;
CREATE TABLE IF NOT EXISTS `posseder` (
  `feature_id` int(11) NOT NULL,
  `bedroom_id` int(11) NOT NULL,
  PRIMARY KEY (`feature_id`,`bedroom_id`),
  KEY `POSSEDER_bedroom0_FK` (`bedroom_id`),
  CONSTRAINT `POSSEDER_bedroom0_FK` FOREIGN KEY (`bedroom_id`) REFERENCES `bedroom` (`bedroom_id`),
  CONSTRAINT `POSSEDER_feature_FK` FOREIGN KEY (`feature_id`) REFERENCES `feature` (`feature_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- Listage des données de la table resotel.posseder : ~0 rows (environ)
/*!40000 ALTER TABLE `posseder` DISABLE KEYS */;
/*!40000 ALTER TABLE `posseder` ENABLE KEYS */;

-- Listage de la structure de la table resotel. role
DROP TABLE IF EXISTS `role`;
CREATE TABLE IF NOT EXISTS `role` (
  `role_name` varchar(150) COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`role_name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- Listage des données de la table resotel.role : ~5 rows (environ)
/*!40000 ALTER TABLE `role` DISABLE KEYS */;
INSERT INTO `role` (`role_name`) VALUES
	('hote d\'accueil'),
	('responsable de l\'hygiène'),
	('responsable de la restauration'),
	('standardiste');
/*!40000 ALTER TABLE `role` ENABLE KEYS */;

-- Listage de la structure de la table resotel. user
DROP TABLE IF EXISTS `user`;
CREATE TABLE IF NOT EXISTS `user` (
  `user_id` int(11) NOT NULL AUTO_INCREMENT,
  `user_identifiant` varchar(150) COLLATE utf8_unicode_ci NOT NULL,
  `user_password` longtext COLLATE utf8_unicode_ci NOT NULL,
  `user_lastname` varchar(150) COLLATE utf8_unicode_ci NOT NULL,
  `user_firstname` varchar(150) COLLATE utf8_unicode_ci NOT NULL,
  `role_name` varchar(150) COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`user_id`),
  KEY `user_role_FK` (`role_name`),
  CONSTRAINT `user_role_FK` FOREIGN KEY (`role_name`) REFERENCES `role` (`role_name`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- Listage des données de la table resotel.user : ~5 rows (environ)
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` (`user_id`, `user_identifiant`, `user_password`, `user_lastname`, `user_firstname`, `role_name`) VALUES
	(1, 'sarah.pell', '$2b$10$iDW1/xOEXptqPSMT0YQ1Ue4IvCGGbv06NR8ZL4vDCT4O8TWCYzFD6', 'pell', 'sarah', 'standardiste'),
	(2, 'henriette.dumans', '$2b$10$iDW1/xOEXptqPSMT0YQ1Ue4IvCGGbv06NR8ZL4vDCT4O8TWCYzFD6', 'dumans', 'henriette', 'hote d\'accueil'),
	(3, 'harry.golade', '$2b$10$iDW1/xOEXptqPSMT0YQ1Ue4IvCGGbv06NR8ZL4vDCT4O8TWCYzFD6', 'golade', 'harry', 'hote d\'accueil'),
	(4, 'marc.menager', '$2b$10$iDW1/xOEXptqPSMT0YQ1Ue4IvCGGbv06NR8ZL4vDCT4O8TWCYzFD6', 'menager', 'marc', 'responsable de l\'hygiène'),
	(5, 'jean.bonnot', '$2b$10$iDW1/xOEXptqPSMT0YQ1Ue4IvCGGbv06NR8ZL4vDCT4O8TWCYzFD6', 'bonnot', 'jean', 'responsable de la restauration');
/*!40000 ALTER TABLE `user` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
