-- phpMyAdmin SQL Dump
-- version 4.9.0.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Sep 29, 2019 at 02:13 PM
-- Server version: 10.4.6-MariaDB
-- PHP Version: 7.3.9

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `tiket`
--

-- --------------------------------------------------------

--
-- Table structure for table `data_tiket`
--

CREATE TABLE `data_tiket` (
  `id_tiket` varchar(5) NOT NULL,
  `nama_tiket` varchar(50) NOT NULL,
  `harga_tiket` int(11) NOT NULL,
  `alamat_tiket` varchar(100) NOT NULL,
  `tanggal_tiket` date NOT NULL,
  `stok_tiket` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `data_tiket`
--

INSERT INTO `data_tiket` (`id_tiket`, `nama_tiket`, `harga_tiket`, `alamat_tiket`, `tanggal_tiket`, `stok_tiket`) VALUES
('0', 'cnoth', 21412, 'samaskljflk', '2019-09-11', 0),
('1', 'Reputation Stadium Tour', 200000, 'Stadion Gajayana', '2020-12-12', 0),
('2', 'Lover Tour', 100000, 'Perum Puri Candi BC 26', '2019-08-07', 0),
('3', 'Pentas Seni SMAN 1 Malang', 100000, 'Jalan Pahlawan 123 Kota Malang', '2019-12-12', 0);

-- --------------------------------------------------------

--
-- Table structure for table `membeli`
--

CREATE TABLE `membeli` (
  `id_pembelian` int(11) NOT NULL,
  `id_tiket` varchar(5) NOT NULL,
  `id_member` int(5) NOT NULL,
  `jumlah_dibeli` int(11) NOT NULL,
  `id_promo` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `member`
--

CREATE TABLE `member` (
  `id_member` int(5) NOT NULL,
  `username` varchar(50) NOT NULL,
  `password` varchar(50) NOT NULL,
  `nama_member` varchar(50) NOT NULL,
  `no_hp` varchar(12) NOT NULL,
  `email` varchar(70) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `member`
--

INSERT INTO `member` (`id_member`, `username`, `password`, `nama_member`, `no_hp`, `email`) VALUES
(1, 'irsyadra99', 'madiun99', 'Irsyad Rifqi Arrazaq', '082334196283', 'irsyad099@gmail.com'),
(2, 'dora123', 'mboh', 'Dora', '6446', 'sfsfsafas'),
(3, 'afani', '123', 'afani kurniawan', '081231705627', 'afanikurniawan@gmail.com');

-- --------------------------------------------------------

--
-- Table structure for table `promo`
--

CREATE TABLE `promo` (
  `id_promo` int(11) NOT NULL,
  `nama_promo` varchar(50) NOT NULL,
  `kode_promo` varchar(50) NOT NULL,
  `diskon` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `data_tiket`
--
ALTER TABLE `data_tiket`
  ADD PRIMARY KEY (`id_tiket`);

--
-- Indexes for table `membeli`
--
ALTER TABLE `membeli`
  ADD PRIMARY KEY (`id_pembelian`,`id_tiket`,`id_member`,`id_promo`),
  ADD KEY `id_member` (`id_member`),
  ADD KEY `id_tiket` (`id_tiket`),
  ADD KEY `id_promo` (`id_promo`);

--
-- Indexes for table `member`
--
ALTER TABLE `member`
  ADD PRIMARY KEY (`id_member`),
  ADD UNIQUE KEY `username` (`username`);

--
-- Indexes for table `promo`
--
ALTER TABLE `promo`
  ADD PRIMARY KEY (`id_promo`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `member`
--
ALTER TABLE `member`
  MODIFY `id_member` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `membeli`
--
ALTER TABLE `membeli`
  ADD CONSTRAINT `membeli_ibfk_1` FOREIGN KEY (`id_member`) REFERENCES `member` (`id_member`),
  ADD CONSTRAINT `membeli_ibfk_2` FOREIGN KEY (`id_tiket`) REFERENCES `data_tiket` (`id_tiket`),
  ADD CONSTRAINT `membeli_ibfk_3` FOREIGN KEY (`id_promo`) REFERENCES `promo` (`id_promo`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
