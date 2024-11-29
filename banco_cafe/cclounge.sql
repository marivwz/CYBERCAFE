	CREATE DATABASE cclounge;
	USE cclounge;


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
	select*from cabine;
drop table cabine;
	CREATE TABLE cabine (
	  idcabine INTEGER UNSIGNED NOT NULL AUTO_INCREMENT,
	  tipo VARCHAR(15) NOT NULL,
	  preço DECIMAL NULL,
	  ocupação VARCHAR(105) NULL,
	  PRIMARY KEY(idcabine)
	);

	CREATE TABLE cliente (
	  idcliente INTEGER UNSIGNED NOT NULL AUTO_INCREMENT,
	  endereço_idendereço INTEGER UNSIGNED NOT NULL,
	  nome VARCHAR(100) NULL,
	  cpf VARCHAR(100) NULL,
	  telefone VARCHAR(100) NULL,
	  email VARCHAR(100) NULL,
	  senha INTEGER UNSIGNED NULL,
	  PRIMARY KEY(idcliente),
	  INDEX cliente_FKIndex1(endereço_idendereço)
	);

	CREATE TABLE endereço (
	  idendereço INTEGER UNSIGNED NOT NULL AUTO_INCREMENT,
	  logadouro VARCHAR(100) NULL,
	  bairro VARCHAR(100) NULL,
	  cidade VARCHAR(100) NULL,
	  estado VARCHAR(100) NULL,
	  cep VARCHAR(10) NULL,
	  numero INTEGER UNSIGNED NULL,
	  PRIMARY KEY(idendereço)
	);

	CREATE TABLE estoque (
	  idestoque INTEGER UNSIGNED NOT NULL AUTO_INCREMENT,
	  nome VARCHAR(100) NULL,
	  quantidade INTEGER UNSIGNED NULL,
	  data_de_chegada DATETIME NULL,
	  data_de_vencimento DATETIME NULL,
	  PRIMARY KEY(idestoque)
	);

	CREATE TABLE fornecedor (
	  idfornecedor INTEGER UNSIGNED NOT NULL AUTO_INCREMENT,
	  empresa VARCHAR(100) NULL,
	  razao_social VARCHAR(100) NULL,
	  cnpj VARCHAR(100) NULL,
	  telefone INTEGER UNSIGNED NULL,
	  email VARCHAR(100) NULL,
	  PRIMARY KEY(idfornecedor)
	);

	CREATE TABLE funcionários (
	  idfuncionários INTEGER UNSIGNED NOT NULL AUTO_INCREMENT,
	  endereço_idendereço INTEGER UNSIGNED NOT NULL,
	  gerente_idgerente INTEGER UNSIGNED NOT NULL,
	  nome VARCHAR(100) NULL,
	  idade INTEGER UNSIGNED NULL,
	  turno VARCHAR(10) NULL,
	  email VARCHAR(100) NULL,
	  salario DECIMAL(10,2) NULL,
	  cargo VARCHAR(100) NULL,
	  telefone VARCHAR(16) NULL,
	  cpf VARCHAR(15) NULL,
	  senha VARCHAR(15) NULL,
	  PRIMARY KEY(idfuncionários),
	  INDEX funcionários_FKIndex1(gerente_idgerente),
	  INDEX funcionários_FKIndex2(endereço_idendereço)
	);

	CREATE TABLE gerente (
	  idgerente INTEGER UNSIGNED NOT NULL AUTO_INCREMENT,
	  nome VARCHAR(100) NULL,
	  email VARCHAR(100) NULL,
	  telefone VARCHAR(11) NULL,
	  senha VARCHAR(15) NULL,
	  PRIMARY KEY(idgerente)
	);

	CREATE TABLE mercadoria (
	  idmercadoria INTEGER UNSIGNED NOT NULL AUTO_INCREMENT,
	  fornecedor_idfornecedor INTEGER UNSIGNED NOT NULL,
	  estoque_idestoque INTEGER UNSIGNED NOT NULL,
	  nome VARCHAR(100) NULL,
	  preço DECIMAL NULL,
	  PRIMARY KEY(idmercadoria),
	  INDEX mercadoria_FKIndex1(estoque_idestoque),
	  INDEX mercadoria_FKIndex2(fornecedor_idfornecedor)
	);
