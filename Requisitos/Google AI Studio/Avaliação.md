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
  
  - *MpNotaEtapa*
  
    - IdMpEtapa (PK)
    - Descricao

      IdMpEtapa | Descricao
      0         | 1º Avaliação
      1         | 2º Avaliação
      2         | Recuperação Paralela
      3         | 3 Avaliação
      4         | 4 Avaliação
      5         | Recuperação Final

  - *MpNotaAvaliacao*

    - IdAva (PK)
    - IdMpEtapa: 0 - 1º Avaliação
    - IdDiscProf: 1 - Marcos | Português
    - IdTurma: 9º Ano | 2026
    - IdAvaDesc: 5 - Sarau Literário
    - DataAva

  - *MpNotaAvaliacaoDesc*
  
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

  - *MpNotaAvaliacaoItens*

    - IdAvaItens (PK)
    - IdAva: IdAva-MpNotaAvaliacao
    - IdAvaItensDesc: 0 - Expressão Oral
    
  - *MpNotaAvaliacaoItensDesc*
    
    - IdAvaItensDesc (PK)
    - Descricao

    IdAvaItensDesc | Descricao
    0              | Expressão Oral
    1              | Criatividade
    2              | Participação
    3              | Trabalho em Equipe

  - *MpNotaAvaliacaoAluno*

    - IdAva (PK): 1º Avaliação | Marcos-Português | 9º Ano-2026 | Sarau Literário
    - idAluno (PK): 0-Rannyere Costa
    - NotaAva
  
  - *MpNotaAvaliacaoItensAluno*: Obs: Opcional
    
    - IdAvaItens (PK)
    - idAluno (PK): IdPessoa - Pessoa
    - NotaItem
  
  - *MpNotaAluno*: Nota final é fruto de cálculo da tabela MpNotaAvaliacaoAluno
    - IdMapa (PK)
    - IdMpEtapa: 0-1º Avaliação
    - idAluno: 0-Rannyere Costa
    - IdDiscProf: Marcos | Português
    - IdTurma: 9º Ano | 2026
    - NotaFinal
