using System;

namespace Genetic_Algorithms_Experiments
{
    class Program
    {
        static void Main(string[] args)
        {
            string goal = "yeah dont make this sentence too long";
            Population population = new Population(500, goal.Length);
            int limit = 2000;
            int count = 0;
            bool found = false;
            string winner = "";
            while (count < limit && !found) {
                population.CalculateFitness(goal);
                Member a = population.population[0];
                for (int i = 1; i < 500; i++) {
                    if (population.population[i].dna == goal) {
                        winner = population.population[i].dna;
                        found = true;
                    }
                    if (population.population[i].fitness > a.fitness)
                        a = population.population[i];
                }
                Console.Write("current champ: " + a.dna);
                population.Mate();
                Console.WriteLine(" ");
                count++;
            }
            Console.Write($"WE HAVE A WINNER at {count} : {winner}");
        }
    }
}
