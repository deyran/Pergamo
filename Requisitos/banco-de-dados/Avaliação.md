# Pergamo - Banco de Dados
## Processo de Avaliação

- *AVA_MP*: Avaliação Mapa de Notas

- *AVA_MP_Etapa*

  - IdMpEtapa (PK)
  - Descricao

    IdMpEtapa | Descricao
    0         | 1º Avaliação
    1         | 2º Avaliação
    2         | Recuperação Paralela
    3         | 3 Avaliação
    4         | 4 Avaliação
    5         | Recuperação Final

- *AVA_MP_Avaliacao*

  - IdAva (PK)
  - IdMpEtapa: 0 - 1º Avaliação
  - IdDiscProf: 1 - Marcos | Português
  - IdTurma: 9º Ano | 2026
  - IdAvaDesc: 5 - Sarau Literário
  - DataAva

- *AVA_MP_AvaliacaoDesc*

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

- *AVA_MP_AvaliacaoItens*

  - IdAvaItens (PK)
  - IdAva: IdAva-AVA_MP_Avaliacao
  - IdAvaItensDesc: 0 - Expressão Oral
  
- *AVA_MP_AvaliacaoItensDesc*
  
  - IdAvaItensDesc (PK)
  - Descricao

    IdAvaItensDesc | Descricao
    0              | Expressão Oral
    1              | Criatividade
    2              | Participação
    3              | Trabalho em Equipe

- *AVA_MP_AvaliacaoAluno* 

  - IdAva (PK): 1º Avaliação | Marcos-Português | 9º Ano-2026 | Sarau Literário
  - idAluno (PK): 0-Rannyere Costa
  - NotaAva: É a consolidação NotaItem-AVA_MP_AvaliacaoItensAluno, se houver

- *AVA_MP_AvaliacaoItensAluno*
  
  - IdAvaItens (PK)
  - idAluno (PK): IdPessoa - Pessoa
  - NotaItem

- *AVA_MP_Aluno* 

    - IdMapa: Autoincremente
    - IdMpEtapa (PK): 0-1º Avaliação
    - idAluno (PK): 0-Rannyere Costa
    - IdDiscProf (PK): Marcos | Português
    - IdTurma (PK): 9º Ano | 2026
    - NotaFinal: É consolidação NotaAva-AVA_MP_AvaliacaoAluno