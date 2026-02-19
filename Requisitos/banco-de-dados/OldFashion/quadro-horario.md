# Grade Horário

## Cadastro de unidade

*Não contemplado nesta fase*

## Cadastro das disciplinas
   
Já contemplado no esquema **pedagógico**
   
## Relação professor e disciplina

Já contemplado no esquema **pedagógico**
   
## Cadastro da grade currícular das turmas

Já contemplado no esquema **pedagógico**

## Gestão de horário das turmas

*Uma turma tem vários horários*

GRD_Horario
Id  |IdTurma    |Inicio |Fim    |Tipo
0   |0          |07:00  |08:00  |0 (Aula)
1   |0          |08:00  |09:00  |0 (Aula)
2   |0          |09:00  |09:20  |1 (Intervalo)
3   |0          |09:20  |10:20  |0 (Aula)
4   |0          |10:20  |11:20  |0 (Aula)

*O mesmo horário se repete me vários dias da semana*

GRD_HorarioSemana
Id  |IdHorario      |Semana
0   |0 (07:00-08:00)|1 (Segunda)
1   |0 (07:00-08:00)|2 (Terça)
2   |0 (07:00-08:00)|3 (Quarta)
3   |0 (07:00-08:00)|4 (Quinta)
4   |0 (07:00-08:00)|5 (Sexta)

5   |1 (08:00-09:00)|1 (Segunda)
6   |1 (08:00-09:00)|2 (Terça)
7   |1 (08:00-09:00)|3 (Quarta)
8   |1 (08:00-09:00)|4 (Quinta)
9   |1 (08:00-09:00)|5 (Sexta)

GRD_Semana
Id  |Descricao      |DescAbv
0   |Domingo        |Domingo
1   |Segunda-feira  |Segunda
2   |Terça-feira    |Terça
3   |Quarta-feira   |Quarta
4   |Quinta-feira   |Quinta
5   |Sexta-feira    |Sexta
6   |Sábado         |Sábado

## Gestão de horário disponibilizado pelo professor

GRD_Horario |Disponibilidade
IdHSem      |idProfessor
0           |0

## Gestão de horário, Turma, Disciplina e Professor

GRD_HorarioDisciplina
IdHSem  |idDisciplina   |idProfessor
0       |0              |0