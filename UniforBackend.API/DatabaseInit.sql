--Roupas

INSERT INTO "Categorias"(
	"Id", "Nome")
	VALUES ('1', 'Roupas');

INSERT INTO "SubCategorias"(
	"Id", "Nome", "CategoriaId")
	VALUES ('1', 'Roupas Masculinas', '1');

INSERT INTO "SubCategorias"(
	"Id", "Nome", "CategoriaId")
	VALUES ('2', 'Roupas Femininas', '1');

--Acessorios

INSERT INTO "Categorias"(
	"Id", "Nome")
	VALUES ('2', 'Acessorios');

INSERT INTO "SubCategorias"(
	"Id", "Nome", "CategoriaId")
	VALUES ('3', 'Acessorios Bijouteria', '2');

INSERT INTO "SubCategorias"(
	"Id", "Nome", "CategoriaId")
	VALUES ('4', 'Acessorios Bolsas', '2');

--Eletronicos

INSERT INTO "Categorias"(
	"Id", "Nome")
	VALUES ('3', 'Eletronicos');

INSERT INTO "SubCategorias"(
	"Id", "Nome", "CategoriaId")
	VALUES ('5', 'Eletronicos', '3');

--Livros

INSERT INTO "Categorias"(
	"Id", "Nome")
	VALUES ('4', 'Livros');

INSERT INTO "SubCategorias"(
	"Id", "Nome", "CategoriaId")
	VALUES ('6', 'Livros', '4');

--Instrumentos

INSERT INTO "Categorias"(
	"Id", "Nome")
	VALUES ('5', 'Instrumentos');

INSERT INTO "SubCategorias"(
	"Id", "Nome", "CategoriaId")
	VALUES ('7', 'Instrumentos', '5');

--Artigos de casa

INSERT INTO "Categorias"(
	"Id", "Nome")
	VALUES ('6', 'Artigos Casa');

INSERT INTO "SubCategorias"(
	"Id", "Nome", "CategoriaId")
	VALUES ('8', 'Artigos Casa', '6');

-- Pré-populando

INSERT INTO "Users"(
	"Id", "Nome", "Email", "Matricula", "Foto", "Password", "Tipo", "Contato", "CriadoEm", "IsVerificado", "CodigoVerificacao")
	VALUES ('Admin1', 'UsuarioAdminSQLscript', 'admin@admin.com', '123456789', '', '$2a$11$AFDxQBUYbazjRGIRW9yrQe4lIzfKoHWgd1OSWT9D6oBiQsC/Dhq36', 1, '123456789', CURRENT_TIMESTAMP, true, 'admin');

