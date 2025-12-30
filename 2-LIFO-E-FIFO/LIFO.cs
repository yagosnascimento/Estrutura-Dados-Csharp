using System;
using System.Collections.Generic;

public class EstudoPilha
{
    public static void Executar()
    {
        Console.WriteLine("=== Operações com Stack (Pilha) - LIFO ===");

        // 1. CRIAÇÃO
        // Stack<T> é otimizada para acessar apenas o TOPO.
        Stack<string> navegador = new Stack<string>();

        // 2. EMPILHAR (Push - O(1))
        // Adiciona itens no topo da pilha.
        navegador.Push("google.com");
        navegador.Push("github.com");
        navegador.Push("stackoverflow.com");

        Console.WriteLine($"Página atual (Topo): {navegador.Peek()}");

        // 3. DESEMPILHAR (Pop - O(1))
        // Remove e retorna o item do topo (o último que entrou).
        string paginaFechada = navegador.Pop(); 
        Console.WriteLine($"Voltando de: {paginaFechada}");
        
        // Agora o topo é "github.com"
        Console.WriteLine($"Página atual agora: {navegador.Peek()}");

        // 4. ITERAÇÃO (O(n))
        // A iteração na Stack ocorre do topo para a base (ordem de saída).
        Console.Write("Histórico (Do mais recente ao mais antigo): ");
        foreach (var pagina in navegador)
        {
            Console.Write($"[{pagina}] -> ");
        }
        Console.WriteLine("FIM");
    }
}