-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
-- -----------------------------------------------------
-- Schema library
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema library
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `library` DEFAULT CHARACTER SET utf8 ;
USE `library` ;

-- -----------------------------------------------------
-- Table `library`.`accesslevels`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `library`.`accesslevels` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `access` CHAR(1) NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `id_UNIQUE` (`id` ASC) VISIBLE)
ENGINE = InnoDB
AUTO_INCREMENT = 4
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `library`.`authors`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `library`.`authors` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(45) NOT NULL,
  `surname` VARCHAR(45) NOT NULL,
  `lastname` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `id_UNIQUE` (`id` ASC) VISIBLE)
ENGINE = InnoDB
AUTO_INCREMENT = 7
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `library`.`countries`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `library`.`countries` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `id_UNIQUE` (`id` ASC) VISIBLE)
ENGINE = InnoDB
AUTO_INCREMENT = 3
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `library`.`genres`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `library`.`genres` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `id_UNIQUE` (`id` ASC) VISIBLE)
ENGINE = InnoDB
AUTO_INCREMENT = 9
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `library`.`books`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `library`.`books` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(45) NOT NULL,
  `bookDate` YEAR NOT NULL,
  `review` VARCHAR(120) NULL DEFAULT NULL,
  `pagesCount` INT NOT NULL,
  `authors_id` INT NOT NULL,
  `genres_id` INT UNSIGNED NOT NULL,
  `countries_id` INT UNSIGNED NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `id_UNIQUE` (`id` ASC) VISIBLE,
  INDEX `fk_books_authors1_idx` (`authors_id` ASC) VISIBLE,
  INDEX `fk_books_genres1_idx` (`genres_id` ASC) VISIBLE,
  INDEX `fk_books_countries1_idx` (`countries_id` ASC) VISIBLE,
  CONSTRAINT `fk_books_authors1`
    FOREIGN KEY (`authors_id`)
    REFERENCES `library`.`authors` (`id`),
  CONSTRAINT `fk_books_countries1`
    FOREIGN KEY (`countries_id`)
    REFERENCES `library`.`countries` (`id`),
  CONSTRAINT `fk_books_genres1`
    FOREIGN KEY (`genres_id`)
    REFERENCES `library`.`genres` (`id`))
ENGINE = InnoDB
AUTO_INCREMENT = 8
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `library`.`users`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `library`.`users` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `login` VARCHAR(45) NOT NULL,
  `password` VARCHAR(45) NOT NULL,
  `name` VARCHAR(45) NOT NULL,
  `surname` VARCHAR(45) NOT NULL,
  `lastname` VARCHAR(45) NOT NULL,
  `dateOfRegister` DATE NOT NULL,
  `phone` VARCHAR(12) NULL DEFAULT NULL,
  `street` VARCHAR(45) NOT NULL,
  `building` VARCHAR(45) NOT NULL,
  `apartments` VARCHAR(45) NULL DEFAULT NULL,
  `notes` VARCHAR(120) NULL DEFAULT NULL,
  `accessLevels_id` INT UNSIGNED NOT NULL,
  `reputation` INT NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `id_UNIQUE` (`id` ASC) VISIBLE,
  UNIQUE INDEX `login_UNIQUE` (`login` ASC) VISIBLE,
  INDEX `fk_users_accessLevels1_idx` (`accessLevels_id` ASC) VISIBLE,
  CONSTRAINT `fk_users_accessLevels1`
    FOREIGN KEY (`accessLevels_id`)
    REFERENCES `library`.`accesslevels` (`id`))
ENGINE = InnoDB
AUTO_INCREMENT = 7
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `library`.`readings`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `library`.`readings` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `dateStart` DATE NOT NULL,
  `dateEnd` DATE NOT NULL,
  `status` TINYINT NOT NULL,
  `books_id` INT UNSIGNED NOT NULL,
  `readers_id` INT UNSIGNED NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `id_UNIQUE` (`id` ASC) VISIBLE,
  INDEX `fk_readings_books1_idx` (`books_id` ASC) VISIBLE,
  INDEX `fk_readings_readers1_idx` (`readers_id` ASC) VISIBLE,
  CONSTRAINT `fk_readings_books1`
    FOREIGN KEY (`books_id`)
    REFERENCES `library`.`books` (`id`),
  CONSTRAINT `fk_readings_readers1`
    FOREIGN KEY (`readers_id`)
    REFERENCES `library`.`users` (`id`))
ENGINE = InnoDB
AUTO_INCREMENT = 15
DEFAULT CHARACTER SET = utf8mb3;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
