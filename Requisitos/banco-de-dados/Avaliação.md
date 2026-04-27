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
  - IdMpEtapa   (FK): IdMpEtapa-AVA_MP_Etapa
  - IdDiscProf  (FK): IdDiscProf-PED_DiscProf
  - IdTurma     (FK): IdTurma-PED_Turma
  - IdAvaDesc   (FK): IdAvaDesc-AVA_MP_AvaliacaoDesc
  - DataAva

  IdAva | IdMpEtapa       | IdDiscProf            | IdTurma         | IdAvaDesc | DataAva
  0     | 0 (1º Avaliação)| 1 (Marcos-Português)  | 0 (9º ano-2026) | 5 (Sarau) | 10-04-26


- *AVA_MP_AvaliacaoDesc*

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

  - IdAvaItens (PK)
  - IdAva: IdAva-AVA_MP_Avaliacao
  - IdAvaItensDesc: 0 - Expressão Oral
  
- *AVA_MP_AvaliacaoItensDesc*
  
  - IdAvaItensDesc (PK)
  - Descricao

    IdAvaItensDesc | Descricao
    0              | Expressão Oral
    1              | Criatividade
    2              | Participação
    3              | Trabalho em Equipe

- *AVA_MP_AvaliacaoAluno* 

  - IdAva (PK): 1º Avaliação | Marcos-Português | 9º Ano-2026 | Sarau Literário
  - idAluno (PK): 0-Rannyere Costa
  - NotaAva: É a consolidação NotaItem-AVA_MP_AvaliacaoItensAluno, se houver

- *AVA_MP_AvaliacaoItensAluno*
  
  - IdAvaItens (PK)
  - idAluno (PK): IdPessoa - Pessoa
  - NotaItem

- *AVA_MP_Aluno* 

    - IdMapa: Autoincremente
    - IdMpEtapa (PK): 0-1º Avaliação
    - idAluno (PK): 0-Rannyere Costa
    - IdDiscProf (PK): Marcos | Português
    - IdTurma (PK): 9º Ano | 2026
    - NotaFinal: É consolidação NotaAva-AVA_MP_AvaliacaoAluno
  
  
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