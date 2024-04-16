INSERT INTO "Categorias"(
	"Id", "Nome")
	VALUES ('1', 'Roupas');

INSERT INTO "SubCategorias"(
	"Id", "Nome", "CategoriaId")
	VALUES ('1', 'Masculino', '1');

INSERT INTO "SubCategorias"(
	"Id", "Nome", "CategoriaId")
	VALUES ('2', 'Feminino', '1');

INSERT INTO "Users"(
	"Id", "Nome", "Email", "Matricula", "Foto", "Password", "Tipo", "Contato", "CriadoEm")
	VALUES ('Admin1', 'UsuarioAdminSQLscript', 'admin@admin', '123456789', '', '$2a$11$AFDxQBUYbazjRGIRW9yrQe4lIzfKoHWgd1OSWT9D6oBiQsC/Dhq36', 1, '123456789', CURRENT_TIMESTAMP);