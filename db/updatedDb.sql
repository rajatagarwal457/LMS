create database LMS1;

use LMS1;

create table categories(
category varchar(100) primary key,
);

create table materials(
material varchar(100) primary key,
);

create table category_material
(
    category varchar(100),
    material varchar(100),
    PRIMARY KEY (category, material),
    FOREIGN KEY (category) REFERENCES categories(category),
    FOREIGN KEY (material) REFERENCES materials(material)
);

create table item_master (
item_id UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
issue_status VARCHAR(8) CHECK (issue_status IN ('issued', 'waiting', 'rejected')),
item_description varchar(25),
item_make varchar(100) references materials(material),
item_category varchar(100) references categories(category),
item_valuation int
);

create table employee_master(
employee_id UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
employee_name varchar(20) not null,
designation varchar(20),
department varchar(25),
gender VARCHAR(30) CHECK (gender IN ('Male', 'Female','Prefer not to Say')),
date_of_birth date,
date_of_joining date default cast(getdate() as date)
);

create table employee_credentials(
employee_id UNIQUEIDENTIFIER references employee_master(employee_id),
employee_email varchar(100) primary key,
employee_password varchar(100) not null,
employee_role VARCHAR(10) CHECK (employee_role IN ('Admin', 'Employee')),
);

create table employee_issue_details(
issue_id UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
employee_id UNIQUEIDENTIFIER references employee_master(employee_id),
item_id UNIQUEIDENTIFIER references item_master(item_id),
issue_date date default cast(getdate() as date),
return_date date
);

create table loan_card_master(
loan_id UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
loan_type varchar(100) references categories(category),
duration_in_years int
);


create table employee_card_details(
employee_id UNIQUEIDENTIFIER references employee_master(employee_id),
loan_id UNIQUEIDENTIFIER references loan_card_master(loan_id),
card_issue_date date default cast(getdate() as date),
);

create table loan_request(
employee_id UNIQUEIDENTIFIER references employee_master(employee_id),
item_id UNIQUEIDENTIFIER references item_master(item_id),
loan_id UNIQUEIDENTIFIER references loan_card_master(loan_id)
)