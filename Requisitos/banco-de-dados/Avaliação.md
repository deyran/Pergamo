# Pergamo - Banco de Dados
## Processo de Avaliação

### Projeto

- *AVA_MP*: Avaliação Mapa de Notas

- *AVA_MP_Etapa*

  - IdMpEtapa (PK)
  - Descricao

    IdMpEtapa | Descricao
    0         | 1º Avaliação
    1         | 2º Avaliação
    2         | Recuperação Paralela
    3         | 3 Avaliação
    4         | 4 Avaliação
    5         | Recuperação Final

- *AVA_MP_Avaliacao*

  - IdAva       (PK)
  - IdMpEtapa   (FK): IdMpEtapa - AVA_MP_Etapa
  - IdDiscProf  (FK): IdDiscProf - PED_DiscProf
  - IdTurma     (FK): IdTurma - PED_Turma
  - IdAvaDesc   (FK): IdAvaDesc - AVA_MP_AvaliacaoDesc
  - DataAva

  IdAva | IdMpEtapa       | IdDiscProf            | IdTurma         | IdAvaDesc | DataAva
  0     | 0 (1º Avaliação)| 1 (Marcos-Português)  | 0 (9º ano-2026) | 5 (Sarau) | 10-04-26


- *AVA_MP_AvaliacaoDesc*: *IdAvaDesc-AVA_MP_Avaliacao*

  - IdAvaDesc (PK)
  - Descricao

    IdAvaDesc | Descricao
    0         | Atividades em sala
    1         | Atividades Livro
    2         | Atividades Caderno
    3         | Seminário
    4         | Trabalhos Escrito
    5         | Sarau Literário
    6         | Mostra Folclórica
    7         | Jogos Internos
    8         | Feira de Geociências
    9         | Feira do Empreendedorismo
    10        | Prova Escrita
    11        | Simulado

- *AVA_MP_AvaliacaoItens*

  - IdAvaItens      (PK)
  - IdAva           (FK): IdAva - AVA_MP_Avaliacao
  - IdAvaItensDesc  (FK): IdAvaItensDesc - AVA_MP_AvaliacaoItensDesc
  
- *AVA_MP_AvaliacaoItensDesc*
  
  - IdAvaItensDesc (PK)
  - Descricao

    IdAvaItensDesc | Descricao
    0              | Expressão Oral
    1              | Criatividade
    2              | Participação
    3              | Trabalho em Equipe

- *AVA_MP_AvaliacaoAluno* 

  - IdAva   (PK): IdAva - AVA_MP_Avaliacao
  - idAluno (PK): IdPessoa - ADM_Pessoa
  - NotaAva     : É a consolidação NotaItem-AVA_MP_AvaliacaoItensAluno, se houver

- *AVA_MP_AvaliacaoItensAluno*
  
  - IdAvaItens  (PK): IdAvaItens - AVA_MP_AvaliacaoItens
  - idAluno     (PK): IdPessoa - ADM_Pessoa
  - NotaItem

- *AVA_MP_Aluno*: Mapa de Notas do Aluno

    - IdMpAluno       : AutoIncremento
    - IdMpEtapa   (PK): IdMpEtapa - AVA_MP_Etapa
    - idAluno     (PK): IdPessoa - ADM_Pessoa
    - IdDiscProf  (PK): IdDiscProf - PED_DiscProf
    - IdTurma     (PK): IdTurma - PED_Turma
    - NotaFinal       : É consolidação NotaAva - AVA_MP_AvaliacaoAluno

- *AVA_MP_Boletim*: Mapa de Notas do Aluno

  - IdMpAluno (FK): IdMpAluno - AVA_MP_Aluno
  - Situacao      : 0 - Em andamento; 1 - Aprovado; 2 - Reprovado
    
### SQL - SQLite

CREATE TABLE AVA_MP_Etapa (
  IdMpEtapa INTEGER PRIMARY KEY,
  Descricao TEXT NOT NULL
);

INSERT INTO AVA_MP_Etapa (IdMpEtapa, Descricao) VALUES
(0, '1º Avaliação'),
(1, '2º Avaliação'),
(2, 'Recuperação Paralela'),
(3, '3º Avaliação'),
(4, '4º Avaliação'),
(5, 'Recuperação Final');

-- #######################################################################

CREATE TABLE AVA_MP_Avaliacao (
    IdAva       INTEGER PRIMARY KEY AUTOINCREMENT,
    IdMpEtapa   INTEGER NOT NULL,
    IdDiscProf  INTEGER NOT NULL,
    IdTurma     INTEGER NOT NULL,
    IdAvaDesc   INTEGER NOT NULL,
    DataAva     DATE,
    
    -- Definição das Chaves Estrangeiras (FK)
    FOREIGN KEY (IdMpEtapa)  REFERENCES AVA_MP_Etapa(IdMpEtapa),
    FOREIGN KEY (IdDiscProf) REFERENCES PED_DiscProf(IdDiscProf),
    FOREIGN KEY (IdTurma)    REFERENCES PED_Turma(IdTurma),
    FOREIGN KEY (IdAvaDesc)  REFERENCES AVA_MP_AvaliacaoDesc(IdAvaDesc)
);

