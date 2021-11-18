insert into country (code, name) values ('IT', 'Italy');
insert into country (code, name) values ('DE', 'Germany');
insert into country (code, name) values ('PF', 'French Polynesia/Tahiti');
insert into country (code, name) values ('CH', 'Switzerland');


insert into  hotel (name, stars, homepage, house_number, street, city, zip_code, COUNTRY_ID) values ('Bellevue Palace', 5, 'https://www.bellevue-palace.ch', '3-5', 'Kochergasse', 'Bern', '3011', (select ID from country where code = 'CH'));
insert into  hotel (name, stars, homepage, house_number, street, city, zip_code, COUNTRY_ID) values ('Intercontinental', 5, 'https://www.bellevue-palace.ch', '3-5', 'Kochergasse', 'Bern', '3011', (select ID from country where code = 'CH'));
insert into  hotel (name, stars, homepage, house_number, street, city, zip_code, COUNTRY_ID) values ('H24', 5, 'https://www.h24.ch', '12', 'Herostrasse', 'Zurich', '8048', (select ID from country where code = 'CH'));
insert into  hotel (name, stars, homepage, house_number, street, city, zip_code, COUNTRY_ID) values ('InterContinental Bora Bora Le Moana Resort', 4, 'https://www.ihg.com/intercontinental/hotels/us/en/bora-bora/bobpf/hoteldetail?cm_mmc=GoogleMaps-_-IC-_-PF-_-BOBPF', 'Bp 156', 'Matira Point', 'Vaitape : Bora Bora', '98730', (select ID from country where code = 'PF'));
insert into  hotel (name, stars, homepage, house_number, street, city, zip_code, COUNTRY_ID) values ('Orangerie Estrel', 4, 'https://www.estrel.com/en/', '225', 'Sonnenallee', 'Berlin', '12057', (select ID from country where code = 'DE'));
insert into  hotel (name, stars, homepage, house_number, street, city, zip_code, COUNTRY_ID) values ('Hotel ArtemIDe', 5, 'https://www.hotelartemIDe.it/it/', '22', 'Via Nazionale', 'Rome', '00184',  (select ID from country where code = 'IT'));


insert into facility (name) values ('Terrace');
insert into facility (name) values ('Lobby');
insert into facility (name) values ('Bellevue Bar');
insert into facility (name) values ('SPA');
insert into facility (name) values ('Pool');
insert into facility (name) values ('WiFi');
insert into facility (name) values ('Bar');
insert into facility (name) values ('Fitness');

insert into facility_assignment (facility_id, hotel_id) values ((select id from facility where name = 'Terrace'), (select id from hotel where name = 'Bellevue Palace'));
insert into facility_assignment (facility_id, hotel_id) values ((select id from facility where name = 'Lobby'), (select id from hotel where name = 'Bellevue Palace'));
insert into facility_assignment (facility_id, hotel_id) values ((select id from facility where name = 'SPA'), (select id from hotel where name = 'Bellevue Palace'));
insert into facility_assignment (facility_id, hotel_id) values ((select id from facility where name = 'Pool'), (select id from hotel where name = 'Bellevue Palace'));

insert into facility_assignment (facility_id, hotel_id) values ((select id from facility where name = 'Terrace'), (select id from hotel where name = 'Hotel ArtemIDe'));
insert into facility_assignment (facility_id, hotel_id) values ((select id from facility where name = 'Lobby'), (select id from hotel where name = 'Hotel ArtemIDe'));
insert into facility_assignment (facility_id, hotel_id) values ((select id from facility where name = 'SPA'), (select id from hotel where name = 'Hotel ArtemIDe'));
insert into facility_assignment (facility_id, hotel_id) values ((select id from facility where name = 'Pool'), (select id from hotel where name = 'Hotel ArtemIDe'));
insert into facility_assignment (facility_id, hotel_id) values ((select id from facility where name = 'Fitness'), (select id from hotel where name = 'Hotel ArtemIDe'));

