namespace Genetic_Algorithms_Experiments
{
    public class Population {
        public Member[] population;
        public Member[] matingpool;

        public Population(int populationSize, int goalSize) {
            population = generatePopulation(populationSize, goalSize);
        }

        public Member[] generatePopulation(int popSize, int goalSize) {
            Member[] pop = new Member[popSize];
            for (int i = 0; i < pop.Length; i++) {
                pop[i] = new Member(goalSize);
            }
            return pop;
        }

        public void CalculateFitness(string goal) {
            for (int i = 0; i < population.Length; i++)
            {
                population[i].calFitness(goal);
            }
        }

        public void Mate() {
            var random = new System.Random();
            generateMatingPool();
            for (int i = 0; i < population.Length; i++)
                population[i] = Breed(matingpool[random.Next(matingpool.Length)].dna, matingpool[random.Next(matingpool.Length)].dna);
        }

        public Member Breed(string a, string b) {
            var random = new System.Random();
            string newboi = "";
            var chars = "abcdefghijklmnopqrstuvwxyz ";
            for (int i = 0; i < a.Length; i++)
            {
                int rand = random.Next(102);
                if (rand > 100)
                    newboi += chars[random.Next(chars.Length)];
                else
                    newboi += ((rand < 50) ? a[i] : b[i]);
            }
            return new Member(newboi);
        }

        public void generateMatingPool() {
            int size = 0;
            for (int i = 0; i < population.Length; i++)
                size += (population[i].fitness + 1);
            matingpool = new Member[size];
            int count = 0;
            for (int i = 0; i < population.Length; i++)
            {
                int cnt = 0;
                while (cnt <= population[i].fitness)
                {
                    matingpool[count] = population[i]; 
                    cnt++;
                    count++;
                }
            }
        }
    }
}