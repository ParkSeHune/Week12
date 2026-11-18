namespace Game.Core
{
    public class RewardSystem
    {
        public string grade;
        public int lastR;

        public int ApplyStageReward(
            int t, int c, int b, bool isEvent, int diff)
        {
            int r = CalcBaseReward(c, b, isEvent, diff);

            grade = JudgeGrade(t);

            if (grade == "S")
                r += 100;

            LogResult(r);

            return r;
        }

        public int Proc(
            int t, int c, int b, bool isEvent, int diff)
        {
            return ApplyStageReward(t, c, b, isEvent, diff);
        }

        private int CalcBaseReward(
            int c, int b, bool isEvent, int diff)
        {
            int r = c * 10 + b * 50;

            if (diff == 2) r = (int)(r * 1.2f);
            if (diff == 3) r = (int)(r * 1.5f);
            if (isEvent) r = (int)(r * 1.5f);

            return r;
        }

        private string JudgeGrade(int t)
        {
            if (t < 60) return "S";
            if (t < 90) return "A";
            if (t < 120) return "B";

            return "C";
        }

        private void LogResult(int r)
        {
            lastR = r;
        }
    }
}