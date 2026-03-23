# Pedagógico

- PED_Classe

  - IdClasse
  - Descricao
  - Nivel: 0 - Fundamental I; 1 - Fundamental II; 2 - Médio

- PED_Turma

  - IdTurma
  - IdClasse
  - Descricao
  - AnoLetivo
  - Turno: 0 - Matutino; 1 - Vespertino; 2 - Noturno; 3 - Integral
  - CapMaxima

- PED_TurmaAluno
    
  - IdTurma
  - IdAluno
  - Status: 0 - Ativo; 1 - Trancado; 2 - Transferido

- PED_Disciplina
  
  - IdDisciplina
  - Descricao
  - Abreviado

- PED_ClasseDisc
  
  - IdClasse
  - IdDisciplina

- PED_DiscProf

  - IdDiscProf
  - IdDisciplina
  - IdProfessor

- Ped_Grade

  - IdGrade
  - IdTurma
  - DiaSemana: 0 - Domingo; ... ; 6 - Sábado
  - Inicio: 00:00
  - Fim: 00:00
  - Tipo: 0 - Aula; 1 - Intervalo

- Ped_Aula

  - IdAula
  - IdGrade
  - IdDiscProf
  - DataAula
  - HoraAula
  - Status: 0 - Realizada; 1 - Cancelada; 2 - Substituída

- Ped_Frequencia

  - IdAula
  - IdAluno
  - Status: 0 - Presente; 1 - Falta; 3 - Justificada    