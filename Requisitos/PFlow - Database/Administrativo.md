# Administrativo

## Pessoa

CREATE TABLE "ADM_Pessoa" 
(
	"IdPessoa"		INTEGER,
	"Nome"			TEXT NOT NULL,
	"RG"			TEXT,
	"CPF"			TEXT UNIQUE,
	"Sexo"			TEXT,
	"DataNasc"		DATE,
	"Naturalidade"	TEXT CHECK(length("Naturalidade") <= 2),
	"EstadoCivil"	INTEGER CHECK("EstadoCivil" BETWEEN 0 AND 4),
	
	PRIMARY KEY("IdPessoa" AUTOINCREMENT)
);
 
- Naturalidade limitada a 2 caracteres (ex: PA, BA, SP)
- EstadoCivil conforme a legenda: 0-Solteiro, 1-Casado, 2-Divorciado, 3-Viúvo, 4-União Estável




## Old

- ADM_Endereco

    - IdEndereco
    - Logradouro: O nome da via (Rua, Avenida, Alameda, Travessa, etc.).
    - Número: A identificação específica do imóvel na via.
    - Complemento: Opcional, Informações adicionais
    - Bairro: A subdivisão da cidade ou distrito.
    - Cidade: O nome do município.
    - UF
    - CEP

- ADM_EnderecoPes

    - IdEndereco
    - IdPessoa

- ADM_Contato

    - IdContato
    - IdPessoa
    - TipoContato
    - Descricao    

### SQL

- *ADM_Pessoa*


- *ADM_Endereco*

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

- *ADM_EnderecoPes*

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

- *ADM_Contato*

    CREATE TABLE ADM_Contato 
    (
        IdContato   INTEGER PRIMARY KEY AUTOINCREMENT,
        IdPessoa    INTEGER NOT NULL,
        TipoContato TEXT NOT NULL, -- Ex: 'Celular', 'E-mail', 'WhatsApp'
        Descricao   TEXT NOT NULL, -- Ex: '(11) 98888-7777' ou 'contato@email.com'
        FOREIGN KEY (IdPessoa) REFERENCES ADM_Pessoa (IdPessoa) 
            ON DELETE CASCADE
    );