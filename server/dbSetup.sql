CREATE TABLE IF NOT EXISTS accounts (
    id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
    updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
    name varchar(255) COMMENT 'User Name',
    email varchar(255) UNIQUE COMMENT 'User Email',
    picture varchar(255) COMMENT 'User Picture'
) default charset utf8mb4 COMMENT '';

CREATE TABLE IF NOT EXISTS keeps (
    id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
    updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
    name VARCHAR(255) NOT NULL,
    description TEXT NOT NULL,
    img TEXT NOT NULL,
    views INT NOT NULL DEFAULT 0,
    creatorId VARCHAR(255) NOT NULL,
    FOREIGN KEY (creatorId) REFERENCES accounts (id) ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS vaults (
    id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
    updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
    name VARCHAR(255) NOT NULL,
    description TEXT NOT NULL,
    img TEXT NOT NULL,
    isPrivate BOOLEAN NOT NULL DEFAULT false,
    creatorId VARCHAR(255) NOT NULL,
    FOREIGN KEY (creatorId) REFERENCES accounts (id) ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS vault_keeps (
    id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
    updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
    keepId INT NOT NULL,
    vaultId INT NOT NULL,
    creatorId VARCHAR(255) NOT NULL,
    FOREIGN KEY (keepId) REFERENCES keeps (id) ON DELETE CASCADE,
    FOREIGN KEY (vaultId) REFERENCES vaults (id) ON DELETE CASCADE,
    FOREIGN KEY (creatorId) REFERENCES accounts (id) ON DELETE CASCADE
);

ALTER TABLE accounts ADD COLUMN coverImg TEXT NOT NULL;

INSERT INTO vault_keeps (`vaultId`, `keepId`, `creatorId`) VALUES (2,2, '66f48ffd320bc392ffcdc633') ;

 SELECT
          accounts.*,
          keeps.*
        FROM
          keeps
        JOIN
          accounts on accounts.id = keeps.creatorId
        WHERE
          accounts.id = '66f3263a6fbf3fcb53702407';