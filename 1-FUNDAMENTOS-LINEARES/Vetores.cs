// Vetores
// É a estrutura mais "honesta". O que você vê é o que você tem: um bloco fixo na memória.
// Quando usar: Quando você sabe exatamente quantos itens vai precisar (ex: os dias da semana, os 4 naipes do baralho, um buffer de tamanho fixo).
using System;

public class EstudoVetor
{
    public static void Executar()
    {
        Console.WriteLine("Operações com Array: ");

        // 1. CRIAÇÃO (Alocação Fixa)
        // Cria um bloco contíguo na memória para exatamente 5 inteiros.
        // Valores padrão iniciam como 0.
        int[] numeros = new int[5];

        // 2. ESCRITA (Acesso Aleatório - O(1))
        // Super rápido, vai direto ao endereço de memória.
        numeros[0] = 10;
        numeros[1] = 20;
        numeros[4] = 50;

        // 3. LEITURA (Acesso Aleatório - O(1))
        Console.WriteLine($"Valor no índice 1: {numeros[1]}");

        // 4. ATUALIZAÇÃO (O(1))
        numeros[1] = 99; // Substitui o valor antigo instantaneamente.

        // 5. REDIMENSIONAMENTO (A "Gambiarra" - O(n))
        // Arrays não crescem. Para "aumentar", o C# cria um NOVO array 
        // e copia tudo do velho para o novo. Custo alto de memória e CPU.
        Array.Resize(ref numeros, 10); 
        Console.WriteLine($"Novo tamanho do array: {numeros.Length}");

        // 6. ITERAÇÃO (Percorrer - O(n))
        Console.Write("Vetor Completo: ");
        for (int i = 0; i < numeros.Length; i++)
        {
            Console.Write(numeros[i] + " ");
        }
        Console.WriteLine("\n");
    }
}