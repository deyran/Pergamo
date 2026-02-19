# Administrativo

- ADM_Pessoa

    - IdPessoa
    - Nome
    - RG
    - CPF
    - Sexo
    - DataNas
    - Naturalidade: Estado de nascimento.
    - Nacionalidade: País de origem.
    - EstadoCivil: Solteiro, casado, divorciado, viúvo ou união estável.

    CREATE TABLE ADM_Pessoa 
    (
        IdPessoa      INTEGER PRIMARY KEY AUTOINCREMENT,
        Nome          TEXT NOT NULL,
        RG            TEXT,
        CPF           TEXT UNIQUE,
        Sexo          TEXT CHECK(Sexo IN ('M', 'F', 'Outro')),
        DataNas       TEXT, -- Formato esperado: YYYY-MM-DD
        Naturalidade  TEXT,
        Nacionalidade TEXT DEFAULT 'Brasileira',
        EstadoCivil   TEXT CHECK(EstadoCivil IN ('Solteiro', 'Casado', 'Divorciado', 'Viúvo', 'União Estável'))
    );

- ADM_Endereco

    - IdEndereco
    - Logradouro: O nome da via (Rua, Avenida, Alameda, Travessa, etc.).
    - Número: A identificação específica do imóvel na via.
    - Complemento (Opcional): Informações adicionais para localizar a unidade (Apartamento 102, Bloco B, Fundos, Sala 5).
    - Bairro: A subdivisão da cidade ou distrito.
    - Cidade: O nome do município.
    - UF
    - CEP

    CREATE TABLE ADM_Endereco 
    (
        IdEndereco  INTEGER PRIMARY KEY AUTOINCREMENT,
        Logradouro  TEXT NOT NULL,
        Numero      TEXT NOT NULL, -- Definido como TEXT para aceitar "S/N" ou números com letras
        Complemento TEXT,          -- Campo opcional
        Bairro      TEXT NOT NULL,
        Cidade      TEXT NOT NULL,
        UF          TEXT NOT NULL CHECK(length(UF) = 2), -- Garante a sigla de 2 letras
        CEP         TEXT NOT NULL                        -- Formato esperado: 00000-000
    );


- ADM_EnderecoPes

    - IdEndereco
    - IdPessoa

    CREATE TABLE ADM_EnderecoPes 
    (
        IdEndereco INTEGER NOT NULL,
        IdPessoa   INTEGER NOT NULL,

        PRIMARY KEY (IdEndereco, IdPessoa), -- Chave primária composta

        FOREIGN KEY (IdEndereco) REFERENCES ADM_Endereco (IdEndereco) 
            ON DELETE CASCADE,

        FOREIGN KEY (IdPessoa) REFERENCES ADM_Pessoa (IdPessoa) 
            ON DELETE CASCADE
    );


- ADM_Contato

    - IdContato
    - IdPessoa
    - TipoContato
    - Descricao    


    CREATE TABLE ADM_Contato 
    (
        IdContato   INTEGER PRIMARY KEY AUTOINCREMENT,
        IdPessoa    INTEGER NOT NULL,
        TipoContato TEXT NOT NULL, -- Ex: 'Celular', 'E-mail', 'WhatsApp'
        Descricao   TEXT NOT NULL, -- Ex: '(11) 98888-7777' ou 'contato@email.com'
        FOREIGN KEY (IdPessoa) REFERENCES ADM_Pessoa (IdPessoa) 
            ON DELETE CASCADE
    );

# Secretaria
# Financeiro
# Pedagógico