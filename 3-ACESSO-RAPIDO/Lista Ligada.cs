using System;
using System.Collections.Generic;

public class EstudoListaEncadeada
{
    public static void Executar()
    {
        Console.WriteLine("=== Operações com LinkedList (Lista Encadeada) ===");

        // 1. CRIAÇÃO
        // Diferente da List<T>, aqui trabalhamos com "Nós" (Nodes).
        LinkedList<string> transporte = new LinkedList<string>();

        // 2. ADICIONAR (AddLast / AddFirst - O(1))
        // Não importa o tamanho da lista, inserir nas pontas é instantâneo.
        transporte.AddLast("Carro");
        transporte.AddLast("Avião");
        transporte.AddFirst("Bicicleta"); // Vira o primeiro!

        // Estado atual: Bicicleta <-> Carro <-> Avião

        // 3. INSERIR NO MEIO (O(1)* se tivermos a referência)
        // Queremos adicionar "Trem" depois de "Carro".
        // Primeiro, precisamos encontrar o NÓ do Carro.
        LinkedListNode<string> noCarro = transporte.Find("Carro"); // Busca é O(n)
        
        // Tendo o nó em mãos, a inserção é O(1) (apenas troca de ponteiros)
        transporte.AddAfter(noCarro, "Trem");

        // Estado: Bicicleta <-> Carro <-> Trem <-> Avião

        // 4. REMOVER (Remove - O(n) p/ buscar, O(1) p/ apagar)
        transporte.Remove("Bicicleta"); // Remove do início

        // 5. NAVEGAÇÃO MANUAL (Next / Previous)
        // Podemos "caminhar" pelos nós manualmente.
        Console.WriteLine("\nNavegando pelos nós:");
        
        LinkedListNode<string> atual = transporte.First; // Pega o primeiro (Carro)
        while (atual != null)
        {
            Console.Write($"[{atual.Value}] <-> ");
            atual = atual.Next; // Pula para o próximo elo da corrente
        }
        Console.WriteLine("null");
    }
}