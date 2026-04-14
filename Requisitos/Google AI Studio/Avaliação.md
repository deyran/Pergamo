# Pergamo - Requisitos - Google AI Studio
## Processo de Avaliação

- **Visão Geral**

  - 4 Etapas de avaliação.
  - Estado da avaliação: Elaboração, Produção e Execução.
  - Atores envolvidos: Aluno, Professor, Secretária e Diretoria.
  - Processos: Mapa de Notas e Boletim
  
- **Organização**
  
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

- **Mapa de Notas**
  
  - MapaNota
  
    - IdMapa
    - IdTurma
    - IdDiscProf
    - Etapa: 
          0: 1º Avaliação
          1: 2º Avaliação
          2: Recuperação Paralela
          3: 3 Avaliação
          4: 4 Avaliação
          5: Recuperação Final



  - MapaCriterio
    
    - idCriterio
    - IdMapa
    - Tipo:
          0: Atividades em sala
          1: Atividades Livro
          2: Atividades Caderno
          3: Assiduidade
          4: Comportamento
          5: Seminário
          6: Trabalhos Escrito
    - Nota       

  - MapaCriterioAluno

    - idCriterio
    - IdAluno: IdPessoa



  - MapaEvento
    
    - idEvento
    - IdMapa
    - Tipo:
          0: Sarau Literário
          1: Mostra Folclórica
          2: Jogos Internos
          3: Feira de Geociências
          4: Feira do Empreededorismo
    - Nota        

  - MapaEventoAluno

    - idEvento
    - IdAluno: IdPessoa



  - MapaExame
    
    - idExame
    - IdMapa
    - Tipo:
          0: Prova
          1: Simulado
    - Nota  

  - MapaExameAluno

    - idExame
    - IdAluno: IdPessoa

  