create table Customer
(
    Id                                  integer primary key AUTOINCREMENT,
    FirstName                           varchar(100) not null,
    LastName                            varchar(100) not null,
    DateOfBirth                         datetime not null
);

create table Department
(
    Id                                      integer primary key AUTOINCREMENT,
    Code                                    varchar(10) not null,
    Name									varchar(100) not null
);

create table Languages
(
    Id                                      integer primary key AUTOINCREMENT,
    Code                                    varchar(10) not null,
    Name									varchar(100) not null
);
