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
  `bedroom_number` int(11) NOT NULL,
  `bedroom_floor` int(11) NOT NULL,
  `bedroom_status` varchar(150) COLLATE utf8_unicode_ci NOT NULL,
  `bedroom_type_id` int(11) NOT NULL,
  PRIMARY KEY (`bedroom_number`),
  KEY `bedroom_bedroom_type_FK` (`bedroom_type_id`),
  CONSTRAINT `bedroom_bedroom_type_FK` FOREIGN KEY (`bedroom_type_id`) REFERENCES `bedroom_type` (`bedroom_type_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- Listage des données de la table resotel.bedroom : ~57 rows (environ)
/*!40000 ALTER TABLE `bedroom` DISABLE KEYS */;
INSERT INTO `bedroom` (`bedroom_number`, `bedroom_floor`, `bedroom_status`, `bedroom_type_id`) VALUES
	(1, 1, 'libre', '1'),
	(2, 1, 'libre', '1'),
	(3, 1, 'libre', '1'),
	(4, 1, 'libre', '1'),
	(5, 1, 'libre', '1'),
	(6, 1, 'libre', '1'),
	(7, 1, 'libre', '1'),
	(8, 1, 'libre', '1'),
	(9, 1, 'libre', '1'),
	(10, 1, 'libre', '1'),
	(11, 1, 'libre', '1'),
	(12, 1, 'libre', '1'),
	(13, 1, 'libre', '1'),
	(14, 1, 'libre', '1'),
	(15, 1, 'libre', '1'),
	(16, 1, 'libre', '1'),
	(17, 1, 'libre', '1'),
	(18, 1, 'libre', '1'),
	(19, 1, 'libre', '1'),
	(20, 1, 'libre', '1'),
	(21, 1, 'libre', '1'),
	(22, 1, 'libre', '1'),
	(23, 2, 'libre', '2'),
	(24, 2, 'libre', '2'),
	(25, 2, 'libre', '2'),
	(26, 2, 'libre', '2'),
	(27, 2, 'libre', '2'),
	(28, 2, 'libre', '2'),
	(29, 2, 'libre', '2'),
	(30, 2, 'libre', '2'),
	(31, 2, 'libre', '2'),
	(32, 2, 'libre', '2'),
	(33, 2, 'libre', '2'),
	(34, 2, 'libre', '2'),
	(35, 2, 'libre', '2'),
	(36, 2, 'libre', '2'),
	(37, 2, 'libre', '2'),
	(38, 2, 'libre', '2'),
	(39, 3, 'libre', '6'),
	(40, 3, 'libre', '6'),
	(41, 3, 'libre', '5'),
	(42, 3, 'libre', '5'),
	(43, 3, 'libre', '5'),
	(44, 3, 'libre', '4'),
	(45, 3, 'libre', '4'),
	(46, 3, 'libre', '4'),
	(47, 3, 'libre', '4'),
	(48, 3, 'libre', '4'),
	(49, 3, 'libre', '4'),
	(50, 3, 'libre', '4'),
	(51, 3, 'libre', '4'),
	(52, 4, 'libre', '3'),
	(53, 4, 'libre', '3'),
	(54, 4, 'libre', '3'),
	(55, 4, 'libre', '3'),
	(56, 4, 'libre', '3'),
	(57, 4, 'libre', '3');
/*!40000 ALTER TABLE `bedroom` ENABLE KEYS */;

-- Listage de la structure de la table resotel. bedroom_type
DROP TABLE IF EXISTS `bedroom_type`;
CREATE TABLE IF NOT EXISTS `bedroom_type` (
  `bedroom_type_id` int(11) NOT NULL AUTO_INCREMENT,
  `bedroom_type` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`bedroom_type_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- Listage des données de la table resotel.bedroom_type : ~0 rows (environ)
/*!40000 ALTER TABLE `bedroom_type` DISABLE KEYS */;
	INSERT INTO `bedroom_type` (`bedroom_type_id`, `bedroom_type`) VALUES
	('1', 'Chambre 1 place'),
	('2', 'Chambre 2 places'),
	('3', 'Chambre 2 places avec lit bébé'),
	('4', 'Chambre 3 places'),
	('5', 'Chambre 4 places'),
	('6', 'Chambre 6 places');
/*!40000 ALTER TABLE `bedroom_type` ENABLE KEYS */;

-- Listage de la structure de la table resotel. booking
DROP TABLE IF EXISTS `booking`;
CREATE TABLE IF NOT EXISTS `booking` (
  `booking_id` int(11) NOT NULL AUTO_INCREMENT,
  `booking_start` date NOT NULL,
  `booking_end` date NOT NULL,
  `bedroom_number` int(11) NOT NULL,
  `invoice_reference` int(11) NOT NULL,
  PRIMARY KEY (`booking_id`),
  KEY `booking_bedroom_FK` (`bedroom_number`),
  KEY `booking_invoice0_FK` (`invoice_reference`),
  CONSTRAINT `booking_bedroom_FK` FOREIGN KEY (`bedroom_number`) REFERENCES `bedroom` (`bedroom_number`),
  CONSTRAINT `booking_invoice0_FK` FOREIGN KEY (`invoice_reference`) REFERENCES `invoice` (`invoice_reference`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- Listage des données de la table resotel.booking : ~0 rows (environ)
/*!40000 ALTER TABLE `booking` DISABLE KEYS */;
/*!40000 ALTER TABLE `booking` ENABLE KEYS */;

-- Listage de la structure de la table resotel. carry_out
DROP TABLE IF EXISTS `carry_out`;
CREATE TABLE IF NOT EXISTS `carry_out` (
  `booking_id` int(11) NOT NULL,
  `client_id` int(11) NOT NULL,
  PRIMARY KEY (`booking_id`,`client_id`),
  KEY `carry_out_client0_FK` (`client_id`),
  CONSTRAINT `carry_out_booking_FK` FOREIGN KEY (`booking_id`) REFERENCES `booking` (`booking_id`),
  CONSTRAINT `carry_out_client0_FK` FOREIGN KEY (`client_id`) REFERENCES `client` (`client_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- Listage des données de la table resotel.carry_out : ~0 rows (environ)
/*!40000 ALTER TABLE `carry_out` DISABLE KEYS */;
/*!40000 ALTER TABLE `carry_out` ENABLE KEYS */;

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
	(4, 'cadieux', 'gérard ', '90, rue Victor Hugo', 'CORBEIL-ESSONNES', '91100', 'gerardcadieux@jourrapide.com', '0175098520'),
	(5, 'cousteau', 'natalie', '3, rue du Paillle en queue', 'LEVALLOIS-PERRET', '92300', 'nataliecousteau@dayrep.com', '0111900313'),
	(6, 'fleur', 'lamare', '75, rue Pierre De Coubertin', 'TOULOUSE', '31100', 'fleurlamare@jourrapide.com', '0502865228'),
	(7, 'heureux', 'grégoire', '49, Rue Marie De Médicis', 'CANNES-LA-BOCCA', '06150', 'gregoireheureux@jourrapide.com', '0453776730'),
	(8, 'rené', 'bertrand', '37, rue Michel Ange', 'LE LAMENTIN', '97232', 'renebertrand@teleworm.us', '0591167112'),
	(9, 'malagigi', 'daviau', '86, avenue de Provence', 'VANDOEUVRE-LÈS-NANCY', '54500', 'malagigiDaviau@rhyta.com', '0350821579'),
	(10, 'beauchemin', 'jérôme', '8, avenue Voltaire', 'MÂCON', '71000', 'jeromebeauchemin@jourrapide.com', '0319106325'),
	(11, 'hébert', 'ruby', '65, boulevard Bryas', 'CRÉTEIL', '94000', 'rubyhebert@rhyta.com', '0120722486'),
	(12, 'fortier', 'paul', '28, Square de la Couronne', 'OZOIR-LA-FERRIÈRE', 'OZOIR-LA-FERRIÈRE', 'paulfortier@teleworm.us', '0141207873');
/*!40000 ALTER TABLE `client` ENABLE KEYS */;

-- Listage de la structure de la table resotel. concern
DROP TABLE IF EXISTS `concern`;
CREATE TABLE IF NOT EXISTS `concern` (
  `feature_id` int(11) NOT NULL,
  `booking_id` int(11) NOT NULL,
  `fearture_date_start` date DEFAULT NULL,
  `fearture_date_end` date DEFAULT NULL,
  PRIMARY KEY (`feature_id`,`booking_id`),
  KEY `concern_booking0_FK` (`booking_id`),
  CONSTRAINT `concern_booking0_FK` FOREIGN KEY (`booking_id`) REFERENCES `booking` (`booking_id`),
  CONSTRAINT `concern_feature_FK` FOREIGN KEY (`feature_id`) REFERENCES `feature` (`feature_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- Listage des données de la table resotel.concern : ~0 rows (environ)
/*!40000 ALTER TABLE `concern` DISABLE KEYS */;
/*!40000 ALTER TABLE `concern` ENABLE KEYS */;

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
	INSERT INTO `feature` (`feature_id`, `feature_default`, `feature_name`, `feature_price`) VALUES
	('1', false, 'Espace Cardio', 15),
	('2', false, 'Espace Jacuzzi/Hammam', 15),
	('3', false, 'Wi-Fi', 20),
	('4', false, 'Cours de Tennis', 25),
	('5', false, 'Vue sur cours intérieure', 89);
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

-- Listage de la structure de la table resotel. own
DROP TABLE IF EXISTS `own`;
CREATE TABLE IF NOT EXISTS `own` (
  `feature_id` int(11) NOT NULL,
  `bedroom_number` int(11) NOT NULL,
  PRIMARY KEY (`feature_id`,`bedroom_number`),
  KEY `own_bedroom0_FK` (`bedroom_number`),
  CONSTRAINT `own_bedroom0_FK` FOREIGN KEY (`bedroom_number`) REFERENCES `bedroom` (`bedroom_number`),
  CONSTRAINT `own_feature_FK` FOREIGN KEY (`feature_id`) REFERENCES `feature` (`feature_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- Listage des données de la table resotel.own : ~0 rows (environ)
/*!40000 ALTER TABLE `own` DISABLE KEYS */;
/*!40000 ALTER TABLE `own` ENABLE KEYS */;

-- Listage de la structure de la table resotel. promotion
DROP TABLE IF EXISTS `promotion`;
CREATE TABLE IF NOT EXISTS `promotion` (
  `promotion_id` int(11) NOT NULL AUTO_INCREMENT,
  `promotion_date_start` date NOT NULL,
  `promotion_date_end` date NOT NULL,
  `promotion_percentage` int(11) NOT NULL,
  `feature_id` int(11) NOT NULL,
  PRIMARY KEY (`promotion_id`),
  KEY `promotion_feature_FK` (`feature_id`),
  CONSTRAINT `promotion_feature_FK` FOREIGN KEY (`feature_id`) REFERENCES `feature` (`feature_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- Listage des données de la table resotel.promotion : ~0 rows (environ)
/*!40000 ALTER TABLE `promotion` DISABLE KEYS */;
/*!40000 ALTER TABLE `promotion` ENABLE KEYS */;

-- Listage de la structure de la table resotel. rate
DROP TABLE IF EXISTS `rate`;
CREATE TABLE IF NOT EXISTS `rate` (
  `rate_id` int(11) NOT NULL AUTO_INCREMENT,
  `rate_days_number` int(11) NOT NULL,
  `rate_price` float NOT NULL,
  `bedroom_type_id` int(11) NOT NULL,
  PRIMARY KEY (`rate_id`),
  KEY `rate_bedroom_type_FK` (`bedroom_type_id`),
  CONSTRAINT `rate_bedroom_type_FK` FOREIGN KEY (`bedroom_type_id`) REFERENCES `bedroom_type` (`bedroom_type_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- Listage des données de la table resotel.rate : ~0 rows (environ)
/*!40000 ALTER TABLE `rate` DISABLE KEYS */;
/*!40000 ALTER TABLE `rate` ENABLE KEYS */;

-- Listage de la structure de la table resotel. role
DROP TABLE IF EXISTS `role`;
CREATE TABLE IF NOT EXISTS `role` (
  `role_name` varchar(150) COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`role_name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- Listage des données de la table resotel.role : ~0 rows (environ)
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
  `user_identifiant` varchar(150) COLLATE utf8_unicode_ci NOT NULL,
  `user_password` longtext COLLATE utf8_unicode_ci NOT NULL,
  `user_lastname` varchar(150) COLLATE utf8_unicode_ci NOT NULL,
  `user_firstname` varchar(150) COLLATE utf8_unicode_ci NOT NULL,
  `role_name` varchar(150) COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`user_identifiant`),
  KEY `user_role_FK` (`role_name`),
  CONSTRAINT `user_role_FK` FOREIGN KEY (`role_name`) REFERENCES `role` (`role_name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- Listage des données de la table resotel.user : ~0 rows (environ)
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` (`user_identifiant`, `user_password`, `user_lastname`, `user_firstname`, `role_name`) VALUES
	('sarah.pell', '$2b$10$iDW1/xOEXptqPSMT0YQ1Ue4IvCGGbv06NR8ZL4vDCT4O8TWCYzFD6', 'pell', 'sarah', 'standardiste'),
	('henriette.dumans', '$2b$10$iDW1/xOEXptqPSMT0YQ1Ue4IvCGGbv06NR8ZL4vDCT4O8TWCYzFD6', 'dumans', 'henriette', 'hote d\'accueil'),
	('harry.golade', '$2b$10$iDW1/xOEXptqPSMT0YQ1Ue4IvCGGbv06NR8ZL4vDCT4O8TWCYzFD6', 'golade', 'harry', 'hote d\'accueil'),
	('marc.menager', '$2b$10$iDW1/xOEXptqPSMT0YQ1Ue4IvCGGbv06NR8ZL4vDCT4O8TWCYzFD6', 'menager', 'marc', 'responsable de l\'hygiène'),
	('jean.bonnot', '$2b$10$iDW1/xOEXptqPSMT0YQ1Ue4IvCGGbv06NR8ZL4vDCT4O8TWCYzFD6', 'bonnot', 'jean', 'responsable de la restauration');
/*!40000 ALTER TABLE `user` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
