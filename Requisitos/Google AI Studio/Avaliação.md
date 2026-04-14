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


  - MapaAvaliacaoNota

    - IdAluno: IdPessoa
    - IdAvaliacao
    - Nota
    
  - MapaAvaliacao
    
    - IdMapa  
    - IdAvaliacao
    - Tipo:
        0: Critério
        1: Evento
        2: Exame

  - MapaAvaliacaoIten
  
    - IdIten
    - IdAvaliacao
    - Descricao

    IdAvaliacao | IdIten  | Descricao
    0           | 0       | Atividades em sala
    0           | 1       | Atividades Livro
    0           | 2       | Atividades Caderno
    0           | 3       | Assiduidade
    0           | 4       | Comportamento
    0           | 5       | Seminário
    0           | 6       | Trabalhos Escrito
    1           | 7       | Sarau Literário
    1           | 8       | Mostra Folclórica
    1           | 9       | Jogos Internos
    1           | 10      | Feira de Geociências
    1           | 11      | Feira do Empreededorismo
    2           | 12      | Sarau Literário
    2           | 13      | Mostra Folclórica
    2           | 14      | Jogos Internos
    2           | 15      | Feira de Geociências
    2           | 16      | Feira do Empreededorismo
    3           | 17      | Prova
    3           | 18      | Simulado