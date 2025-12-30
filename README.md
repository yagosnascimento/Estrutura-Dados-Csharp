# Estrutura de Dados e Algoritmos em C#

Este repositório documenta minha jornada de aprendizado em Estruturas de Dados, focando não apenas na sintaxe do C#, mas na engenharia de software e análise de complexidade (Big O Notation).

## 1. Análise de Complexidade (Big O)

Antes de escrever código, é crucial entender como ele se comporta conforme o volume de dados cresce. Não medimos velocidade em segundos, mas em **passos de execução**.

| Notação | Nome | Descrição | Exemplo Prático |
| :--- | :--- | :--- | :--- |
| **$O(1)$** | Constante | O tempo é o mesmo, não importa o tamanho da entrada. | Acessar um índice de Array (`arr[5]`). |
| **$O(\log n)$** | Logarítmico | O tempo cresce muito pouco; corta o problema pela metade a cada passo. | Busca Binária. |
| **$O(n)$** | Linear | O tempo cresce proporcionalmente aos dados (10 itens = 10 passos). | Loop `foreach` simples. |
| **$O(n^2)$** | Quadrático | O desempenho degrada exponencialmente. Evitar em grandes volumes. | Loops aninhados (um `for` dentro de outro). |

---

## 2. Arrays (Vetores)

A estrutura de dados mais fundamental. No C#, arrays são objetos alocados na Heap, mas seus elementos são armazenados em um bloco **contíguo** de memória.

### Características
* **Tamanho Fixo:** Uma vez criado (`new int[5]`), não pode aumentar ou diminuir.
* **Acesso Rápido:** Como a memória é contígua, o acesso matemático ao endereço é instantâneo.
* **Tipagem Forte:** Armazena apenas um tipo de dado definido.

### Análise de Performance

| Operação | Complexidade | Explicação |
| :--- | :---: | :--- |
| **Acesso (Leitura/Escrita)** | **$O(1)$** | O computador calcula o endereço de memória exato. É instantâneo. |
| **Busca (Search)** | **$O(n)$** | Para achar um valor, é necessário verificar elemento por elemento (no pior caso). |
| **Inserção/Remoção** | **N/A** | Não é possível alterar o tamanho sem criar um novo array e copiar os dados ($O(n)$). |

### Exemplo em C#

```csharp
public void ExemploArray()
{
    // Declaração e Alocação na Memória
    int[] pontuacoes = new int[5] { 10, 20, 30, 40, 50 };

    // 1. Acesso Direto - O(1)
    // O computador vai direto ao endereço de memória. Super rápido.
    int primeiraPontuacao = pontuacoes[0]; 
    pontuacoes[4] = 100;

    // 2. Busca Linear - O(n)
    // O computador não sabe onde está o valor '30'.
    // Ele precisa testar o índice 0, depois 1, depois 2...
    int valorProcurado = 30;
    bool encontrado = false;

    for (int i = 0; i < pontuacoes.Length; i++)
    {
        if (pontuacoes[i] == valorProcurado)
        {
            encontrado = true;
            break; // O(n) no pior caso (se o item estiver no fim ou não existir)
        }
    }
}
```

---

## 3. Listas Dinâmicas (`List<T>`)

Diferente dos Arrays, a `List<T>` no C# é dinâmica. Ela resolve o problema do tamanho fixo, mas introduz custos de processamento ocultos.

### Como funciona (Under the Hood)
Por baixo dos panos, a Lista **usa um Array**. Quando esse array interno fica cheio e você tenta adicionar um novo item, a Lista cria automaticamente um novo array com o **dobro do tamanho**, copia os itens antigos e descarta o array anterior.

### Características
* **Tamanho Dinâmico:** Cresce conforme a necessidade.
* **Contíguo (Geralmente):** Mantém a performance de acesso rápido do Array.
* **Custo de Deslocamento (Shift):** Inserir ou remover itens no *meio* da lista obriga o deslocamento de todos os elementos subsequentes na memória.

### Análise de Performance

