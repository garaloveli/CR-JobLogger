-- drop database JobLogger;

create database JobLogger;

use JobLogger;

CREATE TABLE Log ( Message LONGTEXT NOT NULL);

SELECT * from Log