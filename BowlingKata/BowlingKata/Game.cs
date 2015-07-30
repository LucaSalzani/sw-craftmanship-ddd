﻿namespace BowlingKata
{
    public class Game
    {
        private readonly int[] rolls = new int[21];
        private int currentRoll;

        public void Roll(int pins)
        {
            rolls[currentRoll++] = pins;
        }

        public int Score()
        {
            int score = 0;
            int frameIndex = 0;
            for (int frame = 0; frame < 10; frame++)
            {
                var currentFrame = new Frame(frameIndex, rolls);
                if (currentFrame.IsStrike())
                {
                    score += 10 + currentFrame.StrikeBonus();
                    frameIndex++;
                }
                else if (currentFrame.IsSpare())
                {
                    score += 10 + currentFrame.SpareBonus();
                    frameIndex += 2;
                }
                else
                {
                    score += currentFrame.SumOfBallsInFrame();
                    frameIndex += 2;
                }
            }
            return score;
        }
    }
}