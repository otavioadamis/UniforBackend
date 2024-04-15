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
	VALUES ('Admin1', 'UsuarioAdminSQLscript', 'adminteste@teste', '1234', '', '1234', 1, '1234', CURRENT_TIMESTAMP);