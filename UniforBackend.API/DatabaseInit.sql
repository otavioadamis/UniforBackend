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
	"Id", "Nome", "Email", "Matricula", "Foto", "Password", "Tipo", "Contato", "CriadoEm")
	VALUES ('Admin1', 'UsuarioAdminSQLscript', 'admin@admin.com', '123456789', '', '$2a$11$AFDxQBUYbazjRGIRW9yrQe4lIzfKoHWgd1OSWT9D6oBiQsC/Dhq36', 1, '123456789', CURRENT_TIMESTAMP);

INSERT INTO "Users"(
	"Id", "Nome", "Email", "Matricula", "Foto", "Password", "Tipo", "Contato", "CriadoEm")
	VALUES ('User1', 'Usuario1SQLscript', 'user@user.com', '987654321', '', '$2a$11$AFDxQBUYbazjRGIRW9yrQe4lIzfKoHWgd1OSWT9D6oBiQsC/Dhq36', 0, '987654321', CURRENT_TIMESTAMP);

INSERT INTO "Itens"(
	"Id", "Nome", "Descricao", "Preco", "IsVendido", "UserId", "isAprovado", "AceitaTroca", "PostadoEm", "SubCategoriaId", "MostrarContato")
	VALUES ('1', 'Camiseta', 'Camiseta de algodão', '50', false, 'User1', true, true, CURRENT_TIMESTAMP, '1', true);

INSERT INTO "Imagens"(
	"Id", "Extensao", "Index", "ItemId")
	VALUES ('1', 'jpg', '1', '1');	

INSERT INTO "Imagens"(
	"Id", "Extensao", "Index", "ItemId")
	VALUES ('2', 'jpg', '2', '1');	

INSERT INTO "Itens"(
	"Id", "Nome", "Descricao", "Preco", "IsVendido", "UserId", "isAprovado", "AceitaTroca", "PostadoEm", "SubCategoriaId", "MostrarContato")
	VALUES ('2', 'Bolsa', 'Bolsa de couro', '100', false, 'User1', true, true, CURRENT_TIMESTAMP, '4', false);

INSERT INTO "Imagens"(
	"Id", "Extensao", "Index", "ItemId")
	VALUES ('3', 'jpg', '1', '2');

INSERT INTO "Itens"(
	"Id", "Nome", "Descricao", "Preco", "IsVendido", "UserId", "isAprovado", "AceitaTroca", "PostadoEm", "SubCategoriaId", "MostrarContato")
	VALUES ('3', 'Livro', 'Livro de ficção', '30', false, 'User1', true, false, CURRENT_TIMESTAMP, '6', true);

INSERT INTO "Imagens"(
	"Id", "Extensao", "Index", "ItemId")
	VALUES ('4', 'jpg', '1', '3');

INSERT INTO "Imagens"(
	"Id", "Extensao", "Index", "ItemId")
	VALUES ('5', 'jpg', '2', '3');

INSERT INTO "Imagens"(
	"Id", "Extensao", "Index", "ItemId")
	VALUES ('6', 'jpg', '3', '3');

INSERT INTO "Itens"(
	"Id", "Nome", "Descricao", "Preco", "IsVendido", "UserId", "isAprovado", "AceitaTroca", "PostadoEm", "SubCategoriaId", "MostrarContato")
	VALUES ('4', 'Guitarra', 'Guitarra elétrica', '500', false, 'User1', false, true, CURRENT_TIMESTAMP, '7', true);

INSERT INTO "Imagens"(
	"Id", "Extensao", "Index", "ItemId")
	VALUES ('7', 'jpg', '1', '4');