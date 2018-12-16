```sql
CREATE TABLE `access` (
  `access_id` int(11) NOT NULL AUTO_INCREMENT,
  `access_name` varchar(20) CHARACTER SET utf8 NOT NULL,
  PRIMARY KEY (`access_id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1
CREATE TABLE `user_kinds` (
  `user_kinds_id` int(11) NOT NULL AUTO_INCREMENT,
  `user_kinds_name` varchar(20) CHARACTER SET utf8 NOT NULL,
  PRIMARY KEY (`user_kinds_id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1
CREATE TABLE `users`
 (
  `user_id` int(11) NOT NULL AUTO_INCREMENT,
  
`user_name` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
 
 `user_email` varchar(200) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
 
 `password` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  
`team_leader_id` int(11) DEFAULT NULL,
 
 `user_kind_id` int(11) NOT NULL,
 
 `user_ip` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '0',
 
 `verify_password` varchar(45) DEFAULT '0',
PRIMARY KEY (`user_id`)
) ENGINE=InnoDB AUTO_INCREMENT=62 DEFAULT CHARSET=latin1
CREATE TABLE `userkind_to_access` (
  `userkind_to_access_id` int(11) NOT NULL AUTO_INCREMENT,
  `user_kind_id` int(11) NOT NULL,
  `access_id` int(11) NOT NULL,
  PRIMARY KEY (`userkind_to_access_id`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=latin1

CREATE TABLE `projects` (
  `project_id` int(11) NOT NULL AUTO_INCREMENT,
  `project_name` varchar(20) CHARACTER SET utf8 NOT NULL,
  `client_name` varchar(20) CHARACTER SET utf8 NOT NULL,
  `team_leader_id` int(11) NOT NULL,
  `develope_hours` int(11) NOT NULL,
  `qa_hours` int(11) NOT NULL,
  `ui/ux_hours` int(11) NOT NULL,
  `start_date` date NOT NULL,
  `finish_date` date NOT NULL,
  `is_active` tinyint(4) DEFAULT '1',
  PRIMARY KEY (`project_id`),
  KEY `team_idx` (`team_leader_id`),
  CONSTRAINT `team` FOREIGN KEY (`team_leader_id`) REFERENCES `users` (`user_id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=latin1

CREATE TABLE `worker_to_project` (
  `worker_to_project_id` int(11) NOT NULL AUTO_INCREMENT,
  `user_id` int(11) NOT NULL,
  `project_id` int(11) NOT NULL,
  `hours` int(11) DEFAULT '0',
  `worker_to_projectcol` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`worker_to_project_id`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=latin1

CREATE TABLE `actual_hours` (
  `actual_hours_id` int(11) NOT NULL AUTO_INCREMENT,
  `user_id` int(11) NOT NULL,
  `project_id` int(11) NOT NULL,
  `count_houers` double NOT NULL,
  `date` date NOT NULL,
  PRIMARY KEY (`actual_hours_id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=latin1
```