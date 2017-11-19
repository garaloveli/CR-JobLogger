
DELIMITER $$

-- drop database JobLogger;

create database JobLogger;
$$

use JobLogger;
$$

CREATE TABLE Log ( Message LONGTEXT NOT NULL);
$$

SELECT * from Log;
$$

-- SET @message = "6:41";
-- 
-- SELECT * FROM Log WHERE Message LIKE CONCAT('%', @message, '%');
-- SELECT COUNT(1) FROM Log WHERE Message LIKE CONCAT('%', @message, '%');