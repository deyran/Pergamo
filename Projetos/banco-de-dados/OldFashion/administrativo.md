# ADMINISTRATIVO

Registro de processos administrativos

```
CREATE TABLE "ADM_EMPREGADOS" (
	"IdFuncao"	INTEGER NOT NULL,
	"IdPessoa"	INTEGER NOT NULL,
	"Ativo"	INTEGER,
	FOREIGN KEY("IdPessoa") REFERENCES "EXT_PESSOAS"("Id"),
	FOREIGN KEY("IdFuncao") REFERENCES "ADM_FUNCAO"("Id"),
	PRIMARY KEY("IdFuncao","IdPessoa")
)
```

* ADM_FUNCAO - Cargo ou função dos empregados da escola

```
CREATE TABLE "ADM_FUNCAO" (
	"Id"	INTEGER NOT NULL,
	"Descricao"	TEXT NOT NULL,
	PRIMARY KEY("Id" AUTOINCREMENT)
)
```

