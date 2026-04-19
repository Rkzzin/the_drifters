# The Drifters 🏎️💨

**Estudante:** Henrique Leite dos Santos
**Disciplina:** Jogos Digitais 2026.1 - Insper 
**Link para o Jogo (Itch.io):** [LINK DO SEU PROJETO NO ITCH.IO AQUI]

## 📝 Descrição do Projeto
Este jogo é um arcade de drift em ritmo acelerado onde o objetivo é coletar o máximo de moedas possível em uma janela de **~30 segundos**. O desafio aumenta progressivamente à medida que "sombras" do próprio jogador surgem a cada 7 segundos, seguindo o rastro deixado pelo carro e forçando o jogador a planejar suas rotas para não colidir com seu próprio passado.

## 🕹️ Como Jogar
O jogo possui suporte total para teclado e joysticks (Xbox/PC).
- **W / S ou Seta Cima/Baixo:** Acelerar e Ré.
- **A / D ou Seta Esquerda/Direita:** Esterçar o volante.
- **Controle:** Analógico esquerdo para movimento

## 📊 Itens da Rubrica Implementados
Para atender aos requisitos da avaliação:

1. **Mecânica de Tempo:** Cronômetro regressivo de 30 segundos, exibição de tempo final e uso do tempo para acelerar a trilha sonora.
2. **Inimigos:** Sombras que perseguem o rastro do jogador através de um sistema de buffer de posição e rotação.
3. **Visual:** Uso de assets de carro e fundo de pista.
4. **Áudio:** Trilha sonora no estilo **Drift Phonk** com alteração dinâmica de pitch e efeitos sonoros de coleta.
5. **UI:** Interface completa exibindo Score, Tempo e a quantidade de inimigos ativos.
6. **Configurações:** Build otimizada para WebGL em resolução 900x600.

## 🛠️ Referências e Créditos
Conforme as regras de integridade intelectual da disciplina:

- **Lógica de Física e Drifting:** O sistema de fricção lateral (`LateralFriction`) e movimentação 2D foi baseado em protótipos de simulação física para Unity 6.
- **Sistema de Sombras (Ghost System):** A lógica de gravação de rastro (`PathHistory`) e o atraso incremental para evitar sobreposição foram desenvolvidos com auxílio de assistência de IA (Gemini), adaptando conceitos de *Input Buffering* para Unity.
- **Scripts de UI e Controle de Jogo:** Estrutura baseada no tutorial "Introdução Rápida" fornecido em aula, com expansões para variáveis estáticas e persistência de dados.
- **Assets de Áudio:** O áudio de coleta de moedas foi feita no site https://sfxr.me/ e a criação da música principal do jogo foi feita em https://suno.com/create, e está acessível em: https://suno.com/s/rLqsoaoHJGkLIlaP.
- **Assets Visuais** O asset do carro foi o único não gerado por IA e foi selecionado dentro do bundle: https://craftpix.net/freebies/free-racing-game-kit/, além disso, a imagem de game over foi pega do WikiPedia: https://en.wikipedia.org/wiki/Drifting_%28motorsport%29.