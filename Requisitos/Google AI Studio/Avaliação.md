# Pergamo - Requisitos - Google AI Studio
## Processo de Avaliação

- **Visão Geral**

  - 4 Etapas de avaliação.
  - Estado da avaliação: Elaboração  |   Produção e Execução.
  - Atores envolvidos: Aluno  |   Professor  |   Secretária e Diretoria.
  - Processos: Mapa de Notas e Boletim
  
- **Organização**
  
  - Pessoa: Alunos  |   Professores  |   Usuários do Sistema
    
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
  
  - MpNota
  
    - IdMapa (PK)
    
    - IdTurma
    - Etapa: 
          0: 1º Avaliação
          1: 2º Avaliação
          2: Recuperação Paralela
          3: 3 Avaliação
          4: 4 Avaliação
          5: Recuperação Final

  - MpNotaAvaliacao

    - IdAva (PK)

    - IdMapa: 0 - 1º Avaliação | 9º ano
    - IdDiscProf: 1 - Marcos | Português
    - IdAvaDesc: 5 - Sarau Literário

  - MpNotaAvaliacaoDesc
  
    - IdAvaDesc (PK)
    - Descricao

    IdAvaAux  | Descricao
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
