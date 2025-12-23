using System;
using System.Collections.Generic; // Necessário para List<T>

public class EstudoLista
{
    public static void Executar()
    {
        Console.WriteLine("Operações com List: ");

        // 1. CRIAÇÃO (Dinâmica)
        // Começa vazia, mas pronta para crescer.
        List<string> inventario = new List<string>();

        // 2. ADICIONAR AO FINAL (Add - Geralmente O(1))
        // É rápido porque ele só coloca no próximo espaço vazio.
        inventario.Add("Espada");
        inventario.Add("Escudo");
        inventario.Add("Poção");

        // 3. INSERIR NO MEIO (Insert - O(n))
        // CUSTOSO: "Escudo" e "Poção" precisam ser movidos para a direita
        // para o "Mapa" entrar no índice 1.
        inventario.Insert(1, "Mapa"); 

        // 4. REMOVER (Remove - O(n))
        // CUSTOSO: Ao tirar "Espada" (índice 0), todos os outros itens
        // precisam voltar uma casa para esquerda (Shift).
        inventario.Remove("Espada");

        // 5. VERIFICAR TAMANHO
        // Count: Quantos itens existem (3)
        // Capacity: Quantos espaços reais estão alocados na memória (geralmente 4 ou 8)
        Console.WriteLine($"Itens: {inventario.Count} | Capacidade Real: {inventario.Capacity}");

        // 6. BUSCA (Contains/Find - O(n))
        // Precisa olhar item por item até achar.
        bool temPoção = inventario.Contains("Poção");
        Console.WriteLine($"Tem poção? {temPoção}");

        // 7. ITERAÇÃO (ForEach)
        Console.Write("Inventário: ");
        foreach (var item in inventario)
        {
            Console.Write($"[{item}] ");
        }
        Console.WriteLine();
    }
}