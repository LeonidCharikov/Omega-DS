create database shop;
use shop;

create table zamestnanec(
ID int primary key auto_increment,
Jmeno varchar(50) not null,
Prijmeni varchar(50) not null,
Adresa varchar(100) not null,
Cislo varchar(20) not null,
PSC int not null,
Login varchar(50) not null,
Passwd varchar(50) not null
);

create table Vyrobce(
ID int primary key auto_increment,
Nazev varchar(50) not null
);


create table produkt(
ID int primary key auto_increment,
Nazev varchar(50) not null,
Pocet_kusu int not null,
Cena float not null,
Popis text not null,
vyrobce_id int,
foreign key (vyrobce_id) references Vyrobce(ID)
);

create table objednavka(
ID int primary key auto_increment,
zak_id int,
foreign key (zak_id) references zakaznik(ID),
produkt_id int,
foreign key (produkt_id) references produkt(ID),
Pocet_kusu int not null,
Celkova_cena int not null,
Datum date not null,
Platba varchar(10) not null
);

create table zakaznik(
ID int primary key auto_increment,
Nazev varchar(50) not null,
ICO int not null,
Adresa varchar(50) not null,
PSC int not null
);

insert into zakaznik(Nazev, ICO, Adresa, PSC) values("Jecna", 2654984, "Jecna 30", 12000);
insert into Vyrobce(Nazev) values("Samsung");                                                                 
insert into produkt(Nazev,Pocet_kusu,Cena,Popis,vyrobce_id) values("Telefon", 3,15000,'Vykonny telefon', 1);


CREATE VIEW Pohled AS
SELECT objednavka.ID, zakaznik.Nazev AS ZakaznikNazev, zakaznik.ICO, 
produkt.Nazev AS ProduktNazev, Vyrobce.Nazev AS VyrobceNazev, 
produkt.Cena, objednavka.Pocet_kusu, objednavka.Datum, objednavka.Platba
FROM objednavka, zakaznik, produkt, Vyrobce
WHERE produkt.ID = objednavka.produkt_id AND Vyrobce.ID = produkt.vyrobce_id AND objednavka.zak_id = zakaznik.ID ;

select * from Pohled;