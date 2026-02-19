# REGISTROS EXTERNOS

Registros externos - representam todos os dodos obtidos fora da realidade da escola

## Pessoas

Representa todas as pessoas física que estão vinculadas com a escola

```
CREATE TABLE "EXT_PESSOAS" 
(
	"Id"		INTEGER NOT NULL,
	"Nome"		TEXT NOT NULL,
	"DtNasc"	TEXT,
	"Sexo"		TEXT,

	PRIMARY KEY("Id" AUTOINCREMENT)
)
```

## Vinculos

1. Tabela destinada para registro de como as pessoas da tabela EXT_PESSOAS
2. No caso de pessoa física mapea vínculos famíliares

```
CREATE TABLE "EXT_PESS_VINC"
(
	"IdPess1"	INTEGER,
	"IdPess2"	INTEGER,
	"Tipo"		INTEGER,

	FOREIGN KEY("IdPess1")	REFERENCES "EXT_PESSOAS"("Id"),
	FOREIGN KEY("IdPess2")	REFERENCES "EXT_PESSOAS"("Id"),
	FOREIGN KEY("Tipo") 	REFERENCES "EXT_PESS_VINC_TIPO"("Id"),

	PRIMARY KEY("IdPessoa","IdAluno")
)
```

## Tipo
 
```
CREATE TABLE "EXT_PESS_VINC_TIPO"
(
	"Id"		INTEGER,
	"Descricao"	TEXT,

	PRIMARY KEY("Id" AUTOINCREMENT)
)

INSERT INTO EXT_PESS_VINC_TIPO (Descricao) VALUES ('Pai');
INSERT INTO EXT_PESS_VINC_TIPO (Descricao) VALUES ('Mãe');
INSERT INTO EXT_PESS_VINC_TIPO (Descricao) VALUES ('Tio(a)');
INSERT INTO EXT_PESS_VINC_TIPO (Descricao) VALUES ('Avô(ó)');
INSERT INTO EXT_PESS_VINC_TIPO (Descricao) VALUES ('Padrasto');
INSERT INTO EXT_PESS_VINC_TIPO (Descricao) VALUES ('Madrasta');
INSERT INTO EXT_PESS_VINC_TIPO (Descricao) VALUES ('Outro');
```