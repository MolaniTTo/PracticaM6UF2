DROP TABLE IF EXISTS ORDERP;
DROP TABLE IF EXISTS SUPPLIER;
DROP TABLE IF EXISTS PRODUCT;
DROP TABLE IF EXISTS EMPLOYEE;


CREATE TABLE EMPLOYEE ( id			SERIAL NOT NULL PRIMARY KEY,
					   surname		VARCHAR (25) NOT NULL,
                       job			VARCHAR (50),
                       managerno	INTEGER,
                       startdate	TIMESTAMPTZ,
                       salary		DECIMAL(12,2),
                       commission	DECIMAL(12,2),
					   deptno		INTEGER NOT NULL 
					   );

INSERT INTO EMPLOYEE (surname,job,managerno,startdate,salary,commission,deptno) VALUES ('SÁNCHEZ','ADMINISTRATIU',6, '1980-12-17', 104000,NULL,20);
INSERT INTO EMPLOYEE (surname,job,managerno,startdate,salary,commission,deptno) VALUES ('ARROYO','VENEDOR',4, '1980-02-20', 208000,39000,30);
INSERT INTO EMPLOYEE (surname,job,managerno,startdate,salary,commission,deptno) VALUES ('SALA','VENEDOR',4, '1981-02-22', 162500,65000,30);
INSERT INTO EMPLOYEE (surname,job,managerno,startdate,salary,commission,deptno) VALUES ('JIMÉNEZ','DIRECTOR',9, '1981-04-02', 386750,NULL,30);
INSERT INTO EMPLOYEE (surname,job,managerno,startdate,salary,commission,deptno) VALUES ('MARTÍN','VENEDOR',4, '1981-09-29', 162500,182000,30);
INSERT INTO EMPLOYEE (surname,job,managerno,startdate,salary,commission,deptno) VALUES ('NEGRO','DIRECTOR',9, '1981-05-01', 370500,NULL,20);
INSERT INTO EMPLOYEE (surname,job,managerno,startdate,salary,commission,deptno) VALUES ('CEREZO','DIRECTOR',9, '1981-06-09', 318500,NULL,10);
INSERT INTO EMPLOYEE (surname,job,managerno,startdate,salary,commission,deptno) VALUES ('GIL','ANALISTA',7, '1981-11-09', 390000,NULL,10);
INSERT INTO EMPLOYEE (surname,job,managerno,startdate,salary,commission,deptno) VALUES ('REY','GERENT',NULL, '1981-11-17', 650000,NULL,10);
INSERT INTO EMPLOYEE (surname,job,managerno,startdate,salary,commission,deptno) VALUES ('TOVAR','VENEDOR',4, '1981-09-08', 195000,0,30);
INSERT INTO EMPLOYEE (surname,job,managerno,startdate,salary,commission,deptno) VALUES ('ALONSO','ADMINISTRATIU',6, '1981-09-23', 143000,NULL,20);
INSERT INTO EMPLOYEE (surname,job,managerno,startdate,salary,commission,deptno) VALUES ('JIMENO','ADMINISTRATIU',6, '1981-12-03', 123500,NULL,20);
INSERT INTO EMPLOYEE (surname,job,managerno,startdate,salary,commission,deptno) VALUES ('FERNÁNDEZ','ANALISTA',7, '1981-12-03', 390000,NULL,10);
INSERT INTO EMPLOYEE (surname,job,managerno,startdate,salary,commission,deptno) VALUES ('MUÑOZ','ADMINISTRATIU',6, '1982-01-23', 169000,NULL,20);


CREATE TABLE PRODUCT ( id			SERIAL NOT NULL PRIMARY KEY,
                      code			NUMERIC (12) NOT NULL,
                      description	VARCHAR (30) NOT NULL,
                      currentstock	NUMERIC (12),
                      minstock		NUMERIC (12),
                      price			DECIMAL(8,2),
					  empno			INTEGER,
					  CONSTRAINT FK_EMP FOREIGN KEY (empno) REFERENCES EMPLOYEE(id) ON DELETE CASCADE 
					  );


