insert into country (code, name) values ('IT', 'Italy');
insert into country (code, name) values ('DE', 'Germany');
insert into country (code, name) values ('PF', 'French Polynesia/Tahiti');
insert into country (code, name) values ('CH', 'Switzerland');


insert into  hotel (name, stars, homepage, house_number, street, city, zip_code, price, COUNTRY_ID) values ('Bellevue Palace', 5, 'https://www.bellevue-palace.ch', '3-5', 'Kochergasse', 'Bern', '3011', 110, (select ID from country where code = 'CH'));
insert into  hotel (name, stars, homepage, house_number, street, city, zip_code, price, COUNTRY_ID) values ('InterContinental Bora Bora Le Moana Resort', 4, 'https://www.ihg.com/intercontinental/hotels/us/en/bora-bora/bobpf/hoteldetail?cm_mmc=GoogleMaps-_-IC-_-PF-_-BOBPF', 'Bp 156', 'Matira Point', 'Vaitape : Bora Bora', '98730', 76, (select ID from country where code = 'PF'));
insert into  hotel (name, stars, homepage, house_number, street, city, zip_code, price, COUNTRY_ID) values ('Orangerie Estrel', 4, 'https://www.estrel.com/en/', '225', 'Sonnenallee', 'Berlin', '12057', 88, (select ID from country where code = 'DE'));
insert into  hotel (name, stars, homepage, house_number, street, city, zip_code, price, COUNTRY_ID) values ('Hotel ArtemIDe', 5, 'https://www.hotelartemIDe.it/it/', '22', 'Via Nazionale', 'Rome', '00184',170,  (select ID from country where code = 'IT'));


insert into facility (name) values ('Terrace');
insert into facility (name) values ('Lobby');
insert into facility (name) values ('Bellevue Bar');
insert into facility (name) values ('SPA');
insert into facility (name) values ('Pool');
insert into facility (name) values ('WiFi');
insert into facility (name) values ('Bar');
insert into facility (name) values ('Fitness');

insert into facility_assignment (facility_id, hotel_id) values (select id from facility where name = 'Terrace', select id from hotel where name = 'Bellevue Palace');
insert into facility_assignment (facility_id, hotel_id) values (select id from facility where name = 'Lobby', select id from hotel where name = 'Bellevue Palace');
insert into facility_assignment (facility_id, hotel_id) values (select id from facility where name = 'SPA', select id from hotel where name = 'Bellevue Palace');
insert into facility_assignment (facility_id, hotel_id) values (select id from facility where name = 'Pool', select id from hotel where name = 'Bellevue Palace');

insert into facility_assignment (facility_id, hotel_id) values (select id from facility where name = 'Terrace', select id from hotel where name = 'Hotel ArtemIDe');
insert into facility_assignment (facility_id, hotel_id) values (select id from facility where name = 'Lobby', select id from hotel where name = 'Hotel ArtemIDe');
insert into facility_assignment (facility_id, hotel_id) values (select id from facility where name = 'SPA', select id from hotel where name = 'Hotel ArtemIDe');
insert into facility_assignment (facility_id, hotel_id) values (select id from facility where name = 'Pool', select id from hotel where name = 'Hotel ArtemIDe');
insert into facility_assignment (facility_id, hotel_id) values (select id from facility where name = 'Fitness', select id from hotel where name = 'Hotel ArtemIDe');


insert into image (name, width, height, download_url, HOTEL_ID) values ('Lukas Budimaier',5626 , 3635, 'https://picsum.photos/ID/1000/5626/3635', (select ID from hotel where city = 'Bern'));
insert into image (name, width, height, download_url, HOTEL_ID) values ('NASA',4312 , 2868, 'https://picsum.photos/ID/1002/4312/2868', (select ID from hotel where city = 'Bern'));
insert into image (name, width, height, download_url, HOTEL_ID) values ('E+N Photographies',1181 , 1772, 'https://picsum.photos/ID/1003/1181/1772', (select ID from hotel where city = 'Bern'));

insert into room (name, type, price, HOTEL_ID) values ('101','KING', 125, (select ID from hotel where city = 'Bern'));
insert into room (name, type, price, HOTEL_ID) values ('102','QUEEN', 170, (select ID from hotel where city = 'Bern'));
insert into room (name, type, price, HOTEL_ID) values ('103','DOUBLE', 250, (select ID from hotel where city = 'Bern'));

insert into booking(booked_from, booked_to, room_id) values ('2021-05-21','2021-05-30',(select ID from room where name = '101'));
insert into booking(booked_from, booked_to, room_id) values ('2021-05-31','2021-06-05',(select ID from room where name = '101'));
insert into booking(booked_from, booked_to, room_id) values ('2021-06-21','2021-06-30',(select ID from room where name = '102'));
insert into booking(booked_from, booked_to, room_id) values ('2021-07-31','2021-07-05',(select ID from room where name = '102'));
insert into booking(booked_from, booked_to, room_id) values ('2021-08-21','2021-08-30',(select ID from room where name = '103'));
insert into booking(booked_from, booked_to, room_id) values ('2021-09-28','2021-09-05',(select ID from room where name = '103'));