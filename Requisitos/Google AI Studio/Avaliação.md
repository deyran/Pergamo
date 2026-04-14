# Pergamo - Requisitos - Google AI Studio
## Processo de Avaliação

- **Visão Geral**

  - 4 Etapas de avaliação.
  - Estado da avaliação: Elaboração, Produção e Execução.
  - Atores envolvidos: Aluno, Professor, Secretária e Diretoria.
  - Processos: Mapa de Notas e Boletim
  
- **Principais Tabelas**
  
  - Pessoa: Alunos, Professores, Usuários do Sistema
    
    - Pessoa
        
      - IdPessoa
      - Nome
      - CPF

  - Turma-Aluno
    
    - Turma
      
      - IdTurma
      - Descricao
      - AnoLetivo

    - TurmaAluno
        
      - IdTurma
      - IdAluno: IdPessoa
      - Status: 
        
            0: Ativo
            1: Trancado
            2: Transferido

  - Disciplina-Professor
  
    - Disciplina
      
      - IdDisciplina
      - Descricao
  
    - DisciplinaProf

      - IdDiscProf
      - IdDisciplina
      - IdProfessor: IdPessoa

  - Mapa de Nota
    
    - MapaNota
    
      - IdMapaNota
      - IdTurma
      - IdDiscProf
      - Etapa: 
            0: 1º Avaliação
            1: 2º Avaliação
            2: Recuperação Paralela
            3: 3 Avaliação
            4: 4 Avaliação
            5: Recuperação Final
    
    - MapaNotaAvaliacao

      - idMapaNotaAv
      - IdMapaNota
      - IdAluno: IdPessoa
      - NotaTotal

    - MapaNotaCriterio
      
      - idMapaNotaCrit
      - idMapaNotaAv
      - Tipo:
            0: Atividades em sala
            1: Atividades Livro
            2: Atividades Caderno
            3: Assiduidade
            4: Comportamento
            5: Seminário
            6: Trabalhos Escrito
      - Nota       

    - MapaNotaEvento
      
      - idMapaNotaEvento
      - idMapaNotaAv
      - Tipo:
            0: Atividades em sala
            1: Atividades Livro
            2: Atividades Caderno
            3: Assiduidade
            4: Comportamento
            5: Seminário
            6: Trabalhos Escrito
      - Nota        

    - MapaNotaExame
      
      - idMapaNotaEvento
      - idMapaNotaAv
      - Tipo:
            0: Prova
            1: Simulado
      - Nota        

  - Boletim
    
    - IdBoletim
    - idMapaNotaAv
    - Situacao: 
        
        0: Em aberto (O período ainda não acabou; faltam notas)
        1: Aprovado
        2: Reprovado

- **Processos**