INSERT INTO PRODUCT (code, description, currentstock, minstock,price,empno)
VALUES (100860, 'ACE TENNIS RACKET I', 10, 5, 308,10);
INSERT INTO PRODUCT (code, description, currentstock, minstock,price,empno)
VALUES (100861, 'ACE TENNIS RACKET II', 10, 5, 15.275,10);
INSERT INTO PRODUCT (code, description, currentstock, minstock,price,empno)
VALUES (100870, 'ACE TENNIS BALLS-3 PACK',10,5,40.6,5);
INSERT INTO PRODUCT (code, description, currentstock, minstock,price,empno)
VALUES (100871, 'ACE TENNIS BALLS-6 PACK',10,5,33.2,2);
INSERT INTO PRODUCT (code, description, currentstock, minstock,price,empno)
VALUES (100890, 'ACE TENNIS NET',10,5,30,2);
INSERT INTO PRODUCT (code, description, currentstock, minstock,price,empno)
VALUES (101860, 'SP TENNIS RACKET',10,5,548,3);
INSERT INTO PRODUCT (code, description, currentstock, minstock,price,empno)
VALUES (101863, 'SP JUNIOR RACKET',10,5,124,5);
INSERT INTO PRODUCT (code, description, currentstock, minstock,price,empno)
VALUES (102130, 'RH: "GUIDE TO TENNIS"',10,5,48,3);
INSERT INTO PRODUCT (code, description, currentstock, minstock,price,empno)
VALUES (200376, 'SB ENERGY BAR-6 PACK',10,5,16,5);
INSERT INTO PRODUCT (code, description, currentstock, minstock,price,empno)
VALUES (200380, 'SB VITA SNACK-6 PACK',10,5,24,2);



CREATE TABLE SUPPLIER ( id			SERIAL NOT NULL PRIMARY KEY,
						name		VARCHAR (45) NOT NULL,
						address 	VARCHAR (40) NOT NULL,
						city		VARCHAR (30) NOT NULL,
						stcode		VARCHAR (2),
						zipcode		VARCHAR (10) NOT NULL,
						area		NUMERIC(5),
						phone		VARCHAR (10),
						productno	INTEGER NOT NULL,
						amount		NUMERIC (12),
						credit		DECIMAL(9,2),
						remark		TEXT,
						CONSTRAINT FK_PROD FOREIGN KEY (productno) REFERENCES PRODUCT(id) ON DELETE CASCADE						
						);				


INSERT INTO SUPPLIER (name,address,city,stcode,zipcode,area,phone, productno ,amount, credit, remark)
VALUES ('JOCKSPORTS', '345 VIEWRIDGE', 'BELMONT', 'CA', '96711', 415,
        '598-6609',5,350,5000,
        'Very friendly people to work with -- sales rep likes to be called Mike.');
INSERT INTO SUPPLIER (name,address,city,stcode,zipcode,area,phone, productno ,amount, credit, remark)
VALUES ('TKB SPORT SHOP', '490 BOLI RD.', 'REDWOOD city', 'CA', '94061', 415,
        '368-1223',6, 752, 10000,
        'Rep called 5/8 about change in order - contact shipping.');
INSERT INTO SUPPLIER (name,address,city,stcode,zipcode,area,phone, productno ,amount, credit, remark)
VALUES ('VOLLYRITE', '9722 HAMILTON', 'BURLINGAME', 'CA', '95133', 415,
        '644-3341',2, 800, 7000,
        'Company doing heavy promotion beginning 10/89. Prepare for large orders during winter.');
INSERT INTO SUPPLIER (name,address,city,stcode,zipcode,area,phone, productno ,amount, credit, remark)
VALUES ('JUST TENNIS', 'HILLVIEW MALL', 'BURLINGAME', 'CA', '97544', 415,
        '677-9312',7, 400, 3000,
        'Contact rep about new line of tennis rackets.');
INSERT INTO SUPPLIER (name,address,city,stcode,zipcode,area,phone, productno ,amount, credit, remark)
VALUES ('EVERY MOUNTAIN', '574 SURRY RD.', 'CUPERTINO', 'CA', '93301', 408,
        '996-2323',8, 250, 10000,
        'CLIENT with high market share (23%) due to aggressive advertising.');
INSERT INTO SUPPLIER (name,address,city,stcode,zipcode,area,phone, productno ,amount, credit, remark)
VALUES ('K + T SPORTS', '3476 EL PASEO', 'SANTA CLARA', 'CA', '91003', 408,
        '376-9966',9, 625, 5000,
        'Tends to order large amounts of merchandise at once. Accounting is considering raising their credit limit. Usually pays on time.');
INSERT INTO SUPPLIER (name,address,city,stcode,zipcode,area,phone, productno ,amount, credit, remark)
VALUES ('SHAPE UP', '908 SEQUOIA', 'PALO ALTO', 'CA', '94301', 415,
        '364-9777',10, 280, 6000,
        'Support intensive. Orders small amounts (< 800) of merchandise at a time.');
INSERT INTO SUPPLIER (name,address,city,stcode,zipcode,area,phone, productno ,amount, credit, remark)
VALUES ('WOMEN SPORTS', 'VALCO VILLAGE', 'SUNNYVALE', 'CA', '93301', 408,
        '967-4398',1, 2000, 10000,
        'First sporting goods store geared exclusively towards women. Unusual promotion al style and very willing to take chances towards new PRODUCTs!');