-- #######################################################################

CREATE TABLE AVA_MP_AvaliacaoDesc (
    IdAvaDesc INTEGER PRIMARY KEY,
    Descricao TEXT NOT NULL
);

INSERT INTO AVA_MP_AvaliacaoDesc (IdAvaDesc, Descricao) VALUES 
(0, 'Atividades em sala'),
(1, 'Atividades Livro'),
(2, 'Atividades Caderno'),
(3, 'Seminário'),
(4, 'Trabalhos Escrito'),
(5, 'Sarau Literário'),
(6, 'Mostra Folclórica'),
(7, 'Jogos Internos'),
(8, 'Feira de Geociências'),
(9, 'Feira do Empreendedorismo'),
(10, 'Prova Escrita'),
(11, 'Simulado');

-- #######################################################################

CREATE TABLE AVA_MP_AvaliacaoItens (
    IdAvaItens     INTEGER PRIMARY KEY AUTOINCREMENT,
    IdAva          INTEGER NOT NULL,
    IdAvaItensDesc INTEGER NOT NULL,
    FOREIGN KEY (IdAva) REFERENCES AVA_MP_Avaliacao(IdAva),
    FOREIGN KEY (IdAvaItensDesc) REFERENCES AVA_MP_AvaliacaoItensDesc(IdAvaItensDesc)
);

-- #######################################################################

CREATE TABLE AVA_MP_AvaliacaoItensDesc (
    IdAvaItensDesc INTEGER PRIMARY KEY,
    Descricao TEXT NOT NULL
);

INSERT INTO AVA_MP_AvaliacaoItensDesc (IdAvaItensDesc, Descricao) VALUES 
(0, 'Expressão Oral'), 
(1, 'Criatividade'),
(2, 'Participação'),
(3, 'Trabalho em Equipe');

-- #######################################################################

CREATE TABLE AVA_MP_AvaliacaoAluno (
    IdAva     INTEGER NOT NULL,
    idAluno   INTEGER NOT NULL,
    NotaAva   REAL, -- Usamos REAL para notas decimais (float)
    
    -- Definição da Chave Primária Composta
    PRIMARY KEY (IdAva, idAluno),
    
    -- Definição das Chaves Estrangeiras
    FOREIGN KEY (IdAva) REFERENCES AVA_MP_Avaliacao(IdAva),
    FOREIGN KEY (idAluno) REFERENCES ADM_Pessoa(IdPessoa)
);

-- #######################################################################

CREATE TABLE AVA_MP_AvaliacaoItensAluno (
    IdAvaItens  INTEGER NOT NULL,
    idAluno     INTEGER NOT NULL,
    NotaItem    REAL, -- Nota individual de cada item (ex: Criatividade, Participação)

    -- Definição da Chave Primária Composta (Garante que um aluno não tenha duas notas para o mesmo item)
    PRIMARY KEY (IdAvaItens, idAluno),

    -- Definição das Chaves Estrangeiras
    FOREIGN KEY (IdAvaItens) REFERENCES AVA_MP_AvaliacaoItens(IdAvaItens),
    FOREIGN KEY (idAluno) REFERENCES ADM_Pessoa(IdPessoa)
);

-- #######################################################################

CREATE TABLE AVA_MP_Aluno (
    IdMpAluno    INTEGER PRIMARY KEY AUTOINCREMENT,
    IdMpEtapa    INTEGER NOT NULL,
    idAluno      INTEGER NOT NULL,
    IdDiscProf   INTEGER NOT NULL,
    IdTurma      INTEGER NOT NULL,
    NotaFinal    REAL, -- Consolidação das notas das avaliações

    -- Definição da Chave Primária Composta (Regra de Negócio)
    -- Nota: No SQLite, se IdMpAluno é PRIMARY KEY AUTOINCREMENT, 
    -- usamos uma restrição UNIQUE para garantir a composição PK descrita
    UNIQUE (IdMpEtapa, idAluno, IdDiscProf, IdTurma),

    -- Definição das Chaves Estrangeiras
    FOREIGN KEY (IdMpEtapa)  REFERENCES AVA_MP_Etapa(IdMpEtapa),
    FOREIGN KEY (idAluno)    REFERENCES ADM_Pessoa(IdPessoa),
    FOREIGN KEY (IdDiscProf) REFERENCES PED_DiscProf(IdDiscProf),
    FOREIGN KEY (IdTurma)    REFERENCES PED_Turma(IdTurma)
);