insert into facility_assignment (facility_id, hotel_id) values ((select id from facility where name = 'Terrace'), (select id from hotel where name = 'Intercontinental'));
insert into facility_assignment (facility_id, hotel_id) values ((select id from facility where name = 'Lobby'), (select id from hotel where name = 'Intercontinental'));
insert into facility_assignment (facility_id, hotel_id) values ((select id from facility where name = 'SPA'), (select id from hotel where name = 'Intercontinental'));
insert into facility_assignment (facility_id, hotel_id) values ((select id from facility where name = 'Pool'), (select id from hotel where name = 'Intercontinental'));
insert into facility_assignment (facility_id, hotel_id) values ((select id from facility where name = 'Fitness'), (select id from hotel where name = 'Intercontinental'));

insert into image (name, width, height, download_url, HOTEL_ID) values ('Lukas Budimaier',5626 , 3635, 'http://htp-vendor-hotel2-ui.azurewebsites.net/static/media/room-2.48c60181.jpeg', (select ID from hotel where name = 'Bellevue Palace'));
insert into image (name, width, height, download_url, HOTEL_ID) values ('NASA',4312 , 2868, 'https://htp-vendor-hotel2-ui.azurewebsites.net/static/media/room-6.3697aea3.jpeg', (select ID from hotel where name = 'Bellevue Palace'));
insert into image (name, width, height, download_url, HOTEL_ID) values ('E+N Photographies',1181 , 1772, 'https://htp-vendor-hotel2-ui.azurewebsites.net/static/media/room-11.1605f19e.jpeg', (select ID from hotel where name = 'Bellevue Palace'));

insert into image (name, width, height, download_url, HOTEL_ID) values ('Lukas Budimaier',5626 , 3635, 'http://htp-vendor-hotel2-ui.azurewebsites.net/static/media/room-2.48c60181.jpeg', (select ID from hotel where name = 'H24'));
insert into image (name, width, height, download_url, HOTEL_ID) values ('NASA',4312 , 2868, 'https://htp-vendor-hotel2-ui.azurewebsites.net/static/media/room-6.3697aea3.jpeg', (select ID from hotel where name = 'H24'));
insert into image (name, width, height, download_url, HOTEL_ID) values ('E+N Photographies',1181 , 1772, 'https://htp-vendor-hotel2-ui.azurewebsites.net/static/media/room-11.1605f19e.jpeg', (select ID from hotel where name = 'H24'));

insert into image (name, width, height, download_url, HOTEL_ID) values ('Lukas Budimaier',5626 , 3635, 'http://htp-vendor-hotel2-ui.azurewebsites.net/static/media/room-2.48c60181.jpeg', (select ID from hotel where name = 'Intercontinental'));
insert into image (name, width, height, download_url, HOTEL_ID) values ('NASA',4312 , 2868, 'https://htp-vendor-hotel2-ui.azurewebsites.net/static/media/room-6.3697aea3.jpeg', (select ID from hotel where name = 'Intercontinental'));
insert into image (name, width, height, download_url, HOTEL_ID) values ('E+N Photographies',1181 , 1772, 'https://htp-vendor-hotel2-ui.azurewebsites.net/static/media/room-11.1605f19e.jpeg', (select ID from hotel where name = 'Intercontinental'));

insert into image (name, width, height, download_url, HOTEL_ID) values ('Lukas Budimaier',5626 , 3635, 'http://htp-vendor-hotel2-ui.azurewebsites.net/static/media/room-2.48c60181.jpeg', (select ID from hotel where name = 'InterContinental Bora Bora Le Moana Resort'));
insert into image (name, width, height, download_url, HOTEL_ID) values ('NASA',4312 , 2868, 'https://htp-vendor-hotel2-ui.azurewebsites.net/static/media/room-6.3697aea3.jpeg', (select ID from hotel where name = 'InterContinental Bora Bora Le Moana Resort'));
insert into image (name, width, height, download_url, HOTEL_ID) values ('E+N Photographies',1181 , 1772, 'https://htp-vendor-hotel2-ui.azurewebsites.net/static/media/room-11.1605f19e.jpeg', (select ID from hotel where name = 'InterContinental Bora Bora Le Moana Resort'));

