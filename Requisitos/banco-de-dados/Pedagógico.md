# Pergamo - Banco de Dados
## Organização pedagógica

### Projeto

- *PED_Classe*

  - IdClasse: AutoIncremento
  - Descricao
  - Nivel: 0 - Fundamental I; 1 - Fundamental II; 2 - Médio

- *PED_Disciplina*
  
  - IdDisciplina (PK)
  - CategoriaMec
  - Descricao
  - Abreviado

- *PED_Turma*

  - IdTurma
  - IdClasse: IdClasse-PED_Classe
  - Descricao
  - AnoLetivo
  - Turno: 
      0: Matutino; 
      1: Vespertino; 
      2: Noturno; 
      3: Integral;
  - CapMaxima

- *PED_TurmaAluno*
    
  - IdTurma (PK): IdTurma-PED_Turma
  - IdAluno (PK): IdPessoa-ADM_Pessoa
  - Status:
  
      0: Matrículado; 
      1: Trancado;
      2: Transferido;

- *PED_TurmaProfessor*

  - IdTurmaProf       : AutoIncremento
  - IdTurma       (PK): IdTurma-PED_Turma
  - IdProfessor   (PK): IdPessoa-ADM_Pessoa
  - IdDisciplina  (PK): IdDisciplina-PED_Disciplina
  
- PED_Grade: Planejamento de horários da turma

  - IdGrade
  - IdTurma
  - DiaSemana: 0 - Domingo; ... ; 6 - Sábado
  - Inicio: 00:00
  - Fim: 00:00
  - Tipo: 0 - Aula; 1 - Intervalo

- PED_GradeAula: Planejamento de horários das aulas e professor. Somente Grade do tipo 0
  
  - IdGradeAula	
  - IdGrade
  - IdProfessor
  - IdDisciplina

- PED_Aula: Registro de aulas de fato executadas

  - IdAula
  - IdGradeAula : Aula Planejada
  - IdProfessor : Aula realizada
  - IdDisciplina: Aula realizada
  - DataAula
  - HoraAula
  - StatusAula  : 0 - Presencial; 1 - Ead; 2 - Externa;

- PED_Frequencia: OBS: O não registro de aluna implica em falta 

  - IdAula
  - IdAluno
  - StatusFreq: 0 - Presente; 1 - Justificado

### SQL

- *PED_Classe*

  CREATE TABLE PED_Classe (
      IdClasse  INTEGER PRIMARY KEY AUTOINCREMENT,
      Descricao TEXT NOT NULL,
      -- Nível conforme a legenda: 0 - Fundamental I, 1 - Fundamental II, 2 - Médio
      Nivel     INTEGER CHECK(Nivel IN (0, 1, 2))
  );

  INSERT INTO PED_Classe (Descricao, Nivel) VALUES 
  ('Jardim I', 0),
  ('Jardim II', 0),
  ('1º Ano', 0),
  ('2º Ano', 0),
  ('3º Ano', 0),
  ('4º Ano', 0),
  ('5º Ano', 0),
  ('6º Ano', 1),
  ('7º Ano', 1),
  ('8º Ano', 1),
  ('9º Ano', 1),
  ('1º Ano Médio', 2),
  ('2º Ano Médio', 2),
  ('3º Ano Médio', 2);

- *PED_Turma*

  CREATE TABLE PED_Turma (
      IdTurma      INTEGER PRIMARY KEY AUTOINCREMENT,
      IdClasse     INTEGER,
      Descricao    TEXT NOT NULL,
      AnoLetivo    INTEGER NOT NULL,
      -- Turno conforme a legenda: 0:Matutino, 1:Vespertino, 2:Noturno, 3:Integral
      Turno        INTEGER CHECK(Turno BETWEEN 0 AND 3),
      CapMaxima    INTEGER,
      FOREIGN KEY (IdClasse) REFERENCES PED_Classe (IdClasse)
  );

  INSERT INTO PED_Turma (IdClasse, Descricao, AnoLetivo, Turno, CapMaxima) VALUES 
  (1, 'JD I', 2026, 0, 15),
  (2, 'JD II', 2026, 0, 15),
  (3, '1A', 2026, 0, 15),
  (4, '2A', 2026, 0, 15),
  (5, '3A', 2026, 0, 15),
  (6, '4A', 2026, 0, 15),
  (7, '5A', 2026, 0, 15),
  (8, '6A', 2026, 0, 15),
  (9, '7A', 2026, 0, 15),
  (10, '8A', 2026, 0, 15),
  (11, '9A', 2026, 0, 15),
  (12, '1M', 2026, 0, 15),
  (13, '2M', 2026, 0, 15),
  (14, '3M', 2026, 0, 15);

