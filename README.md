# Marseille

**Bem-vindo(a)!**  
Este projeto está sendo desenvolvido como parte do Trabalho de Conclusão de Curso (TCC) por estudantes da FATEC - São Caetano do Sul.

## Visão Geral

**Marseille** é um jogo de cartas desenvolvido em Unity, inspirado no tradicional baralho de Tarot de Marseille. Com uma jogabilidade por turnos rica em elementos de ataque e defesa, este jogo convida você a explorar o místico mundo do Tarot e enfrentar oponentes em emocionantes batalhas de cartas.

Em **Marseille**, você assume o papel do Mago (Carta I do Tarot) e viaja por Marselha em busca de compreensão sobre os sentimentos humanos, encontrando personagens representados por cartas do Tarot. Cada personagem oferece um novo desafio e um aprendizado, conforme o Mago explora sua própria identidade e a natureza invertida do reino.

### Funcionalidades

- **Baralho Tradicional de Tarot**: Experimente o simbolismo e as imagens icônicas do Tarot de Marseille.
- **Jogabilidade por Turnos**: Enfrente oponentes em turnos estratégicos, planejando ataques e defesas com suas cartas.
- **Mecânica de Ataque e Defesa**: Use cartas para manobras ofensivas e defensivas. Cada carta pode ser jogada como um ataque/defesa direto ou para acionar seu efeito especial.
  
## Requisitos de Sistema

- **Sistema Operacional**: Windows 10 ou superior, macOS 10.12+.
- **Processador**: Intel Core i5 ou equivalente.
- **Memória RAM**: 8 GB de RAM.
- **Placa de Vídeo**: NVIDIA GTX 960 ou equivalente.
- **DirectX**: Versão 11.
- **Armazenamento**: 2 GB de espaço disponível.

## Tecnologias Utilizadas

- **Unity** (versão 2021.3 ou superior)
- **C#**
- **DoTween** (para animações e movimentações interpoladas)

## Mecânica do Jogo

**Marseille** é um jogo estratégico de cartas que combina habilidade, planejamento e interpretação do Tarot. Abaixo está a mecânica principal:

- **Mão Inicial**:  
  Cada jogador inicia com uma mão de **7 cartas**, compradas de um baralho de **40 cartas**.

- **Estrutura de Round e Turnos**:  
  Cada round é composto de **4 turnos**, alternando entre o jogador e o inimigo. A dinâmica é a seguinte:  
  1. **Turnos de Ataque (1º e 2º turnos)**:  
     Ambos os jogadores escolhem, alternadamente, uma carta para ser usada como **valor de ataque**. O objetivo é causar dano ao adversário com base no valor da carta escolhida.
  2. **Turnos de Habilidade (3º e 4º turnos)**:  
     Nos turnos finais, ambos os jogadores escolhem cartas cujas **habilidades especiais** serão ativadas. Essas habilidades podem incluir buffs, debuffs, cura ou outros efeitos estratégicos.

- **Conceito de Ataque e Defesa**:  
  - **Cartas de Ataque**: A carta escolhida determina o dano que será infligido ao adversário.  
  - **Cartas de Defesa**: Algumas cartas possuem efeitos que aumentam a resistência a danos ou diminuem o impacto de ataques inimigos.

- **Interação com o Baralho**:  
  - Após cada turno, o jogador compra uma nova carta se possível.
  - O baralho é embaralhado automaticamente quando esgotado, movendo cartas do descarte de volta ao jogo.

- **Vencer a Partida**:  
  O objetivo é reduzir os pontos de vida do adversário a zero antes que o próprio jogador seja derrotado.

---

## Instalação

### Pré-requisitos

Antes de instalar o jogo, certifique-se de ter as seguintes dependências instaladas:

1. **Unity Hub** – [Baixar aqui](https://unity.com/download).
2. **Git** – [Baixar aqui](https://git-scm.com/).
3. **.NET SDK** – [Baixar aqui](https://dotnet.microsoft.com/en-us/download).

### Clonando o Repositório

Para obter uma cópia local do projeto, siga os seguintes passos:

1. Abra um terminal ou prompt de comando.
2. Navegue até o diretório onde deseja clonar o projeto.
3. Execute o comando:

   ```bash
   git clone https://github.com/usuario/repositorio-marseille.git

## Desenvolvedores

- **Artista:** Gwen Monteiro da Silva
- **Compositor:** Gabriel Souza de Lima
- **Desenvolvedor:** Murilo Aggio Sartori
- **Game Designer:** Gustavo Martins Ferrari