| Operação | Complexidade | Explicação |
| :--- | :---: | :--- |
| **Acesso (Index)** | **$O(1)$** | Igual ao Array. Acesso direto ao endereço de memória. |
| **Adicionar (Add)** | **$O(1)$*** | Rápido, pois adiciona no primeiro espaço vazio ao final. (*Pode ser $O(n)$ se precisar redimensionar a capacidade interna*). |
| **Inserir (Insert)** | **$O(n)$** | Lento. Obriga o deslocamento (shift) de todos os elementos à direita para abrir espaço. |
| **Remover (Remove)** | **$O(n)$** | Lento. Obriga o deslocamento de todos os elementos para preencher o "buraco". |
| **Busca (Find)** | **$O(n)$** | Percorre a lista linearmente até encontrar o item. |

### Exemplo em C#

```csharp
public void ExemploLista()
{
    // Declaração: Não precisa definir tamanho inicial
    List<string> inventario = new List<string>();

    // 1. Adicionar ao Final - O(1) (Amortizado)
    inventario.Add("Espada");
    inventario.Add("Escudo");
    inventario.Add("Poção");

    // 2. Inserir no Meio - O(n)
    // CUSTOSO: O C# precisa mover "Escudo" e "Poção" para a direita
    // para encaixar o "Mapa" no índice 1.
    inventario.Insert(1, "Mapa"); 

    // 3. Remover - O(n)
    // CUSTOSO: Ao remover o índice 0 ("Espada"), todos os itens 
    // seguintes voltam uma casa para a esquerda.
    inventario.RemoveAt(0);

    // 4. Acesso Direto - O(1)
    string itemAtual = inventario[1];
    
    // Curiosidade: Capacidade vs Contagem
    // Count: Quantos itens existem (3)
    // Capacity: Tamanho real do array interno reservado (pode ser 4, 8, etc)
    Console.WriteLine($"Itens: {inventario.Count} / Capacidade: {inventario.Capacity}");
}
```
---

## 4. Pilhas (Stacks) - LIFO

A Pilha opera no modelo **LIFO** (*Last-In, First-Out*). O último elemento a entrar é obrigatoriamente o primeiro a sair. Pense nela como uma pilha de livros ou pratos.

### Características
* **Acesso Restrito:** Você só tem acesso direto ao elemento do **Topo**.
* **Ideal para:** Desfazer ações (Ctrl+Z), recursividade e algoritmos de backtracking (como sair de um labirinto).

### Análise de Performance

| Operação | Nome (C#) | Complexidade | Explicação |
| :--- | :--- | :---: | :--- |
| **Inserir** | `Push()` | **$O(1)$** | Adiciona no topo instantaneamente. |
| **Remover** | `Pop()` | **$O(1)$** | Remove do topo instantaneamente. |
| **Espiar** | `Peek()` | **$O(1)$** | Vê o valor do topo sem remover. |
| **Busca** | `Contains()`| **$O(n)$** | Precisa vasculhar a pilha inteira. |

### Exemplo em C#

```csharp
Stack<string> historico = new Stack<string>();
historico.Push("Home");
historico.Push("Perfil"); 

// O "Perfil" é o topo. Se dermos Pop, voltamos para "Home".
string voltar = historico.Pop(); // Retorna "Perfil"

```

---

## 5. Filas (Queues) - FIFO

A Fila opera no modelo **FIFO** (*First-In, First-Out*). O primeiro elemento a entrar é o primeiro a sair. É a estrutura mais justa para processamento de tarefas.

### Características

* **Ordem Cronológica:** Mantém a ordem exata de chegada.
* **Ideal para:** Filas de impressão, atendimento a clientes, requisições em servidores web.

### Análise de Performance

| Operação | Nome (C#) | Complexidade | Explicação |
| --- | --- | --- | --- |
| **Inserir** | `Enqueue()` | **** | Adiciona no final da fila. |
| **Remover** | `Dequeue()` | **** | Remove do início da fila. |
| **Espiar** | `Peek()` | **** | Vê quem está no início (próximo a sair). |
| **Busca** | `Contains()` | **** | Precisa percorrer a fila. |

### Exemplo em C#

```csharp
Queue<string> filaBanco = new Queue<string>();
filaBanco.Enqueue("Cliente A");
filaBanco.Enqueue("Cliente B");

// O "Cliente A" chegou primeiro, então é atendido primeiro.
string atendimento = filaBanco.Dequeue(); // Retorna "Cliente A"

```
