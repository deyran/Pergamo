# Pergamo - Requisitos - Google AI Studio
## Avaliação

- **Visão Geral**

  - 4 Etapas de avaliação.
  - Estado da avaliação: Elaboração, Produção e Execução.
  - Atores envolvidos: Aluno, Professor, Secretária e Diretorial.
  - Processos: Mapa de Notas e Boletim
  
- **Principais Tabelas**
  
  - Pessoa
    
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
      - IdPessoa: Aluno
      - Status: 0 - Ativo; 1 - Trancado; 2 - Transferido


  - Disciplina-Professor
  
    - Disciplina
      
      - IdDisciplina
      - Descricao
  

    - DisciplinaProf

      - IdDiscProf
      - IdDisciplina
      - IdPessoa: Professor

  - Mapa de Nota
  - Boletim

- **Processos**