insert into image (name, width, height, download_url, HOTEL_ID) values ('Lukas Budimaier',5626 , 3635, 'http://htp-vendor-hotel2-ui.azurewebsites.net/static/media/room-2.48c60181.jpeg', (select ID from hotel where name = 'Orangerie Estrel'));
insert into image (name, width, height, download_url, HOTEL_ID) values ('NASA',4312 , 2868, 'https://htp-vendor-hotel2-ui.azurewebsites.net/static/media/room-6.3697aea3.jpeg', (select ID from hotel where name = 'Orangerie Estrel'));
insert into image (name, width, height, download_url, HOTEL_ID) values ('E+N Photographies',1181 , 1772, 'https://htp-vendor-hotel2-ui.azurewebsites.net/static/media/room-11.1605f19e.jpeg', (select ID from hotel where name = 'Orangerie Estrel'));

insert into image (name, width, height, download_url, HOTEL_ID) values ('Lukas Budimaier',5626 , 3635, 'http://htp-vendor-hotel2-ui.azurewebsites.net/static/media/room-2.48c60181.jpeg', (select ID from hotel where name = 'Hotel ArtemIDe'));
insert into image (name, width, height, download_url, HOTEL_ID) values ('NASA',4312 , 2868, 'https://htp-vendor-hotel2-ui.azurewebsites.net/static/media/room-6.3697aea3.jpeg', (select ID from hotel where name = 'Hotel ArtemIDe'));
insert into image (name, width, height, download_url, HOTEL_ID) values ('E+N Photographies',1181 , 1772, 'https://htp-vendor-hotel2-ui.azurewebsites.net/static/media/room-11.1605f19e.jpeg', (select ID from hotel where name = 'Hotel ArtemIDe'));

insert into room (name, type, price, HOTEL_ID) values ('101','KING', 125, (select ID from hotel where name = 'Bellevue Palace'));
insert into room (name, type, price, HOTEL_ID) values ('102','QUEEN', 170, (select ID from hotel where name = 'Bellevue Palace'));
insert into room (name, type, price, HOTEL_ID) values ('103','DOUBLE', 250, (select ID from hotel where name = 'Bellevue Palace'));

insert into room (name, type, price, HOTEL_ID) values ('101','TWIN', 125, (select ID from hotel where name = 'Intercontinental'));
insert into room (name, type, price, HOTEL_ID) values ('102','QUEEN', 170, (select ID from hotel where name = 'Intercontinental'));
insert into room (name, type, price, HOTEL_ID) values ('103','DOUBLE', 250, (select ID from hotel where name = 'Intercontinental'));

insert into booking(booked_from, booked_to, room_id) values ('2021-05-21','2021-05-30',(select ID from room where name = '101' and hotel_id = (select ID from hotel where name = 'Bellevue Palace')));
insert into booking(booked_from, booked_to, room_id) values ('2021-05-31','2021-06-05',(select ID from room where name = '101' and hotel_id = (select ID from hotel where name = 'Bellevue Palace')));
insert into booking(booked_from, booked_to, room_id) values ('2021-06-21','2021-06-30',(select ID from room where name = '102' and hotel_id = (select ID from hotel where name = 'Bellevue Palace')));
insert into booking(booked_from, booked_to, room_id) values ('2021-07-31','2021-07-05',(select ID from room where name = '102' and hotel_id = (select ID from hotel where name = 'Bellevue Palace')));
insert into booking(booked_from, booked_to, room_id) values ('2021-08-21','2021-08-30',(select ID from room where name = '103' and hotel_id = (select ID from hotel where name = 'Bellevue Palace')));
insert into booking(booked_from, booked_to, room_id) values ('2021-09-28','2021-09-05',(select ID from room where name = '103' and hotel_id = (select ID from hotel where name = 'Bellevue Palace')));