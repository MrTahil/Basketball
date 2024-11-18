-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2024. Nov 18. 11:21
-- Kiszolgáló verziója: 10.4.20-MariaDB
-- PHP verzió: 7.3.29

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `basketteam`
--
CREATE DATABASE IF NOT EXISTS `basketteam` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_hungarian_ci;
USE `basketteam`;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `matchdata`
--

CREATE TABLE `matchdata` (
  `Id` varchar(36) COLLATE utf8mb4_hungarian_ci NOT NULL,
  `In` datetime NOT NULL,
  `Out` datetime NOT NULL,
  `Try` int(11) NOT NULL,
  `Goal` int(11) NOT NULL,
  `Fault` int(11) NOT NULL,
  `CreatedTime` datetime NOT NULL,
  `UpdatedTime` datetime NOT NULL,
  `PlayerId` varchar(36) COLLATE utf8mb4_hungarian_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `player`
--

CREATE TABLE `player` (
  `Id` varchar(36) COLLATE utf8mb4_hungarian_ci NOT NULL,
  `Name` varchar(37) COLLATE utf8mb4_hungarian_ci NOT NULL,
  `Height` int(11) NOT NULL,
  `Weight` int(11) NOT NULL,
  `CreatedTime` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `matchdata`
--
ALTER TABLE `matchdata`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `Random` (`PlayerId`);

--
-- A tábla indexei `player`
--
ALTER TABLE `player`
  ADD PRIMARY KEY (`Id`);

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `matchdata`
--
ALTER TABLE `matchdata`
  ADD CONSTRAINT `Random` FOREIGN KEY (`PlayerId`) REFERENCES `player` (`Id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
