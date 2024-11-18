create database CCLounge;
use CCLounge;

CREATE TABLE agendamentos (
  idagendamentos INTEGER UNSIGNED NOT NULL AUTO_INCREMENT,
  cabine_idcabine INTEGER UNSIGNED NOT NULL,
  data_2 DATE NULL,
  horário_início TIME NULL,
  horário_saída TIME NULL,
  preço_final DECIMAL NULL,
  PRIMARY KEY(idagendamentos),
  INDEX agendamentos_FKIndex1(cabine_idcabine)
);

CREATE TABLE cabine (
  idcabine INTEGER UNSIGNED NOT NULL AUTO_INCREMENT,
  tipo VARCHAR (255) NULL,
  preço DECIMAL NULL,
  ocupação VARCHAR (45) NULL,
  PRIMARY KEY(idcabine)
);

CREATE TABLE cliente (
  idcliente INTEGER UNSIGNED NOT NULL AUTO_INCREMENT,
  endereço_idendereço INTEGER UNSIGNED NOT NULL,
  nome VARCHAR (255) NULL,
  cpf VARCHAR (11) NULL,
  telefone VARCHAR (11) NULL,
  email VARCHAR (255) NULL,
  senha INTEGER UNSIGNED NULL,
  PRIMARY KEY(idcliente),
  INDEX cliente_FKIndex1(endereço_idendereço)
);

CREATE TABLE endereço (
  idendereço INTEGER UNSIGNED NOT NULL AUTO_INCREMENT,
  logadouro VARCHAR (255) NULL,
  bairro VARCHAR (255) NULL,
  cidade VARCHAR (255) NULL,
  estado VARCHAR (2) NULL,
  cep VARCHAR (9) NULL,
  numero INTEGER UNSIGNED NULL,
  PRIMARY KEY(idendereço)
);

CREATE TABLE estoque (
  idestoque INTEGER UNSIGNED NOT NULL AUTO_INCREMENT,
  nome VARCHAR (255) NULL,
  quantidade INTEGER UNSIGNED NULL,
  data_de_chegada DATETIME NULL,
  data_de_vencimento DATETIME NULL,
  PRIMARY KEY(idestoque)
);

CREATE TABLE fornecedor (
  idfornecedor INTEGER UNSIGNED NOT NULL AUTO_INCREMENT,
  empresa VARCHAR (255) NULL,
  razao_social VARCHAR (255) NULL,
  cnpj VARCHAR (255) NULL,
  telefone INTEGER UNSIGNED NULL,
  email VARCHAR (255) NULL,
  PRIMARY KEY(idfornecedor)
);

CREATE TABLE funcionários (
  idfuncionários INTEGER UNSIGNED NOT NULL AUTO_INCREMENT,
  endereço_idendereço INTEGER UNSIGNED NOT NULL,
  gerente_idgerente INTEGER UNSIGNED NOT NULL,
  nome VARCHAR (255) NULL,
  idade INTEGER UNSIGNED NULL,
  turno VARCHAR(10) NULL,
  email VARCHAR (255) NULL,
  salario DECIMAL NULL,
  cargo VARCHAR (255) NULL,
  telefone VARCHAR (11) NULL,
  cpf VARCHAR (11) NULL,
  senha VARCHAR (255) NULL,
  PRIMARY KEY(idfuncionários),
  INDEX funcionários_FKIndex1(gerente_idgerente),
  INDEX funcionários_FKIndex2(endereço_idendereço)
);

CREATE TABLE gerente (
  idgerente INTEGER UNSIGNED NOT NULL AUTO_INCREMENT,
  nome VARCHAR (255) NULL,
  email VARCHAR (255) NULL,
  telefone VARCHAR (11) NULL,
  senha VARCHAR (255) NULL,
  PRIMARY KEY(idgerente)
);

CREATE TABLE mercadoria (
  idmercadoria INTEGER UNSIGNED NOT NULL AUTO_INCREMENT,
  fornecedor_idfornecedor INTEGER UNSIGNED NOT NULL,
  estoque_idestoque INTEGER UNSIGNED NOT NULL,
  nome VARCHAR (255) NULL,
  preço DECIMAL NULL,
  PRIMARY KEY(idmercadoria),
  INDEX mercadoria_FKIndex1(estoque_idestoque),
  INDEX mercadoria_FKIndex2(fornecedor_idfornecedor)
);

