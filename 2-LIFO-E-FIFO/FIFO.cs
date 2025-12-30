using System;
using System.Collections.Generic;

public class EstudoFila
{
    public static void Executar()
    {
        Console.WriteLine("=== Operações com Queue (Fila) - FIFO ===");

        // 1. CRIAÇÃO
        // Queue<T> é otimizada para adicionar no fim e remover do começo.
        Queue<string> filaImpressao = new Queue<string>();

        // 2. ENFILEIRAR (Enqueue - O(1))
        // Entra no final da fila.
        filaImpressao.Enqueue("Relatorio.pdf");
        filaImpressao.Enqueue("Foto.jpg");
        filaImpressao.Enqueue("Contrato.docx");

        // 3. ESPIAR (Peek - O(1))
        // Olha quem é o próximo (o primeiro da fila), sem remover.
        Console.WriteLine($"Próximo a imprimir: {filaImpressao.Peek()}");

        // 4. DESENFILEIRAR (Dequeue - O(1))
        // Remove e retorna o primeiro item (o mais antigo).
        string arquivoImpresso = filaImpressao.Dequeue();
        Console.WriteLine($"Imprimindo: {arquivoImpresso}");

        // Agora "Foto.jpg" é o próximo.
        Console.WriteLine($"Próximo da fila agora: {filaImpressao.Peek()}");

        // 5. VERIFICAR PRESENÇA (Contains - O(n))
        if (filaImpressao.Contains("Contrato.docx"))
        {
            Console.WriteLine("O contrato ainda está na fila.");
        }
    }
}