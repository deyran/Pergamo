# Pedagógico

## Organização 

## Organização 

- PED_ORG_Classe

  - IdClasse
  - Descricao
  - Nivel: 0 - Fundamental I; 1 - Fundamental II; 2 - Médio

- PED_ORG_Turma

  - IdTurma
  - IdClasse
  - Descricao
  - AnoLetivo
  - Turno: 0 - Matutino; 1 - Vespertino; 2 - Noturno; 3 - Integral
  - CapMaxima

- PED_ORG_TurmaAluno
    
  - IdTurma
  - IdAluno
  - Status: 0 - Ativo; 1 - Trancado; 2 - Transferido

- PED_ORG_Disciplina
  
  - IdDisciplina
  - Descricao
  - Abreviado

- PED_ORG_DiscProf

  - IdDiscProf
  - IdDisciplina
  - IdProfessor

- PED_ORG_Grade: Planejamento de horários da turma

  - IdGrade
  - IdTurma
  - DiaSemana: 0 - Domingo; ... ; 6 - Sábado
  - Inicio: 00:00
  - Fim: 00:00
  - Tipo: 0 - Aula; 1 - Intervalo

- PED_ORG_GradeAula: Planejamento de horários das aulas e professor. Somente Grade do tipo 0
  
  - IdGradeAula	
  - IdGrade
  - IdDiscProf

- PED_ORG_Aula: Registro de aulas de fato executadas

  - IdAula
  - IdGradeAula: Aula Planejada
  - IdDiscProf: Aula realizada
  - DataAula
  - HoraAula
  - StatusAula: 0 - Presencial; 1 - Ead; 2 - Externa;

- PED_ORG_Frequencia: OBS: O não registro de aluna implica em falta 

  - IdAula
  - IdAluno
  - StatusFreq: 0 - Presente; 1 - Justificado