- *PED_TurmaAluno*

  CREATE TABLE PED_TurmaAluno (
    IdTurma  INTEGER,
    IdAluno  INTEGER,
    -- Status: 0: Matriculado, 1: Trancado, 2: Transferido
    Status   INTEGER DEFAULT 0 CHECK(Status IN (0, 1, 2)),
    
    -- Definição da Chave Primária Composta
    PRIMARY KEY (IdTurma, IdAluno),
    
    -- Definição das Chaves Estrangeiras (Relacionamentos)
    FOREIGN KEY (IdTurma) REFERENCES PED_Turma (IdTurma),
    FOREIGN KEY (IdAluno) REFERENCES ADM_Pessoa (IdPessoa)
  );

  SELECT 
      C.Descricao AS Classe,
      T.Descricao AS Turma,
      P.Nome AS Aluno,
      T.AnoLetivo,
      CASE TA.Status 
          WHEN 0 THEN 'Matriculado'
          WHEN 1 THEN 'Trancado'
          WHEN 2 THEN 'Transferido'
      END AS Status_Matricula
  FROM PED_TurmaAluno TA
  INNER JOIN PED_Turma T ON TA.IdTurma = T.IdTurma
  INNER JOIN PED_Classe C ON T.IdClasse = C.IdClasse
  INNER JOIN ADM_Pessoa P ON TA.IdAluno = P.IdPessoa
  ORDER BY 
      T.Descricao ASC, 
      P.Nome ASC;


- *PED_Disciplina*

  CREATE TABLE PED_Disciplina (
      IdDisciplina INTEGER PRIMARY KEY AUTOINCREMENT,
      CategoriaMec TEXT NOT NULL,
      Descricao    TEXT NOT NULL,
      Abreviado    TEXT NOT NULL
  );

  INSERT INTO PED_Disciplina (CategoriaMec, Descricao, Abreviado) VALUES 
  ('Ciências da Natureza', 'Ciências físicas e biológicas', 'CFB'),
  ('Ciências Humanas', 'Filosofia', 'Filosofia'),
  ('Ciências Humanas', 'Geografia', 'Geografia'),
  ('Ciências Humanas', 'História', 'História'),
  ('Ciências Humanas', 'Sociologia', 'Sociologia'),
  ('Diversificado', 'Educação financeira', 'E. Financeira'),
  ('Diversificado', 'Empreendedorismo', 'Empreend.'),
  ('Diversificado', 'Estudos amazônicos', 'E. Amazônicos'),
  ('Diversificado', 'Laboratório', 'Laboratório'),
  ('Ensino Religioso', 'Ensino religioso', 'Religião'),
  ('Linguagens', 'Artes', 'Artes'),
  ('Linguagens', 'Educação física', 'E. Física'),
  ('Linguagens', 'Língua Inglesa', 'Inglês'),
  ('Linguagens', 'Língua portuguesa', 'Português'),
  ('Linguagens', 'Literatura', 'Literatura'),
  ('Linguagens', 'Música', 'Música'),
  ('Linguagens', 'Redação', 'Redação'),
  ('Pedagogia', 'Pedagogia', 'Pedagogia'),
  ('Matemática', 'Matemática', 'Matemática');

  SELECT * FROM PED_Disciplina;

- *PED_DiscProf*

  CREATE TABLE PED_DiscProf (
      IdDiscProf  INTEGER PRIMARY KEY AUTOINCREMENT,
      IdDisciplina INTEGER NOT NULL,
      IdProfessor  INTEGER NOT NULL,
      -- Garantindo que o mesmo professor não seja vinculado duas vezes à mesma disciplina
      UNIQUE(IdDisciplina, IdProfessor),
      FOREIGN KEY (IdDisciplina) REFERENCES PED_Disciplina (IdDisciplina),
      FOREIGN KEY (IdProfessor) REFERENCES ADM_Pessoa (IdPessoa)
  );
  -- ========================================================================

  INSERT INTO PED_DiscProf (IdProfessor, IdDisciplina) VALUES 
  (99, 19),  -- Karla Cristina De Araújo Reis -> Matemática
  (100, 1),  -- Lauro Alcides Cordeiro Neto -> Ciências físicas e biológicas
  (101, 15), -- Israel Henrique Cavalcante Mendonça -> Literatura
  (102, 3),  -- Michelle Gomes Garcia Fernandes Prestes -> Geografia
  (103, 4),  -- Luciano Almeida Da Silva -> História
  (109, 19), -- Sara Machado De Souza -> Matemática
  (110, 13), -- Isabela Cristina De Matos Fernandes -> Língua Inglesa
  (111, 14), -- Marcos Henrique De Oliveira Zanotti Rosi -> Língua portuguesa
  (104, 18), -- Josiani Melo Monteiro -> Pedagogia
  (105, 18), -- Maria Do Socorro Santos Raiol -> Pedagogia
  (107, 18), -- Janete Bentes Pereira -> Pedagogia
  (108, 18), -- Ana Claudia Santos Cruz -> Pedagogia
  (112, 12); -- William Lima Pereira -> Educação física  
  -- ========================================================================

  SELECT 
    P.Nome AS Professor,
    D.Descricao AS Disciplina
  FROM PED_DiscProf DP
  INNER JOIN ADM_Pessoa P ON DP.IdProfessor = P.IdPessoa
  INNER JOIN PED_Disciplina D ON DP.IdDisciplina = D.IdDisciplina
  ORDER BY P.Nome ASC, D.Descricao ASC;
