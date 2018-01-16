namespace Genetic_Algorithms_Experiments
{
    public class Member {
        public string dna;
        public int fitness;

        public Member(int size) {
            this.dna = generateMember(size);
            this.fitness = 0;
        }

        public Member(string dna) {
            this.dna = dna;
            this.fitness = 0;
        }

        public string generateMember(int size) {
            var chars = "abcdefghijklmnopqrstuvwxyz ";
            var stringChars = new char[size];
            var random = new System.Random();

            for (int i = 0; i < stringChars.Length; i++)
                stringChars[i] = chars[random.Next(chars.Length)];

            return new string(stringChars);
        }

        public void calFitness(string goal) {
            int score = 0;
            for (int i = 0; i < goal.Length; i++)
              if (goal[i] == dna[i])
                score++;
            fitness = score;
        }
    }
}