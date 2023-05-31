-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 31, 2023 at 04:46 AM
-- Server version: 10.4.28-MariaDB
-- PHP Version: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `evaluation`
--

-- --------------------------------------------------------

--
-- Table structure for table `account_role`
--

CREATE TABLE `account_role` (
  `account_role_id` int(11) NOT NULL,
  `action_role` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `account_role`
--

INSERT INTO `account_role` (`account_role_id`, `action_role`) VALUES
(1, 'admin'),
(2, 'student');

-- --------------------------------------------------------

--
-- Table structure for table `commitment`
--

CREATE TABLE `commitment` (
  `Question_Id` int(11) NOT NULL,
  `Questions` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `commitment`
--

INSERT INTO `commitment` (`Question_Id`, `Questions`) VALUES
(1, 'Demonstrates sensitivity to students’ ability to attend and absorb content information.'),
(2, 'Integrates sensitively his/her learning objectives with those of the students in a collaborative process.'),
(3, 'Makes self-available to students beyond official time.'),
(4, 'Regularly comes to class on time, well-groomed and well-prepared to complete assigned responsibilities.'),
(5, 'Keeps accurate records of students’ performance and prompt submission of the same.');

-- --------------------------------------------------------

--
-- Table structure for table `knowledge_of_subject`
--

CREATE TABLE `knowledge_of_subject` (
  `Question_Id` int(11) NOT NULL,
  `Questions` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `knowledge_of_subject`
--

INSERT INTO `knowledge_of_subject` (`Question_Id`, `Questions`) VALUES
(1, 'Demonstrates mastery of the subject matter (explain the subject matter without relying solely on the \r\nprescribed textbook).'),
(2, 'Draws and share information on the state on the art of theory and practice in his/her discipline. '),
(3, 'Integrates subject to practical circumstances and learning intents/purposes of students.'),
(4, 'Explains the relevance of present topics to the previous lessons, and relates the subject matter to \r\nrelevant current issues and/or daily life activities.'),
(5, 'Demonstrates up-to-date knowledge and/or awareness on current trends and issues of the subject. ');

-- --------------------------------------------------------

--
-- Table structure for table `management_of_learning`
--

CREATE TABLE `management_of_learning` (
  `Question_Id` int(11) NOT NULL,
  `Questions` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `management_of_learning`
--

INSERT INTO `management_of_learning` (`Question_Id`, `Questions`) VALUES
(1, 'Creates opportunities for intensive and/or extensive contribution of students in the class activities (e.g. \r\nbreaks class into dyads, triads, or buzz/task groups).'),
(2, 'Assumes roles as facilitator, resource person, coach, inquisitor, integration, referee in drawing students \r\nto contribute to knowledge and understanding of the concepts at hands.'),
(3, 'Designs and implements learning conditions and experience that promotes healthy exchange and/or \r\nconfrontations'),
(4, 'Structures/re-structures learning and teaching-learning context to enhance attainment of collective \r\nlearning objectives.'),
(5, 'Use of Instructional Materials (audio/video materials: fieldtrips, film showing, computer aided \r\ninstruction and etc.) to reinforces learning processes.');

-- --------------------------------------------------------

--
-- Table structure for table `teaching_for_independent_learning`
--

CREATE TABLE `teaching_for_independent_learning` (
  `Question_Id` int(11) NOT NULL,
  `Questions` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `teaching_for_independent_learning`
--

INSERT INTO `teaching_for_independent_learning` (`Question_Id`, `Questions`) VALUES
(1, 'Creates teaching strategies that allow students to practice using concepts they need to understand \r\n(interactive discussion).'),
(2, 'Enhances student self-esteem and/or gives due recognition to students’ performance/potentials.'),
(3, 'Allows students to create their own course with objectives and realistically defined student-professor \r\nrules and make them accountable for their performance. '),
(4, 'Allows students to think independently and make their own decisions and holding them accountable \r\nfor their performance based largely on their success in executing decisions.'),
(5, 'Encourages students to learn beyond what is required and help/guide the students how to apply the \r\nconcepts learned.');

-- --------------------------------------------------------

--
-- Table structure for table `user_info`
--

CREATE TABLE `user_info` (
  `users_id` int(11) NOT NULL,
  `first_name` varchar(50) NOT NULL,
  `last_name` varchar(50) NOT NULL,
  `birth_date` date NOT NULL,
  `username` varchar(50) NOT NULL,
  `account_role` varchar(50) NOT NULL,
  `total_evaluation_score` int(11) NOT NULL,
  `total_evaluation_item` int(11) NOT NULL,
  `token` longtext NOT NULL,
  `password` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `user_info`
--

INSERT INTO `user_info` (`users_id`, `first_name`, `last_name`, `birth_date`, `username`, `account_role`, `total_evaluation_score`, `total_evaluation_item`, `token`, `password`) VALUES
(47, 'Angelo', 'Licmoan', '2000-03-19', 'angelo', 'User', 0, 0, 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VybmFtZSI6ImFuZ2VsbyIsImlhdCI6MTY4NTQzNTU3Mn0.5zrvA8Yq9vLY8KI4x1ltTfNu0WAftich7_5iOzjgsso', '$2b$10$Sip6WGB6LYYi6Pz8SDlZIukpkZYMYO3O4c68UXgLa1h3BMhjWvPLK'),
(49, 'Rosemarie', 'Saligue', '2000-03-19', 'admin', 'Admin', 80, 100, 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VybmFtZSI6ImFkbWluIiwiaWF0IjoxNjg1NDM1OTU5fQ.KD9Ft_tgRbp6Y2oVE-HMl68tONG5hNnNwpMZejIU7gc', '$2b$10$p6w2HrVKlLMGOjdy7JRZDuz1UpoGHM8F2QPFQz5aZJPfFw05wwUTC'),
(50, 'Emannuel', 'Saligue', '2000-03-19', 'admin2', 'Admin', 0, 0, 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VybmFtZSI6ImFkbWluMiIsImlhdCI6MTY4NTQzNjAwOH0.pu3jlITKtqlL2l52m2y5g1ZHMdgnYsYpydsK9Zmu9ng', '$2b$10$9RVwiIHq019Bz/ZBU1BX4OLda.5rPd1CFDiadyLuWf9OJI5tKE8OW'),
(51, 'Nhemuel', 'Buctot', '2000-03-19', 'zmhen', 'User', 0, 0, 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VybmFtZSI6InptaGVuIiwiaWF0IjoxNjg1NDM5MjU4fQ.U75PBngPepgF6JLl5Xib7RdLCgjlAetKO2ZMdhonjQU', '$2b$10$CDC.WGZMViJQ3liKwp9CEOZFqczeDU8pQdQaYhqjhnShuVgu9tBbS');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `account_role`
--
ALTER TABLE `account_role`
  ADD PRIMARY KEY (`account_role_id`);

--
-- Indexes for table `commitment`
--
ALTER TABLE `commitment`
  ADD PRIMARY KEY (`Question_Id`);

--
-- Indexes for table `knowledge_of_subject`
--
ALTER TABLE `knowledge_of_subject`
  ADD PRIMARY KEY (`Question_Id`);

--
-- Indexes for table `management_of_learning`
--
ALTER TABLE `management_of_learning`
  ADD PRIMARY KEY (`Question_Id`);

--
-- Indexes for table `teaching_for_independent_learning`
--
ALTER TABLE `teaching_for_independent_learning`
  ADD PRIMARY KEY (`Question_Id`);

--
-- Indexes for table `user_info`
--
ALTER TABLE `user_info`
  ADD PRIMARY KEY (`users_id`),
  ADD UNIQUE KEY `username` (`username`),
  ADD UNIQUE KEY `token` (`token`) USING HASH;

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `account_role`
--
ALTER TABLE `account_role`
  MODIFY `account_role_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `commitment`
--
ALTER TABLE `commitment`
  MODIFY `Question_Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `knowledge_of_subject`
--
ALTER TABLE `knowledge_of_subject`
  MODIFY `Question_Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `management_of_learning`
--
ALTER TABLE `management_of_learning`
  MODIFY `Question_Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `teaching_for_independent_learning`
--
ALTER TABLE `teaching_for_independent_learning`
  MODIFY `Question_Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `user_info`
--
ALTER TABLE `user_info`
  MODIFY `users_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=57;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
