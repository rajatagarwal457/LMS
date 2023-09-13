create database LMS
use LMS;
create table categories(
category varchar(100) primary key,
);

create table materials(
material varchar(100) primary key,
);

create table item_master (
item_id varchar(100) primary key,
issue_status varchar(1),
item_description varchar(25),
item_make varchar(100) references materials(material),
item_category varchar(100) references categories(category),
item_valuation int
);

create table employee_credentials(
employee_id varchar(100) primary key,
employee_password varchar(100) not null,
employee_role varchar(100) not null
);

create table employee_master(
employee_id varchar(100) primary key references employee_credentials(employee_id),
employee_name varchar(20) not null,
designation varchar(20),
department varchar(25),
gender varchar(1),
date_of_birth date,
date_of_joining date
);

create table employee_issue_details(
issue_id varchar(6),
employee_id varchar(100) references employee_master(employee_id),
item_id varchar(100) references item_master(item_id),
issue_date date,
return_date date
);

create table loan_card_master(
loan_id varchar(100) primary key,
loan_type varchar(100) references categories(category),
duration_in_years int
);


create table employee_card_details(
employee_id varchar(100) references employee_master(employee_id),
loan_id varchar(100) references loan_card_master(loan_id),
card_issue_date date
);

delete from categories;
insert into categories values ('Furniture'),('Crockery'),('Stationery');

delete from materials;
insert into materials values ('Plastic');
insert into materials values ('Glass');
insert into materials values ('Wood');

delete from employee_credentials;
insert into employee_credentials values 
('E0001','admin','admin'),
('E0002','customer','customer'),
('E0003','customer','customer'),
('E0004','customer','customer');


delete from employee_master;
insert into employee_master values ('E0001','Bob','Manager','IT','M','1995-05-01','2021-05-02'), ('E0002','Dylan','CA','Finance','M','1993-02-03','2019-02-06'), ('E0003','Tara','DGM','Sales','F','1997-07-10','2015-03-11'),('E0004','Barney','Associate','HR','M','1991-10-11','2022-07-08');

delete from loan_card_master;
insert into loan_card_master values ('L0001','Furniture', 1), 
('L0002', 'Crockery', 2),
('L0003', 'Stationery', 3),
('L0004', 'Furniture', 2);

delete from employee_card_details;
insert into employee_card_details values ('E0002','L0001','2023-08-23'),
('E0002','L0002','2023-07-24')
,('E0003','L0003','2023-08-22'),
('E0004','L0004','2023-09-01');

delete from item_master;
insert into item_master values 
('I0001','Y','Table','Wood', 'Furniture', 1000),
('I0002','Y','Plates','Glass', 'Crockery', 100),
('I0003','Y','Scissors','Plastic', 'Stationery', 50),
('I0004','Y','Chair','Wood', 'Furniture', 500);

delete from employee_issue_details;
insert into employee_issue_details values
('1','E0002','I0001', '2023-08-23', '2024-08-23' ),
('2','E0002','I0002', '2023-07-24', '2025-07-24' ),
('3','E0003','I0003', '2023-08-22', '2026-08-22' ),
('4','E0004','I0004', '2023-09-01', '2025-09-01' );
