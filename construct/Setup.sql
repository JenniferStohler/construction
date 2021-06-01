-- CREATE TABLE IF NOT EXISTS jobs(
--   id int NOT NULL primary key AUTO_INCREMENT COMMENT 'primary key',
--   createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
--   updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
--   name varchar(255) COMMENT 'Job Name',
--   description varchar(255) COMMENT 'Job Description',
--   location varchar(255) COMMENT 'Job Location',
--   pay INT(6, 2) COMMENT 'Job Pay'
-- ) default charset utf8 COMMENT '';
-- CREATE TABLE IF NOT EXISTS contractors(
--   id int NOT NULL primary key AUTO_INCREMENT COMMENT 'primary key',
--   createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
--   updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
--   location varchar(255) COMMENT 'Contractor Name and location'
-- ) default charset utf8 COMMENT '';
-- INSERT INTO
--   contractors (location)
-- VALUES
--   ("Contractor 1 - Kara-Tur");
-- INSERT INTO
--   contractors (location)
-- VALUES
--   ("Contractor 2 - Waterdeep");
-- INSERT INTO
--   jobs (name, description, location, pay)
-- VALUES
--   (
--     "Adventurers",
--     "We are in dire need of adventurers to rid us of the monsters that roam our land of Kara-Tur.",
--     1,000
-- INSERT INTO
--   jobs (name, description, location, pay)
-- VALUES
--   (
--     "Healer Needed",
--     "My adventuring group is in need of a healer. We are located in Waterdeep.",
--     100
--   );
CREATE TABLE IF NOT EXISTS contractor_jobs(
    id int NOT NULL primary key AUTO_INCREMENT COMMENT 'primary key',
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
    updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
    contractorId int NOT NULL COMMENT 'FK: Contractor Relationship',
    jobId int NOT NULL COMMENT 'FK: Job Relationship',
    FOREIGN KEY (contractorId) REFERENCES contractors(id) ON DELETE CASCADE,
    FOREIGN KEY (jobId) REFERENCES jobs(id) ON DELETE CASCADE
  );
INSERT INTO
  contractor_jobs (contractorId, jobId)
VALUES
  (1, 2);
INSERT INTO
  contractor_jobs (contractorId, jobId)
VALUES
  (2, 1);
SELECT
  j.*,
  c.location,
  cj.id as warehousejobId,
  cj.jobId as jobId,
  cj.contractorId as contractorId
FROM
  contractor_jobs cj
  JOIN contractors c ON c.id = cj.contractorId
  JOIN jobs j ON j.id = cj.jobId
WHERE
  cj.contractorId = 2;