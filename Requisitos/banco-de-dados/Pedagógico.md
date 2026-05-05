# Pergamo - Banco de Dados
## Organização pedagógica

### Projeto

- *PED_Classe*

  - IdClasse: AutoIncremento
  - Descricao
  - Nivel: 0 - Fundamental I; 1 - Fundamental II; 2 - Médio

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
    
  - IdTurma PK: IdTurma-PED_Turma
  - IdAluno PK: IdPessoa-ADM_Pessoa
  - Status:
  
      0: Matrículado; 
      1: Trancado;
      2: Transferido;

- PED_Disciplina
  
  - IdDisciplina
  - Descricao
  - Abreviado

- PED_DiscProf

  - IdDiscProf
  - IdDisciplina
  - IdProfessor

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
  - IdDiscProf

- PED_Aula: Registro de aulas de fato executadas

  - IdAula
  - IdGradeAula: Aula Planejada
  - IdDiscProf: Aula realizada
  - DataAula
  - HoraAula
  - StatusAula: 0 - Presencial; 1 - Ead; 2 - Externa;

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
