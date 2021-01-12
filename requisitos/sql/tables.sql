create table pais(
  id_pais int primary key,
  nm_pais varchar(30),
  siglad_pais char(2)
);

create table estados(
  uf char(2) primary key,
  nm_estado varchar(30),
  id_pais int not null,
  foreign key(id_pais) references pais(id_pais)  
);

create table cidades(  
  id_cidade int primary key,  
  nm_cidade varchar(30),
  uf char(2) not null,
  foreign key(uf) references estados(uf)  
);

create table bairros(  
  id_bairro int primary key,
  nm_bairro varchar(30),
  id_cidade int not null,    
  foreign key(id_cidade) references cidades(id_cidade) 
);

create table logradouros(
  nr_cep int primary key,  
  nm_lograd varchar(50),  
  uf char(2) not null,
  id_cidade int not null, 
  id_bairro int not null,
  foreign key(uf) references estados(uf),
  foreign key(id_bairro) references bairros(id_bairro), 
  foreign key(id_cidade) references cidades(id_cidade)  
);

create table pessoas(
  id_pessoa int primary key,
  nm_pessoa varchar(100) not null,
  dt_cadastro datetime not null,
  dt_alterado datetime not null,
  tp_pessoa char(1) not null,     
  nr_cep int,  
  ds_complemento varchar(30),
  obsr varchar (50) 
);

create table clientes(
 id_cliente int primary key, 
 id_pessoa  int not null,
 dt_nascimento date,
 rg_rne varchar(20),
 cpf_cnpj varchar(20),
 foreign key(id_pessoa) references pessoas(id_pessoa)   
);

create table usuarios(
 id_pessoa int primary key,
 ds_login varchar(20) unique,
 ds_senha varchar(50) not null,
 dt_bloqueio date, 
 foreign key(id_pessoa) references pessoas(id_pessoa)
);