INSERT INTO SUPPLIER (name,address,city,stcode,zipcode,area,phone, productno ,amount, credit, remark)
VALUES ('NORTH WOODS HEALTH AND FITNESS SUPPLY CENTER', '98 LONE PINE WAY', 'HIBBING', 'MN', '55649', 612,
        '566-9123',3, 800, 8000, '');
INSERT INTO SUPPLIER (name,address,city,stcode,zipcode,area,phone, productno ,amount, credit, remark)
VALUES ('SPRINGFIELD NUCLEAR POWER PLANT', '13 PERCEBE STR.', 'SPRINGFIELD', 'NT', '0000', 636,
        '999-6666', 4, 700,10000, '');



CREATE TABLE ORDERP  (id			SERIAL NOT NULL PRIMARY KEY,
                      supplierno	INTEGER,
                      orderdate		TIMESTAMPTZ,
                      amount		NUMERIC (12),
                      deliverydate	TIMESTAMPTZ,
                      cost			DECIMAL(12,2),
					  CONSTRAINT FK_SUPP FOREIGN KEY (supplierno) REFERENCES SUPPLIER(id) ON DELETE CASCADE
					  );



INSERT INTO ORDERP (supplierno,orderdate, amount,deliverydate,cost)
VALUES (5,'1987-01-07', 40, '1987-01-08', 1200);
INSERT INTO ORDERP (supplierno,orderdate, amount,deliverydate,cost)
VALUES (7,'1987-01-11',100,'1987-01-11', 12400);
INSERT INTO ORDERP (supplierno,orderdate, amount,deliverydate,cost)
VALUES (8,'1987-01-15',100, '1987-01-20', 4800);
INSERT INTO ORDERP (supplierno,orderdate, amount,deliverydate,cost)
VALUES (6,'1986-05-01',20, '1986-05-30',10960 );
INSERT INTO ORDERP (supplierno,orderdate, amount,deliverydate,cost)
VALUES (6,'1986-06-05', 50, '1986-06-20', 27400);
INSERT INTO ORDERP (supplierno,orderdate, amount,deliverydate,cost)
VALUES (10,'1986-06-15', 120, '1986-06-30', 2880);
INSERT INTO ORDERP (supplierno,orderdate, amount,deliverydate,cost)
VALUES (3,'1986-07-14', 130,  '1986-07-30', 5278);
INSERT INTO ORDERP (supplierno,orderdate, amount,deliverydate,cost)
VALUES (2,'1986-07-14',100, '1986-07-30', 1227.5);
INSERT INTO ORDERP (supplierno,orderdate, amount,deliverydate,cost)
VALUES (6,'1986-08-01', 100, '1986-08-15', 54800);
INSERT INTO ORDERP (supplierno,orderdate, amount,deliverydate,cost)
VALUES (7, '1986-07-18', 120,  '1986-07-18', 14880);
INSERT INTO ORDERP (supplierno,orderdate, amount,deliverydate,cost)
VALUES (8,'1986-07-25', 70, '1986-07-25', 560);
INSERT INTO ORDERP (supplierno,orderdate, amount,deliverydate,cost)
VALUES (3,'1986-06-05', 94, '1986-06-05', 3816.4);
INSERT INTO ORDERP (supplierno,orderdate, amount,deliverydate,cost)
VALUES (9, '1987-03-12', 100, '1987-03-12', 1600);
INSERT INTO ORDERP (supplierno,orderdate, amount,deliverydate,cost)
VALUES (9,'1987-02-01', 110, '1987-02-01', 1760);
INSERT INTO ORDERP (supplierno,orderdate, amount,deliverydate,cost)
VALUES (10,'1987-02-01', 125, '1987-02-05', 3000);
INSERT INTO ORDERP (supplierno,orderdate, amount,deliverydate,cost)
VALUES (6,'1987-02-03', 130, '1987-02-10', 71240);
INSERT INTO ORDERP (supplierno,orderdate, amount,deliverydate,cost)
VALUES (7,'1987-02-22', 200, '1987-02-04', 24800);
INSERT INTO ORDERP (supplierno,orderdate, amount,deliverydate,cost)
VALUES (10,'1987-02-05',125, '1987-03-03', 3000);
INSERT INTO ORDERP (supplierno,orderdate, amount,deliverydate,cost)
VALUES (7, '1987-02-01', 60, '1987-02-06', 7440);
INSERT INTO ORDERP (supplierno,orderdate, amount,deliverydate,cost)
VALUES (8, '1987-02-15', 85, '1987-03-06', 4080);
INSERT INTO ORDERP (supplierno,orderdate, amount,deliverydate,cost)
VALUES (10, '1987-03-15', 100, '1987-01-01', 2400);

COMMIT;






