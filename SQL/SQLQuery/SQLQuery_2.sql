
create table lk.Category(

CategoryID int identity primary key clustered,

CategoryName nvarchar(20) not null unique,

CategoryDescription nvarchar(1000)

);

create table lk.Product(

ProductID int identity primary key clustered,

CategoryID int References vc.Category(CategoryID),

ProductName nvarchar(50) not null unique,

ProductDescription nvarchar(100)

);


insert into lk.Category(CategoryName,CategoryDescription)

values('Hardware','Things you put inside a computer box');

insert into lk.Category(CategoryName,CategoryDescription)

values('Software','Things you install');