# PEDAGÓGICO

## Classe

```
CREATE TABLE "PED_CLASSES" 
(
	"Id"		INTEGER,
	"Descricao"	TEXT NOT NULL,
	"IdEtapa	INTEGER,

	PRIMARY KEY("Id" AUTOINCREMENT)
    FOREIGN KEY("IdEtapa") REFERENCES "PED_CLASSES_ETAPA"("Id"),    
)
```

### Etapa

```
CREATE TABLE PED_CLASSES_ETAPA
(
    "Id"		INTEGER,
    "Descricao"	TEXT NOT NULL,

    PRIMARY KEY("Id" AUTOINCREMENT)
)

INSERT INTO PED_CLASSES_ETAPA ("Descricao") VALUES ('Ensino infantil');
INSERT INTO PED_CLASSES_ETAPA ("Descricao") VALUES ('Anos iniciais');
INSERT INTO PED_CLASSES_ETAPA ("Descricao") VALUES ('Anos finais');
INSERT INTO PED_CLASSES_ETAPA ("Descricao") VALUES ('Ensino médio');
```

## Turma

*Uma classe tem várias turmas*

```
CREATE TABLE "PED_TURMAS" 
(
	"Id"		INTEGER NOT NULL,
	"IdClasse"	INTEGER,
	"Turno"		INTEGER NOT NULL,
	"Ano"		INTEGER NOT NULL,
	"Descricao"	TEXT NOT NULL,
	
	PRIMARY KEY("Id" AUTOINCREMENT),
	FOREIGN KEY("IdClasse") REFERENCES "PED_CLASSES"("Id")
)
```

* *Turno*
0 - Manhã
1 - Vespertino
2 - Noturno

### Relacionamento entre Turma & Alunos

- *Uma turma tem vários alunos*
- *Um aluno pode estar em várias turmas*

```
CREATE TABLE "PED_TURMA_ALUNOS" 
(
	"Id"		INTEGER,
	"IdTurma"	INTEGER NOT NULL,
	"IdAluno"	INTEGER NOT NULL,
	
    PRIMARY KEY("IdTurma" "IdAluno"),
	
	FOREIGN KEY("IdAluno") REFERENCES "EXT_PESSOAS"("Id"),
	FOREIGN KEY("IdTurma") REFERENCES "PED_TURMAS"("Id")
)
```

## Disciplina

```
CREATE TABLE "PED_DISCIPLINAS" (
	"Id"			INTEGER NOT NULL,
	"Descricao"		TEXT NOT NULL,
	"DescricaoAbv"	TEXT NOT NULL,
	"Cor"			TEXT NOT NULL,

    PRIMARY KEY("Id" AUTOINCREMENT),
)
```

### Relacionamento entre Classe & Disciplinas

- *Uma classe tem está para várias disciplinas*
- *Assim como uma disciplina está para várias classes*

```
CREATE TABLE "PED_CLASS_DISC" 
(
	"Id"			INTEGER,
    "IdClasse"		INTEGER NOT NULL,
    "IdDisciplina"	INTEGER NOT NULL,

    PRIMARY KEY ("IdClasse", "IdDisciplina"),

    FOREIGN KEY("IdClasse")     REFERENCES "PED_CLASSES"("Id"),
    FOREIGN KEY("IdDisciplina") REFERENCES "PED_DISCIPLINAS"("Id")
)

```

### Relacionamento entre Disciplinas e professores

- *Uma disciplina está para vários professores*
- *Um professor está para vários disciplinas*

```
CREATE TABLE "PED_DISC_PROF" 
(
    "Id"			INTEGER,
    "IdDisciplina"	INTEGER NOT NULL,
    "IdProfessor"	INTEGER NOT NULL,	

    PRIMARY KEY ("IdDisciplina", "IdProfessor"),

    FOREIGN KEY("IdDisciplina") REFERENCES "PED_DISCIPLINAS"("Id")
	FOREIGN KEY("IdProfessor")	REFERENCES "EXT_PESSOAS"("Id")
)
```
  