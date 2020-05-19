CREATE TABLE Products (
	Id_products INT PRIMARY KEY,
	"Name_products" TEXT
);

INSERT INTO Products
VALUES
	(1, 'Колбаса'),
	(2, 'Молоко'),
	(3, 'Хлеб'),
	(4, 'Мыло'),
	(5, 'Шампунь'),
	(6, 'Мочалка'),
	(7, 'Лампочка'),
	(8, 'Стул'),
	(9, 'Чипсы'),
	(10, 'Рыбка'),
	(11, 'Сухарики');
	

CREATE TABLE Categories (
	Id_categories INT PRIMARY KEY,
	"Name_categories" TEXT
);

INSERT INTO Categories
VALUES
	(1, 'Продукты питания'),
	(2, 'Бытовая химия'),
	(3, 'К пиву');
	

CREATE TABLE ProductCategories (
	ProductId INT FOREIGN KEY REFERENCES Products(Id_products),
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id_categories),
	PRIMARY KEY (ProductId, CategoryId)
);

INSERT INTO ProductCategories
VALUES
	(1, 1),
	(2, 1),
	(3, 1),
	(4, 2),
	(5, 2),
	(6, 2),
	(9, 1),
	(10, 1),
	(11, 1),
	(9, 3),
	(10, 3),
	(11, 3);

SELECT P."Name_products", C."Name_categories"
FROM Products P
LEFT JOIN ProductCategories PC
	ON P.Id_products = PC.ProductId
LEFT JOIN Categories C
	ON PC.CategoryId = C.Id_categories;