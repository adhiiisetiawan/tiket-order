-- phpMyAdmin SQL Dump
-- version 4.9.0.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Dec 11, 2019 at 05:08 PM
-- Server version: 10.4.6-MariaDB
-- PHP Version: 7.1.32

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
  `id_tiket` int(5) NOT NULL,
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
(1, 'cnoth', 21412, 'samaskljflk', '2019-09-11', 100),
(2, 'Reputation Stadium Tour', 200000, 'Stadion Gajayana', '2020-12-12', 39),
(3, 'Lover Tour', 100000, 'Perum Puri Candi BC 26', '2019-08-07', 991),
(4, 'Pentas Seni SMAN 2 Surabaya', 120000, 'Jalan Pahlawan 123 Kota Surabaya', '2019-12-01', 1),
(5, 'jlkajslskj', 70000, 'kjaslkjalk', '2019-09-09', 80000),
(7, 'kjsahsakjh', 677, 'jkhsajhj', '2019-09-29', 888),
(10, 'kjalkjalk', 88, 'lakjkaljl', '2019-09-25', 88),
(14, 'asdlkjsakl', 88888, 'alkaalj', '2019-09-20', 99),
(16, 'Babymetal Tour ', 500000, 'Tokyo, Japan', '2019-10-04', 106),
(19, 'Tiket Konser', 100000, 'Malang', '2019-03-29', 100),
(20, 'Tiket Konser 2', 100000, 'Malang', '2019-03-29', 100),
(21, 'Konser Aimer', 100000, 'Tokyo, Japan', '2019-09-09', 10000);

-- --------------------------------------------------------

--
-- Table structure for table `membeli`
--

CREATE TABLE `membeli` (
  `id_pembelian` int(11) NOT NULL,
  `id_tiket` int(5) NOT NULL,
  `id_member` int(5) NOT NULL,
  `jumlah_dibeli` int(11) NOT NULL,
  `id_promo` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `membeli`
--

INSERT INTO `membeli` (`id_pembelian`, `id_tiket`, `id_member`, `jumlah_dibeli`, `id_promo`) VALUES
(1, 2, 12, 2, 2),
(2, 4, 10, 1, 3);

-- --------------------------------------------------------

--
-- Table structure for table `member`
--

CREATE TABLE `member` (
  `id_member` int(5) NOT NULL,
  `nama_member` varchar(50) NOT NULL,
  `no_hp` varchar(12) NOT NULL,
  `email` varchar(70) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `member`
--

INSERT INTO `member` (`id_member`, `nama_member`, `no_hp`, `email`) VALUES
(1, 'Irsyad Rifqi Arrazaq', '082334196283', 'irsyad099@gmail.com'),
(2, 'Dora', '6446', 'sfsfsafas'),
(3, 'afani kurniawan', '081231705627', 'afanikurniawan@gmail.com'),
(6, 'Irsyad Rifqi', '0888888888', 'ir@gmail.com'),
(10, 'Tomi Isa Su', '8888888888', 't@gmail.com'),
(11, 'Tomy Isa', '082231551009', 'mtomi@gmail.com'),
(12, 'Adhi Setiawan', '082331821877', 'adhisetiawan@student.ub.ac.id'),
(13, 'Afani kur kur', '987987987', 'w@gmail.com'),
(14, 'Tuahta', '082331821877', 'tuahta@gmail.com'),
(15, 'Tuahta', '082331821877', 'tuahta@gmail.com');

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
-- Dumping data for table `promo`
--

INSERT INTO `promo` (`id_promo`, `nama_promo`, `kode_promo`, `diskon`) VALUES
(1, 'Promo Harian', 'PROMOKUY', 5000),
(2, 'Promo 45', 'GASKAN45', 7000),
(3, 'Promo G30S PKI', 'HANCURKANPKI', 50000),
(5, 'Promo Gak Genah', '??', 2000),
(9, 'GASKAN', 'GASKEAN', 10000),
(10, 'GASKAN', 'GASKEAN', 10000),
(11, 'GASKAN', 'GASKEAN', 10000),
(12, 'GASKAN', 'GASKEAN', 10000),
(13, 'promo apa ini', 'ADOHHHH', 10000),
(14, 'promo apa ini', 'ADOHHHH', 10000),
(15, 'promo apa ini', 'ADOHHHH', 10000),
(16, 'nge grab asik', 'GRABBIKE', 10000),
(17, 'Tiket Konser 2', '100000', 0),
(18, 'PROMO GRAB', 'GRABKUYKOY', 15000);

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
  ADD PRIMARY KEY (`id_pembelian`),
  ADD UNIQUE KEY `id_tiket` (`id_tiket`),
  ADD KEY `id_member` (`id_member`),
  ADD KEY `id_promo` (`id_promo`);

--
-- Indexes for table `member`
--
ALTER TABLE `member`
  ADD PRIMARY KEY (`id_member`);

--
-- Indexes for table `promo`
--
ALTER TABLE `promo`
  ADD PRIMARY KEY (`id_promo`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `data_tiket`
--
ALTER TABLE `data_tiket`
  MODIFY `id_tiket` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=22;

--
-- AUTO_INCREMENT for table `membeli`
--
ALTER TABLE `membeli`
  MODIFY `id_pembelian` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `member`
--
ALTER TABLE `member`
  MODIFY `id_member` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- AUTO_INCREMENT for table `promo`
--
ALTER TABLE `promo`
  MODIFY `id_promo` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=19;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `membeli`
--
ALTER TABLE `membeli`
  ADD CONSTRAINT `membeli_ibfk_1` FOREIGN KEY (`id_member`) REFERENCES `member` (`id_member`),
  ADD CONSTRAINT `membeli_ibfk_4` FOREIGN KEY (`id_tiket`) REFERENCES `data_tiket` (`id_tiket`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `membeli_ibfk_5` FOREIGN KEY (`id_promo`) REFERENCES `promo` (`id_promo`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
