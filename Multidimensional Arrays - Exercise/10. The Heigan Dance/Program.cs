namespace _10.The_Heigan_Dance
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        private const int matrixSize = 15;
        private static decimal pointsPlayer;
        private static decimal pointsHeigan;
        private static int[] playerPosition;
        private static int pendingDamage;
        private static string lastSpell;

        public static void Main()
        {
            var damageToHeigan = decimal.Parse(Console.ReadLine());
            Initialization();

            while (true)
            {
                pointsHeigan -= damageToHeigan;
                pointsPlayer -= pendingDamage;
                pendingDamage = 0;

                if (IsGameOver())
                {
                    break;
                }

                GetHeigansSpell();

                if (IsGameOver())
                {
                    break;
                }
            }
            PrintOutcome();
        }

        private static void TakeDamageFromHeigan(Dictionary<string, int> damageFromHeigan, string spell)
        {
            pointsPlayer -= damageFromHeigan[spell];
            if (spell == "Cloud")
            {
                pendingDamage += damageFromHeigan[spell];
            }

            lastSpell = spell == "Cloud" ? "Plague Cloud" : spell;
        }

        private static bool EscapeInDirection(int row, int col, int spellRow, int spellCol)
        {
            if (IsPointInsideMatrix(row, col) && !IsWithinSpellRange(spellRow, spellCol, new int[] { row, col }))
            {
                playerPosition = new int[] { row, col };
                return true;
            }

            return false;
        }

        private static void GetHeigansSpell()
        {
            var damageFromHeigan = new Dictionary<string, int>() { { "Cloud", 3500 }, { "Eruption", 6000 } };
            var args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var spell = args[0];
            var spellRow = int.Parse(args[1]);
            var spellColl = int.Parse(args[2]);
            var playerRow = playerPosition[0];
            var playerCol = playerPosition[1];

            if (!IsWithinSpellRange(spellRow, spellColl, playerPosition))
            {
                // unaffected by spell
                return;
            }
            if (EscapeInDirection(playerRow - 1, playerCol, spellRow, spellColl))
            {
                return;
            }
            if (EscapeInDirection(playerRow, playerCol + 1, spellRow, spellColl))
            {
                return;
            }
            if (EscapeInDirection(playerRow + 1, playerCol, spellRow, spellColl))
            {
                return;
            }
            if (EscapeInDirection(playerRow, playerCol - 1, spellRow, spellColl))
            {
                return;
            }

            TakeDamageFromHeigan(damageFromHeigan, spell);
        }

        private static bool IsWithinSpellRange(int spellRow, int spellCol, int[] playerPosition)
        {
            for (int row = Math.Max(spellRow - 1, 0); row <= Math.Min(spellRow + 1, matrixSize - 1); row++)
            {
                for (int col = Math.Max(spellCol - 1, 0); col <= Math.Min(spellCol + 1, matrixSize - 1); col++)
                {
                    if (row == playerPosition[0] && col == playerPosition[1])
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private static bool IsPointInsideMatrix(int row, int col)
        {
            return row >= 0 && row < matrixSize && col >= 0 && col < matrixSize;
        }

        private static void PrintOutcome()
        {
            if (pointsHeigan <= 0)
            {
                Console.WriteLine($"Heigan: Defeated!");
            }
            else
            {
                Console.WriteLine($"Heigan: {pointsHeigan:f2}");
            }

            if (pointsPlayer <= 0)
            {
                Console.WriteLine($"Player: Killed by {lastSpell}");
            }
            else
            {
                Console.WriteLine($"Player: {pointsPlayer}");
            }

            Console.WriteLine($"Final position: {string.Join(", ", playerPosition)}");
        }

        private static bool IsGameOver()
        {
            return pointsHeigan <= 0 || pointsPlayer <= 0;
        }

        private static void Initialization()
        {
            playerPosition = new int[] { matrixSize / 2, matrixSize / 2 };
            pointsPlayer = 18500;
            pointsHeigan = 3000000;
            pendingDamage = 0;
            lastSpell = string.Empty;
        }
    }
}
